using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste1
{
     public class Forças
    {
        private string sentido;
        private double valor;
        private PointF inicio; 
        



        public string Sentido
        {
            get
            {
                return sentido;
                    
            }

            set
            {
                
                
                    sentido = value;

            }
        }

        public double Valor { get; set; }

        public PointF Inicio
        { get { return inicio; } set { inicio = value; } }



    }
}
