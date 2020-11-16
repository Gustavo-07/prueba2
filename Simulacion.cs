using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BackpropagationAndPerceptron
{
    public partial class Simulacion : Form
    {
        int entradas, salidas;
        List<string> registros;
        float[,] pesos;
        float[] umbrales;
        bool bandera;
        public Simulacion()
        {
            InitializeComponent();

            entradas=10;
            salidas=1;
            registros= new List<string>();
            pesos = new float[salidas, entradas];
            umbrales = new float[salidas];
            bandera = bandera;
            grillaMatrizPesos.Enabled = false;
            grillaVectorUmbrales.Enabled = false;

            //Definicion de entradas y salidas, creacion y llenado de grilla.
            for (int i = 0; i < entradas; i++)
            {
                string titulo = "Xr" + (i + 1);
                //grilladedatos.Columns.Add("Xr", titulo);
                grillaSimulacion.Columns.Add("Xr", titulo);
            }
            DataGridViewButtonColumn btnAccion = new DataGridViewButtonColumn();
            grillaSimulacion.Columns.Add(btnAccion);
            btnAccion.Name = "btnAccion";
            btnAccion.HeaderText = "Accion";
            for (int i = 0; i < salidas; i++)
            {
                string titulo = "Yr" + (i + 1);

                grillaSimulacion.Columns.Add("Yr", titulo);
            }
            foreach (string registro in registros)

                grillaSimulacion.Rows.Add();
            grillaSimulacion.Rows[0].Cells[entradas].Value = "Simular Salida";
            grillaSimulacion.Rows[0].Height = 25;

            grillaSimulacion.AllowUserToAddRows = false;
            //Creacion y llenado de grilla de pesos y umbrales...
            for (int i = 0; i < entradas; i++)
            {
                string _titulo = "Wji" + (i + 1).ToString();
                grillaMatrizPesos.Columns.Add("Wji", _titulo);
            }
            string titul = "Ui" + (1);
            grillaVectorUmbrales.Columns.Add("Ui", titul);
            grillaMatrizPesos.AllowUserToAddRows = false;
            grillaVectorUmbrales.AllowUserToAddRows = false;
        }

        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VentanaPrincipal ventanaPrincipal = new VentanaPrincipal();
            ventanaPrincipal.Show();
            this.Hide();
        }

        private void ayudaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void BtnCargarUmbrales_Click(object sender, EventArgs e)
        {
            grillaVectorUmbrales.Rows.Clear();
         
           
            
            OpenFileDialog ventana = new OpenFileDialog();
            if (ventana.ShowDialog() == DialogResult.OK)
            {
                string rutadoc = ventana.FileName;//Obtenemos la ruta del archivo.
                TextReader sr = new StreamReader(File.OpenRead(rutadoc));//Leeremos el archivo.
                string registro;
                while ((registro = sr.ReadLine()) != null)
                {
                    grillaVectorUmbrales.Rows.Add(registro);
                }
                sr.Close();
                for (int i = 0; i < salidas; i++)
                {
                    umbrales[i] = float.Parse(grillaVectorUmbrales.Rows[i].Cells[0].Value.ToString());
                }
            }
        }

        private void BtnCargarPesos_Click(object sender, EventArgs e)
        {
            grillaMatrizPesos.Rows.Clear();
           
            OpenFileDialog ventana = new OpenFileDialog();
            if (ventana.ShowDialog() == DialogResult.OK)
            {
                string rutadoc = ventana.FileName;//Obtenemos la ruta del archivo.
                TextReader sr2 = new StreamReader(File.OpenRead(rutadoc));//Leeremos el archivo.
                string registro;
                while ((registro = sr2.ReadLine()) != null)
                {
                    string[] array = registro.Split(' ');
                    grillaMatrizPesos.Rows.Add(registro.Split(' '));
                }
                sr2.Close();
                for (int i = 0; i < salidas; i++)
                {
                    for (int j = 0; j < entradas; j++)
                    {
                        pesos[i, j] = float.Parse(grillaMatrizPesos.Rows[i].Cells[j].Value.ToString());
                    }
                }
            }
        }

        private void grillaSimulacion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grillaSimulacion.Columns[e.ColumnIndex].Name.Equals("btnAccion"))
            {
                for (int i = 0; i < grillaSimulacion.Rows.Count; i++)
                {
                    if (e.RowIndex == i)
                    {
                        Simular();
                    }
                }
            }
        }



        private void Simular()
        {
            Dictionary<int, float[,]> diccionariodelassalidasdecapa = new Dictionary<int, float[,]>();
            int pt = 2;
            float[,] arraydematrizdepesos;
            float[] arraydeumbrales;
            float[,] arraydesalidadelacapaanterior = null;
            float[,] arraydesalidadelacapaactual = null;

            for (int i = (entradas + 1); i <= (salidas + entradas); i++)
            {
                grillaSimulacion.Rows[0].Cells[i].Value = 0;
                
            }
        }


        private void BtnCargarRed_Click(object sender, EventArgs e)
        {
           
        }
    }
}
