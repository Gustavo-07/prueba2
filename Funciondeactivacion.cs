using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackpropagationAndPerceptron
{
    class Funciondeactivacion
    {
        double res;
        string funcion;
        float salidaCapa;
        public Funciondeactivacion(string funcion, float salidaCapa)
        {
            this.funcion = funcion;
            this.salidaCapa = salidaCapa;
        }
        public float getfunActivacion()
        {
            switch (funcion)
            {
                case "Lineal.":
                    if (salidaCapa >= 0)
                        this.res = 1;
                    else
                        this.res = 0;
                    break;
                case "Bipolar.":
                    if (salidaCapa >= 0)
                        this.res = 1;
                    else
                        this.res = -1;
                    break;
                case "Sigmoidal.":
                    this.res = 1 / (1 + Math.Pow(Math.E, -salidaCapa));
                    break;
                case "Tangente hiperbólica.":
                    this.res = Math.Tanh(salidaCapa);
                    break;
                case "Seno.":
                    this.res = Math.Sin(salidaCapa);
                    break;
                case "Coseno.":
                    this.res = Math.Cos(salidaCapa);
                    break;
                case "Gausiana.":
                    this.res = Math.Pow(Math.E, -Math.Pow(salidaCapa, 2));
                    break;
            }
            return (float.Parse(this.res.ToString()));
        }
    }
}
