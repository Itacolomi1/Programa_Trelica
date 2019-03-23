using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Teste1
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            cont = 0;
            Pontos = new Coordenadas();
            g = pictureBox1.CreateGraphics();

        }
        Coordenadas Pontos;

        int cont;



        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {


        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        { 

            
        }




       

        bool verifica;
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            
           
                                   
        }



        private void groupBox1_CursorChanged(object sender, EventArgs e)
        {

        }




        Graphics g = null; // initialize in Form_Load with this.CreateGraphics()
        



        private void Form1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void Form1_MouseMove_1(object sender, MouseEventArgs e)
        {
           
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (cont == 0)
            {
                Pontos.PontoInicial = e.Location;
                cont++;
                Console.WriteLine('h');

            }
            else
            {
                Pontos.PontoFinal = e.Location;
                g.DrawLine(Pens.Black, Pontos.PontoInicial, Pontos.PontoFinal);
                cont = 0;
            }

        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
        }

        private void btn_Valida_Click(object sender, EventArgs e)
        {
            if(Trelica.ValidaTrelica(4,5,3)== true)
            {
                MessageBox.Show("Treliça Válida");
            }
            else
            {
                MessageBox.Show("Treliça Inválida");
            }
        }
    }
}
