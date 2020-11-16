using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BackpropagationAndPerceptron
{
    public partial class VentanaPrincipal : Form
    {
        public VentanaPrincipal()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void BtnEntrenar_Click(object sender, EventArgs e)
        {
            Entrenamiento entrenamiento = new Entrenamiento();
            entrenamiento.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void BtnSimular_Click(object sender, EventArgs e)
        {
            Simulacion simulacion = new Simulacion();
            simulacion.Show();
            this.Hide();
        }
    }
}
