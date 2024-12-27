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
    public partial class Enrollment : Form
    {
        public Enrollment()
        {
            InitializeComponent();
        }
        private void Enrollment_Load(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "Server=localhost;Database=school_db;Uid=root;Pwd=1234;";
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    con.Open();

                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM enrollment", con);
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
        private void btnSave_Click_1(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "Server=localhost;Database=school_db;Uid=root;Pwd=1234;";

                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    con.Open();

                    string query = "INSERT INTO enrollment (id, name,section, dob) VALUES (@id, @name, @section, @dob)";
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id", int.Parse(txtId.Text));
                        cmd.Parameters.AddWithValue("@name", txtName.Text);
                        cmd.Parameters.AddWithValue("@section", texSection.Text);
                        cmd.Parameters.AddWithValue("@dob", dateTimePicker1.Value);


                        cmd.ExecuteNonQuery();
                    }

                    con.Close();
                }

                MessageBox.Show("Record saved successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            string connectionString = "Server=localhost;Database=school_db;Uid=root;Pwd=1234;";
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM enrollment", con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable table = new DataTable();
                da.Fill(table);

                dataGridView1.DataSource = table;
            }
        }
        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection con = new MySqlConnection("Server=localhost;Database=school_db;Uid=root;Pwd=1234");
                con.Open();

                MySqlCommand cmd = new MySqlCommand("UPDATE enrollment SET name=@name,section=@section, dob=@dob WHERE id=@id", con);
                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@section", texSection.Text);
                cmd.Parameters.AddWithValue("@dob", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@id", int.Parse(txtId.Text));

                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Record updated successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("Server=localhost;Database=school_db;Uid=root;Pwd=1234");
            con.Open();

            if (int.TryParse(txtId.Text, out int id))
            {
                MySqlCommand cmd = new MySqlCommand("DELETE FROM enrollment WHERE id=@id", con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Record deleted successfully", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please enter a valid ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtName.Text = "";
            texSection.Text = "";
        }
        private void btnDisplay_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "Server=localhost;Database=school_db;Uid=root;Pwd=1234;";
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    con.Open();

                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM enrollment", con);
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
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)

        {
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
        }
        private void dateTimePicker1_KeyDown_1(object sender, KeyEventArgs e)
        {
            dateTimePicker1.CustomFormat = "";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}








        