using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Teste1
{
    public class Trelica 
    {
        
        private int NumNos;
        
        private int NumBarras;

        private List<Shape> barras1;
        

        
        


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

        public List<Shape> Barras1
        {
            get
            {
                return barras1;
            }
            set
            {
                barras1 = value;
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

        public static Dictionary<PointF ,List<Shape>> Barra_NO(Dictionary<int, Shape> barritas,List<PointF> Nozitos)
        {
            Dictionary<PointF, List<Shape>> Dicionario = new Dictionary<PointF, List<Shape>>();
            List<Shape> Perfis = new List<Shape>();
            foreach (var item in Nozitos)
            {
                foreach (var i in barritas)
                {
                    if(i.Value.pt1== item || i.Value.pt2== item)
                    {
                        Perfis.Add(i.Value);
                        Dicionario.Add(item, Perfis);
                    }
                }
            }

            return Dicionario;

        }


        
       



    }
}
