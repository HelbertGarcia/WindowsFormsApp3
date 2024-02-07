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
    public partial class FormReporteProducto : Form
    {
        public FormReporteProducto()
        {
            InitializeComponent();
        }

        private void FormReporteProducto_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'proyectoDataSet3.Producto' Puede moverla o quitarla según sea necesario.
            this.ProductoTableAdapter.Fill(this.proyectoDataSet3.Producto);

            this.reportViewer1.RefreshReport();
        }
    }
}
