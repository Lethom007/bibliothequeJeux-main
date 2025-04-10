using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace repertJeux
{
    public partial class LoginForm : Form
    {
        private readonly string connectionString;

        public LoginForm()
        {
            InitializeComponent();

            // Configuration de la chaîne de connexion
            var builder = new MySqlConnectionStringBuilder
            {
                Server = "localhost",
                Database = "repjeux",
                UserID = "root",
                Password = "",
                Port = 3306,
                ConnectionTimeout = 30
            };

            connectionString = builder.ConnectionString;
        }
       

        private void button1_Click(object sender, EventArgs e)
        {
            string utilisateur = textBox1.Text.Trim();
            string motDePasse = textBox2.Text.Trim();

            string role = "admin"; // Récupérez ce rôle depuis la base de données
            ;

            if (string.IsNullOrEmpty(utilisateur) || string.IsNullOrEmpty(motDePasse))
            {
               
                labelerror.Text ="❌ Veuillez entrer un identifiant et un mot de passe.";
                labelerror.Visible = true;
                return;
            }

            string requete = "SELECT role FROM users WHERE username = @username AND password = @password";

            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@username", utilisateur },
                { "@password", motDePasse } // ⚠️ Il est préférable d'utiliser des mots de passe hachés !
            };

            DataTable result = ExecuterSelect(requete, parameters);

            if (result.Rows.Count == 1)
            {
                labelsucces.Text ="connexion réussi";
                role = result.Rows[0]["role"].ToString();
                MessageBox.Show($"✅ Connexion réussie en tant que {role} !");
                OuvrirInterface(role);
            }
            else
            {
                labelerror.Text = "erreur de connexion";
                MessageBox.Show("❌ Identifiant ou mot de passe incorrect.");
            }
        }

        private DataTable ExecuterSelect(string requete, Dictionary<string, object> parameters = null)
        {
            DataTable dataTable = new DataTable();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                using (MySqlCommand cmd = new MySqlCommand(requete, conn))
                {
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                        }
                    }

                    conn.Open();
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Erreur de requête : {ex.Message}");
            }

            return dataTable;
        }
        private void OuvrirInterface(string role)
        {
            
            if (role == "Admin")
            {
                
                adminform adminForm = new adminform(true);
                adminForm.Show();
            }
            else if (role == "User")
            {
                userform userForm = new userform();
                userForm.Show();
            }
            this.Hide(); // Cache la fenêtre de connexion après l'ouverture

        }
    }
}
