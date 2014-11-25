using Carmotub.Data;
using Carmotub.Model;
using Carmotub.ViewModel;
using Carmotub.Views.Controls;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace Carmotub.Views
{
    public partial class UpdateCustomer : Window
    {
        public List<string> colNames { get; set; }
        public DataRow CustomerToUpdate { get; set; }

        public DataTable Table { get; set; }

        private static UpdateCustomer _instance = null;
        public static UpdateCustomer Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UpdateCustomer(null);
                return _instance;
            }
        }

        public UpdateCustomer(DataRow customer)
        {
            InitializeComponent();

            _instance = this;

            CustomerToUpdate = customer;
            this.DataContext = this;

            RefreshDataGridInterventions();
            CreateGridDynamically();

            var listPhoto = CustomerPhotoVM.Instance.Photos.Where(x => x.identifiant_client == int.Parse(customer["identifiant"].ToString()));

            if (listPhoto.Count() > 0)
                ImageListbox.ItemsSource = listPhoto;

            else
                ListPhotos.Visibility = Visibility.Collapsed;
        }

        public async Task GetInterventions()
        {
            Table = new DataTable();

            DataGridInterventions.Columns.Clear();

            List<Dictionary<string, string>> listInterventions = await InterventionVM.Instance.GetAllIntervention();

            foreach (Dictionary<string, string> d in listInterventions)
            {
                foreach (string key in d.Keys)
                {
                    if (key != "identifiant_client")
                        Addcolumn(key);
                }
                break;
            }

            // LINQ 
            foreach (Dictionary<string, string> d in listInterventions)
            {
                DataRow row = Table.NewRow();

                if (d["identifiant_client"].ToString() == CustomerToUpdate["identifiant"].ToString())
                {
                    foreach (KeyValuePair<string, string> keyValue in d)
                    {
                        if (keyValue.Key != "identifiant_client")
                            row[keyValue.Key] = keyValue.Value;
                    }

                    Table.Rows.Add(row);
                }
            }

            DataGridInterventions.ItemsSource = Table.DefaultView;
        }

        private void Addcolumn(string columnname)
        {
            if (!Table.Columns.Contains(columnname))
            {
                DataGridTextColumn dgColumn = new DataGridTextColumn();
                dgColumn.Header = columnname;
                dgColumn.Binding = new Binding(string.Format("[{0}]", columnname));
                dgColumn.SortMemberPath = columnname;
                dgColumn.IsReadOnly = true;

                DataGridInterventions.Columns.Add(dgColumn);

                DataColumn dtcolumn = new DataColumn();
                dtcolumn.Caption = columnname;
                dtcolumn.ColumnName = columnname;

                Table.Columns.Add(dtcolumn);
            }
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
                    UpdateCustomerGridRow.RowDefinitions.Add(rowDef1);

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
                    textBoxGeneric.Text = CustomerToUpdate[list[i - 2].ToString()].ToString();
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
                    textBoxGeneric1.Text = CustomerToUpdate[list[i - 1].ToString()].ToString();
                    textBoxGeneric1.Margin = new Thickness(0, 0, 5, 0);
                    Grid.SetColumn(textBoxGeneric1, 3);
                    Grid.SetRow(textBoxGeneric1, nbRow);

                    nbRow++;

                    UpdateCustomerGridRow.Children.Add(textBlockGeneric);
                    UpdateCustomerGridRow.Children.Add(textBoxGeneric);
                    UpdateCustomerGridRow.Children.Add(textBlockGeneric1);
                    UpdateCustomerGridRow.Children.Add(textBoxGeneric1);
                }

                else
                {
                    if (j == colNames.Count - 1)
                    {
                        RowDefinition rowDef1 = new RowDefinition();
                        rowDef1.Height = new GridLength(30, GridUnitType.Pixel);
                        UpdateCustomerGridRow.RowDefinitions.Add(rowDef1);

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
                        textBoxGeneric.Text = CustomerToUpdate[colNames[j].ToString()].ToString();
                        textBoxGeneric.Margin = new Thickness(0, 0, 5, 0);
                        Grid.SetColumn(textBoxGeneric, 1);
                        Grid.SetRow(textBoxGeneric, nbRow);

                        UpdateCustomerGridRow.Children.Add(textBlockGeneric);
                        UpdateCustomerGridRow.Children.Add(textBoxGeneric);
                    }
                }
            }

            RowDefinition row1 = new RowDefinition();
            row1.Height = new GridLength(30, GridUnitType.Pixel);
            UpdateCustomerGridRow.RowDefinitions.Add(row1);

            TextBlock textBlockGeneric2 = new TextBlock();
            textBlockGeneric2.Text = "Commentaire : ";
            textBlockGeneric2.Height = 20;
            textBlockGeneric2.Foreground = Brushes.Black;
            textBlockGeneric2.Margin = new Thickness(5, 0, 0, 0);
            Grid.SetColumn(textBlockGeneric2, 0);
            Grid.SetRow(textBlockGeneric2, nbRow);

            UpdateCustomerGridRow.Children.Add(textBlockGeneric2);

            RowDefinition row = new RowDefinition();
            row.Height = new GridLength(100, GridUnitType.Pixel);
            UpdateCustomerGridRow.RowDefinitions.Add(row);

            RichTextBox RichtextBoxGeneric1 = new RichTextBox();
            RichtextBoxGeneric1.Name = "commentaire_textbox";
            RichtextBoxGeneric1.Height = 100;
            RichtextBoxGeneric1.Margin = new Thickness(5, 0, 5, 0);

            RichtextBoxGeneric1.Document.Blocks.Clear();
            RichtextBoxGeneric1.Document.Blocks.Add(new Paragraph(new Run(CustomerToUpdate["commentaire"].ToString())));

            Grid.SetColumnSpan(RichtextBoxGeneric1, 4);
            Grid.SetColumn(RichtextBoxGeneric1, 0);
            Grid.SetRow(RichtextBoxGeneric1, nbRow + 1);

            UpdateCustomerGridRow.Children.Add(RichtextBoxGeneric1);
        }

        public async void RefreshDataGridInterventions()
        {
            await GetInterventions();
        }

        public void RefreshAndDeleteListBoxPhotoCustomer()
        {
            //ImageListbox.ItemsSource = CustomerPhotoVM.Instance.Photos.Where(x => x.identifiant_client == CustomerToUpdate.identifiant);
        }

        private async void UpdateCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            string query = "UPDATE clients SET ";

            foreach (string col in colNames)
            {
                TextBox foundTextBox = UIHelper.Instance.FindChild<TextBox>(UpdateCustomerGridRow, col + "_textbox");

                query += @"" + col + " = '" + foundTextBox.Text + "',";
            }

            RichTextBox foundRichTextBox = UIHelper.Instance.FindChild<RichTextBox>(UpdateCustomerGridRow, "commentaire_textbox");

            foundRichTextBox.SelectAll();
            query += "commentaire = '" + foundRichTextBox.Selection.Text.Replace(Environment.NewLine,"") + "'";
            query += " where identifiant = " + CustomerToUpdate["identifiant"].ToString();

            if (await CustomerVM.Instance.UpdateCustomer(query) == true)
            {
                await ActionsCustomers.Instance.Init();
                this.Close();
            }

            else
            {
                MessageBox.Show("Une erreur est intervenue lors de la modification du client.", "Erreur client non modifié", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void DataGridInterventions_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var intervention = (Intervention)DataGridInterventions.SelectedItem;

            UpdateIntervention updateIntervention = new UpdateIntervention(intervention);
            updateIntervention.Show();
        }

        private async void AddPhoto_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog openfile = new OpenFileDialog();
                openfile.DefaultExt = "*.jpg";
                openfile.Filter = "Image Files|*.jpg";
                Nullable<bool> result = openfile.ShowDialog();
                if (result == true)
                {
                    string path = @"C:\Users\" + Environment.UserName + @"\Documents\Carmotub\Photos\" + openfile.SafeFileName;
                    File.Copy(openfile.FileName, path);

                    /*if (await CustomerPhotoVM.Instance.AddPhoto(new CustomerPhoto() { identifiant_client = CustomerToUpdate.identifiant, uri = path }))
                    {
                        await CustomerPhotoVM.Instance.GetAllPhoto();
                        //ImageListbox.ItemsSource = CustomerPhotoVM.Instance.Photos.Where(x => x.identifiant_client == CustomerToUpdate.identifiant);
                    }

                    else
                    {
                        MessageBox.Show("Une erreur est intervenue lors de l'ajout de la photo.");
                    }*/
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(E.StackTrace);
            }
        }

        private void ImageListbox_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            CustomerPhoto photo = (CustomerPhoto)ImageListbox.SelectedItem;

            PopupPhotoCustomer popup = new PopupPhotoCustomer(photo);
            popup.Show();
        }
    }
}
