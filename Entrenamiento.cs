using Entity;
using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace BackpropagationAndPerceptron
{
    public partial class Entrenamiento : Form
    {

        public Entrenamiento()
        {
            InitializeComponent();

        }

        // datos para el cargue del data set y entradas salidas y patrones
        int posiciongrafica = 1;
        int entrenando = 0;
        int entradas;
        int salidas;
        int patrones;
        int iteracion = 0;
        int conti = 1;
        float ratadeaprendizaje = 0;
        float errormaximopermitido = 0;
        float errordeiteracion = 0;
        float[] arraydenumerosmayoresporcolumnasdeetradas;
        float[] arraydenumerosmayoresporcolumnasdesalidas;
        //float[] arraydesalidasdelared;
        float[] arraydeerrordelospatrones;
        float[] arraydeerroreslineales;
        float[] arraydeumbrales;
        float[] arraydeerrornolinealporneuronasdecapasocultas = null;
        float[,] arraydematrizdepesos;
        float[,] arraydeentradasdelared;
        float[,] arraydesalidasdeseadas;
        float[,] arraydesalidadelacapaactual;
        float[,] arraydesalidadelacapaanterior;
        List<string> registros = new List<string>();
        List<float> listadeerroresdeiteracion = new List<float>();
        List<int> listadeiteraciones = new List<int>();
        string comboBox1 = "Regla Delta";
        Dictionary<int, float[,]> diccionariodearraydematrizdepesos = new Dictionary<int, float[,]>();
        List<float[,]> ListDmp = new List<float[,]>();
        Dictionary<int, float[]> diccionariodearraydeumbrales = new Dictionary<int, float[]>();
        List<float[,]> ListDu = new List<float[,]>();
        Dictionary<int, float[,]> diccionariodelassalidasdecapa = new Dictionary<int, float[,]>();
        List<float[,]> ListDsc = new List<float[,]>();
        Dictionary<int, float[]> diccionariodeerrornolinealdeneuronasporcapaoscultas = new Dictionary<int, float[]>();

        private void ayudaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VentanaPrincipal ventanaPrincipal = new VentanaPrincipal();
            ventanaPrincipal.Show();
            this.Hide();
        }


        public void LlenarDataGrid()
        {

            DtgCapas.Rows.Clear();
            DtgCapas.Columns.Clear();

            DataGridViewComboBoxColumn Funciondeactivacion = new DataGridViewComboBoxColumn();
            Funciondeactivacion.HeaderText = "Funciones de activación.";
            Funciondeactivacion.Items.Add("Tangente hiperbólica.");
            Funciondeactivacion.Items.Add("Sigmoidal.");
            Funciondeactivacion.Items.Add("Seno.");
            Funciondeactivacion.Items.Add("Coseno.");
            Funciondeactivacion.Items.Add("Gausiana.");

            DtgCapas.Columns.Add("Numerodecapaoculta", "# de capas ocultas.");
            DtgCapas.Columns.Add("Numerodeneuronas", "# de neuronas en capa.");
            DtgCapas.Columns.Add(Funciondeactivacion);
            DtgCapas.AllowUserToAddRows = false;

            for (int i = 0; i < TxtNumeroCapas.Value; i++)
            {
                DtgCapas.Rows.Add();
                DtgCapas.Rows[i].Cells[0].Value = (i + 1).ToString();
                DtgCapas.Rows[i].Cells[1].Value = "1";
                DtgCapas.Rows[i].Cells[2].Value = "Tangente hiperbólica.";
            }






        }

        private void BtnCargarDatos_Click(object sender, EventArgs e)
        {
            
            /*GraficaComportamientoSalida.Series.Clear();
            GraficaComportamientoSalidas2.Series.Clear();
            
            DtgvDatos.Rows.Clear();
            DtgvDatos.Columns.Clear();
            DtgvDatos.Rows.Clear();
            DtgvDatos.Columns.Clear();
            registros.Clear();
            patrones = -1;
            entradas = 0;
            salidas = 0;

            OpenFileDialog ventana = new OpenFileDialog();

            if (ventana.ShowDialog() == DialogResult.OK)
            {
                string rutadoc = ventana.FileName;//Obtenemos la ruta del archivo.
                TextReader leerdatos = new StreamReader(File.OpenRead(rutadoc));//Leeremos el archivo.
                string fila;
                while ((fila = leerdatos.ReadLine()) != null)//Leemos línea por línea del archivo.
                {
                    patrones = patrones + 1;
                    registros.Add(fila);
                }
                leerdatos.Close();//Cerramos la lectura del archivo.
                string[] nentradas = registros[0].Split(' ');//Obtenemos la primera fila del registro.
                for (int i = 0; i < nentradas.Length; i++)
                {
                    if (nentradas[i].ToUpper().Equals("X"))//Encontramos las entradas.
                        entradas = entradas + 1;
                    else                                   //Sino las salidas.
                        salidas = salidas + 1;
                }


                LblResultados.Text = ("Entradas: " + entradas.ToString() + " Salidas: " + salidas.ToString() + " Patrones: " + patrones.ToString());
                //arraydesalidasdelared = new float[salidas];
                arraydeentradasdelared = new float[patrones, entradas];
                arraydesalidasdeseadas = new float[patrones, salidas];
                arraydeerrordelospatrones = new float[patrones];
                arraydeerroreslineales = new float[salidas];
                arraydenumerosmayoresporcolumnasdeetradas = new float[entradas];
                arraydenumerosmayoresporcolumnasdesalidas = new float[salidas];

                registros.RemoveAt(0);//Removemos la primera fila del registro que contienes X's y Y's
                for (int i = 0; i < entradas; i++)//Creamos las columnas de entradas.
                {
                    string titulo = "Xr" + (i + 1);
                    DtgvDatos.Columns.Add("Xr", titulo);
                }
                for (int i = 0; i < salidas; i++)//Creamos las columnas de las salidas.
                {
                    string titulo = "Yr" + (i + 1);
                    DtgvDatos.Columns.Add("Yr", titulo);
                }
                int _i = 0;
                foreach (string registro in registros)//Lleno la grila de datos y las matrices de entradas y salidas.
                {
                    DtgvDatos.Rows.Add(registro.Split(' '));
                    string[] reg = registro.Split(' ');
                    for (int j = 0; j < reg.Length; j++)
                    {
                        if (j < entradas)
                            arraydeentradasdelared[_i, j] = float.Parse(reg[j]);//Lleno la matriz de entradas de la red.
                        else
                            arraydesalidasdeseadas[_i, j - entradas] = float.Parse(reg[j]);//Lleno las salidas deseadas de la red.
                    }
                    _i++;
                }
                DtgvDatos.AllowUserToAddRows = false;

                //Graficando salidas deseadas de la red... 

                float Mayor = -10000;
                float Menor = 10000;
                for (int i = 0; i < arraydesalidasdeseadas.GetLength(0); i++)
                {
                    for (int j = 0; j < arraydesalidasdeseadas.GetLength(1); j++)
                    {
                        if (Mayor < arraydesalidasdeseadas[i, j])
                            Mayor = arraydesalidasdeseadas[i, j];
                        else if (Menor > arraydesalidasdeseadas[i, j])
                            Menor = arraydesalidasdeseadas[i, j];
                    }
                }
                for (int i = 0; i < salidas; i++)
                {
                   GraficaComportamientoSalida.Series.Add("salidas deseadas " + (i + 1).ToString());
                   GraficaComportamientoSalida.Series[i].ChartType = SeriesChartType.Spline;

                   GraficaComportamientoSalidas2.Series.Add("salidas de la red " + (i + 1).ToString());
                   GraficaComportamientoSalidas2.Series[i].ChartType = SeriesChartType.Spline;
                }
               GraficaComportamientoSalida.ChartAreas["ChartArea1"].AxisY.Minimum = Menor - 0.2;
               GraficaComportamientoSalida.ChartAreas["ChartArea1"].AxisY.Maximum = Mayor + 0.2;



                for (int i = 0; i < arraydesalidasdeseadas.GetLength(1); i++)
                {
                    List<float> listadesalidasdeseadas = new List<float>();
                    List<int> numerodepatrones = new List<int>();
                    for (int J = 0; J < arraydesalidasdeseadas.GetLength(0); J++)
                    {
                        listadesalidasdeseadas.Add(arraydesalidasdeseadas[J, i]);
                        numerodepatrones.Add((J + 1));
                    }
                    GraficaComportamientoSalida.Series[i].Points.DataBindXY(numerodepatrones, listadesalidasdeseadas);
                }


                for (int i = entradas; i < (entradas + salidas); i++)
                {
                    List<float> listadesalidasdeseadas = new List<float>();
                    List<int> numerodepatrones = new List<int>();

                    for (int J = 0; J < patrones; J++)
                    {
                        string[] salidadeseada = registros[J].Split(' ');
                        listadesalidasdeseadas.Add(float.Parse(salidadeseada[i]));
                        
                        numerodepatrones.Add((J + 1));

                    }
                    // graficaComportamientodelentrenamiento.Series[i - entradas].Points.DataBindXY(numerodepatrones, listadesalidasdeseadas);
                    GraficaComportamientoSalida.Series[i - entradas].Points.DataBindXY(numerodepatrones, listadesalidasdeseadas);

                }
                MessageBox.Show("Se ha generado la matriz de datos con éxito.");

            }

            BtnNormalizar.Enabled = true;
            */



            GraficaComportamientoSalida.Series.Clear();
            GraficaComportamientoSalidas2.Series.Clear();
            if (BtnCargarDatos.Text.Equals("Cargar Datos"))
            {
                DtgvDatos.Rows.Clear();
                DtgvDatos.Columns.Clear();
                DtgCapas.Rows.Clear();
                DtgCapas.Columns.Clear();
                registros.Clear();
                patrones = -1;
                entradas = 0;
                salidas = 0;
                OpenFileDialog ventana = new OpenFileDialog();
                if (ventana.ShowDialog() == DialogResult.OK)
                {
                    string rutadoc = ventana.FileName;//Obtenemos la ruta del archivo.
                    TextReader leerdatos = new StreamReader(File.OpenRead(rutadoc));//Leeremos el archivo.
                    string fila;
                    while ((fila = leerdatos.ReadLine()) != null)//Leemos línea por línea del archivo.
                    {
                        patrones = patrones + 1;
                        registros.Add(fila);
                    }
                    leerdatos.Close();//Cerramos la lectura del archivo.
                    string[] nentradas = registros[0].Split(' ');//Obtenemos la primera fila del registro.
                    for (int i = 0; i < nentradas.Length; i++)
                    {
                        if (nentradas[i].ToUpper().Equals("X"))//Encontramos las entradas.
                            entradas = entradas + 1;
                        else                                   //Sino las salidas.
                            salidas = salidas + 1;
                    }

                    LblResultados.Text = ("Entradas: " + entradas.ToString() + " Salidas: " + salidas.ToString() + " Patrones: " + patrones.ToString());
                    //arraydesalidasdelared = new float[salidas];
                    arraydeentradasdelared = new float[patrones, entradas];
                    arraydesalidasdeseadas = new float[patrones, salidas];
                    arraydeerrordelospatrones = new float[patrones];
                    arraydeerroreslineales = new float[salidas];
                    arraydenumerosmayoresporcolumnasdeetradas = new float[entradas];
                    arraydenumerosmayoresporcolumnasdesalidas = new float[salidas];
                    registros.RemoveAt(0);//Removemos la primera fila del registro que contienes X's y Y's
                    for (int i = 0; i < entradas; i++)//Creamos las columnas de entradas.
                    {
                        string titulo = "Xr" + (i + 1);
                        DtgvDatos.Columns.Add("Xr", titulo);
                    }
                    for (int i = 0; i < salidas; i++)//Creamos las columnas de las salidas.
                    {
                        string titulo = "Yr" + (i + 1);
                        DtgvDatos.Columns.Add("Yr", titulo);
                    }
                    int _i = 0;
                    foreach (string registro in registros)//Lleno la grila de datos y las matrices de entradas y salidas.
                    {
                        DtgvDatos.Rows.Add(registro.Split(' '));
                        string[] reg = registro.Split(' ');
                        for (int j = 0; j < reg.Length; j++)
                        {
                            if (j < entradas)
                                arraydeentradasdelared[_i, j] = float.Parse(reg[j]);//Lleno la matriz de entradas de la red.
                            else
                                arraydesalidasdeseadas[_i, j - entradas] = float.Parse(reg[j]);//Lleno las salidas deseadas de la red.
                        }
                        _i++;
                    }
                    DtgvDatos.AllowUserToAddRows = false;

                    //Graficando salidas deseadas de la red... 
                    float Mayor = -10000;
                    float Menor = 10000;
                    for (int i = 0; i < arraydesalidasdeseadas.GetLength(0); i++)
                    {
                        for (int j = 0; j < arraydesalidasdeseadas.GetLength(1); j++)
                        {
                            if (Mayor < arraydesalidasdeseadas[i, j])
                                Mayor = arraydesalidasdeseadas[i, j];
                            else if (Menor > arraydesalidasdeseadas[i, j])
                                Menor = arraydesalidasdeseadas[i, j];
                        }
                    }
                    for (int i = 0; i < salidas; i++)
                    {
                        GraficaComportamientoSalida.Series.Add("salidas deseadas " + (i + 1).ToString());
                        GraficaComportamientoSalida.Series[i].ChartType = SeriesChartType.Spline;
                        GraficaComportamientoSalidas2.Series.Add("salidas de la red " + (i + 1).ToString());
                        GraficaComportamientoSalidas2.Series[i].ChartType = SeriesChartType.Spline;
                    }
                    GraficaComportamientoSalida.ChartAreas["ChartArea1"].AxisY.Minimum = Menor - 0.2;
                    GraficaComportamientoSalida.ChartAreas["ChartArea1"].AxisY.Maximum = Mayor + 0.2;
                    for (int i = 0; i < arraydesalidasdeseadas.GetLength(1); i++)
                    {
                        List<float> listadesalidasdeseadas = new List<float>();
                        List<int> numerodepatrones = new List<int>();
                        for (int J = 0; J < arraydesalidasdeseadas.GetLength(0); J++)
                        {
                            listadesalidasdeseadas.Add(arraydesalidasdeseadas[J, i]);
                            numerodepatrones.Add((J + 1));
                        }
                        GraficaComportamientoSalida.Series[i].Points.DataBindXY(numerodepatrones, listadesalidasdeseadas);
                    }
                    MessageBox.Show("Se ha generado la matriz de datos con éxito.");
                    BtnCargarDatos.Text = "Normalizar";
                }
            }
            else
            {
                for (int i = 0; i < arraydeentradasdelared.GetLength(1); i++)//Obtenemos el valor máximo para las columns de entradas.
                {
                    float Maximovalor = -1000;
                    for (int j = 0; j < arraydeentradasdelared.GetLength(0); j++)
                    {
                        if (Maximovalor < arraydeentradasdelared[j, i])
                            Maximovalor = arraydeentradasdelared[j, i];
                    }
                    arraydenumerosmayoresporcolumnasdeetradas[i] = Maximovalor;
                }
                for (int i = 0; i < arraydesalidasdeseadas.GetLength(1); i++)//Ob/mos el valor máximo para las columnas de salidas.
                {
                    float Maximovalor = -1000;
                    for (int j = 0; j < arraydesalidasdeseadas.GetLength(0); j++)
                    {
                        if (Maximovalor < arraydesalidasdeseadas[j, i])
                            Maximovalor = arraydesalidasdeseadas[j, i];
                    }
                    arraydenumerosmayoresporcolumnasdesalidas[i] = Maximovalor;
                }
                for (int i = 0; i < arraydeentradasdelared.GetLength(0); i++)//Normalizamos las entradas.
                {
                    for (int j = 0; j < arraydeentradasdelared.GetLength(1); j++)
                    {
                        arraydeentradasdelared[i, j] = arraydeentradasdelared[i, j] / arraydenumerosmayoresporcolumnasdeetradas[j];
                    }
                }
                for (int i = 0; i < arraydesalidasdeseadas.GetLength(0); i++)//Normalizamos las salidas.
                {
                    for (int j = 0; j < arraydesalidasdeseadas.GetLength(1); j++)
                    {
                        arraydesalidasdeseadas[i, j] = arraydesalidasdeseadas[i, j] / arraydenumerosmayoresporcolumnasdesalidas[j];
                    }
                }
                for (int i = 0; i < patrones; i++)//Volvemos a llenar la tabla de datos con los datos normalizados.
                {
                    for (int j = 0; j < entradas + salidas; j++)
                    {
                        if (j < entradas)
                            DtgvDatos.Rows[i].Cells[j].Value = arraydeentradasdelared[i, j].ToString();//Lleno las entradas.
                        else
                            DtgvDatos.Rows[i].Cells[j].Value = arraydesalidasdeseadas[i, j - entradas];//Lleno las salidas.
                    }
                }
                float Mayor = -10000;
                float Menor = 10000;
                for (int i = 0; i < arraydesalidasdeseadas.GetLength(0); i++)
                {
                    for (int j = 0; j < arraydesalidasdeseadas.GetLength(1); j++)
                    {
                        if (Mayor < arraydesalidasdeseadas[i, j])
                            Mayor = arraydesalidasdeseadas[i, j];
                        else if (Menor > arraydesalidasdeseadas[i, j])
                            Menor = arraydesalidasdeseadas[i, j];
                    }
                }
                for (int i = 0; i < salidas; i++)//Graficamos las salidas normalizadas.
                {
                    GraficaComportamientoSalida.Series.Add("salidas deseadas " + (i + 1).ToString());
                    GraficaComportamientoSalida.Series[i].ChartType = SeriesChartType.Spline;
                    GraficaComportamientoSalidas2.Series.Add("salidas de la red " + (i + 1).ToString());
                    GraficaComportamientoSalidas2.Series[i].ChartType = SeriesChartType.Spline;
                }
                GraficaComportamientoSalida.ChartAreas["ChartArea1"].AxisY.Minimum = Menor - 0.2;
                GraficaComportamientoSalida.ChartAreas["ChartArea1"].AxisY.Maximum = Mayor + 0.2;
                GraficaComportamientoSalidas2.ChartAreas["ChartArea1"].AxisY.Minimum = Menor - 0.2;
                GraficaComportamientoSalidas2.ChartAreas["ChartArea1"].AxisY.Maximum = Mayor + 0.2;
                for (int i = 0; i < arraydesalidasdeseadas.GetLength(1); i++)
                {
                    List<float> listadesalidasdeseadas = new List<float>();
                    List<int> numerodepatrones = new List<int>();
                    for (int J = 0; J < arraydesalidasdeseadas.GetLength(0); J++)
                    {
                        listadesalidasdeseadas.Add(arraydesalidasdeseadas[J, i]);
                        numerodepatrones.Add((J + 1));
                    }
                    GraficaComportamientoSalida.Series[i].Points.DataBindXY(numerodepatrones, listadesalidasdeseadas);
                }
                BtnCargarDatos.Text = "Cargar Datos";
                TxtTipoRed.Enabled = true;
                TxtNumeroCapas.Enabled = true;
                CbxFuncionActivacionCapaSalida.Enabled = true;
                NudCapasocultasactivado();
            }



        }
    
    public  void NudCapasocultasactivado()
    {
        DtgCapas.Rows.Clear();
        DtgCapas.Columns.Clear();

        DataGridViewComboBoxColumn Funciondeactivacion = new DataGridViewComboBoxColumn();
        Funciondeactivacion.HeaderText = "Funciones de activación.";
        Funciondeactivacion.Items.Add("Tangente hiperbólica.");
        Funciondeactivacion.Items.Add("Sigmoidal.");
        Funciondeactivacion.Items.Add("Seno.");
        Funciondeactivacion.Items.Add("Coseno.");
        Funciondeactivacion.Items.Add("Gausiana.");

        DtgCapas.Columns.Add("Numerodecapaoculta", "# de capas ocultas.");
        DtgCapas.Columns.Add("Numerodeneuronas", "# de neuronas en capa.");
        DtgCapas.Columns.Add(Funciondeactivacion);
        DtgCapas.AllowUserToAddRows = false;

        for (int i = 0; i < TxtNumeroCapas.Value; i++)
        {
            DtgCapas.Rows.Add();
            DtgCapas.Rows[i].Cells[0].Value = (i + 1).ToString();
            DtgCapas.Rows[i].Cells[1].Value = "1";
            DtgCapas.Rows[i].Cells[2].Value = "Tangente hiperbólica.";
        }
        BtnInicializarPU.Enabled = true;
    }







        private void btnInicializarred_Click(object sender, EventArgs e)
        {
            conti = 1;
            graficaErroriteracion.Series[0].Points.Clear();
            for (int i = 0; i < salidas; i++)
                GraficaComportamientoSalida.Series[i].Points.Clear();
            listadeiteraciones.Clear();
            listadeerroresdeiteracion.Clear();
            lsterrores.Items.Clear();
            iteracion = 0;
            diccionariodearraydematrizdepesos.Clear();
            diccionariodearraydeumbrales.Clear();
            for (int capa = 0; capa <= TxtNumeroCapas.Value; capa++)
            {//Inicializamos las dimensiondes de los pesos y umbrales.
                if (capa == 0)
                {
                    arraydeumbrales = new float[Convert.ToInt32(DtgCapas.Rows[capa].Cells[1].Value.ToString())];
                    arraydematrizdepesos = new float[Convert.ToInt32(DtgCapas.Rows[capa].Cells[1].Value.ToString()), entradas];
                }
                else if (capa > 0 && capa < TxtNumeroCapas.Value)
                {
                    arraydeumbrales = new float[Convert.ToInt32(DtgCapas.Rows[capa].Cells[1].Value.ToString())];
                    arraydematrizdepesos = new float[Convert.ToInt32(DtgvDatos.Rows[capa].Cells[1].Value.ToString()), Convert.ToInt32(DtgCapas.Rows[capa - 1].Cells[1].Value.ToString())];
                }
                else if (capa == TxtNumeroCapas.Value)
                {
                    arraydeumbrales = new float[salidas];
                    arraydematrizdepesos = new float[salidas, Convert.ToInt32(DtgCapas.Rows[capa - 1].Cells[1].Value.ToString())];
                }
                diccionariodearraydeumbrales.Add(capa, arraydeumbrales);
                diccionariodearraydematrizdepesos.Add(capa, arraydematrizdepesos);
            }
            Random rnd = new Random();
            foreach (KeyValuePair<int, float[,]> Par in diccionariodearraydematrizdepesos)
            {
                for (int i = 0; i < Par.Value.GetLength(1); i++)
                {
                    for (int j = 0; j < Par.Value.GetLength(0); j++)
                    {
                        double val = rnd.NextDouble() * 1 - (-1) + (-1);
                        Par.Value[j, i] = float.Parse(val.ToString());
                    }
                }
            }
            foreach (KeyValuePair<int, float[]> Par in diccionariodearraydeumbrales)
            {
                for (int i = 0; i < Par.Value.GetLength(0); i++)
                {
                    double val = rnd.NextDouble() * 1 - (-1) + (-1);
                    Par.Value[i] = float.Parse(val.ToString());
                }
            }
            MessageBox.Show("Pesos y umbrales inicializados con éxito.");
            TxtNumeroIteraciones.Enabled = true;
            TxtErrorMaximoPermitido.Enabled = true;
            TxtRataAprendizaje.Enabled = true;
            BtnEntrenar.Enabled = true;
        }


        private void BtnConfigurar_Click(object sender, EventArgs e)
        {
            
            

        }

        
        private void BtnInicializarPU_Click(object sender, EventArgs e)
        {

            if (TxtTipoRed.SelectedItem.ToString().Equals("Perceptrón Multicapa"))
            {

                conti = 1;
                graficaErroriteracion.Series[0].Points.Clear();
                for (int i = 0; i < salidas; i++)
                   GraficaComportamientoSalidas2.Series[0].Points.Clear();
                listadeiteraciones.Clear();
                listadeerroresdeiteracion.Clear();
                lsterrores.Items.Clear();
                iteracion = 0;
                diccionariodearraydematrizdepesos.Clear();
                diccionariodearraydeumbrales.Clear();
                for (int capa = 0; capa <= TxtNumeroCapas.Value; capa++)
                {//Inicializamos las dimensiondes de los pesos y umbrales.
                    if (capa == 0)
                    {
                        arraydeumbrales = new float[Convert.ToInt32(DtgCapas.Rows[capa].Cells[1].Value.ToString())];
                        arraydematrizdepesos = new float[Convert.ToInt32(DtgCapas.Rows[capa].Cells[1].Value.ToString()), entradas];
                    }
                    else if (capa > 0 && capa < TxtNumeroCapas.Value)
                    {
                        arraydeumbrales = new float[Convert.ToInt32(DtgCapas.Rows[capa].Cells[1].Value.ToString())];
                        arraydematrizdepesos = new float[Convert.ToInt32(DtgCapas.Rows[capa].Cells[1].Value.ToString()), Convert.ToInt32(DtgCapas.Rows[capa - 1].Cells[1].Value.ToString())];
                    }
                    else if (capa == TxtNumeroCapas.Value)
                    {
                        arraydeumbrales = new float[salidas];
                        arraydematrizdepesos = new float[salidas, Convert.ToInt32(DtgCapas.Rows[capa - 1].Cells[1].Value.ToString())];
                    }
                    diccionariodearraydeumbrales.Add(capa, arraydeumbrales);
                    diccionariodearraydematrizdepesos.Add(capa, arraydematrizdepesos);

                }
            }
            else
            {
                conti = 1;
                graficaErroriteracion.Series[0].Points.Clear();
                for (int i = 0; i < salidas; i++)
                    GraficaComportamientoSalidas2.Series[i].Points.Clear();
                listadeiteraciones.Clear();
                listadeerroresdeiteracion.Clear();
                lsterrores.Items.Clear();
                iteracion = 0;
                diccionariodearraydematrizdepesos.Clear();
                diccionariodearraydeumbrales.Clear();
                for (int capa = 0; capa <= TxtNumeroCapas.Value; capa++)
                {//Inicializamos las dimensiondes de los pesos y umbrales.
                    if (capa == 0)
                    {
                        arraydeumbrales = new float[Convert.ToInt32(DtgCapas.Rows[capa].Cells[1].Value.ToString())];
                        arraydematrizdepesos = new float[Convert.ToInt32(DtgCapas.Rows[capa].Cells[1].Value.ToString()), entradas];
                    }
                    else if (capa > 0 && capa < TxtNumeroCapas.Value)
                    {
                        arraydeumbrales = new float[Convert.ToInt32(DtgCapas.Rows[capa].Cells[1].Value.ToString())];
                        arraydematrizdepesos = new float[Convert.ToInt32(DtgCapas.Rows[capa].Cells[1].Value.ToString()), Convert.ToInt32(DtgCapas.Rows[capa - 1].Cells[1].Value.ToString())];
                    }
                    else if (capa == TxtNumeroCapas.Value)
                    {
                        arraydeumbrales = new float[salidas];
                        arraydematrizdepesos = new float[salidas, Convert.ToInt32(DtgCapas.Rows[capa - 1].Cells[1].Value.ToString())];
                    }
                    diccionariodearraydeumbrales.Add(capa, arraydeumbrales);
                    diccionariodearraydematrizdepesos.Add(capa, arraydematrizdepesos);
                }

            }


            TxtNumeroIteraciones.Enabled = true;
            TxtErrorMaximoPermitido.Enabled = true;
            TxtRataAprendizaje.Enabled = true;
            BtnEntrenar.Enabled = true;
        }


        private void BtnAgregar_Click(object sender, EventArgs e)
        {
           
        }

        private void DtgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        
           

        private void BtnEntrenar_Click(object sender, EventArgs e)
        {
            if (TxtTipoRed.SelectedItem.ToString().Equals("Perceptrón Multicapa"))
            {

                if (entrenando == 0)
                {
                    listadeerroresdeiteracion.Clear();
                    lsterrores.Items.Clear();
                    entrenando = 1;
                    EntrenamientodelaredPercetron();
                    
                }
                else if (entrenando == 1)
                {
                    EntrenamientodelaredPercetron();
                }

                BtnGuardarRed.Enabled = true;
            }
            else
            {
                if (entrenando == 0)
                {
                    listadeerroresdeiteracion.Clear();
                    lsterrores.Items.Clear();
                    entrenando = 1;
                    EntrenamientodelaredBackpropagation();
                }
                else if (entrenando == 1)
                {
                    EntrenamientodelaredBackpropagation();
                }
            }
    
        }

        

        private void EntrenamientodelaredPercetron()
        {
            iteracion += Convert.ToInt32(TxtNumeroIteraciones.Value);
            ratadeaprendizaje = float.Parse(TxtRataAprendizaje.Value.ToString());
            errormaximopermitido = float.Parse(TxtErrorMaximoPermitido.Value.ToString());
            errordeiteracion = 1000;
            while (errormaximopermitido < errordeiteracion && conti <= iteracion)
            {
                List<string> listadesalidasdelared = new List<string>();
                List<int> numerodepatrones = new List<int>();
                arraydeerrordelospatrones = new float[patrones];
                for (int pt = 0; pt < patrones; pt++)
                {
                    numerodepatrones.Add(pt + 1);
                    diccionariodelassalidasdecapa.Clear();
                    for (int cp = 0; cp <= TxtNumeroCapas.Value; cp++)
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
                            else if (cp > 0 && cp < TxtNumeroCapas.Value)
                            {
                                for (int j = 0; j < arraydematrizdepesos.GetLength(1); j++)
                                    arraydesalidadelacapaactual[pt, i] += arraydesalidadelacapaanterior[pt, j] * arraydematrizdepesos[i, j];
                            }
                            else if (cp == TxtNumeroCapas.Value)
                            {
                                for (int j = 0; j < arraydematrizdepesos.GetLength(1); j++)
                                    arraydesalidadelacapaactual[pt, i] += arraydesalidadelacapaanterior[pt, j] * arraydematrizdepesos[i, j];
                            }
                            arraydesalidadelacapaactual[pt, i] -= arraydeumbrales[i];
                            if (cp != TxtNumeroCapas.Value)
                                arraydesalidadelacapaactual[pt, i] = new Funciondeactivacion(DtgCapas.Rows[cp].Cells[2].Value.ToString(), arraydesalidadelacapaactual[pt, i]).getfunActivacion();
                            else
                            {
                             arraydesalidadelacapaactual[pt, i] = new Funciondeactivacion(CbxFuncionActivacionCapaSalida.SelectedItem.ToString(), arraydesalidadelacapaactual[pt, i]).getfunActivacion();
                             listadesalidasdelared.Add(i.ToString() + " " + arraydesalidadelacapaactual[pt, i].ToString());
                                
                            }
                           
                        }

                       
                        diccionariodelassalidasdecapa.Add(cp, arraydesalidadelacapaactual);
                    }
                    //Error lineal de las salidas de la red ....
                    arraydeerroreslineales = new float[salidas];
                    for (int i = 0; i < salidas; i++)
                    {
                        arraydeerroreslineales[i] = arraydesalidasdeseadas[pt, i] - arraydesalidadelacapaactual[pt, i];
                    }
                    //Calculando el error del patron.
                    float totalerrorlineal = 0;
                    for (int i = 0; i < salidas; i++)
                    {
                        totalerrorlineal = totalerrorlineal + Math.Abs(arraydeerroreslineales[i]);
                    }
                    arraydeerrordelospatrones[pt] = totalerrorlineal / conti;
                    //Modificacion de pesos y umbrales...
                    for (int cp = 0; cp <= TxtNumeroCapas.Value; cp++)
                        Modificaciondepesosyumbrales(pt, cp, arraydeerroreslineales, arraydeerrordelospatrones[pt], conti);
                }
                //Graficar salida de la red...

                //Graficar salida de la red...
               int sa = 0;
                List<float> salidasdelared = new List<float>();
                while (sa < salidas)
                {
                    foreach (var obj in listadesalidasdelared)
                    {
                        string[] reg = obj.Split(' ');
                        if (reg[0].Equals(sa.ToString()))
                        {
                            salidasdelared.Add(float.Parse(reg[1]));
                        }
                    }
                    GraficaComportamientoSalidas2.Series[sa].Points.DataBindXY(numerodepatrones, salidasdelared);
                    GraficaComportamientoSalidas2.Update();
                    salidasdelared.Clear();
                    sa++;
                }

                //Calculo del error por iteracion...
                errordeiteracion = 0;
                for (int i = 0; i < patrones; i++)
                {
                    errordeiteracion += arraydeerrordelospatrones[i];
                }
                errordeiteracion = errordeiteracion / patrones;
                listadeiteraciones.Add(conti);
                //Graficas generales...
                lsterrores.Items.Add("[" + (listadeiteraciones.Count - 1) + "]" + " " + errordeiteracion);
                lsterrores.SelectedIndex = lsterrores.Items.Count - 1;
                lsterrores.Update();
                Graficarerror();
                conti++;
                posiciongrafica++;
            }
            if (errordeiteracion <= errormaximopermitido)
            {
                MessageBox.Show("La red entrenó correctamente y obtuvo su pesos y umbrales optimos en la iteración número " + (listadeiteraciones.Count) + ".");
                TxtErrorMaximoPermitido.Enabled = false;
                TxtRataAprendizaje.Enabled = false;
                TxtNumeroIteraciones.Enabled = false;
                guardarpesosyumbrales(arraydematrizdepesos, arraydeumbrales);
                BtnSimular.Enabled = true;
            }
            else
            {
                MessageBox.Show("La red no termina aún su proceso de aprendizaje. ¡Sigue iterando!");
                
            }
        }


        private void EntrenamientodelaredBackpropagation()
        {

            iteracion = iteracion + Convert.ToInt32(TxtNumeroIteraciones.Value);
            ratadeaprendizaje = float.Parse(TxtRataAprendizaje.Value.ToString());
            errormaximopermitido = float.Parse(TxtErrorMaximoPermitido.Value.ToString());
            errordeiteracion = 1000;
            while (errormaximopermitido < errordeiteracion && conti <= iteracion)
            {
                List<string> listadesalidasdelared = new List<string>();
                List<int> numerodepatrones = new List<int>();
                arraydeerrordelospatrones = new float[patrones];
                for (int pt = 0; pt < patrones; pt++)
                {
                    float[] arraydeerroresdeneuronasendiccionario = null;
                    float[,] arraydesalidasdecapasocultasanterior = null;
                    diccionariodeerrornolinealdeneuronasporcapaoscultas.Clear();
                    numerodepatrones.Add(pt + 1);
                    diccionariodelassalidasdecapa.Clear();
                    for (int cp = 0; cp <= TxtNumeroCapas.Value; cp++)
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
                            else if (cp > 0 && cp < TxtNumeroCapas.Value)
                            {
                                for (int j = 0; j < arraydematrizdepesos.GetLength(1); j++)
                                    arraydesalidadelacapaactual[pt, i] += arraydesalidadelacapaanterior[pt, j] * arraydematrizdepesos[i, j];
                            }
                            else if (cp == TxtNumeroCapas.Value)
                            {
                                for (int j = 0; j < arraydematrizdepesos.GetLength(1); j++)
                                    arraydesalidadelacapaactual[pt, i] += arraydesalidadelacapaanterior[pt, j] * arraydematrizdepesos[i, j];
                            }
                            arraydesalidadelacapaactual[pt, i] -= arraydeumbrales[i];
                            if (cp != TxtNumeroCapas.Value)
                                arraydesalidadelacapaactual[pt, i] = new Funciondeactivacion(DtgCapas.Rows[cp].Cells[2].Value.ToString(), arraydesalidadelacapaactual[pt, i]).getfunActivacion();
                            else
                            {
                                arraydesalidadelacapaactual[pt, i] = new Funciondeactivacion(CbxFuncionActivacionCapaSalida.SelectedItem.ToString(), arraydesalidadelacapaactual[pt, i]).getfunActivacion();
                                listadesalidasdelared.Add(i.ToString() + " " + arraydesalidadelacapaactual[pt, i].ToString());
                            }
                        }
                        diccionariodelassalidasdecapa.Add(cp, arraydesalidadelacapaactual);
                    }
                    //Error lineal de las salidas de la red ....
                    arraydeerroreslineales = new float[salidas];
                    for (int i = 0; i < salidas; i++)
                        arraydeerroreslineales[i] = arraydesalidasdeseadas[pt, i] - arraydesalidadelacapaactual[pt, i];
                    //COMIENZA AQUÍ LA RETROPROPAGACIÓN, DE CADA NEURONA DESDE LA ÚLTIMA CAPA OCULTA HASTA LA PRIMERA...
                    //Error no lineal por neuronas de las capas ocultas....
                    for (int capOculta = Convert.ToInt32(TxtNumeroCapas.Value) - 1; capOculta >= 0; capOculta--)
                    {
                        //Última capa oculta con salida...
                        if (capOculta == Convert.ToInt32(TxtNumeroCapas.Value) - 1)
                        {
                            arraydeerrornolinealporneuronasdecapasocultas = new float[Convert.ToInt32(DtgCapas.Rows[capOculta].Cells[1].Value.ToString())];
                            arraydematrizdepesos = diccionariodearraydematrizdepesos[capOculta + 1];
                            for (int neucapActual = 0; neucapActual < arraydeerrornolinealporneuronasdecapasocultas.Length; neucapActual++)
                            {
                                float sumerr = 0;
                                for (int sal = 0; sal < salidas; sal++)
                                    sumerr = sumerr + (arraydeerroreslineales[sal] * arraydematrizdepesos[sal, neucapActual]);
                                arraydeerrornolinealporneuronasdecapasocultas[neucapActual] = sumerr;
                            }
                            diccionariodeerrornolinealdeneuronasporcapaoscultas.Add(capOculta, arraydeerrornolinealporneuronasdecapasocultas);
                        }
                        else
                        //Entre capas ocultas....
                        {
                            float[] Errorneuronasiguiente = diccionariodeerrornolinealdeneuronasporcapaoscultas[capOculta + 1];
                            arraydeerrornolinealporneuronasdecapasocultas = new float[Convert.ToInt32(DtgCapas.Rows[capOculta].Cells[1].Value.ToString())];
                            arraydematrizdepesos = diccionariodearraydematrizdepesos[capOculta + 1];
                            for (int neucapActual = 0; neucapActual < arraydeerrornolinealporneuronasdecapasocultas.Length; neucapActual++)
                            {
                                float sumerr = 0;
                                for (int neucapaSiguiente = 0; neucapaSiguiente < Errorneuronasiguiente.Length; neucapaSiguiente++)
                                    sumerr = sumerr + (Errorneuronasiguiente[neucapaSiguiente] * arraydematrizdepesos[neucapaSiguiente, neucapActual]);
                                arraydeerrornolinealporneuronasdecapasocultas[neucapActual] = sumerr;
                            }
                            diccionariodeerrornolinealdeneuronasporcapaoscultas.Add(capOculta, arraydeerrornolinealporneuronasdecapasocultas);
                        }
                    }
                    //TERMINA LA RETROPROPAGACIÓN Y SE MODIFICAR PESOS Y UMBRALES CON LOS ERRORES NO LINEALES POR
                    //CADA NEURONA DE CADA CAPA OCULTA...
                    //Modificacion de pesos y umbrales...
                    for (int capOculta = 0; capOculta <= Convert.ToInt32(TxtNumeroCapas.Value); capOculta++)
                    {
                        //Desde la capa entrada hasta la última capa oculta....
                        arraydematrizdepesos = diccionariodearraydematrizdepesos[capOculta];
                        arraydeumbrales = diccionariodearraydeumbrales[capOculta];
                        if (capOculta < Convert.ToInt32(TxtNumeroCapas.Value))
                            arraydeerroresdeneuronasendiccionario = diccionariodeerrornolinealdeneuronasporcapaoscultas[capOculta];
                        arraydesalidadelacapaactual = diccionariodelassalidasdecapa[capOculta];
                        for (int sal = 0; sal < arraydematrizdepesos.GetLength(0); sal++)
                        {
                            if (capOculta < Convert.ToInt32(TxtNumeroCapas.Value))
                                arraydeumbrales[sal] += 2 * ratadeaprendizaje * new Funcionderivada(DtgCapas.Rows[capOculta].Cells[2].Value.ToString(), arraydesalidadelacapaactual[pt, sal]).getfunDerivada() * arraydeerroresdeneuronasendiccionario[sal];
                            else
                                arraydeumbrales[sal] += 2 * ratadeaprendizaje * arraydeerroreslineales[sal];
                            for (int ent = 0; ent < arraydematrizdepesos.GetLength(1); ent++)
                            {
                                if (capOculta == 0)
                                {
                                    arraydematrizdepesos[sal, ent] += 2 * ratadeaprendizaje * new Funcionderivada(DtgCapas.Rows[capOculta].Cells[2].Value.ToString(), arraydesalidadelacapaactual[pt, sal]).getfunDerivada() * arraydeerroresdeneuronasendiccionario[sal] * arraydeentradasdelared[pt, ent];
                                }
                                if (capOculta > 0 && capOculta < Convert.ToInt32(TxtNumeroCapas.Value))
                                {
                                    arraydesalidasdecapasocultasanterior = diccionariodelassalidasdecapa[capOculta - 1];
                                    arraydematrizdepesos[sal, ent] += 2 * ratadeaprendizaje * new Funcionderivada(DtgCapas.Rows[capOculta].Cells[2].Value.ToString(), arraydesalidadelacapaactual[pt, sal]).getfunDerivada() * arraydeerroresdeneuronasendiccionario[sal] * arraydesalidasdecapasocultasanterior[pt, ent];
                                }
                                if (capOculta == Convert.ToInt32(TxtNumeroCapas.Value))
                                {
                                    arraydesalidasdecapasocultasanterior = diccionariodelassalidasdecapa[capOculta - 1];
                                    arraydematrizdepesos[sal, ent] += 2 * ratadeaprendizaje * arraydeerroreslineales[sal] * arraydesalidasdecapasocultasanterior[pt, ent];
                                }
                            }
                        }
                        diccionariodearraydematrizdepesos[capOculta] = arraydematrizdepesos;
                        diccionariodearraydeumbrales[capOculta] = arraydeumbrales;
                    }
                    //Encontrando el error del patron...
                    float totalerrorlineal = 0;
                    for (int i = 0; i < salidas; i++)
                    {
                        totalerrorlineal = totalerrorlineal + Math.Abs(arraydeerroreslineales[i]);
                    }
                    arraydeerrordelospatrones[pt] = totalerrorlineal / salidas;
                }
                //Graficar salida de la red...
                int sa = 0;
                List<float> salidasdelared = new List<float>();
                while (sa < salidas)
                {
                    foreach (var obj in listadesalidasdelared)
                    {
                        string[] reg = obj.Split(' ');
                        if (reg[0].Equals(sa.ToString()))
                        {
                            salidasdelared.Add(float.Parse(reg[1]));
                        }
                    }
                    GraficaComportamientoSalidas2.Series[sa].Points.DataBindXY(numerodepatrones, salidasdelared);
                    GraficaComportamientoSalidas2.Update();
                    salidasdelared.Clear();
                    sa++;
                }
                //Calculo del error por iteracion...
                errordeiteracion = 0;
                for (int i = 0; i < patrones; i++)
                {
                    errordeiteracion += arraydeerrordelospatrones[i];
                }
                errordeiteracion = errordeiteracion / patrones;
                listadeiteraciones.Add(conti);
                //Graficas generales...
                lsterrores.Items.Add("[" + listadeiteraciones.Count + "]" + " " + errordeiteracion);
                lsterrores.SelectedIndex = lsterrores.Items.Count - 1;
                lsterrores.Update();
                Graficarerror();
                conti++;
                posiciongrafica++;
            }
            if (errordeiteracion <= errormaximopermitido)
            {
                MessageBox.Show("La red entrenó correctamente y obtuvo su pesos y umbrales optimos en la iteración número " + (listadeiteraciones.Count) + ".");
                guardarpesosyumbrales(arraydematrizdepesos, arraydeumbrales);
                BtnSimular.Enabled = true;
            }
            else
            {
                MessageBox.Show("La red no termina aún su proceso de aprendizaje. ¡Sigue iterando!");
                TxtErrorMaximoPermitido.Enabled = false;
            }
        }


        private void Modificaciondepesosyumbrales(int pt, int cp, float[] arraydeerroreslineales, float errordelpatron, int conti)
        {
            arraydematrizdepesos = diccionariodearraydematrizdepesos[cp];
            arraydeumbrales = diccionariodearraydeumbrales[cp];

            
                if (cp > 0)
                    arraydesalidadelacapaanterior = diccionariodelassalidasdecapa[cp - 1];
                for (int i = 0; i < arraydematrizdepesos.GetLength(0); i++)
                {
                    if (cp < TxtNumeroCapas.Value)
                        arraydeumbrales[i] += (ratadeaprendizaje * errordelpatron);
                    else
                        arraydeumbrales[i] += (ratadeaprendizaje * arraydeerroreslineales[i]);
                    for (int j = 0; j < arraydematrizdepesos.GetLength(1); j++)
                    {
                        if (cp == 0)
                            arraydematrizdepesos[i, j] += (ratadeaprendizaje * errordelpatron * arraydeentradasdelared[pt, j]);
                        else if (cp > 0 && cp < TxtNumeroCapas.Value)
                            arraydematrizdepesos[i, j] += (ratadeaprendizaje * errordelpatron * arraydesalidadelacapaanterior[pt, j]);
                        else if (cp == TxtNumeroCapas.Value)
                            arraydematrizdepesos[i, j] += (ratadeaprendizaje * arraydeerroreslineales[i] * arraydesalidadelacapaanterior[pt, j]);
                    }
                }
            
         
            diccionariodearraydematrizdepesos[cp] = arraydematrizdepesos;
            diccionariodearraydeumbrales[cp] = arraydeumbrales;
        }
        private void Graficarerror()
        {
            if (posiciongrafica >= 5)
                graficaErroriteracion.ChartAreas["ChartArea1"].AxisX.Maximum = (graficaErroriteracion.ChartAreas["ChartArea1"].AxisX.Maximum + 1);
            listadeerroresdeiteracion.Add(errordeiteracion);
            graficaErroriteracion.Series[0].Points.DataBindXY(listadeiteraciones, listadeerroresdeiteracion);
            graficaErroriteracion.Update();
        }



        private void guardarpesosyumbrales(float[,] pesos, float[] umbrales)
        {
            try
            {
                //File.Delete("Pesos.txt");
                //File.Delete("Umbrales.txt");

                File.Delete(@"C:\Users\Acer\Desktop\Universidad Popular Del Cesar\Inteligemcia Artificial\UmbralesRed.txt");
                File.Delete(@"C:\Users\Acer\Desktop\Universidad Popular Del Cesar\Inteligemcia Artificial\PesosRed.txt");

                StreamWriter swp = new StreamWriter(@"C:\Users\Acer\Desktop\Universidad Popular Del Cesar\Inteligemcia Artificial\PesosRed.txt", true);
                StreamWriter swu = new StreamWriter(@"C:\Users\Acer\Desktop\Universidad Popular Del Cesar\Inteligemcia Artificial\UmbralesRed.txt", true);
                for (int i = 0; i < pesos.GetLength(0); i++)
                {
                    for (int j = 0; j < pesos.GetLength(1); j++)
                    {
                        if ((j + 1 < pesos.GetLength(1)))
                            swp.Write(pesos[i, j] + " ");
                        else
                            swp.WriteLine(pesos[i, j]);
                    }
                }
                for (int i = 0; i < umbrales.GetLength(0); i++)
                {
                    swu.WriteLine(umbrales[i]);
                }
                swp.Close();
                swu.Close();
            }
            catch (Exception)
            { }
        }


        private void guardarConfiguracionRed()
        {
            try
            {
                //File.Delete("Pesos.txt");
                //File.Delete("Umbrales.txt");

                File.Delete(@"C:\Users\Acer\Desktop\Universidad Popular Del Cesar\Inteligemcia Artificial\ConfiguracionRed.txt");

                StreamWriter swp = new StreamWriter(@"C:\Users\Acer\Desktop\Universidad Popular Del Cesar\Inteligemcia Artificial\ConfiguracionRed.txt", true);

                ListDmp = diccionariodearraydematrizdepesos.Values.ToList();
                

           
                swp.Write(entradas);
                swp.Write(" ");
                swp.Write(salidas);
                swp.Write(" ");
                swp.Write(patrones);
                swp.WriteLine(" ");
                for (int i = 0; i < patrones; i++)
                {
                    for (int j = 0; j < entradas; j++)
                    {
                        swp.Write(arraydeentradasdelared[i,j].ToString());
                        swp.Write(" ");
                    }
                }

                swp.WriteLine(" ");

                for (int i = 0; i < salidas; i++)
                  
                for (int capa = 0; capa <= TxtNumeroCapas.Value; capa++)
                {//Inicializamos las dimensiondes de los pesos y umbrales.
                   

                        swp.Write(arraydematrizdepesos[capa,i]);
                        
                }

                
                swp.WriteLine(" ");

                swp.Write(CbxFuncionActivacionCapaSalida);



                swp.Close();
               
            }
            catch (Exception)
            { }
        }


        private void TxtTipoRed_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DtgCapas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            Entrenamiento entrenamiento = new Entrenamiento();

            entrenamiento.Show();
            this.Close();

        }

        private void TxtNumeroCapas_ValueChanged(object sender, EventArgs e)
        {
           
            LlenarDataGrid();
        }

         private void Entrenamiento_Load(object sender, EventArgs e)
        {
            
            GraficaComportamientoSalida.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            GraficaComportamientoSalida.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
            GraficaComportamientoSalida.ChartAreas[0].AxisY.Title = "Salida";
            GraficaComportamientoSalida.ChartAreas[0].AxisX.Title = "Patrón";
            GraficaComportamientoSalida.ChartAreas["ChartArea1"].AxisY.Minimum = -2;
            GraficaComportamientoSalida.ChartAreas["ChartArea1"].AxisY.Maximum = 2;


            GraficaComportamientoSalidas2.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            GraficaComportamientoSalidas2.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
            GraficaComportamientoSalidas2.ChartAreas[0].AxisX.Title = "Salidas de la red.";

            graficaErroriteracion.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            graficaErroriteracion.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
            graficaErroriteracion.ChartAreas["ChartArea1"].AxisX.Maximum = 5;
            graficaErroriteracion.ChartAreas[0].AxisY.Title = "Error.";
            graficaErroriteracion.ChartAreas[0].AxisX.Title = "Iteraciones.";
        }

        private void Menu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void TxtRataAprendizaje_ValueChanged(object sender, EventArgs e)
        {

        }

        private void GraficaComportamientoSalidas2_Click(object sender, EventArgs e)
        {

        }

        private void BtnGuardarRed_Click(object sender, EventArgs e)
        {
            if (TxtTipoRed.SelectedItem.Equals("Perceptrón Multicapa"))
            {
                guardarConfiguracionRed();
                MessageBox.Show("Se han guardado los pesos y umbrales optimos de la red Perceptron Multicapa");
                
            }
            else
            {
                guardarConfiguracionRed();
                MessageBox.Show("Se han guardado los pesos y umbrales optimos de la red Backpropagation");
            }
        }

        private void BtnSimular_Click(object sender, EventArgs e)
        {
            SimulacionInterna sim = new SimulacionInterna(entradas, salidas, patrones, arraydeentradasdelared, arraydesalidasdeseadas,
                      diccionariodearraydematrizdepesos, diccionariodearraydeumbrales, Convert.ToInt32(TxtNumeroCapas.Value), DtgCapas, CbxFuncionActivacionCapaSalida.SelectedItem.ToString());

            sim.ShowDialog();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
