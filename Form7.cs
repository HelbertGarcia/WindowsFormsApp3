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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        public DataTable llenar_Factura()
        {
            Conexion.Conectar();
            DataTable dt = new DataTable();
            string consulta = "SELECT ID_Producto, Descripción, Cantidad, Subtotal FROM Detalle_Factura";
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtID_Producto.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtDescripción.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtCantidad.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txtprecio.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            }
            catch
            {

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.RemoveAt(row.Index);
            }

            txtMonto.Clear();

            double montoTotal = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                montoTotal += Convert.ToDouble(row.Cells["Subtotal"].Value);
            }


            txtMonto.Text = Convert.ToString(montoTotal);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();

            string insertar = "INSERT INTO Detalle_factura (ID_Factura, ID_Producto, Descripción, Cantidad, Subtotal) VALUES (@ID_Factura, @ID_Producto, @Descripción, @Cantidad, @Subtotal)";
            SqlCommand cmd1 = new SqlCommand(insertar, Conexion.Conectar());

            cmd1.Parameters.AddWithValue("@ID_Factura", txtID.Text);
            cmd1.Parameters.AddWithValue("@ID_Producto", txtID_Producto.Text);
            cmd1.Parameters.AddWithValue("@Descripción", txtDescripción.Text);
            cmd1.Parameters.AddWithValue("@Cantidad", txtCantidad.Text);
            cmd1.Parameters.AddWithValue("@Subtotal", txtprecio.Text);

            cmd1.ExecuteNonQuery();
            MessageBox.Show("Los datos fueron ingresados correctamente");

            double precio = Convert.ToDouble(txtprecio.Text);
            double cantidad = Convert.ToDouble(txtCantidad.Text);
            double Subtotal = precio * cantidad;
            double montoTotal = 0;

            dataGridView1.Rows.Add(txtID_Producto.Text, txtDescripción.Text, txtprecio.Text, txtCantidad.Text, Subtotal);




            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                montoTotal += Convert.ToDouble(row.Cells["Subtotal"].Value);
            }

            txtMonto.Text = Convert.ToString(montoTotal);

            txtID_Producto.Text = "";
            txtDescripción.Text = "";
            txtprecio.Text = "";
            txtCantidad.Text = "";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();

            string insersion = "INSERT INTO Factura (ID_Factura,ID_Cliente, ID_Empleado, Fecha, Estado, Monto_t) VALUES (@ID_Factura,@ID_Cliente, @ID_Empleado, @Fecha, @Estado, @Monto_t)";
            SqlCommand cmd2 = new SqlCommand(insersion, Conexion.Conectar());

            cmd2.Parameters.AddWithValue("@ID_Factura", txtID.Text);
            cmd2.Parameters.AddWithValue("@ID_Cliente", txtIDCliente.Text);
            cmd2.Parameters.AddWithValue("@ID_Empleado", txtIDEmpleado.Text);
            cmd2.Parameters.AddWithValue("@Fecha", dateTimePicker1.Value.Date);
            cmd2.Parameters.AddWithValue("@Estado", txtEstado.Text);
            cmd2.Parameters.AddWithValue("@Monto_t", txtMonto.Text);

            cmd2.ExecuteNonQuery();
            MessageBox.Show("Factura creada correctamente");
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string Monto = "Uptade Factura Set Monto_t=@Monto_t Where ID_Factura=@ID_Factura ";
            SqlCommand cmd4 = new SqlCommand(Monto, Conexion.Conectar());
            cmd4.Parameters.AddWithValue("@Monto_t", txtMonto.Text);

            string MontoT = "Select Monto_t from Factura ";
            SqlCommand cmd = new SqlCommand(MontoT, Conexion.Conectar());
            cmd.Parameters.AddWithValue("@Monto_t", txtMonto);
        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMonto.Text) || string.IsNullOrWhiteSpace(txtMonto.Text))
            {

            }
            else
            {
                double montoTotal = Convert.ToDouble(txtMonto.Text);
                double efectivo = Convert.ToDouble(txtEfectivo.Text);
                double devuelta = efectivo - montoTotal;

                txtDevuelta.Text = Convert.ToString(devuelta);

            }
        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Conexion.Conectar();
                DataTable dt = new DataTable();
                string consulta = "SELECT Nombre_Cliente, Apellidos, Teléfono FROM Cliente WHERE ID_Cliente=@ID_Cliente";
                SqlCommand cmd3 = new SqlCommand(consulta, Conexion.Conectar());
                cmd3.Parameters.AddWithValue("@ID_Cliente", txtIDCliente.Text);
                SqlDataReader reader = cmd3.ExecuteReader();

                if (reader.Read())
                {

                    txtNombre_Cliente.Text = reader["Nombre_Cliente"].ToString();
                    txtApellidoCliente.Text = reader["Apellidos"].ToString();
                    txtTeléfono.Text = reader["Teléfono"].ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Conexion.Conectar();
                DataTable dt = new DataTable();
                string consulta = "SELECT ID_Factura, Estado, Monto_t FROM Factura WHERE ID_Factura=@ID_Factura";
                SqlCommand cmd3 = new SqlCommand(consulta, Conexion.Conectar());
                cmd3.Parameters.AddWithValue("@ID_Factura", txtID.Text);
                SqlDataReader reader = cmd3.ExecuteReader();

                if (reader.Read())
                {

                    txtID.Text = reader["ID_Factura"].ToString();
                    txtEstado.Text = reader["Estado"].ToString();
                    txtMonto.Text = reader["Monto_t"].ToString();


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Conexion.Conectar();
                DataTable dt = new DataTable();
                string consulta = "SELECT ID_Producto, Descripción, Precio_P FROM Producto WHERE ID_Producto=@ID_Producto";
                SqlCommand cmd3 = new SqlCommand(consulta, Conexion.Conectar());
                cmd3.Parameters.AddWithValue("@ID_Producto", txtID_Producto.Text);
                SqlDataReader reader = cmd3.ExecuteReader();

                if (reader.Read())
                {

                    txtID_Producto.Text = reader["ID_Producto"].ToString();
                    txtDescripción.Text = reader["Descripción"].ToString();
                    txtprecio.Text = reader["Precio_P"].ToString();


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Conexion.Conectar();
                DataTable dt = new DataTable();
                string consulta = "SELECT Nombre FROM Empleado WHERE ID_Empleado=@ID_Empleado";
                SqlCommand cmd3 = new SqlCommand(consulta, Conexion.Conectar());
                cmd3.Parameters.AddWithValue("@ID_Empleado", txtIDEmpleado.Text);
                SqlDataReader reader = cmd3.ExecuteReader();

                if (reader.Read())
                {

                    txtNombre_Empleado.Text = reader["Nombre"].ToString();


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form7_Load(object sender, EventArgs e)
        {
            Conexion.Conectar();
        }
    }
}
