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
    public partial class Form3 : Form
    {
        public Form3()
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

        private void Form3_Load(object sender, EventArgs e)
        {
            Conexion.Conectar();


            dataGridView1.DataSource = llenar_Empleado();
        }
        public DataTable llenar_Empleado()
        {
            Conexion.Conectar();
            DataTable dt = new DataTable();
            string consulta = "SELECT * FROM Empleado";
            SqlCommand cmd = new SqlCommand(consulta, Conexion.Conectar());

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dt);
            return (dt);

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string insertar = "INSERT INTO Empleado (Cédula,Nombre,Apellidos,teléfono,Residencia,Domicilio,Cargo,Sueldo) VALUES (@Cédula,@Nombre,@Apellidos,@teléfono,@Residencia,@Domicilio,@Cargo,@Sueldo)";
            SqlCommand cmd1 = new SqlCommand(insertar, Conexion.Conectar());

            cmd1.Parameters.AddWithValue("@Cédula", txtCédula.Text);
            cmd1.Parameters.AddWithValue("@Nombre", txtNombre.Text);
            cmd1.Parameters.AddWithValue("@Apellidos", txtApellidos.Text);
            cmd1.Parameters.AddWithValue("@teléfono", txtTeléfono.Text);
            cmd1.Parameters.AddWithValue("@Residencia", txtResidencia.Text);
            cmd1.Parameters.AddWithValue("@Domicilio", txtDomicilio.Text);
            cmd1.Parameters.AddWithValue("@Cargo", txtCargo.Text);
            cmd1.Parameters.AddWithValue("@Sueldo", txtSueldo.Text);

            cmd1.ExecuteNonQuery();

            MessageBox.Show("Los datos fueron agregados correctamente");

            dataGridView1.DataSource = llenar_Empleado();

            txtEmpleado.Clear();
            txtCédula.Clear();
            txtNombre.Clear();
            txtApellidos.Clear();
            txtTeléfono.Clear();
            txtResidencia.Clear();
            txtDomicilio.Clear();
            txtCargo.Clear();
            txtSueldo.Clear();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string actualizar = "UPDATE Empleado SET Cédula=@Cédula, Nombre=@Nombre, Apellidos=@Apellidos, teléfono=@teléfono, Residencia=@Residencia, Domicilio=@Domicilio, Cargo=@Cargo, Sueldo=@Sueldo where Cédula=@Cédula";

            SqlCommand cmd2 = new SqlCommand(actualizar, Conexion.Conectar());

            cmd2.Parameters.AddWithValue("@Cédula", txtCédula.Text);
            cmd2.Parameters.AddWithValue("@Nombre", txtNombre.Text);
            cmd2.Parameters.AddWithValue("@Apellidos", txtApellidos.Text);
            cmd2.Parameters.AddWithValue("@teléfono", txtTeléfono.Text);
            cmd2.Parameters.AddWithValue("@Residencia", txtResidencia.Text);
            cmd2.Parameters.AddWithValue("@Domicilio", txtDomicilio.Text);
            cmd2.Parameters.AddWithValue("@Cargo", txtCargo.Text);
            cmd2.Parameters.AddWithValue("@Sueldo", txtSueldo.Text);

            cmd2.ExecuteNonQuery();

            MessageBox.Show("Los datos fueron actualizados correctamente");
            dataGridView1.DataSource = llenar_Empleado();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();

            string eliminar = "DELETE FROM Empleado WHERE Cédula=@Cédula";
            SqlCommand cmd3 = new SqlCommand(eliminar, Conexion.Conectar());
            cmd3.Parameters.AddWithValue("@Cédula", txtCédula.Text);

            cmd3.ExecuteNonQuery();

            MessageBox.Show("Los datos fueron eliminados correctamente");

            dataGridView1.DataSource = llenar_Empleado();

            txtEmpleado.Clear();
            txtCédula.Clear();
            txtNombre.Clear();
            txtApellidos.Clear();
            txtTeléfono.Clear();
            txtResidencia.Clear();
            txtDomicilio.Clear();
            txtCargo.Clear();
            txtSueldo.Clear();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           try
            {
                txtEmpleado.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtCédula.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtNombre.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txtApellidos.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                txtTeléfono.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                txtResidencia.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                txtDomicilio.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                txtCargo.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                txtSueldo.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            }
            catch
            {

            }
        }
    }
}
