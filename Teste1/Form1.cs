using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
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
            string[] dados = File.ReadAllLines("dados.txt");
            double[,] matriz = new double[8, 8];
            for (int i = 0; i < 8; i++)
            {
                for (int y = 0; y < 8; y++)
                {
                    matriz[i, y] = 0;
                }
            }
            string[] nums = File.ReadAllLines("num.txt");
            int t = 0;
            for (int i = 0; i < dados.Length; i++)
            {
                int a = int.Parse(nums[t][0].ToString());
                int b = int.Parse(nums[t][1].ToString());
                int c = int.Parse(nums[t][2].ToString());
                int d = int.Parse(nums[t][3].ToString());

                string mod = dados[i];
                double px = double.Parse(mod.Substring(0, mod.IndexOf(','))) / 10;
                mod = mod.Remove(0, mod.IndexOf(',') + 1);
                double py = double.Parse(mod.Substring(0, mod.IndexOf('|'))) / 10;
                mod = mod.Remove(0, mod.IndexOf('|') + 1);
                double sx = double.Parse(mod.Substring(0, mod.IndexOf(','))) / 10;
                mod = mod.Remove(0, mod.IndexOf(',') + 1);
                double sy = Convert.ToDouble(mod) / 10;
                double l = Math.Sqrt((Math.Pow((sx - px), 2) + Math.Pow((sy - py), 2))) * 10;
                double cosx = (sx - px) / l;
                double cosy = (sy - sx) / l;

                matriz[a, a] = matriz[a, a] + (cosx * cosx);
                matriz[a, b] = matriz[a, b] + (cosx * cosy);
                matriz[b, a] = matriz[b, a] + (cosy * cosx);
                matriz[b, b] = matriz[b, b] + (cosy * cosy);
                matriz[a, c] = matriz[a, c] + ((-1) * cosx * cosx);
                matriz[a, d] = matriz[a, d] + ((-1) * cosx * cosy);
                matriz[b, c] = matriz[b, c] + ((-1) * cosy * cosx);
                matriz[c, d] = matriz[c, d] + ((-1) * cosy * cosy);
                matriz[c, c] = matriz[c, c] + (cosx * cosx);
                matriz[c, d] = matriz[c, d] + (cosx * cosy);
                matriz[d, c] = matriz[d, c] + (cosy * cosx);
                matriz[d, d] = matriz[d, d] + (cosy * cosy);
                matriz[c, a] = matriz[c, a] + ((-1) * cosx * cosx);
                matriz[c, b] = matriz[c, b] + ((-1) * cosx * cosy);
                matriz[d, a] = matriz[d, a] + ((-1) * cosy * cosx);
                matriz[d, b] = matriz[d, b] + ((-1) * cosy * cosy);

                t++;
            }

            double[,] matrizforca = new double[8, 1];
            matrizforca[2, 0] = 15;
            matrizforca[3, 0] = 26;
            matrizforca[4, 0] = 0;
            matrizforca[5, 0] = 12;
            matrizforca[6, 0] = 0;

            double[,] matrizdeflexao = new double[8, 1];
            double[] deflexao = new double[8];
            deflexao[0] = 0;
            deflexao[1] = 0;
            deflexao[7] = 0;

            int x = 5;
            double[,] matrizid = new double[x, x];
            for (int i = 0; i < x; i++)
            {
                for (int ii = 0; ii < x; ii++)
                {
                    if (i == ii)
                        matrizid[i, ii] = 1;
                    else
                        matrizid[i, ii] = 0;
                }
            }

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
            if (Trelica.ValidaTrelica(4, 5, 3) == true)
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
