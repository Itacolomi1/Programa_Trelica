using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste1
{
     public class Forças
    {
        private string sentido;
        private double valor;



        public string Sentido
        {
            get
            {
                return sentido;
                    
            }

            set
            {
                if (value != "H" || value != "AH")
                    throw new Exception("O sentido da força tem que ser H-> Horário ou AH-> Anti-Horário");
                else
                    sentido = value;

            }
        }

    }
}
