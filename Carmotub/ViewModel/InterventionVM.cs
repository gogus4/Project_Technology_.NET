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

        public async Task<bool> DeleteInterventionWithCustomer(string customer)
        {
            /*try
            {
                string query = "DELETE FROM interventions WHERE identifiant_client = @identifiant_client";
                await SQLDataHelper.Instance.OpenConnection();

                MySqlCommand cmd = new MySqlCommand(query, SQLDataHelper.Instance.Connection);
                cmd.Prepare();

                cmd.Parameters.Add("@identifiant_client", customer.identifiant);
                cmd.ExecuteNonQuery();

                await GetAllIntervention();
            }
            catch (Exception E)
            {
                return false;
            }*/

            return true;
        }

        public async Task<bool> UpdateIntervention(Intervention intervention)
        {
            /*try
            {
                string query = "UPDATE interventions SET date_intervention = @date_intervention, type_chaudiere = @type_chaudiere, carnet = @carnet, nature = @nature, montant = @montant, numero_cheque = @numero_cheque, type_paiement = @type_paiement WHERE identifiant = @identifiant";
                await SQLDataHelper.Instance.OpenConnection();

                MySqlCommand cmd = new MySqlCommand(query, SQLDataHelper.Instance.Connection);
                cmd.Prepare();

                cmd.Parameters.Add("@date_intervention", intervention.date);
                cmd.Parameters.Add("@type_chaudiere", intervention.type_chaudiere);
                cmd.Parameters.Add("@carnet", intervention.carnet);
                cmd.Parameters.Add("@nature", intervention.nature);
                cmd.Parameters.Add("@montant", intervention.montant);
                cmd.Parameters.Add("@numero_cheque", intervention.numero_cheque);
                cmd.Parameters.Add("@type_paiement", intervention.type_paiement);
                cmd.Parameters.Add("@identifiant", intervention.identifiant);

                cmd.ExecuteNonQuery();

                await GetAllIntervention();
            }
            catch (Exception E)
            {
                return false;
            }*/

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

        public async Task<bool> DeleteIntervention(Intervention intervention)
        {
            /*try
            {
                string query = "DELETE FROM interventions WHERE identifiant = @identifiant";
                await SQLDataHelper.Instance.OpenConnection();

                MySqlCommand cmd = new MySqlCommand(query, SQLDataHelper.Instance.Connection);
                cmd.Prepare();

                cmd.Parameters.Add("@identifiant", intervention.identifiant);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                await GetAllIntervention();
            }
            catch (Exception E)
            {
                return false;
            }*/

            return true;
        }

        public async Task<List<Dictionary<string, string>>> GetAllIntervention()
        {
            List<Dictionary<string, string>> interventions = new List<Dictionary<string, string>>();

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

                interventions.Add(intervention);
            }

            return interventions;
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
    }
}