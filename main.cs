using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolManagementSystem
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        private void btnStudent_Click(object sender, EventArgs e)
        {
            Student student = new Student();
           student.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Subject subject = new Subject();
            subject.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Teacher teacher = new Teacher();
            teacher.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Section section = new Section();
            section.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Enrollment enrollment = new Enrollment();   
            enrollment.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Attendance attendance = new Attendance();
            attendance.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
        }
    }
}
