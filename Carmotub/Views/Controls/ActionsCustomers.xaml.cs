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

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            /*if (SearchBoxText.Text == "")
            {
                DataGridCustomers.ItemsSource = Customers;
                return;
            }

            List<Customer> list_customers = new List<Customer>();
            switch (SearchBy.SelectedIndex)
            {
                case 0:
                    list_customers = Customers.Where(x => x.nom.ToUpper().Contains(SearchBoxText.Text.ToUpper())).ToList();
                    break;

                case 1:
                    list_customers = Customers.Where(x => x.adresse.ToUpper().Contains(SearchBoxText.Text.ToUpper())).ToList();
                    break;

                case 2:
                    list_customers = Customers.Where(x => x.code_postal.ToUpper().Contains(SearchBoxText.Text.ToUpper())).ToList();
                    break;

                case 3:
                    list_customers = Customers.Where(x => x.telephone_1.ToUpper().Contains(SearchBoxText.Text.ToUpper())).ToList();
                    break;

                case 4:
                    list_customers = Customers.Where(x => x.Rdv.ToUpper().Contains(SearchBoxText.Text.ToUpper())).ToList();
                    break;

                case 5:
                    list_customers = Customers.Where(x => x.telephone_2.ToUpper().Contains(SearchBoxText.Text.ToUpper())).ToList();
                    break;
            }

            DataGridCustomers.ItemsSource = list_customers;*/
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

        private void SearchBy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                switch (SearchBy.SelectedIndex)
                {
                    case 6:
                        SearchBorder.Visibility = Visibility.Collapsed;
                        SearchByNumberIntervention.Visibility = Visibility.Visible;
                        SelectDateIntervention.Visibility = Visibility.Collapsed;
                        SearchMonthInterventionStackPanel.Visibility = Visibility.Collapsed;
                        break;

                    case 7:
                        SearchByNumberIntervention.Visibility = Visibility.Collapsed;
                        SearchBorder.Visibility = Visibility.Collapsed;
                        SelectDateIntervention.Visibility = Visibility.Visible;
                        SearchMonthInterventionStackPanel.Visibility = Visibility.Collapsed;
                        break;

                    case 8:
                        SearchByNumberIntervention.Visibility = Visibility.Collapsed;
                        SearchBorder.Visibility = Visibility.Collapsed;
                        SelectDateIntervention.Visibility = Visibility.Collapsed;
                        SearchMonthInterventionStackPanel.Visibility = Visibility.Visible;
                        break;

                    default:
                        SearchBorder.Visibility = Visibility.Visible;
                        SearchByNumberIntervention.Visibility = Visibility.Collapsed;
                        SelectDateIntervention.Visibility = Visibility.Collapsed;
                        SearchMonthInterventionStackPanel.Visibility = Visibility.Collapsed;
                        break;
                }
            }
            catch (Exception E) { }
        }

        private void SelectDateIntervention_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            /*var list_interventions = InterventionVM.Instance.Interventions.Where(x => x.date == SelectDateIntervention.Text).ToList();

            var customers = new List<Customer>();

            foreach (Intervention inter in list_interventions)
            {
                var customer_find = Customers.Where(x => x.identifiant == inter.identifiant_client).FirstOrDefault();
                customers.Add(customer_find);
            }

            DataGridCustomers.ItemsSource = customers;*/
        }

        private void ValidSearchByMonth_Click(object sender, RoutedEventArgs e)
        {
            /*var list_interventions = InterventionVM.Instance.Interventions.Where(x => x.date_intervention.Month == SearchByMonthIntervention.SelectedIndex + 1).ToList();

            var customers = new List<Customer>();

            foreach (Intervention inter in list_interventions)
            {
                var customer_find = Customers.Where(x => x.identifiant == inter.identifiant_client).FirstOrDefault();

                if (customers.Where(x => x.identifiant == customer_find.identifiant).Count() == 0)
                    customers.Add(customer_find);
            }

            DataGridCustomers.ItemsSource = customers;*/
        }

        private void ValidSearchByNumberIntervention_Click(object sender, RoutedEventArgs e)
        {
            /*List<Customer> list_customers = new List<Customer>();
            foreach (Customer customer in Customers)
            {
                var list_intervention = InterventionVM.Instance.Interventions.Where(x => x.identifiant_client == customer.identifiant);

                if (list_intervention.Count() == NumberIntervention.SelectedIndex)
                    list_customers.Add(customer);
            }

            DataGridCustomers.ItemsSource = list_customers;*/
        }
    }
}
