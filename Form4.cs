using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp3
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 frm = new Form3();
            frm.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 frm = new Form4();
            frm.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form5 frm = new Form5();
            frm.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form6 frm = new Form6();
            frm.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form7 frm = new Form7();
            frm.Show();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form8 frm = new Form8();
            frm.Show();
            this.Close();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            Conexion.Conectar();


            dataGridView1.DataSource = llenar_Cliente();
        }

        public DataTable llenar_Cliente()
        {
            Conexion.Conectar();
            DataTable dt = new DataTable();
            string consulta = "SELECT * FROM Cliente";
            SqlCommand cmd = new SqlCommand(consulta, Conexion.Conectar());

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dt);
            return (dt);

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string insertar = "INSERT INTO Cliente (Nombre_Cliente,Apellidos,Cédula,Teléfono,Residencia,Domicilio,Fecha_Del_Registro) VALUES (@Nombre_Cliente,@Apellidos,@Cédula,@Teléfono,@Residencia,@Domicilio,@Fecha_Del_Registro)";
            SqlCommand cmd1 = new SqlCommand(insertar, Conexion.Conectar());

            cmd1.Parameters.AddWithValue("@Nombre_Cliente", txtNombre.Text);
            cmd1.Parameters.AddWithValue("@Apellidos", txtApellidos.Text);
            cmd1.Parameters.AddWithValue("@Cédula", txtCédula.Text);
            cmd1.Parameters.AddWithValue("@Teléfono", txtTeléfono.Text);
            cmd1.Parameters.AddWithValue("@Residencia", txtResidencia.Text);
            cmd1.Parameters.AddWithValue("Domicilio", txtDomicilio.Text);
            cmd1.Parameters.AddWithValue("Fecha_Del_Registro", txtFecha_Del_Registro.Value.Date);

            cmd1.ExecuteNonQuery();

            MessageBox.Show("Los datos fueron agregados correctamente");

            dataGridView1.DataSource = llenar_Cliente();

            txtCliente.Clear();
            txtNombre.Clear();
            txtApellidos.Clear();
            txtCédula.Clear();
            txtTeléfono.Clear();
            txtResidencia.Clear();
            txtDomicilio.Clear();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();

            string actualizar = "UPDATE Cliente SET Nombre_Cliente=@Nombre_Cliente, Apellidos=@Apellidos, Cédula=@Cédula, Teléfono=@Teléfono, Residencia=@Residencia, Domicilio=@Domicilio, Fecha_Del_Registro=@Fecha_Del_Registro where Cédula = @Cédula";

            SqlCommand cmd2 = new SqlCommand(actualizar, Conexion.Conectar());

            cmd2.Parameters.AddWithValue("@Nombre_Cliente", txtNombre.Text);
            cmd2.Parameters.AddWithValue("@Apellidos", txtApellidos.Text);
            cmd2.Parameters.AddWithValue("@Cédula", txtCédula.Text);
            cmd2.Parameters.AddWithValue("@Teléfono", txtTeléfono.Text);
            cmd2.Parameters.AddWithValue("@Residencia", txtResidencia.Text);
            cmd2.Parameters.AddWithValue("@Domicilio", txtDomicilio.Text);
            cmd2.Parameters.AddWithValue("@Fecha_Del_Registro", txtFecha_Del_Registro.Value.Date);

            cmd2.ExecuteNonQuery();

            MessageBox.Show("Los datos fueron actualizados correctamente");
            dataGridView1.DataSource = llenar_Cliente();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();

            string eliminar = "DELETE FROM Cliente WHERE Cédula=@Cédula";
            SqlCommand cmd3 = new SqlCommand(eliminar, Conexion.Conectar());
            cmd3.Parameters.AddWithValue("@Cédula", txtCédula.Text);

            cmd3.ExecuteNonQuery();

            MessageBox.Show("Los datos fueron deshabilitados correctamente");

            dataGridView1.DataSource = llenar_Cliente();

            txtCliente.Clear();
            txtNombre.Clear();
            txtApellidos.Clear();
            txtCédula.Clear();
            txtTeléfono.Clear();
            txtResidencia.Clear();
            txtDomicilio.Clear();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtCliente.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtNombre.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtApellidos.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txtCédula.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                txtTeléfono.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                txtResidencia.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                txtDomicilio.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();


            }
            catch
            {

            }
        }
    }
}
