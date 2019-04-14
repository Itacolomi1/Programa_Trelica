using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste1
{
     public class Forca
    {
        private string sentido;
        private double valor;
        private PointF no_aplicado;
        
        
        public PointF No_Aplicado { get; set; }


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

       



    }
}
