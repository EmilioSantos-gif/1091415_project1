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
    public partial class AddForm : Form
    {
        C1091415_CarEntities db = new C1091415_CarEntities();
        public AddForm()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            guardar();
        }

        private void guardar()
        {
            var carro = new CarTable
            {
                ID = Guid.NewGuid(),
                Marca = txtMarca.Text,
                Modelo = txtModelo.Text,
                Year = Int16.Parse(txtYear.Text),
                Uso = txtUse.Text
            };


            db.CarTable.Add(carro);

            bool added = db.SaveChanges() > 0;

            if (added)
            {
                MessageBox.Show($"El auto {carro.Marca} modelo {carro.Modelo} ha sido agregado satisfactoriamente");
                ClearForm();
            }

        }

        private void ClearForm()
        {
            txtMarca.Text = string.Empty;
            txtModelo.Text = string.Empty;
            txtYear.Text = string.Empty;
            txtUse.Text = string.Empty;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var form = new Form1();
            form.Show();
            this.Close();
        }
    }
}
