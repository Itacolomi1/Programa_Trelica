﻿using System;
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
        
        private PointF no_aplicado;
     
        
        
        


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

        public PointF No_aplicado
        {
            get
            {
                return no_aplicado;

            }

            set
            {


                no_aplicado = value;

            }
        }

        public double Valor { get; set; }

        







    }
}
