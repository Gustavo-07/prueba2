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
    public partial class SimulacionInterna : Form
    {
        string funcionsalida;
        int patrones;
        int entradas;
        int salidas;
        int capasocultas;
        float[,] arraydeentradasdelared;
        float[,] arraydesalidasdeseadas;
        Dictionary<int, float[,]> diccionariodearraydematrizdepesos;
        Dictionary<int, float[]> diccionariodearraydeumbrales;
        DataGridView grilladecapasocultas;
        public SimulacionInterna(int entradas, int salidas, int patrones, float[,] arraydeentradasdelared, float[,] arraydesalidasdeseadas,
                     Dictionary<int, float[,]> diccionariodearraydematrizdepesos, Dictionary<int, float[]> diccionariodearraydeumbrales,
                     int capasocultas, DataGridView grilladecapasocultas, string funcionsalida)
        {
            InitializeComponent();

            this.entradas = entradas;
            this.salidas = salidas;
            this.patrones = patrones;
            this.capasocultas = capasocultas;
            this.arraydeentradasdelared = arraydeentradasdelared;
            this.arraydesalidasdeseadas = arraydesalidasdeseadas;
            this.diccionariodearraydematrizdepesos = diccionariodearraydematrizdepesos;
            this.diccionariodearraydeumbrales = diccionariodearraydeumbrales;
            this.grilladecapasocultas = grilladecapasocultas;
            this.funcionsalida = funcionsalida;
            //Definicion de entradas y salidas, creacion y llenado de grilla.
            for (int i = 0; i < entradas; i++)
            {
                string titulo = "Xr" + (i + 1);
                grilladedatos.Columns.Add("Xr", titulo);
                grilladesimulacion.Columns.Add("Xr", titulo);
            }
            DataGridViewButtonColumn btnAccion = new DataGridViewButtonColumn();
            grilladesimulacion.Columns.Add(btnAccion);
            btnAccion.Name = "btnAccion";
            btnAccion.HeaderText = "Accion";
            for (int i = 0; i < salidas; i++)
            {
                string titulo = "Yr" + (i + 1);
                grilladedatos.Columns.Add("Yr", titulo);
                grilladesimulacion.Columns.Add("Yr", titulo);
            }
            for (int i = 0; i < 1; i++)
            {
                grilladedatos.Rows.Add();
                grilladesimulacion.Rows.Add();
                for (int j = 0; j < entradas + salidas; j++)
                {
                    if (j < entradas)
                    {
                        grilladedatos.Rows[i].Cells[j].Value = arraydeentradasdelared[i, j];
                        grilladesimulacion.Rows[i].Cells[j].Value = arraydeentradasdelared[i, j];
                    }
                    else
                        grilladedatos.Rows[i].Cells[j].Value = arraydesalidasdeseadas[i, j - entradas];
                }
            }
            for (int i = 0; i < 1; i++)
            {
                grilladesimulacion.Rows[i].Cells[entradas].Value = "Obtener la salida";
            }
            grilladedatos.AllowUserToAddRows = false;
            grilladesimulacion.AllowUserToAddRows = false;
        }
      
        private void Simular(int r)
        {
            Dictionary<int, float[,]> diccionariodelassalidasdecapa = new Dictionary<int, float[,]>();
            
            float[,] arraydematrizdepesos;
            float[] arraydeumbrales;
            float[,] arraydesalidadelacapaanterior = null;
            float[,] arraydesalidadelacapaactual = null;
            List<int> numerodepatrones = new List<int>();

            int pt = r;
                float[] arraydeerroresdeneuronasendiccionario = null;
                float[,] arraydesalidasdecapasocultasanterior = null;
                numerodepatrones.Add(pt + 1);
                diccionariodelassalidasdecapa.Clear();

                for (int cp = 0; cp <= capasocultas; cp++)
                {
                    arraydematrizdepesos = diccionariodearraydematrizdepesos[cp];
                    arraydeumbrales = diccionariodearraydeumbrales[cp];
                    arraydesalidadelacapaactual = new float[patrones, arraydematrizdepesos.GetLength(0)];
                    if (cp > 0)
                        arraydesalidadelacapaanterior = diccionariodelassalidasdecapa[cp - 1];
                    for (int i = 0; i < arraydematrizdepesos.GetLength(0); i++)
                    {
                        arraydesalidadelacapaactual[pt, i] = 0;
                        if (cp == 0)
                        {
                            for (int j = 0; j < entradas; j++)
                                arraydesalidadelacapaactual[pt, i] += arraydeentradasdelared[pt, j] * arraydematrizdepesos[i, j];
                        }
                        else if (cp > 0 && cp < capasocultas)
                        {
                            for (int j = 0; j < arraydematrizdepesos.GetLength(1); j++)
                                arraydesalidadelacapaactual[pt, i] += arraydesalidadelacapaanterior[pt, j] * arraydematrizdepesos[i, j];
                        }
                        else if (cp == capasocultas)
                        {
                            for (int j = 0; j < arraydematrizdepesos.GetLength(1); j++)
                                arraydesalidadelacapaactual[pt, i] += arraydesalidadelacapaanterior[pt, j] * arraydematrizdepesos[i, j];
                        }
                        arraydesalidadelacapaactual[pt, i] -= arraydeumbrales[i];
                        if (cp != capasocultas)
                            arraydesalidadelacapaactual[pt, i] = new Funciondeactivacion(grilladecapasocultas.Rows[cp].Cells[2].Value.ToString(), arraydesalidadelacapaactual[pt, i]).getfunActivacion();
                        else
                            arraydesalidadelacapaactual[pt, i] = new Funciondeactivacion(funcionsalida, arraydesalidadelacapaactual[pt, i]).getfunActivacion();
                    }
                    diccionariodelassalidasdecapa.Add(cp, arraydesalidadelacapaactual);
                }
                int i2 = 0;
                for (int i = (entradas + 1); i <= (salidas + entradas); i++)
                {
                    grilladesimulacion.Rows[0].Cells[i].Value = arraydesalidadelacapaactual[pt, i2].ToString();
                    i2++;
                }
            
                
           
        }

        private void SimulacionInterna_Load(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void grilladesimulacion_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            
            Simular(1);
                    
        }
    }
}
