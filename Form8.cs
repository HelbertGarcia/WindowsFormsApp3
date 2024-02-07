using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void Form8_Load(object sender, EventArgs e)
        {

         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormReporteEmpleado Form8 = new FormReporteEmpleado();
            Form8.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormReporteCliente Form8 = new FormReporteCliente();
            Form8.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormReporteProveedor Form8 = new FormReporteProveedor();
            Form8.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormReporteProducto Form8 = new FormReporteProducto();
            Form8.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form Form8 = new Form2();
            Form8.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            FormRangoFecha Form8 = new FormRangoFecha();
            Form8.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ProductosVencidos Form8 = new ProductosVencidos();
            Form8.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Ganancias Form8 = new Ganancias();
            Form8.ShowDialog();
        }
    }
}
