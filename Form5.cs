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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();

            string insertar = "INSERT INTO Proveedor (Nombre_Proveedor, Teléfono_Proveedor, Dirección_Proveedor, Correo_Proveedor) Values (@Nombre_Proveedor, @Teléfono_Proveedor, @Dirección_Proveedor, @Correo_Proveedor)";
            SqlCommand cmd1 = new SqlCommand(insertar, Conexion.Conectar());

            cmd1.Parameters.AddWithValue("@ID_Proveedor", txtID_Proveedor.Text);
            cmd1.Parameters.AddWithValue("@Nombre_Proveedor", txtNombre.Text);
            cmd1.Parameters.AddWithValue("@Teléfono_Proveedor", txtTeléfono.Text);
            cmd1.Parameters.AddWithValue("@Dirección_Proveedor", txtDirección.Text);
            cmd1.Parameters.AddWithValue("@Correo_Proveedor", txtCorreo.Text);

            cmd1.ExecuteNonQuery();
            MessageBox.Show("Los datos fueron insertados correctamente");

            dataGridView1.DataSource = llenar_Proveedor();

            txtID_Proveedor.Clear();
            txtNombre.Clear();
            txtTeléfono.Clear();
            txtDirección.Clear();
            txtCorreo.Clear();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();

            string actualizar = "UPDATE Proveedor SET Nombre_Proveedor=@Nombre_Proveedor, Teléfono_Proveedor=@Teléfono_Proveedor, Dirección_Proveedor=@Dirección_Proveedor, Correo_Proveedor=@Correo_Proveedor WHERE Nombre_Proveedor=@Nombre_Proveedor";
            SqlCommand cmd2 = new SqlCommand(actualizar, Conexion.Conectar());

           
            cmd2.Parameters.AddWithValue("@Nombre_Proveedor", txtNombre.Text);
            cmd2.Parameters.AddWithValue("@Teléfono_Proveedor", txtTeléfono.Text);
            cmd2.Parameters.AddWithValue("@Dirección_Proveedor", txtDirección.Text);
            cmd2.Parameters.AddWithValue("@Correo_Proveedor", txtCorreo.Text);

            cmd2.ExecuteNonQuery();
            MessageBox.Show("Los datos fueron actualizados correctamente");

            dataGridView1.DataSource = llenar_Proveedor();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string eliminar = "DELETE FROM Proveedor WHERE ID_Proveedor=@ID_Proveedor";
            SqlCommand cmd3 = new SqlCommand(eliminar, Conexion.Conectar());

            cmd3.Parameters.AddWithValue("ID_Proveedor", txtID_Proveedor.Text);
            cmd3.ExecuteNonQuery();

            MessageBox.Show("Los datos fueorn deshabilitados correctamente");
            dataGridView1.DataSource = llenar_Proveedor();

            txtID_Proveedor.Clear();
            txtNombre.Clear();
            txtTeléfono.Clear();
            txtDirección.Clear();
            txtCorreo.Clear();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            Conexion.Conectar();


            dataGridView1.DataSource = llenar_Proveedor();
        }
        public DataTable llenar_Proveedor()
        {
            Conexion.Conectar();
            DataTable dt = new DataTable();
            string consulta = "SELECT * FROM Proveedor";
            SqlCommand cmd = new SqlCommand(consulta, Conexion.Conectar());

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dt);
            return (dt);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtID_Proveedor.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtNombre.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtTeléfono.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txtDirección.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                txtCorreo.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();



            }
            catch
            {

            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

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

    }
}
