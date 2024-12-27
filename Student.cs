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
    public partial class Student : Form
    {
        public Student()
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

                    string query = "INSERT INTO students (id, Name, Dob, Gender, Phone, Email) VALUES (@id, @Name, @Dob, @Gender, @Phone, @Email)";
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id", int.Parse(txtId.Text));
                        cmd.Parameters.AddWithValue("@Name", txtName.Text);
                        cmd.Parameters.AddWithValue("@Dob", dateTimePicker1.Value);
                        cmd.Parameters.AddWithValue("@Gender", texGender.Text);
                        cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                        cmd.Parameters.AddWithValue("@Email", txtemail.Text);

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
        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
        }

        private void DateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            dateTimePicker1.CustomFormat = "";
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=localhost;Database=school_db;Uid=root;Pwd=1234;";
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM students", con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable table = new DataTable();
                da.Fill(table);

                dataGridView1.DataSource = table;
            }
        }

        private void Student_Load(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "Server=localhost;Database=school_db;Uid=root;Pwd=1234;";
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    con.Open();

                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM students", con);
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

        private void BtnUpdate_Click_1(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection con = new MySqlConnection("Server=localhost;Database=school_db;Uid=root;Pwd=1234");
                con.Open();

                MySqlCommand cmd = new MySqlCommand("UPDATE students SET Name=@Name, Dob=@Dob, Gender=@Gender, Phone=@Phone, Email=@Email WHERE id=@id", con);
                cmd.Parameters.AddWithValue("@Name", txtName.Text);
                cmd.Parameters.AddWithValue("@Dob", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@Gender", texGender.Text);
                cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                cmd.Parameters.AddWithValue("@Email", txtemail.Text);
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

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("Server=localhost;Database=school_db;Uid=root;Pwd=1234");
            con.Open();

            MySqlCommand cmd = new MySqlCommand("DELETE FROM students WHERE id=@id", con);
            cmd.Parameters.AddWithValue("@id", int.Parse(txtId.Text));

            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Record deleted successfully", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtName.Text = "";
            texGender.Text = "";
            txtPhone.Text = "";
            txtemail.Text = "";
        }

        private void BtnDisplay_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "Server=localhost;Database=school_db;Uid=root;Pwd=1234;";
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    con.Open();

                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM students", con);
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




        