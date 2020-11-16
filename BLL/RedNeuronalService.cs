using System;
using Entity;
using DALL;
using System.Collections.Generic;

namespace BLL
{
    public abstract class RedNeuronalService
    {

        double[,] pesos = { };
        double[] umbrales = { };
        double errorIteracion = 0;
        double[] patronEntradas = { };

      

        public double[] InicializarUmbrales(int NumeroSalidas)
        {
            Random rnd = new Random();
            umbrales = new double[NumeroSalidas];
            for (int i = 0; i < NumeroSalidas; i++)
            {
                double val = rnd.NextDouble() * 1 - (-1) + (-1);
                umbrales[i] = val;
            }

            return umbrales;
        }


        public double[,] InicializarPesos(int NumeroEntradas, int NumeroSalidas)
        {
            Random rnd = new Random();

            pesos = new double[NumeroEntradas, NumeroSalidas];

            for (int i = 0; i < NumeroSalidas; i++)
            {
                for (int j = 0; j < NumeroEntradas; j++)
                {
                    double val = rnd.NextDouble() * 1 - (-1) + (-1);
                    pesos[j,i] = val;
                }

            }

            return pesos;
        }

      /*  public double SalidaNeuronaXCapa(RedNeuronal redNeuronal)
        {
            double[] Hi = { };

            return Hi;
        }*/
   
        public void ActualizarPesosXCapa()
        {

        }
    
        //public void ActualizarUmbralesXCapa() { }

        public double FuncionSigmoidal(double x)
        {
            return  (1)/(1 + Math.Exp(-x));
        }

        public double FuncionTangenteHiperbolida(double x)
        {
            return Math.Tanh(-x);
        }

        public double FuncionGaussiana(double x)
        {
            return Math.Tanh(-x);
        }
    }
}
