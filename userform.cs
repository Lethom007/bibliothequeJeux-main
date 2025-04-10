using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace repertJeux
{
    public partial class userform : Form
    {
        string connectionString = "Server=localhost;Database=repjeux;User=root;Password=;";

        public userform()
        {
            InitializeComponent();
            LoadData();

            // Configuration de la TextBox pour le placeholder
            textBox1.Text = "Recherche";
            textBox1.ForeColor = SystemColors.GrayText;
            textBox1.Enter += RemovePlaceholder;
            textBox1.Leave += SetPlaceholder;
            textBox1.TextChanged += SearchData;
        }

        private void LoadData()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT Titre, Description, NbrJoueursMax, NbrJoueursMin, Categorie FROM games";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur : " + ex.Message);
                }
            }
        }

        private void SearchData(object sender, EventArgs e)
        {
            // Ne pas effectuer de recherche si le texte est le placeholder
            if (textBox1.Text == "Recherche" || string.IsNullOrWhiteSpace(textBox1.Text))
            {
                LoadData(); // Recharger toutes les données
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT Titre, Description, NbrJoueursMax, NbrJoueursMin, Categorie FROM games WHERE Titre LIKE @searchTerm";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@searchTerm", "%" + textBox1.Text + "%");
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur : " + ex.Message);
                }
            }
        }

        private void RemovePlaceholder(object sender, EventArgs e)
        {
            if (textBox1.Text == "Recherche")
            {
                textBox1.Text = "";
                textBox1.ForeColor = SystemColors.WindowText;
            }
        }

        private void SetPlaceholder(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                textBox1.Text = "Recherche";
                textBox1.ForeColor = SystemColors.GrayText;
            }
        }
    }
}
