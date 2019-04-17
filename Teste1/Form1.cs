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

            Pontos = new Coordenadas();
            g = pictureBox1.CreateGraphics();

        }
        Coordenadas Pontos;







        #region Desenha o Grid

        private PointF Corner = new Point(-5, -5);
        private Single gridStep = 20;
        private Single ScaleWidth = 200;


        private int RoundToIncrement(double theValue, int roundIncrement)
        {
            return Convert.ToInt32((Convert.ToDouble(theValue) + (0.5 * roundIncrement)) / roundIncrement) * roundIncrement;
        }


        private void DrawGrid(Graphics g)
        {
            Single x1 = RoundToIncrement(Corner.X - gridStep, Convert.ToInt32(gridStep));
            Single y1 = RoundToIncrement(Corner.Y - gridStep, Convert.ToInt32(gridStep));

            Single sw = Convert.ToSingle(ScaleWidth + (2 * gridStep));
            double pxlSize = ScaleWidth / pictureBox1.ClientSize.Width;

            Graphics graphics = g;

            using (Pen pg = new Pen(Color.DarkGray, Convert.ToSingle(pxlSize / 6)))
            {
                Font f = new Font("arial", Convert.ToSingle(11 * pxlSize));
                SolidBrush br = new SolidBrush(Color.DimGray);

                for (Single x = x1; x <= Convert.ToSingle(x1 + sw); x = x + gridStep)
                {
                    graphics.DrawLine(pg, x, y1, x, Convert.ToSingle(y1 + sw));
                    graphics.DrawString(x.ToString(), f, br, x, Corner.Y);
                }

                for (Single y = y1; y <= Convert.ToSingle(y1 + sw); y = y + gridStep)
                {
                    graphics.DrawLine(pg, x1, y, Convert.ToSingle(x1 + sw), y);
                    graphics.DrawString(y.ToString(), f, br, Corner.X, y);
                }
            }
        }

        #endregion

        #region EncontroGrid
        private Single SnapStep = 5;

        private PointF GetScalePtFromClientPt(PointF pt)//Converte para a escala da Picture Box
        {
            double sf = pictureBox1.ClientSize.Width / ScaleWidth;
            return new PointF(Convert.ToSingle(Corner.X + (pt.X / sf)), Convert.ToSingle(Corner.Y + (pt.Y / sf)));
        }

        private PointF SnapToGrid(PointF thispt)//Deixa os números inteiros.
        {
            Single x = Convert.ToInt32(thispt.X / SnapStep) * SnapStep;
            Single y = Convert.ToInt32(thispt.Y / SnapStep) * SnapStep;
            return new PointF(x, y);
        }

        #endregion


        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {


        }


        Graphics g = null; // initialize in Form_Load with this.CreateGraphics()





        private void Form1_Load(object sender, EventArgs e)
        {
            g = pictureBox1.CreateGraphics();
            Tre_forca.Visible = false;
            DoubleBuffered = true;
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


            cb_sentido.Items.Add("Cima");
            cb_sentido.Items.Add("Baixo");
            cb_sentido.Items.Add("Direita");
            cb_sentido.Items.Add("Esquerda");


        }



        private PointF MouseDownPt, MouseMovePt;
        private int MouseStaus = 0;
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {


            if (e.Button == MouseButtons.Left)
            {
                PointF pt = GetScalePtFromClientPt(e.Location);
                MouseDownPt = SnapToGrid(pt);
                MouseMovePt = MouseDownPt;
                MouseStaus = 1;
            }





            //if (cont == 0)
            //{
            //    Pontos.PontoInicial = GetScalePtFromClientPt(e.Location); 

            //    cont++;


            //}
            //else
            //{
            //    Pontos.PontoFinal = GetScalePtFromClientPt(e.Location); 

            //    g.DrawLine(Pens.Black, SnapToGrid(Pontos.PontoInicial), SnapToGrid(Pontos.PontoFinal));
            //    cont = 0;
            //}

        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {

            shapes.Clear();
            pictureBox1.Refresh();
            Nosverdade.Clear();


        }


        public static List<double> Angulo(Dictionary<int, Shape> Barras)
        {
            Barras.OrderBy(y => y.Key);
            List<double> Angulos = new List<double>();

            // Barra 1
            double Xinicial;
            double Yinicial;

            // Barra 2
            double Xfinal;
            double Yfinal;

            for (int i = 0; i < Barras.Keys.Count(); i++)
            {
                if (i != Barras.Keys.Count - 1)
                {
                    //Angulos.Add(Math.Atan2(Barras[i].pt2.Y - Barras[i].pt1.Y, Barras[i].pt2.X - Barras[i].pt1.X) -
                    //Math.Atan2(Barras[i + 1].pt2.Y - Barras[i + 1].pt1.Y, Barras[i + 1].pt2.X - Barras[i + 1].pt1.X));

                    Xinicial = Math.Abs(Barras[i].pt2.X - Barras[i].pt1.X);
                    Yinicial = Math.Abs(Barras[i].pt2.Y - Barras[i].pt1.Y);

                    Xfinal = Math.Abs(Barras[i + 1].pt2.X - Barras[i + 1].pt1.X);
                    Yfinal = Math.Abs(Barras[i + 1].pt2.Y - Barras[i + 1].pt1.Y);

                    Angulos.Add(Math.Abs((Math.Atan2(Yinicial, Xinicial) - Math.Atan2(Yfinal, Xfinal)) * 180 / Math.PI));
                }
                else
                {
                    Xinicial = Math.Abs(Barras[i].pt2.X - Barras[i].pt1.X);
                    Yinicial = Math.Abs(Barras[i].pt2.Y - Barras[i].pt1.Y);

                    Xfinal = Math.Abs(Barras[0].pt2.X - Barras[0].pt1.X);
                    Yfinal = Math.Abs(Barras[0].pt2.Y - Barras[0].pt1.Y);

                    Angulos.Add(Math.Abs((Math.Atan2(Yinicial, Xinicial) - Math.Atan2(Yfinal, Xfinal)) * 180 / Math.PI));
                }

                //Angulos.Add(Math.Atan2(Barras[i].pt2.Y - Barras[i].pt1.Y, Barras[i].pt2.X - Barras[i].pt1.X) -
                // Math.Atan2(Barras[i + 1].pt2.Y - Barras[i + 1].pt1.Y, Barras[i + 1].pt2.X - Barras[i + 1].pt1.X));

            }
            //Double Angle = Math.Atan2(y2 - y1, x2 - x1) - Math.Atan2(y4 - y3, x4 - x3);

            return Angulos;

        }

        List<PointF> Nosverdade = new List<PointF>();


        #region ValidaTrelica

        public static bool ValidaTrelica(int NumNos, int NumBarras, int NumRapoios)
        {
            if ((NumNos * 2) == (NumBarras + NumRapoios) || (NumNos * 2) > (NumBarras + NumRapoios))
            {
                return true;
            }
            else
            {
                return false;
            }


        }
        private void btn_Valida_Click(object sender, EventArgs e)
        {
            Trelica Tre = new Trelica();

            Tre.Barras = shapes.Count();



            //Pegar as barras que possuem os nós 
            //List<Shape> Barras_Nos = shapes.Where(x => Nosverdade.Contains(x.Value.pt1) && Nosverdade.Contains(x.Value.pt2)).ToList();
            Tre.Nos = Nosverdade.Count();




            CB_Nos.DataSource = Nosverdade;
            ////List<double> AngulosVerdade = Angulo(shapes);

            if (ValidaTrelica(Tre.Nos, Tre.Barras, 2) == true)
            {
                MessageBox.Show("Treliça Válida");



                //Pega os Nós
                //List<PointF> Nosverdadeiros = Nos.GroupBy(valor => new { valor.X, valor.Y }).Select(gcs => new PointF { X = gcs.Key.X, Y = gcs.Key.Y }).ToList();

                //List<PointF> Nosverdadeiros = Nos.GroupBy(valor => new { valor.X, valor.Y }).Select(gcs => new PointF { X = gcs.Key.X, Y = gcs.Key.Y }).ToList();
            }
            else
            {
                MessageBox.Show("Treliça Inválida");
            }
            if (shapes.Count > 0)
            {
                Angulo(shapes);
            }
        }
        #endregion

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                switch (MouseStaus)
                {
                    case 1:
                        PointF pt = GetScalePtFromClientPt(e.Location);
                        MouseMovePt = SnapToGrid(pt);
                        pictureBox1.Invalidate();
                        break;
                }
            }
        }
        //List<Shape> shapes = new List<Shape>();
        int contador = 0;
        Dictionary<int, Shape> shapes = new Dictionary<int, Shape>();
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            switch (MouseStaus)
            {
                case 1:
                    PointF pt = GetScalePtFromClientPt(e.Location);
                    MouseMovePt = SnapToGrid(pt);

                    Shape shp = new Shape();
                    shp.pt1 = MouseDownPt;
                    shp.pt2 = MouseMovePt;
                    shp.color = Color.Black;
                    shapes.Add(contador, shp);
                    contador++;


                    break;
            }

            MouseStaus = 0;
            pictureBox1.Invalidate();
        }

        private void pictureBox1_Resize(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
        }
        int V_nos = 0;
        PointF Inicio;
        bool valida;
        private void Conta_Nos(object sender, EventArgs e)
        {

            List<PointF> Nos = new List<PointF>();
            List<PointF> teste = new List<PointF>();


            foreach (var item in shapes.Values)
            {
                Nos.Add(item.pt1);
                Nos.Add(item.pt2);

            }


            foreach (var item in Nos)
            {
                if (!teste.Contains(item))
                {
                    teste.Add(item);
                }
                else if (!Nosverdade.Contains(item))
                {
                    Nosverdade.Add(item);
                }
            }
            if (Nosverdade.Count != 0)
            {
                Tre_forca.Visible = true;

                V_nos = 1;

                Inicio = Nosverdade[0];

                CB_Nos.DataSource = Nosverdade;
                valida = true;









            }
            else
            {
                MessageBox.Show("Nenhum nó foi identificado");
            }

            //flecha.DrawLine(new Pen(Color.Red, flecha.VisibleClipBounds.Width / 100), forca.Inicio, GetScalePtFromClientPt( new PointF(forca.Inicio.X - 15, forca.Inicio.Y - 15)));



        }

        //public List<double> CalculaReacao(List<Forca> F)
        //{
        //    List<double> Reacao = new List<double>();
        //    double AB = 0;
        //    double PontoMaisAlto = 0;
        //    foreach (var item in F)
        //    {
        //        if (item.Sentido == "Baixo")
        //            AB += item.Valor;
        //        if (item.No_aplicado.Y > PontoMaisAlto)
        //        {
        //            PontoMaisAlto = item.No_aplicado.Y;
        //        }
        //    }
        //    PointF Inicio = F[0].No_aplicado;
        //    double distancia = 0;
        //    double Momento = 0;

        //    for (int i = 0; i < F.Count(); i++)
        //    {
        //        distancia = F[i].No_aplicado.X - Inicio.X;
        //        if (F[i].Sentido == "Baixo")
        //        {
        //            Momento += (F[i].Valor * distancia);
        //        }

        //        if (F[i].Sentido == "Cima")
        //        {
        //            Momento -= (F[i].Valor * distancia);
        //        }

        //        if (F[i].Sentido == "Direita")
        //        {


        //        }


        //    }
        //}



        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Left && valida == true)
            //{
            //    PointF ponto = GetScalePtFromClientPt(e.Location);

            //    Single sf = Convert.ToSingle(pictureBox1.ClientSize.Width / ScaleWidth);
            //    g.ScaleTransform(sf, sf);
            //    g.TranslateTransform(-Corner.X, -Corner.Y);

            //    g.DrawLine(new Pen(Color.Red, g.VisibleClipBounds.Width / 100), ponto, new PointF(ponto.X, ponto.Y- 15));




            //}
        }

        #region Evento_Adiciona_Pega_Forca
        List<Forca> Forca_Trelica = new List<Forca>();
        private void btn_addForca_Click(object sender, EventArgs e)
        {
            try
            {


                Erro.Clear();
                if (string.IsNullOrEmpty(txtForca.Text))
                {
                    Erro.SetError(txtForca, "Digite Algum valor nesta Força");
                    return;
                }
                if (cb_sentido.SelectedItem == null)
                {
                    Erro.SetError(cb_sentido, "Escolha o sentido da Força");
                    return;
                }
                if (CB_Nos.SelectedItem == null)
                {
                    Erro.SetError(cb_sentido, "Escolha o Nó desejado");
                    return;
                }

                if (cb_sentido.SelectedItem.ToString() == "Baixo")
                {
                    //Pego o nó selecionado
                    PointF Ponto = (PointF)CB_Nos.SelectedItem;
                    //Pego o valor, sentidp e nó da Força
                    Forca force = new Forca();
                    force.Valor = double.Parse(txtForca.Text);
                    force.Sentido = "Baixo";
                    force.No_aplicado = Ponto;

                    Forca_Trelica.Add(force);//Adiciono na Lista de Forças

                    //as próximas 5 linhas transformam as coordenadasda picturebox, na escala correta
                    g.ResetTransform();

                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                    Single sf = Convert.ToSingle(pictureBox1.ClientSize.Width / ScaleWidth);
                    g.ScaleTransform(sf, sf);
                    g.TranslateTransform(-Corner.X, -Corner.Y);

                    //Desenho a flecha
                    g.DrawLine(new Pen(Color.Red, g.VisibleClipBounds.Width / 100), Ponto, new PointF(Ponto.X, Ponto.Y - 15));
                    g.DrawLine(new Pen(Color.Red, g.VisibleClipBounds.Width / 100), Ponto, new PointF(Ponto.X - 5, Ponto.Y - 5));
                    g.DrawLine(new Pen(Color.Red, g.VisibleClipBounds.Width / 100), Ponto, new PointF(Ponto.X + 5, Ponto.Y - 5));
                }



                if (cb_sentido.SelectedItem.ToString() == "Cima")
                {
                    PointF Ponto = (PointF)CB_Nos.SelectedItem;

                    Forca force = new Forca();
                    force.Valor = double.Parse(txtForca.Text);
                    force.Sentido = "Cima";
                    force.No_aplicado = Ponto;

                    Forca_Trelica.Add(force);

                    g.ResetTransform();


                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                    Single sf = Convert.ToSingle(pictureBox1.ClientSize.Width / ScaleWidth);
                    g.ScaleTransform(sf, sf);
                    g.TranslateTransform(-Corner.X, -Corner.Y);


                    g.DrawLine(new Pen(Color.Red, g.VisibleClipBounds.Width / 100), Ponto, new PointF(Ponto.X, Ponto.Y + 15));
                    g.DrawLine(new Pen(Color.Red, g.VisibleClipBounds.Width / 100), Ponto, new PointF(Ponto.X - 5, Ponto.Y + 5));
                    g.DrawLine(new Pen(Color.Red, g.VisibleClipBounds.Width / 100), Ponto, new PointF(Ponto.X + 5, Ponto.Y + 5));
                }

                if (cb_sentido.SelectedItem.ToString() == "Direita")
                {
                    PointF Ponto = (PointF)CB_Nos.SelectedItem;

                    Forca force = new Forca();
                    force.Valor = double.Parse(txtForca.Text);
                    force.Sentido = "Direita";
                    force.No_aplicado = Ponto;

                    Forca_Trelica.Add(force);

                    g.ResetTransform();




                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                    Single sf = Convert.ToSingle(pictureBox1.ClientSize.Width / ScaleWidth);
                    g.ScaleTransform(sf, sf);
                    g.TranslateTransform(-Corner.X, -Corner.Y);


                    g.DrawLine(new Pen(Color.Red, g.VisibleClipBounds.Width / 100), Ponto, new PointF(Ponto.X - 15, Ponto.Y));
                    g.DrawLine(new Pen(Color.Red, g.VisibleClipBounds.Width / 100), Ponto, new PointF(Ponto.X - 5, Ponto.Y + 5));
                    g.DrawLine(new Pen(Color.Red, g.VisibleClipBounds.Width / 100), Ponto, new PointF(Ponto.X - 5, Ponto.Y - 5));
                }

                if (cb_sentido.SelectedItem.ToString() == "Esquerda")
                {
                    PointF Ponto = (PointF)CB_Nos.SelectedItem;

                    Forca force = new Forca();
                    force.Valor = double.Parse(txtForca.Text);
                    force.Sentido = "Esquerda";
                    force.No_aplicado = Ponto;

                    Forca_Trelica.Add(force);

                    g.ResetTransform();




                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                    Single sf = Convert.ToSingle(pictureBox1.ClientSize.Width / ScaleWidth);
                    g.ScaleTransform(sf, sf);
                    g.TranslateTransform(-Corner.X, -Corner.Y);




                    g.DrawLine(new Pen(Color.Red, g.VisibleClipBounds.Width / 100), Ponto, new PointF(Ponto.X + 15, Ponto.Y));
                    g.DrawLine(new Pen(Color.Red, g.VisibleClipBounds.Width / 100), Ponto, new PointF(Ponto.X + 5, Ponto.Y + 5));
                    g.DrawLine(new Pen(Color.Red, g.VisibleClipBounds.Width / 100), Ponto, new PointF(Ponto.X + 5, Ponto.Y - 5));
                }
            }
            catch (Exception msg)
            {
                MessageBox.Show(msg.Message);


            }


        }
        #endregion

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

            Graphics Graficos = e.Graphics;

            Graficos.ResetTransform();

            Graficos.Clear(Color.White);
            Graficos.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            Single sf = Convert.ToSingle(pictureBox1.ClientSize.Width / ScaleWidth);
            Graficos.ScaleTransform(sf, sf);
            Graficos.TranslateTransform(-Corner.X, -Corner.Y);


            DrawGrid(e.Graphics);

            foreach (Shape shp in shapes.Values)
            {
                shp.Draw(e.Graphics);
            }

            switch (MouseStaus)
            {
                case 1:
                    Graficos.DrawLine(new Pen(Color.Black, Graficos.VisibleClipBounds.Width / 100), MouseDownPt, MouseMovePt);
                    break;
            }

            switch (V_nos)
            {
                case 1:
                    Graficos.DrawLine(new Pen(Color.Red, Graficos.VisibleClipBounds.Width / 100), Inicio, new PointF(Inicio.X, Inicio.Y + 10));
                    break;
            }


        }
    }
}
