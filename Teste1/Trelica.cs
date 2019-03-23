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
        


        public double Forca
        {
            get; set;


        }

        public static bool ValidaTrelica(int NumNos,int NumBarras, int NumRapoios)
        {
            if((NumNos*2)==(NumBarras+NumRapoios) | (NumNos * 2) > (NumBarras + NumRapoios))
            {
                return true;
            }
            else
            {
                return false;
            }
            


        }


    }
}
