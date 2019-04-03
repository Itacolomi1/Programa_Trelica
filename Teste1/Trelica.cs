using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste1
{
    public class Trelica
    {
        private double forca;
        private int NumNos;
        private int NumApoios;
        private int NumBarras;



        public int Nos
        {
            get
            {
                return NumNos;
            }
            set
            {
                NumNos = value;
            }


        }

        public int Barras
        {
            get
            {
                return NumBarras;
            }
            set
            {
                NumBarras = value;
            }


        }


        
        //public static List<double> Calcula_Re_Apoio(List<Forças> Forcas)
        //{
        //    double RA, RB;

        //    foreach (var item in Forcas)
        //    {


        //    }




        //}



    }
}
