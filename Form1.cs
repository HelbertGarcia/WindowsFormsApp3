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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            try

            {  
            
            string usuario = textBox2.Text;
            string contraseña = textBox3.Text;

            if (usuario == "Susana"  & contraseña == "12345")
            {
                Form Form1 = new Form2();
                Form1.Show();
                this.Hide();
            }

            else 

            {
                MessageBox.Show("error en usuario o contraseña");
            }

            }

            catch (Exception ex)

            { MessageBox.Show(ex.Message);

            }

        }

    }
}
