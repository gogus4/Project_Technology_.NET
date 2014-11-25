using Carmotub.Data;
using Carmotub.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Carmotub.ViewModel
{
    public class InterventionVM
    {
        public List<Dictionary<string, string>> Interventions { get; set; }

        public List<String> columns { get; set; }

        private static InterventionVM _instance = null;
        public static InterventionVM Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new InterventionVM();

                return _instance;
            }
        }

        public InterventionVM()
        {
        }

        public async Task<bool> DeleteInterventionWithCustomer(string identifiant_client)
        {
            try
            {
                string query = "DELETE FROM interventions WHERE identifiant_client = @identifiant_client";
                await SQLDataHelper.Instance.OpenConnection();

                MySqlCommand cmd = new MySqlCommand(query, SQLDataHelper.Instance.Connection);
                cmd.Prepare();

                cmd.Parameters.Add("@identifiant_client", identifiant_client);
                cmd.ExecuteNonQuery();

                await GetAllIntervention();
            }
            catch (Exception E)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> UpdateIntervention(string query)
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

        public async Task<bool> AddIntervention(string query)
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

        public async Task<bool> DeleteIntervention(string indice_intervention)
        {
            try
            {
                string query = "DELETE FROM interventions WHERE identifiant = @identifiant";
                await SQLDataHelper.Instance.OpenConnection();

                MySqlCommand cmd = new MySqlCommand(query, SQLDataHelper.Instance.Connection);
                cmd.Prepare();

                cmd.Parameters.Add("@identifiant", indice_intervention);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                await GetAllIntervention();
            }
            catch (Exception E)
            {
                return false;
            }

            return true;
        }

        public async Task<List<Dictionary<string, string>>> GetAllIntervention()
        {
            Interventions = new List<Dictionary<string, string>>();

            string query = "SELECT * from interventions";
            await SQLDataHelper.Instance.OpenConnection();
            MySqlCommand cmd = new MySqlCommand(query, SQLDataHelper.Instance.Connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                Dictionary<string, string> intervention = new Dictionary<string, string>();

                for (int i = 0; i < InterventionVM.Instance.columns.Count; i++)
                {
                    intervention.Add(InterventionVM.Instance.columns[i], dataReader[i].ToString());
                }

                Interventions.Add(intervention);
            }

            return Interventions;
        }

        public async Task GetColumns()
        {
            columns = new List<String>();
            await SQLDataHelper.Instance.OpenConnection();

            using (MySqlCommand cmd = new MySqlCommand("select column_name from information_schema.columns where table_name = 'interventions'", SQLDataHelper.Instance.Connection))
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

        public async Task<bool> DropColumnIntervention(string column)
        {
            try
            {
                string query = string.Format("ALTER TABLE interventions DROP COLUMN {0}", column);

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
    }
}