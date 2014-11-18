using Carmotub.Data;
using Carmotub.Model;
using Carmotub.ViewModel;
using Carmotub.Views.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Carmotub.Views
{
    /// <summary>
    /// Logique d'interaction pour Administration.xaml
    /// </summary>
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
