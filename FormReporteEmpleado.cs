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
    public partial class FormReporteEmpleado : Form
    {
        public FormReporteEmpleado()
        {
            InitializeComponent();
        }

        private void FormReporteEmpleado_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'proyectoDataSet.Empleado' Puede moverla o quitarla según sea necesario.
            this.EmpleadoTableAdapter.Fill(this.proyectoDataSet.Empleado);

            this.reportViewer1.RefreshReport();
        }
    }
}
