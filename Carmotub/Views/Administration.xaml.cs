using Carmotub.Data;
using System;
using System.Collections.Generic;
using System.Data;
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

            var colNames = new List<string>();

            // Exceptions
            foreach (string col in typeof(Customer).GetProperties().Select(a => a.Name).ToList())
            {
                if (col != "identifiant" && col != "Intervention" && col != "PhotoClient" && col != "nom" && col != "adresse" && col != "commentaire")
                    colNames.Add(col);
            }

            DataGridCustomerColumn.ItemsSource = colNames;
        }

        private async void DeleteCustomerColumn_Click(object sender, RoutedEventArgs e)
        {
            string col_name = DataGridCustomerColumn.SelectedItem.ToString();

            /*ALTER TABLE nom_table
DROP nom_colonne*/

            var dialogResult = System.Windows.Forms.MessageBox.Show(string.Format("Etes-vous sur de vouloir supprimer la colonne {0} ?", col_name), "Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult.ToString() == "Yes")
            {
               CarmotubServerEntities.Instance.Database.ExecuteSqlCommand(string.Format("ALTER TABLE Customer DROP COLUMN {0}",col_name));
               await CarmotubServerEntities.Instance.SaveChangesAsync();
            }
        }

        private void EditCustomerColumn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
