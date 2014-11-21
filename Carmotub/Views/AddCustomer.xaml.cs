using Carmotub.Model;
using Carmotub.ViewModel;
using Carmotub.Views.Controls;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Linq;
using System.ComponentModel;
using System.Windows.Media;
using Carmotub.Data;

namespace Carmotub.Views
{
    public partial class AddUser : Window
    {
        public List<string> colNames { get; set; }

        public AddUser()
        {
            InitializeComponent();

            CreateGridDynamically();
        }

        private void CreateGridDynamically()
        {
            int i = 0;
            int nbRow = 0;

            colNames = new List<string>();

            // Exceptions
            foreach (string col in CustomerVM.Instance.columns)
            {
                if (col != "identifiant" && col != "commentaire")
                    colNames.Add(col);
            }

            var list = new List<string>();

            // Exceptions
            for (int j = 0; j < colNames.Count; j++)
            {
                i++;
                list.Add(colNames[j]);

                if (i % 2 == 0)
                {
                    RowDefinition rowDef1 = new RowDefinition();
                    rowDef1.Height = new GridLength(30, GridUnitType.Pixel);
                    AddCustomerGridRow.RowDefinitions.Add(rowDef1);

                    TextBlock textBlockGeneric = new TextBlock();
                    textBlockGeneric.Text = list[i - 2] + " : ";
                    textBlockGeneric.Name = list[i - 2] + "_textblock";
                    textBlockGeneric.Height = 20;
                    textBlockGeneric.Margin = new Thickness(5, 0, 0, 0);
                    Grid.SetColumn(textBlockGeneric, 0);
                    Grid.SetRow(textBlockGeneric, nbRow);

                    TextBox textBoxGeneric = new TextBox();
                    textBoxGeneric.Name = list[i - 2] + "_textbox";
                    textBoxGeneric.Height = 20;
                    textBoxGeneric.Margin = new Thickness(0, 0, 5, 0);
                    Grid.SetColumn(textBoxGeneric, 1);
                    Grid.SetRow(textBoxGeneric, nbRow);

                    TextBlock textBlockGeneric1 = new TextBlock();
                    textBlockGeneric1.Text = list[i - 1] + " : ";
                    textBlockGeneric1.Name = list[i - 1] + "_textblock";
                    textBlockGeneric1.Height = 20;
                    textBlockGeneric1.Margin = new Thickness(5, 0, 0, 0);
                    Grid.SetColumn(textBlockGeneric1, 2);
                    Grid.SetRow(textBlockGeneric1, nbRow);

                    TextBox textBoxGeneric1 = new TextBox();
                    textBoxGeneric1.Name = list[i - 1] + "_textbox";
                    textBoxGeneric1.Height = 20;
                    textBoxGeneric1.Margin = new Thickness(0, 0, 5, 0);
                    Grid.SetColumn(textBoxGeneric1, 3);
                    Grid.SetRow(textBoxGeneric1, nbRow);

                    nbRow++;

                    AddCustomerGridRow.Children.Add(textBlockGeneric);
                    AddCustomerGridRow.Children.Add(textBoxGeneric);
                    AddCustomerGridRow.Children.Add(textBlockGeneric1);
                    AddCustomerGridRow.Children.Add(textBoxGeneric1);
                }

                else
                {
                    if (j == colNames.Count - 1)
                    {
                        RowDefinition rowDef1 = new RowDefinition();
                        rowDef1.Height = new GridLength(30, GridUnitType.Pixel);
                        AddCustomerGridRow.RowDefinitions.Add(rowDef1);

                        TextBlock textBlockGeneric = new TextBlock();
                        textBlockGeneric.Text = colNames[j] + " : ";
                        textBlockGeneric.Name = colNames[j] + "_textblock";
                        textBlockGeneric.Height = 20;
                        textBlockGeneric.Margin = new Thickness(5, 0, 0, 0);
                        Grid.SetColumn(textBlockGeneric, 0);
                        Grid.SetRow(textBlockGeneric, nbRow);

                        TextBox textBoxGeneric = new TextBox();
                        textBoxGeneric.Name = colNames[j] + "_textbox";
                        textBoxGeneric.Height = 20;
                        textBoxGeneric.Margin = new Thickness(0, 0, 5, 0);
                        Grid.SetColumn(textBoxGeneric, 1);
                        Grid.SetRow(textBoxGeneric, nbRow);

                        AddCustomerGridRow.Children.Add(textBlockGeneric);
                        AddCustomerGridRow.Children.Add(textBoxGeneric);
                    }
                }
            }

            RowDefinition row1 = new RowDefinition();
            row1.Height = new GridLength(30, GridUnitType.Pixel);
            AddCustomerGridRow.RowDefinitions.Add(row1);

            TextBlock textBlockGeneric2 = new TextBlock();
            textBlockGeneric2.Text = "Commentaire : ";
            textBlockGeneric2.Height = 20;
            textBlockGeneric2.Foreground = Brushes.Black;
            textBlockGeneric2.Margin = new Thickness(5, 0, 0, 0);
            Grid.SetColumn(textBlockGeneric2, 0);
            Grid.SetRow(textBlockGeneric2, nbRow);

            AddCustomerGridRow.Children.Add(textBlockGeneric2);

            RowDefinition row = new RowDefinition();
            row.Height = new GridLength(100, GridUnitType.Pixel);
            AddCustomerGridRow.RowDefinitions.Add(row);

            RichTextBox RichtextBoxGeneric1 = new RichTextBox();
            RichtextBoxGeneric1.Name = "commentaire_textbox";
            RichtextBoxGeneric1.Height = 100;
            RichtextBoxGeneric1.Margin = new Thickness(5, 0, 5, 0);
            Grid.SetColumnSpan(RichtextBoxGeneric1, 4);
            Grid.SetColumn(RichtextBoxGeneric1, 0);
            Grid.SetRow(RichtextBoxGeneric1, nbRow + 1);

            AddCustomerGridRow.Children.Add(RichtextBoxGeneric1);
        }

        private async void AddCustomer_Click(object sender, RoutedEventArgs e)
        {
            string query = "INSERT INTO clients(";

            foreach (string col in colNames)
            {
                query += col + ",";
            }

            query += "commentaire) VALUES(";

            foreach (string col in colNames)
            {
                TextBox foundTextBox = UIHelper.Instance.FindChild<TextBox>(AddCustomerGridRow, col + "_textbox");

                query += @"'" + foundTextBox.Text + "',";
            }

            RichTextBox foundRichTextBox = UIHelper.Instance.FindChild<RichTextBox>(AddCustomerGridRow, "commentaire_textbox");

            foundRichTextBox.SelectAll();
            query += "'" + foundRichTextBox.Selection.Text + "')";

            if(await CustomerVM.Instance.AddCustomer(query) == true)
            {
                await ActionsCustomers.Instance.Init();
            }

            else
            {
                MessageBox.Show("Une erreur est intervenue lors de l'ajout du client.", "Erreur client non ajouté", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}