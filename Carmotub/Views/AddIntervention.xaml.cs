using Carmotub.Data;
using Carmotub.ViewModel;
using Carmotub.Views.Controls;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace Carmotub.Views
{
    public partial class AddIntervention : Window
    {
        public List<string> colNames { get; set; }
        public DataRow Customer { get; set; }

        private static AddIntervention _instance = null;
        public static AddIntervention Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new AddIntervention();
                return _instance;
            }
        }

        public AddIntervention()
        {
            InitializeComponent();
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
                    AddInterventionGridRow.RowDefinitions.Add(rowDef1);

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

                    AddInterventionGridRow.Children.Add(textBlockGeneric);
                    AddInterventionGridRow.Children.Add(textBoxGeneric);
                    AddInterventionGridRow.Children.Add(textBlockGeneric1);
                    AddInterventionGridRow.Children.Add(textBoxGeneric1);
                }

                else
                {
                    if (j == colNames.Count - 1)
                    {
                        RowDefinition rowDef1 = new RowDefinition();
                        rowDef1.Height = new GridLength(30, GridUnitType.Pixel);
                        AddInterventionGridRow.RowDefinitions.Add(rowDef1);

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

                        nbRow++;

                        AddInterventionGridRow.Children.Add(textBlockGeneric);
                        AddInterventionGridRow.Children.Add(textBoxGeneric);
                    }
                }
            }
        }

        public AddIntervention(DataRow customer)
        {
            InitializeComponent();

            _instance = this;

            CustomerSelected.Text = customer["nom"].ToString() + " " + customer["prenom"].ToString();

            Customer = customer;
            CreateGridDynamically();
        }

        private async void AddInterventionButton_Click(object sender, RoutedEventArgs e)
        {
            string query = "INSERT INTO interventions(identifiant_client,";

            foreach (string col in colNames)
            {
                query += col + ",";
            }

            query = query.Remove(query.Length - 1);
            query += ") VALUES(" + Customer["identifiant"].ToString() + ",";

            foreach (string col in colNames)
            {
                TextBox foundTextBox = UIHelper.Instance.FindChild<TextBox>(AddInterventionGridRow, col + "_textbox");
                query += @"'" + foundTextBox.Text + "',";
            }

            query = query.Remove(query.Length - 1);
            query += ")";

            if (await InterventionVM.Instance.AddIntervention(query) == true)
            {
                await ActionsCustomers.Instance.Init();
                this.Close();
            }

            else MessageBox.Show("Une erreur est intervenue lors de l'ajout de l'intervention.", "Erreur intervention non ajoutée", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}
