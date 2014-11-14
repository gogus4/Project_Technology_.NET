﻿using Carmotub.Data;
using Carmotub.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public CustomerVM()
        {
        }

        public async Task<bool> DeleteCustomer(Customer customer)
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

        public async Task<bool> UpdateCustomer(Customer customer)
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

        public async Task<bool> AddCustomer(Customer customer)
        {
            /*try
            {
                string query = "INSERT INTO clients(nom,prenom,adresse,code_postal,ville,etage,escalier,telephone_1,telephone_2,commentaire,recommande_par,code,rdv,voie,numero_adresse) VALUES(@nom,@prenom,@adresse,@code_postal,@ville,@etage,@escalier,@telephone_1,@telephone_2,@commentaire,@recommande_par,@code,@rdv,@voie,@numero_adresse)";
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
                cmd.Parameters.Add("@recommande_par", customer.recommande_par);
                cmd.Parameters.Add("@code", customer.code);
                cmd.Parameters.Add("@rdv", customer.Rdv);
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

        public async Task<List<Customer>> GetAllCustomer()
        {
            return CarmotubServerEntities.Instance.Customer.ToList();
        }
    }
}
