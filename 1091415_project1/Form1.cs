using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1091415_project1
{
    public partial class Form1 : Form
    {
        C1091415_CarEntities db = new C1091415_CarEntities();

        public Form1()
        {
            InitializeComponent();
            displayInfo();
        }

        private void btnAdd_Click (object sender, EventArgs e)
        {
            var form = new AddForm();

            form.Show(); //Showing AddForm
            this.Hide(); //Hidden MainForm (Form1)
        }

        private void displayInfo()
        {
            var info2 = db.CarTable.ToList();
            dgvInfo.DataSource = info2;
        }

    }
}
