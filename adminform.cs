using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace repertJeux //test
{
    public partial class adminform : Form
    {
        string connectionString = "Server=localhost;Database=repjeux;User=root;Password=;";
        private int selectedGameId = -1; // Pour stocker l'ID du jeu sélectionné
        private bool logOuvert;
        public adminform(bool ouvert)
        {
            logOuvert = ouvert;
            InitializeComponent();
            LoadData();

            // Configuration de la TextBox pour le placeholder
            ConfigurePlaceholder(textBox1, "Rechercher un jeu...");
            textBox1.TextChanged += SearchData; // Recherche en temps réel

            // Configuration des TextBox pour les placeholders
            ConfigurePlaceholder(txtTitre, "Titre du jeu");
            ConfigurePlaceholder(txtDescription, "Description du jeu");
            ConfigurePlaceholder(txtCategorie, "Catégorie du jeu");
            ConfigurePlaceholder(txtNbrJoueursMin, "Minimum de joueurs");
            ConfigurePlaceholder(txtNbrJoueursMax, "Maximum de joueurs");

            // Événement pour sélectionner un jeu
            dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;

            // Ajouter des événements TextChanged pour vérifier les placeholders
            txtTitre.TextChanged += (sender, e) => CheckPlaceholder(sender as TextBox, "Titre du jeu");
            txtDescription.TextChanged += (sender, e) => CheckPlaceholder(sender as TextBox, "Description du jeu");
            txtCategorie.TextChanged += (sender, e) => CheckPlaceholder(sender as TextBox, "Catégorie du jeu");
            txtNbrJoueursMin.TextChanged += (sender, e) => CheckPlaceholder(sender as TextBox, "Minimum de joueurs");
            txtNbrJoueursMax.TextChanged += (sender, e) => CheckPlaceholder(sender as TextBox, "Maximum de joueurs");
        }

        private void ConfigurePlaceholder(TextBox textBox, string placeholderText)
        {
            textBox.Text = placeholderText;
            textBox.ForeColor = SystemColors.GrayText;
            textBox.Enter += (sender, e) => RemovePlaceholder(sender as TextBox, placeholderText);
            textBox.Leave += (sender, e) => SetPlaceholder(sender as TextBox, placeholderText);
        }

        private void RemovePlaceholder(TextBox textBox, string placeholderText)
        {
            if (textBox.Text == placeholderText)
            {
                textBox.Text = "";
                textBox.ForeColor = SystemColors.WindowText; // Couleur normale pour le texte saisi
            }
        }

        private void SetPlaceholder(TextBox textBox, string placeholderText)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text) || textBox.Text == placeholderText)
            {
                textBox.Text = placeholderText;
                textBox.ForeColor = SystemColors.GrayText; // Couleur du placeholder
            }
        }

        private void CheckPlaceholder(TextBox textBox, string placeholderText)
        {
            if (textBox.Text != placeholderText)
            {
                textBox.ForeColor = Color.Black; // Couleur normale pour le texte saisi
            }
            else
            {
                textBox.ForeColor = SystemColors.GrayText; // Couleur du placeholder
            }
        }

        private void LoadData()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT Id, Titre, Description, NbrJoueursMin, NbrJoueursMax, Categorie FROM games ORDER BY Id";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns["Id"].Visible = true; // Masquer la colonne ID
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur : " + ex.Message);
                }
            }
        }

        private void SearchData(object sender, EventArgs e)
        {
            // Ne pas effectuer de recherche si le texte est le placeholder ou vide
            if (textBox1.Text == "Rechercher un jeu..." || string.IsNullOrWhiteSpace(textBox1.Text))
            {
                LoadData(); // Recharger toutes les données
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT Id, Titre, Description, NbrJoueursMin, NbrJoueursMax, Categorie FROM games WHERE Titre LIKE @searchTerm";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@searchTerm", "%" + textBox1.Text + "%");
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns["Id"].Visible = true; // Masquer la colonne ID
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur : " + ex.Message);
                }
            }
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                selectedGameId = (int)selectedRow.Cells["Id"].Value;
                txtTitre.Text = selectedRow.Cells["Titre"].Value.ToString();
                txtDescription.Text = selectedRow.Cells["Description"].Value.ToString();
                txtCategorie.Text = selectedRow.Cells["Categorie"].Value.ToString();
                txtNbrJoueursMin.Text = selectedRow.Cells["NbrJoueursMin"].Value.ToString();
                txtNbrJoueursMax.Text = selectedRow.Cells["NbrJoueursMax"].Value.ToString();

                // Marquer les TextBox comme modifiées pour éviter de réinitialiser les placeholders
                txtTitre.Tag = true;
                txtDescription.Tag = true;
                txtCategorie.Tag = true;
                txtNbrJoueursMin.Tag = true;
                txtNbrJoueursMax.Tag = true;
            }
        }

        // Méthode pour ajouter un jeu
        private void AjoutJeu(string titre, string description, string categorie, int nbrJoueursMin, int nbrJoueursMax)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO games (Titre, Description, NbrJoueursMin, NbrJoueursMax, Categorie) VALUES (@titre, @description, @nbrJoueursMin, @nbrJoueursMax, @categorie)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@titre", titre);
                    cmd.Parameters.AddWithValue("@description", description);
                    cmd.Parameters.AddWithValue("@categorie", categorie);
                    cmd.Parameters.AddWithValue("@nbrJoueursMin", nbrJoueursMin);
                    cmd.Parameters.AddWithValue("@nbrJoueursMax", nbrJoueursMax);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Jeu ajouté avec succès !");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur : " + ex.Message);
                }
            }
        }

        // Méthode pour modifier un jeu
        private void UpdateGame(int id, string titre, string description, string categorie, int nbrJoueursMin, int nbrJoueursMax)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE games SET Titre = @titre, Description = @description, Categorie = @categorie, NbrJoueursMin = @nbrJoueursMin, NbrJoueursMax = @nbrJoueursMax WHERE ID = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@titre", titre);
                    cmd.Parameters.AddWithValue("@description", description);
                    cmd.Parameters.AddWithValue("@categorie", categorie);
                    cmd.Parameters.AddWithValue("@nbrJoueursMin", nbrJoueursMin);
                    cmd.Parameters.AddWithValue("@nbrJoueursMax", nbrJoueursMax);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Jeu modifié avec succès !");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur : " + ex.Message);
                }
            }
        }

        // Méthode pour supprimer un jeu
        private void DeleteGame(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "DELETE FROM games WHERE ID = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Jeu supprimé avec succès !");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur : " + ex.Message);
                }
            }
        }

        private void BtAjoutJeu_Click(object sender, EventArgs e)
        {
            // Récupérer les valeurs saisies par l'utilisateur
            string titre = txtTitre.Text;
            string description = txtDescription.Text;
            string categorie = txtCategorie.Text;
            int nbrJoueursMin, nbrJoueursMax;

            // Valider les entrées
            if (string.IsNullOrWhiteSpace(titre) || titre == "Titre du jeu" ||
                string.IsNullOrWhiteSpace(description) || description == "Description du jeu" ||
                string.IsNullOrWhiteSpace(categorie) || categorie == "Catégorie du jeu")
            {
                MessageBox.Show("Veuillez remplir tous les champs.");
                return;
            }

            if (!int.TryParse(txtNbrJoueursMin.Text, out nbrJoueursMin) || txtNbrJoueursMin.Text == "Minimum de joueurs" ||
                !int.TryParse(txtNbrJoueursMax.Text, out nbrJoueursMax) || txtNbrJoueursMax.Text == "Maximum de joueurs")
            {
                MessageBox.Show("Veuillez entrer des nombres valides pour les joueurs.");
                return;
            }

            // Ajouter le jeu
            AjoutJeu(titre, description, categorie, nbrJoueursMin, nbrJoueursMax);

            // Recharger les données
            LoadData();

            // Effacer les champs de saisie et réinitialiser les placeholders
            ClearAndSetPlaceholders();
        }

        private void BtModifJeu_Click(object sender, EventArgs e)
        {
            // Récupérer les valeurs saisies par l'utilisateur
            string titre = txtTitre.Text;
            string description = txtDescription.Text;
            string categorie = txtCategorie.Text;
            int nbrJoueursMin, nbrJoueursMax;

            // Valider les entrées
            if (string.IsNullOrWhiteSpace(titre) || titre == "Titre du jeu" ||
                string.IsNullOrWhiteSpace(description) || description == "Description du jeu" ||
                string.IsNullOrWhiteSpace(categorie) || categorie == "Catégorie du jeu")
            {
                MessageBox.Show("Veuillez sélectionner un jeu ou remplir tous les champs.");
                return;
            }

            if (!int.TryParse(txtNbrJoueursMin.Text, out nbrJoueursMin) || txtNbrJoueursMin.Text == "Minimum de joueurs" ||
                !int.TryParse(txtNbrJoueursMax.Text, out nbrJoueursMax) || txtNbrJoueursMax.Text == "Maximum de joueurs")
            {
                MessageBox.Show("Veuillez entrer des nombres valides pour les joueurs.");
                return;
            }

            // Modifier le jeu
            if (selectedGameId != -1)
            {
                UpdateGame(selectedGameId, titre, description, categorie, nbrJoueursMin, nbrJoueursMax);
                // Recharger les données
                LoadData();
                // Effacer les champs de saisie et réinitialiser les placeholders
                ClearAndSetPlaceholders();
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un jeu à modifier.");
            }
        }

        private void BtSuppJeu_Click(object sender, EventArgs e)
        {
            // Supprimer le jeu
            if (selectedGameId != -1)
            {
                DeleteGame(selectedGameId);
                // Recharger les données
                LoadData();
                // Effacer les champs de saisie et réinitialiser les placeholders
                ClearAndSetPlaceholders();
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un jeu à supprimer.");
            }
        }

        private void ClearAndSetPlaceholders()
        {
            // Effacer les champs de saisie
            txtTitre.Text = "";
            txtDescription.Text = "";
            txtNbrJoueursMin.Text = "";
            txtNbrJoueursMax.Text = "";
            txtCategorie.Text = "";
            selectedGameId = -1; // Réinitialiser l'ID du jeu sélectionné

            // Réinitialiser les placeholders
            SetPlaceholder(txtTitre, "Titre du jeu");
            SetPlaceholder(txtDescription, "Description du jeu");
            SetPlaceholder(txtCategorie, "Catégorie du jeu");
            SetPlaceholder(txtNbrJoueursMin, "Minimum de joueurs");
            SetPlaceholder(txtNbrJoueursMax, "Maximum de joueurs");
        }

        private void adminform_FormClosed(object sender, FormClosedEventArgs e)
        {
            logOuvert = false;
        }
    }
}
