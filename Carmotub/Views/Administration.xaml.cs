using Carmotub.ViewModel;
using Carmotub.Views.Controls;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Forms;

namespace Carmotub.Views
{
    public partial class Administration : Window
    {
        public Administration()
        {
            InitializeComponent();
            InitColumnsName();
        }

        private void InitColumnsName()
        {
            var colNames = new List<string>();

            foreach (string col in CustomerVM.Instance.columns)
            {
                if (col != "identifiant" && col != "commentaire")
                    colNames.Add(col);
            }

            DataGridCustomerColumn.ItemsSource = colNames;

            colNames = new List<string>();
            foreach (string col in InterventionVM.Instance.columns)
            {
                if (col != "identifiant" && col != "date_intervention" && col != "identifiant_client")
                    colNames.Add(col);
            }

            DataGridInterventionColumn.ItemsSource = colNames;
        }

        private async void DeleteCustomerColumn_Click(object sender, RoutedEventArgs e)
        {
            string col_name = DataGridCustomerColumn.SelectedItem.ToString();

            var dialogResult = System.Windows.Forms.MessageBox.Show(string.Format("Etes-vous sur de vouloir supprimer la colonne {0} ?", col_name), "Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult.ToString() == "Yes")
            {
                if (await CustomerVM.Instance.DropColumnCustomer(col_name) == true)
                {
                    await ActionsCustomers.Instance.Init();
                    InitColumnsName();
                }

                else
                    System.Windows.Forms.MessageBox.Show("Une erreur est survenue lors de la suppression de la colonne.", "Erreur");

            }
        }

        private void EditCustomerColumn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
