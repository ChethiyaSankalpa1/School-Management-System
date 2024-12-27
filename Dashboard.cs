using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SchoolManagementSystem
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            display();
            display1();
            display2();
            display3();
        }

        private void display()
        {
            try
            {
                string connectionString = "Server=localhost;Database=school_db;Uid=root;Pwd=1234;";
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    con.Open();

                    MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM students", con);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    if (count > 0)
                    {
                        lblCount.Text = count.ToString();
                    }
                    else
                    {
                        lblCount.Text = "0";
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void display1()
        {
            try
            {
                string connectionString = "Server=localhost;Database=school_db;Uid=root;Pwd=1234;";
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    con.Open();

                    MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM subject", con);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    if (count > 0)
                    {
                        lblCount1.Text = count.ToString();
                    }
                    else
                    {
                        lblCount1.Text = "0";
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void display2()
        {
            try
            {
                string connectionString = "Server=localhost;Database=school_db;Uid=root;Pwd=1234;";
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    con.Open();

                    MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM teacher", con);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    if (count > 0)
                    {
                        lblCount2.Text = count.ToString();
                    }
                    else
                    {
                        lblCount2.Text = "0";
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void display3()
        {
            try
            {
                string connectionString = "Server=localhost;Database=school_db;Uid=root;Pwd=1234;";
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    con.Open();

                    MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM enrollment", con);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    if (count > 0)
                    {
                        lblCount3.Text = count.ToString();
                    }
                    else
                    {
                        lblCount3.Text = "0";
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
