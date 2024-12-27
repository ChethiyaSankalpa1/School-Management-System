using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SchoolManagementSystem
{
    public partial class Subject : Form
    {
        public Subject()
        {
            InitializeComponent();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "Server=localhost;Database=school_db;Uid=root;Pwd=1234;";

                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    con.Open();

                    string query = "INSERT INTO subject (id, SubjectName) VALUES (@id, @SubjectName)";
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        if (string.IsNullOrWhiteSpace(txtId.Text) || !int.TryParse(txtId.Text, out int id))
                        {
                            MessageBox.Show("Please enter a valid numeric ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        if (string.IsNullOrWhiteSpace(txtSubject.Text))
                        {
                            MessageBox.Show("Subject name cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@SubjectName", txtSubject.Text.Trim());
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Record saved successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "Server=localhost;Database=school_db;Uid=root;Pwd=1234;";
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    con.Open();

                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM subject", con);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    da.Fill(table);

                    dataGridView1.DataSource = table;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection("Server=localhost;Database=school_db;Uid=root;Pwd=1234"))
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("UPDATE subject SET SubjectName=@SubjectName WHERE id=@id", con);

                    if (string.IsNullOrWhiteSpace(txtId.Text) || !int.TryParse(txtId.Text, out int id))
                    {
                        MessageBox.Show("Please enter a valid numeric ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (string.IsNullOrWhiteSpace(txtSubject.Text))
                    {
                        MessageBox.Show("Subject name cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@SubjectName", txtSubject.Text.Trim());
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Record updated successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection("Server=localhost;Database=school_db;Uid=root;Pwd=1234"))
                {
                    con.Open();

                    MySqlCommand cmd = new MySqlCommand("DELETE FROM subject WHERE id=@id", con);

                    if (string.IsNullOrWhiteSpace(txtId.Text) || !int.TryParse(txtId.Text, out int id))
                    {
                        MessageBox.Show("Please enter a valid numeric ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Record deleted successfully", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtSubject.Text = "";
        }

        private void BtnDisplay_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "Server=localhost;Database=school_db;Uid=root;Pwd=1234;";
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    con.Open();

                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM subject", con);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    da.Fill(table);
                    dataGridView1.DataSource = table;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while fetching data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Subject_Load(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "Server=localhost;Database=school_db;Uid=root;Pwd=1234;";
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    con.Open();

                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM subject", con);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    da.Fill(table);
                    dataGridView1.DataSource = table;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while fetching data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
