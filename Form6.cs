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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtID_Producto.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtID_Proveedor.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtPrecio.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txtMarca.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                txtClase.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                txtDescripción.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                txtExistencia.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();

            }
            catch
            {

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string insertar = "INSERT INTO Producto (ID_Proveedor, Precio_P, Marca, Clase, Descripción, Existencia, Fecha_V) VALUES (@ID_Proveedor, @Precio_P, @Marca, @Clase, @Descripción, @Existencia, @Fecha_V)";
            SqlCommand cmd1 = new SqlCommand(insertar, Conexion.Conectar());

            cmd1.Parameters.AddWithValue("@ID_Proveedor", txtID_Proveedor.Text);
            cmd1.Parameters.AddWithValue("@Precio_P", txtPrecio.Text);
            cmd1.Parameters.AddWithValue("@Marca", txtMarca.Text);
            cmd1.Parameters.AddWithValue("@Clase", txtClase.Text);
            cmd1.Parameters.AddWithValue("@Descripción", txtDescripción.Text);
            cmd1.Parameters.AddWithValue("@Existencia", txtExistencia.Text);
            cmd1.Parameters.AddWithValue("@Fecha_V", txtFecha_V.Value.Date);

            cmd1.ExecuteNonQuery();
            MessageBox.Show("Los datos fueron agregados correctamente");

            dataGridView1.DataSource = llenar_Producto();

            txtID_Producto.Clear();
            txtID_Proveedor.Clear();
            txtPrecio.Clear();
            txtMarca.Clear();
            txtClase.Clear();
            txtDescripción.Clear();
            txtExistencia.Clear();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();

            string actualizar = "UPDATE Producto SET ID_Proveedor=@ID_Proveedor, Precio_P=@Precio_P, Marca=@Marca, Clase=@Clase, Descripción=@Descripción, Existencia=@Existencia, Fecha_V=@Fecha_V Where ID_Producto = @ID_Producto";

            SqlCommand cmd2 = new SqlCommand(actualizar, Conexion.Conectar());

            cmd2.Parameters.AddWithValue("@ID_Producto", txtID_Producto.Text);
            cmd2.Parameters.AddWithValue("@ID_Proveedor", txtID_Proveedor.Text);
            cmd2.Parameters.AddWithValue("@Precio_P", txtPrecio.Text);
            cmd2.Parameters.AddWithValue("@Marca", txtMarca.Text);
            cmd2.Parameters.AddWithValue("@Clase", txtClase.Text);
            cmd2.Parameters.AddWithValue("@Descripción", txtDescripción.Text);
            cmd2.Parameters.AddWithValue("@Existencia", txtExistencia.Text);
            cmd2.Parameters.AddWithValue("@Fecha_V", txtFecha_V.Value.Date);

            cmd2.ExecuteNonQuery();

            MessageBox.Show("Los datos fueron actualizados correctamente");

            dataGridView1.DataSource = llenar_Producto();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();

            string eliminar = "DELETE FROM Producto WHERE ID_Producto=@ID_Producto";
            SqlCommand cmd3 = new SqlCommand(eliminar, Conexion.Conectar());
            cmd3.Parameters.AddWithValue("@ID_Producto", txtID_Producto.Text);

            cmd3.ExecuteNonQuery();
            MessageBox.Show("Los datos fueron deshabilitados correctamente");

            dataGridView1.DataSource = llenar_Producto();

            txtID_Producto.Clear();
            txtID_Proveedor.Clear();
            txtPrecio.Clear();
            txtMarca.Clear();
            txtClase.Clear();
            txtDescripción.Clear();
            txtExistencia.Clear();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            Conexion.Conectar();


            dataGridView1.DataSource = llenar_Producto();
        }
        public DataTable llenar_Producto()
        {
            Conexion.Conectar();
            DataTable dt = new DataTable();
            string consulta = "SELECT * FROM Producto";
            SqlCommand cmd = new SqlCommand(consulta, Conexion.Conectar());

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dt);
            return (dt);

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
