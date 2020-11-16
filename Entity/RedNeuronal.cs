using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Entity
{
    public class RedNeuronal
    {
        public RedNeuronal()
        {

        }

        public RedNeuronal(int numeroEntradas, int numeroSalidas, int numeroPatrones, double[] entradas, double[] salidas, double[] patrones, int numeroIteraciones, float rataAprendizaje, float errorMaximoPermitido, int numeroCapas, int[] numeroNeuronasCapas, string[] funcionesActivacionCapas, string funcionActivacionCapaSalida, double[,] pesos, double[] umbrales)
        {
            NumeroEntradas = numeroEntradas;
            NumeroSalidas = numeroSalidas;
            NumeroPatrones = numeroPatrones;
            Entradas = entradas;
            Salidas = salidas;
            Patrones = patrones;
            NumeroIteraciones = numeroIteraciones;
            RataAprendizaje = rataAprendizaje;
            ErrorMaximoPermitido = errorMaximoPermitido;
            NumeroCapas = numeroCapas;
            NumeroNeuronasCapas = numeroNeuronasCapas;
            FuncionesActivacionCapas = funcionesActivacionCapas;
            FuncionActivacionCapaSalida = funcionActivacionCapaSalida;
            Pesos = pesos;
            Umbrales = umbrales;

            arraydeerroreslineales = new float[NumeroSalidas];
        }

        public int NumeroEntradas { get; set; }
        public int NumeroSalidas { get; set; }
        public int NumeroPatrones { get; set; }
        public double[] Entradas = { };
        public double[] Salidas = { };
        public double[] Patrones = { };
        public int NumeroIteraciones { get; set; }
        public float RataAprendizaje { get; set; }
        public float ErrorMaximoPermitido { get; set; }
        public int NumeroCapas { get; set; }

        public int[] NumeroNeuronasCapas = { };

        public string[] FuncionesActivacionCapas = { };
        public string FuncionActivacionCapaSalida { get; set; }

        public double[,] Pesos = { };
        public double[] Umbrales = { };


        public List<string> registros = new List<string>();
        public List<float> listadeerroresdeiteracion = new List<float>();
        public List<int> listadeiteraciones = new List<int>();
        public Dictionary<int, float[,]> diccionariodearraydematrizdepesos = new Dictionary<int, float[,]>();
        public Dictionary<int, float[]> diccionariodearraydeumbrales = new Dictionary<int, float[]>();
        public Dictionary<int, float[,]> diccionariodelassalidasdecapa = new Dictionary<int, float[,]>();
        public Dictionary<int, float[]> diccionariodeerrornolinealdeneuronasporcapaoscultas = new Dictionary<int, float[]>();
        public float[] arraydeerrordelospatrones;
        public float[,] arraydematrizdepesos;
        public float[] arraydeumbrales;
        public float[,] arraydesalidadelacapaactual;
        public float[,] arraydesalidadelacapaanterior;
        public float[,] arraydeentradasdelared;
        public float[] arraydeerroreslineales;
        public float[,] arraydesalidasdeseadas;

    }
}
