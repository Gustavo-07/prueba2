using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackpropagationAndPerceptron
{
    class Funcionderivada
    {
        double res;
        string funcion;
        float salidaCapa;
        public Funcionderivada(string funcion, float salidaCapa)
        {
            this.funcion = funcion;
            this.salidaCapa = salidaCapa;
        }
        public float getfunDerivada()
        {
            switch (funcion)
            {
                case "Sigmoidal.":
                    this.res = float.Parse((Math.Pow(Math.E, salidaCapa) / Math.Pow((Math.Pow(Math.E, salidaCapa) + 1), 2)).ToString());
                    break;
                case "Tangente hiperbólica.":
                    this.res = float.Parse((1 / Math.Pow(Math.Cosh(salidaCapa), 2)).ToString());
                    break;
                case "Seno.":
                    this.res = Math.Cos(salidaCapa);
                    break;
                case "Coseno.":
                    this.res = -Math.Sin(salidaCapa);
                    break;
                case "Gausiana.":
                    this.res = float.Parse(((-2) * Math.Pow(Math.E, -Math.Pow(salidaCapa, 2)) * salidaCapa).ToString());
                    break;
            }
            return (float.Parse(this.res.ToString()));
        }
    }
}
