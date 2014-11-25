using Carmotub.Data;
using Carmotub.ViewModel;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace Carmotub.Views
{
    public partial class UpdateIntervention : Window
    {
        public List<string> colNames { get; set; }
        public DataRow InterventionToUpdate { get; set; }

        public UpdateIntervention(DataRow intervention)
        {
            InitializeComponent();

            InterventionToUpdate = intervention;
            this.DataContext = this;

            CreateGridDynamically();
        }

        private void CreateGridDynamically()
        {
            int i = 0;
            int nbRow = 0;

            colNames = new List<string>();

            // Exceptions
            foreach (string col in InterventionVM.Instance.columns)
            {
                if (col != "identifiant" && col != "identifiant_client")
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
                    UpdateInterventionGridRow.RowDefinitions.Add(rowDef1);

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
                    textBoxGeneric.Text = InterventionToUpdate[list[i - 2].ToString()].ToString();
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
                    textBoxGeneric1.Text = InterventionToUpdate[list[i - 1].ToString()].ToString();
                    Grid.SetColumn(textBoxGeneric1, 3);
                    Grid.SetRow(textBoxGeneric1, nbRow);

                    nbRow++;

                    UpdateInterventionGridRow.Children.Add(textBlockGeneric);
                    UpdateInterventionGridRow.Children.Add(textBoxGeneric);
                    UpdateInterventionGridRow.Children.Add(textBlockGeneric1);
                    UpdateInterventionGridRow.Children.Add(textBoxGeneric1);
                }

                else
                {
                    if (j == colNames.Count - 1)
                    {
                        RowDefinition rowDef1 = new RowDefinition();
                        rowDef1.Height = new GridLength(30, GridUnitType.Pixel);
                        UpdateInterventionGridRow.RowDefinitions.Add(rowDef1);

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
                        textBoxGeneric.Text = InterventionToUpdate[list[i - 1].ToString()].ToString();
                        Grid.SetColumn(textBoxGeneric, 1);
                        Grid.SetRow(textBoxGeneric, nbRow);

                        UpdateInterventionGridRow.Children.Add(textBlockGeneric);
                        UpdateInterventionGridRow.Children.Add(textBoxGeneric);
                    }
                }
            }
        }

        private async void UpdateIntervention_Click(object sender, RoutedEventArgs e)
        {
            string query = "UPDATE interventions SET ";

            foreach (string col in colNames)
            {
                TextBox foundTextBox = UIHelper.Instance.FindChild<TextBox>(UpdateInterventionGridRow, col + "_textbox");
                query += @"" + col + " = '" + foundTextBox.Text + "',";
            }

            query = query.Remove(query.Length - 1);
            query += " where identifiant = " + InterventionToUpdate["identifiant"].ToString();

            if (await InterventionVM.Instance.UpdateIntervention(query) == true)
            {
                await UpdateCustomer.Instance.RefreshDataGridInterventions();
                this.Close();
            }

            else MessageBox.Show("Une erreur est intervenue lors de la modification de l'intervention.", "Erreur intervention non modifié", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private async void DeleteInterventionButton_Click(object sender, RoutedEventArgs e)
        {
            if (await InterventionVM.Instance.DeleteIntervention(InterventionToUpdate["identifiant"].ToString()) == true)
            {
                await UpdateCustomer.Instance.RefreshDataGridInterventions();
                this.Close();
            }

            else MessageBox.Show("Une erreur est intervenue lors de la suppression de l'intervention.", "Erreur intervention non supprimé", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}
