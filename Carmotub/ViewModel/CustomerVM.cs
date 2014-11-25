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
                string query = string.Format("ALTER TABLE clients DROP COLUMN {0}", column);

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

        public async Task<bool> UpdateCustomer(string query)
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
