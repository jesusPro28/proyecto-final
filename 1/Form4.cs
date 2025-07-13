using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _1
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            this.BackColor = ColorTranslator.FromHtml("#335B7F");
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            comboBoxelegir.Items.Add("AGREGAR");
            comboBoxelegir.Items.Add("MODIFICAR");
            comboBoxelegir.Items.Add("REPORTES");

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            string seleccion = comboBoxelegir.SelectedItem?.ToString();

            if (seleccion == null)
            {
                MessageBox.Show("Por favor selecciona una opción.");
                return;
            }

            Form nuevoForm = null;

            switch (seleccion)
            {
                case "Abrir FormA":
                    nuevoForm = new Form5();
                    break;
                case "Abrir FormB":
                    nuevoForm = new Form7();
                    break;
                case "Abrir FormC":
                    nuevoForm = new Form9();
                    break;
            }

            if (nuevoForm != null)
            {
                nuevoForm.Show();
                this.Close(); // Cierra el formulario actual
            }
        }
    }
}
