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
        private PointF pontoI;
        private PointF pontoF;

        public Coordenadas()
        {
            
        }


        public PointF PontoInicial
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




        public PointF PontoFinal
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
