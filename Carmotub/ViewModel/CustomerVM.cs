using Carmotub.Data;
using Carmotub.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carmotub.ViewModel
{
    public class CustomerVM
    {
        private static CustomerVM _instance = null;
        public static CustomerVM Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new CustomerVM();
                return _instance;
            }
        }

        public List<String> columns { get; set; }

        public CustomerVM()
        {
        }

        public async Task<bool> DropColumnCustomer(string column)
        {
            try
            {
                string query = string.Format("ALTER TABLE clients DROP COLUMN {0}",column);

                await SQLDataHelper.Instance.OpenConnection();

                MySqlCommand cmd = new MySqlCommand(query, SQLDataHelper.Instance.Connection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception E)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> DeleteCustomer(string customer)
        {
            /*try
            {
                string query = "DELETE FROM clients WHERE identifiant = @identifiant";

                await InterventionVM.Instance.DeleteInterventionWithCustomer(customer);
                await CustomerPhotoVM.Instance.DeletePhotoWithCustomer(customer);

                await SQLDataHelper.Instance.OpenConnection();

                MySqlCommand cmd = new MySqlCommand(query, SQLDataHelper.Instance.Connection);
                cmd.Prepare();

                cmd.Parameters.Add("@identifiant", customer.identifiant);
                cmd.ExecuteNonQuery();
            }
            catch (Exception E)
            {
                return false;
            }*/

            return true;
        }

        public async Task<bool> UpdateCustomer(string customer)
        {
            /*try
            {
                string query = "UPDATE clients SET nom = @nom, prenom = @prenom, adresse = @adresse, code_postal = @code_postal, ville = @ville, etage = @etage, escalier = @escalier, telephone_1=@telephone_1,telephone_2=@telephone_2,commentaire=@commentaire,code=@code,rdv=@rdv,recommande_par=@recommande_par,voie=@voie,numero_adresse=@numero_adresse WHERE identifiant = @identifiant";
                await SQLDataHelper.Instance.OpenConnection();


                MySqlCommand cmd = new MySqlCommand(query, SQLDataHelper.Instance.Connection);
                cmd.Prepare();

                cmd.Parameters.Add("@nom", customer.nom);
                cmd.Parameters.Add("@prenom", customer.prenom);
                cmd.Parameters.Add("@adresse", customer.adresse);
                cmd.Parameters.Add("@code_postal", customer.code_postal);
                cmd.Parameters.Add("@ville", customer.ville);
                cmd.Parameters.Add("@etage", customer.etage);
                cmd.Parameters.Add("@escalier", customer.escalier);
                cmd.Parameters.Add("@telephone_1", customer.telephone_1);
                cmd.Parameters.Add("@telephone_2", customer.telephone_2);
                cmd.Parameters.Add("@commentaire", customer.commentaire);
                cmd.Parameters.Add("@code", customer.code);
                cmd.Parameters.Add("@rdv", customer.Rdv);
                cmd.Parameters.Add("@recommande_par", customer.recommande_par);
                cmd.Parameters.Add("@identifiant", customer.identifiant);
                cmd.Parameters.Add("@voie", customer.voie);
                cmd.Parameters.Add("@numero_adresse", customer.numero_adresse);

                cmd.ExecuteNonQuery();
            }
            catch (Exception E)
            {
                return false;
            }*/

            return true;
        }

        public async Task<bool> AddCustomer(string query)
        {
            try
            {
                await SQLDataHelper.Instance.OpenConnection();

                MySqlCommand cmd = new MySqlCommand(query, SQLDataHelper.Instance.Connection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception E)
            {
                return false;
            }

            return true;
        }

        public async Task<List<Dictionary<string, string>>> GetAllCustomer()
        {
            List<Dictionary<string, string>> customers = new List<Dictionary<string, string>>();

            string query = "SELECT * from clients";
            await SQLDataHelper.Instance.OpenConnection();
            MySqlCommand cmd = new MySqlCommand(query, SQLDataHelper.Instance.Connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                Dictionary<string, string> customer = new Dictionary<string, string>();
                for (int i = 0; i < CustomerVM.Instance.columns.Count; i++)
                {
                    customer.Add(CustomerVM.Instance.columns[i], dataReader[i].ToString());
                }
                customers.Add(customer);
            }

            return customers;
        }

        public async Task GetColumns()
        {
            columns = new List<String>();
            await SQLDataHelper.Instance.OpenConnection();

            using (MySqlCommand cmd = new MySqlCommand("select column_name from information_schema.columns where table_name = 'clients'", SQLDataHelper.Instance.Connection))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        columns.Add(reader.GetString(0));
                    }
                }
            }
        }
    }
}
