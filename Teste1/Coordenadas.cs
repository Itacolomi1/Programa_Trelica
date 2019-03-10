using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste1
{
    public class Coordenadas
    {
        private Point pontoI;
        private Point pontoF;

        public Coordenadas()
        {
            
        }


        public Point PontoInicial
        {
            get
            {
                return pontoI;
            }

            set
            {
                pontoI = value;
            }
        }




        public Point PontoFinal
        {
            get
            {
                return pontoF;
            }

            set
            {
                pontoF = value;
            }
        }



    }
}
