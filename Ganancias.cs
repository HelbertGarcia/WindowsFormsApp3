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
    public partial class Ganancias : Form
    {
        public Ganancias()
        {
            InitializeComponent();
        }

        public DateTime Fecha1 { get; set; }

        public DateTime Fecha2 { get; set; }
        private void Ganancias_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DataSetAgregarFecha.Ganancias' Puede moverla o quitarla según sea necesario.
            this.GananciasTableAdapter.Fill(this.DataSetAgregarFecha.Ganancias,Fecha1,Fecha2);

            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime Fecha1 = dateTimePicker1.Value;
            DateTime Fecha2 = dateTimePicker2.Value;
            this.GananciasTableAdapter.Fill(this.DataSetAgregarFecha.Ganancias, Fecha1, Fecha2);
            this.reportViewer1.RefreshReport();
        }
    }
}
