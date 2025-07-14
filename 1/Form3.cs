using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            this.BackColor = ColorTranslator.FromHtml("#335B7F");
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Form1 nuevoFormulario = new Form1(); // Instanciar el nuevo form
            nuevoFormulario.Show();              // Mostrar el nuevo form
            this.Close();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            string conexionString = "Server=TU_SERVIDOR;Database=sistema de registro de asistencia de personal;Trusted_Connection=True;";
            string passwordIngresada = txtPass.Text;

            using (SqlConnection conexion = new SqlConnection(conexionString))
            {
                try
                {
                    conexion.Open();

                    string consulta = "SELECT COUNT(*) FROM administrador WHERE Password = @password";
                    SqlCommand comando = new SqlCommand(consulta, conexion);
                    comando.Parameters.AddWithValue("@password", passwordIngresada);

                    int resultado = (int)comando.ExecuteScalar();

                    if (resultado > 0)
                    {
                        MessageBox.Show("Acceso correcto", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Abre el nuevo formulario
                        Form4 nuevoForm = new Form4();
                        nuevoForm.Show();

                        // Cierra el formulario actual
                        this.Hide(); // o this.Close(); si no necesitas mantenerlo en memoria
                    }
                    else
                    {
                        MessageBox.Show("Contraseña incorrecta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al conectar con la base de datos: " + ex.Message);
                }
                finally
                {
                    // La conexión se cierra automáticamente al salir del bloque using
                }
            }
        }
    }
}
