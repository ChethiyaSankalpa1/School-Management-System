using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SchoolManagementSystem
{
    public partial class Teacher : Form
    {
        public Teacher()
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

                    string query = "INSERT INTO teacher (id, name, gender, phone) VALUES (@id, @name, @gender, @phone)";
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id", int.Parse(txtId.Text));
                        cmd.Parameters.AddWithValue("@name", txtName.Text);
                        cmd.Parameters.AddWithValue("@gender", texGender.Text);
                        cmd.Parameters.AddWithValue("@phone", txtPhone.Text);

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

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM teacher", con);
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

                    MySqlCommand cmd = new MySqlCommand("UPDATE teacher SET name = @name, gender = @gender, phone = @phone WHERE id = @id", con);
                    cmd.Parameters.AddWithValue("@name", txtName.Text);
                    cmd.Parameters.AddWithValue("@gender", texGender.Text);
                    cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
                    cmd.Parameters.AddWithValue("@id", int.Parse(txtId.Text));

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

                    MySqlCommand cmd = new MySqlCommand("DELETE FROM teacher WHERE id = @id", con);
                    cmd.Parameters.AddWithValue("@id", int.Parse(txtId.Text));

                    cmd.ExecuteNonQuery();
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
            texGender.Text = "";
            txtPhone.Text = "";
        }
        private void btnDisplay_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "Server=localhost;Database=school_db;Uid=root;Pwd=1234;";

                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    con.Open();

                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM teacher", con);
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
        private void Teacher_Load(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "Server=localhost;Database=school_db;Uid=root;Pwd=1234;";

                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    con.Open();

                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM teacher", con);
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