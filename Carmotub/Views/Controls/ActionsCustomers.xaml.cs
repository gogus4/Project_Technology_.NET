using Carmotub.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;

namespace Carmotub.Views.Controls
{
    public partial class ActionsCustomers : UserControl
    {
        public DataTable Table { get; set; }

        private static ActionsCustomers _instance = null;
        public static ActionsCustomers Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ActionsCustomers();
                return _instance;
            }
        }

        public ActionsCustomers()
        {
            InitializeComponent();
            _instance = this;
        }

        public void AddValue()
        {
            ActionsCustomers.Instance.ProgressBackupDatabase.Value += 1;
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {

        }

        private async void UserControl_Initialized(object sender, EventArgs e)
        {
            await Init();
        }

        public async Task Init()
        {
            Table = new DataTable();

            await CustomerVM.Instance.GetColumns();
            await InterventionVM.Instance.GetColumns();

            await CustomerPhotoVM.Instance.GetAllPhoto();

            await CustomerVM.Instance.GetAllCustomer();

            if (CustomerVM.Instance.Customers != null)
                NumberCustomers.Text = CustomerVM.Instance.Customers.Count().ToString();

            DataGridCustomers.Columns.Clear();

            foreach (Dictionary<string, string> d in CustomerVM.Instance.Customers)
            {
                foreach (string key in d.Keys)
                {
                    Addcolumn(key);
                }
                break;
            }

            foreach (Dictionary<string, string> d in CustomerVM.Instance.Customers)
            {
                DataRow row = Table.NewRow();

                foreach (KeyValuePair<string, string> keyValue in d)
                {
                    row[keyValue.Key] = keyValue.Value;
                }

                Table.Rows.Add(row);
            }

            DataGridCustomers.ItemsSource = Table.DefaultView;
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

                DataGridCustomers.Columns.Add(dgColumn);

                DataColumn dtcolumn = new DataColumn();
                dtcolumn.Caption = columnname;
                dtcolumn.ColumnName = columnname;

                Table.Columns.Add(dtcolumn);
            }
        }

        private async void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            if (SearchBoxText.Text == "")
            {
                Table.Rows.Clear();
                foreach (Dictionary<string, string> d in CustomerVM.Instance.Customers)
                {
                    DataRow row = Table.NewRow();

                    foreach (KeyValuePair<string, string> keyValue in d)
                    {
                        row[keyValue.Key] = keyValue.Value;
                    }

                    Table.Rows.Add(row);
                }

                DataGridCustomers.ItemsSource = Table.DefaultView;

                return;
            }

            switch (SearchBy.SelectedIndex)
            {
                case 0:
                    Table.Rows.Clear();
                    foreach (Dictionary<string, string> d in CustomerVM.Instance.Customers)
                    {
                        foreach (KeyValuePair<string, string> keyValue in d)
                        {
                            if (keyValue.Key == "nom" && keyValue.Value.ToString().StartsWith(SearchBoxText.Text))
                            {
                                DataRow row = Table.NewRow();
                                foreach (KeyValuePair<string, string> keyValue1 in d)
                                {
                                    row[keyValue1.Key] = keyValue1.Value;
                                }
                                Table.Rows.Add(row);
                            }
                        }
                    }

                    DataGridCustomers.ItemsSource = Table.DefaultView;
                    break;
            }
        }

        private void DataGridCustomers_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataRow customer = ((DataRowView)DataGridCustomers.SelectedItem).Row == null ? null : ((DataRowView)DataGridCustomers.SelectedItem).Row;

            if (customer != null)
            {
                UpdateCustomer updateCustomer = new UpdateCustomer(customer);
                updateCustomer.Show();
            }

            else
                MessageBox.Show("Merci de selectionné un client pour pouvoir le modifier.", "Aucun client selectionné", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}
