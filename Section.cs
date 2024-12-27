using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SchoolManagementSystem
{
    public partial class Section : Form
    {
        public Section()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "Server=localhost;Database=school_db;Uid=root;Pwd=1234;";

                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    con.Open();

                    string query = "INSERT INTO section (id, subject_name,section) VALUES (@id, @subject_name, @section)";
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id", int.Parse(txtId.Text));
                        cmd.Parameters.AddWithValue("@subject_name", txtName.Text);
                        cmd.Parameters.AddWithValue("@section", texsection.Text);
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=localhost;Database=school_db;Uid=root;Pwd=1234;";
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM section", con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable table = new DataTable();
                da.Fill(table);

                dataGridView1.DataSource = table;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "Server=localhost;Database=school_db;Uid=root;Pwd=1234;";

                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    con.Open();

                    MySqlCommand cmd = new MySqlCommand("UPDATE section SET Name = @subject_name, section = @section  WHERE id = @id", con);
                    cmd.Parameters.AddWithValue("@subject_name", txtName.Text);
                    cmd.Parameters.AddWithValue("@section",texsection.Text);
                    cmd.Parameters.AddWithValue("@id",int.Parse(txtId.Text));

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Record updated successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "Server=localhost;Database=school_db;Uid=root;Pwd=1234;";
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    con.Open();

                    MySqlCommand cmd = new MySqlCommand("DELETE FROM section WHERE id = @id", con);
                    cmd.Parameters.AddWithValue("@id", int.Parse(txtId.Text.Trim()));

                    cmd.ExecuteNonQuery();
                    con.Close();
                }

                MessageBox.Show("Record deleted successfully", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtName.Text = "";
            texsection.Text = "";
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "Server=localhost;Database=school_db;Uid=root;Pwd=1234;";
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    con.Open();

                    string query = "SELECT * FROM section";
                    MySqlCommand cmd = new MySqlCommand(query, con);
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

        private void Section_Load(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "Server=localhost;Database=school_db;Uid=root;Pwd=1234;";
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    con.Open();

                    string query = "SELECT * FROM section";
                    MySqlCommand cmd = new MySqlCommand(query, con);
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
