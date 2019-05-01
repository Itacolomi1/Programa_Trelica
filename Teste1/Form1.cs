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

        Graphics g = null; // initialize in Form_Load with this.CreateGraphics()
        int Num_RE_apoios;
        private void Form1_Load(object sender, EventArgs e)
        {
            g = pictureBox1.CreateGraphics();
            Tre_forca.Visible = false;
            DoubleBuffered = true;
            Num_RE_apoios = 2;



            cb_sentido.Items.Add("Cima");
            cb_sentido.Items.Add("Baixo");
            cb_sentido.Items.Add("Direita");
            cb_sentido.Items.Add("Esquerda");
        }

        private PointF MouseDownPt, MouseMovePt;
        private int MouseStaus = 0;
        bool F_NO = true;
        PointF VA;
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                PointF pt = GetScalePtFromClientPt(e.Location);
                MouseDownPt = SnapToGrid(pt);
                MouseMovePt = MouseDownPt;
                MouseStaus = 1;

                if (F_NO == true)
                {
                    VA = MouseDownPt;
                    F_NO = false;
                }
            }



        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {

            shapes.Clear();
            pictureBox1.Refresh();
            Nosverdade.Clear();
            F_NO = true;
            Num_RE_apoios = 2;
        }


        public static Dictionary<PointF, double> Angulo(Dictionary<int, Shape> Barras)
        {
            Barras.OrderBy(y => y.Key);
            Dictionary<PointF, double> Angulos = new Dictionary<PointF, double>();

            // Barra 1
            double Xinicial;
            double Yinicial;

            // Barra 2
            double Xfinal;
            double Yfinal;

            PointF Nozes = new PointF { X = 0, Y = 0 };

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

                    //Pega o Nó comum entre as barras
                    if (Barras[i].pt1 == Barras[i + 1].pt1)
                    {
                        Nozes = Barras[i].pt1;
                    }
                    if (Barras[i].pt2 == Barras[i + 1].pt2)
                    {
                        Nozes = Barras[i].pt2;
                    }
                    if (Barras[i].pt1 == Barras[i + 1].pt2)
                    {
                        Nozes = Barras[i].pt1;
                    }
                    if (Barras[i].pt2 == Barras[i + 1].pt1)
                    {
                        Nozes = Barras[i].pt2;
                    }




                    //Angulos.Add(Math.Abs((Math.Atan2(Yinicial, Xinicial) - Math.Atan2(Yfinal, Xfinal)) * 180 / Math.PI));

                    double Angle = Math.Atan2(Barras[i].pt2.Y - Barras[i].pt1.Y, Barras[i].pt2.X - Barras[i].pt1.X) - Math.Atan2(Barras[i + 1].pt2.Y - Barras[i + 1].pt1.Y, Barras[i + 1].pt2.X - Barras[i + 1].pt1.X);
                    Angle = Angle * (180 / Math.PI);

                    if (Angle < 0)
                        Angle = 180 + Angle;
                    else
                        Angle = Angle - 180;

                    Angulos.Add(Nozes, Angle);
                }

                else
                {
                    Xinicial = Math.Abs(Barras[i].pt2.X - Barras[i].pt1.X);
                    Yinicial = Math.Abs(Barras[i].pt2.Y - Barras[i].pt1.Y);

                    Xfinal = Math.Abs(Barras[0].pt2.X - Barras[0].pt1.X);
                    Yfinal = Math.Abs(Barras[0].pt2.Y - Barras[0].pt1.Y);


                    //Pega o Nó comum entre as barras
                    if (Barras[i].pt1 == Barras[0].pt1)
                    {
                        Nozes = Barras[i].pt1;
                    }
                    if (Barras[i].pt2 == Barras[0].pt2)
                    {
                        Nozes = Barras[i].pt2;
                    }
                    if (Barras[i].pt1 == Barras[0].pt2)
                    {
                        Nozes = Barras[i].pt1;
                    }
                    if (Barras[i].pt2 == Barras[0].pt1)
                    {
                        Nozes = Barras[i].pt2;
                    }

                    //Angulos.Add(Math.Abs((Math.Atan2(Yinicial, Xinicial) - Math.Atan2(Yfinal, Xfinal)) * 180 / Math.PI));

                    double Angle = Math.Atan2(Barras[i].pt2.Y - Barras[i].pt1.Y, Barras[i].pt2.X - Barras[i].pt1.X) - Math.Atan2(Barras[0].pt2.Y - Barras[0].pt1.Y, Barras[0].pt2.X - Barras[0].pt1.X);
                    Angle = Angle * (180 / Math.PI);

                    if (Angle < 0)
                        Angle = 180 + Angle;
                    else
                        Angle = Angle - 180;

                    Angulos.Add(Nozes, Angle);
                }
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

        public double[] Pega_Trelica_resp (List<PointF> Nos, List<Forca> Forca)
        {
            Nos = Nos.OrderBy(orde => orde.X).ToList();
            Forca = Forca.OrderBy(ordem => ordem.No_aplicado.X).ToList();
            double[] matriz = new double[Nos.Count() * 2];
            int horizontal = 0, vertical=1;

            foreach (var no in Nos)
            {
                foreach (var forci in Forca)
                {
                    if(no==forci.No_aplicado)
                    {

                        switch (forci.Sentido)
                        {
                            case "Cima":
                                matriz[vertical] += forci.Valor;
                                break;
                            case "Baixo":
                                matriz[vertical] -= forci.Valor;
                                break;
                            case "Direita":
                                matriz[horizontal] += forci.Valor;
                                break;

                            case "Esquerda":
                                matriz[horizontal] -= forci.Valor;
                                break;

                        }


                    }
                }
                horizontal+=2;
                vertical+=2;
            }


            return matriz;

        



        }


        public double[,] PegaInformacaoTrelica(List<PointF> Nos)
        {
            double[,] Matriz = new double[(Nos.Count() * 2), shapes.Count + 3];
            Nos = Nos.OrderBy(orde => orde.X).ToList();
            Dictionary<PointF, Forca> Horizontal_Direita = new Dictionary<PointF, Forca>();
            Dictionary<PointF, Forca> Horizontal_Esquerda = new Dictionary<PointF, Forca>();
            Dictionary<PointF, Forca> VErtical_Cima = new Dictionary<PointF, Forca>();
            Dictionary<PointF, Forca> Vertical_Baixo = new Dictionary<PointF, Forca>();
            int x = shapes.Count;
            int z = (Nos.Count() * 2);
            int cont = 0;
            int dinheiros = 0;

            // Assumir sinal das forças como os sinais dos eixos(Dierita e Cima + e Baixo e Esquerda -)


            double[,] matriz = new double[Nos.Count * 2, shapes.Count + 3];
            int linha = 0, coluna = 0;

            foreach (var no in Nos)// Preenchera a matriz
            {
                if (VA == no)// Coloca apoio fixo na matriz
                {
                    matriz[linha, coluna] = 1;
                    matriz[linha + 1, ++coluna] = 1;
                    matriz[linha + 1, ++coluna] = 0;
                }
                else if (VB == no)// Coloca apoio móvel na matriz
                {
                    matriz[linha, coluna] = 0;
                    matriz[linha + 1, ++coluna] = 0;
                    matriz[linha + 1, ++coluna] = 1;
                }
                else// Se não for apoio deve pular as colunas dos mesmos
                {
                    coluna += 2;
                }

                foreach (var barra in shapes)// Coloca na matriz as barras que possuem o nó atual como inicial ou final
                {
                    coluna++;
                    double anguloRad = barra.Value.Agulo * (Math.PI / 180);

                    if (barra.Value.pt1 == no)
                    {
                        //matriz[linha, coluna] = Math.Cos(barra.Value.Agulo * Math.PI/180 );
                        //matriz[linha + 1, coluna] = Math.Sin(barra.Value.Agulo * Math.PI/180);

                        matriz[linha, coluna] = Math.Round(Math.Cos(anguloRad), 9);
                        matriz[linha + 1, coluna] = Math.Round(Math.Sin(anguloRad), 9);
                    }
                    else if (barra.Value.pt2 == no)
                    {
                        // Multiplica-se por -1 pois barras possuem angulos padronizados que vão do ponto inicial para o final
                        //matriz[linha, coluna] = Math.Cos(barra.Value.Agulo * Math.PI / 180) * -1 ;
                        //matriz[linha + 1, coluna] = Math.Sin(barra.Value.Agulo * Math.PI / 180) * -1;
                        matriz[linha, coluna] = Math.Round((Math.Cos(anguloRad)) * -1, 9);
                        matriz[linha + 1, coluna] = Math.Round((Math.Sin(anguloRad)) * -1, 9);
                        // feito apenas para commit
                    }
                }

                coluna++;

                //foreach (clsVetorForca vf in vetores)// Coloca na matriz os vetores já conhecidos na última coluna (considerar como o outro lado do =)
                //{
                //    if (vf.PontaVetor == no.Value)
                //    {

                //        switch (vf.SentidoVetor)
                //        {
                //            case 0:
                //                matriz[linha + 1, coluna] += vf.IntensidadeForca;
                //                break;

                //            case 1:
                //                matriz[linha + 1, coluna] -= vf.IntensidadeForca;
                //                break;

                //            case 2:
                //                matriz[linha, coluna] -= vf.IntensidadeForca;
                //                break;

                //            default:
                //                matriz[linha, coluna] += vf.IntensidadeForca;
                //                break;
                //        }
                //    }
                //}

                linha += 2;
                coluna = 0;
            }








            return matriz;
        }

        private void btn_Valida_Click(object sender, EventArgs e)
        {

            Forca force = new Forca();
            force.Sentido = "Cima";
            force.Valor = 0;

            //Forca_Vertical_Cima.Add(VA, force);
            //Forca_Vertical_Cima.Add(VB, force);
            Trelica Tre = new Trelica();

            Tre.Barras = shapes.Count();

            //Pegar as barras que possuem os nós 
            //List<Shape> Barras_Nos = shapes.Where(x => Nosverdade.Contains(x.Value.pt1) && Nosverdade.Contains(x.Value.pt2)).ToList();
            Tre.Nos = Nosverdade.Count();




            CB_Nos.DataSource = Nosverdade;
            ////List<double> AngulosVerdade = Angulo(shapes);

            if (ValidaTrelica(Tre.Nos, Tre.Barras, Num_RE_apoios) == true)
            {
                MessageBox.Show("Treliça Válida");
                

                //Pega os Nós
                //List<PointF> Nosverdadeiros = Nos.GroupBy(valor => new { valor.X, valor.Y }).Select(gcs => new PointF { X = gcs.Key.X, Y = gcs.Key.Y }).ToList();

                //List<PointF> Nosverdadeiros = Nos.GroupBy(valor => new { valor.X, valor.Y }).Select(gcs => new PointF { X = gcs.Key.X, Y = gcs.Key.Y }).ToList();
                double[,] A_1 = PegaInformacaoTrelica(Nosverdade);
                double[] B_1 = Pega_Trelica_resp(Nosverdade, Forca_Trelica);

                //double[,] A = { { -1, 0, 0, 1, 0, 0, 0, 0 }, { 0, -1, 0, 0, 1, 0, 0, 0 }, { 0, 0, -1, 0, 0, 0.3846, 1, 0 }, { 0, 0, 0, 0, -1, -0.9230, 0, 0 }, { 0, 0, 0, -1, 0, -0.3846, 0, 0 }, { 0, 0, 0, 0, 0, 0.9230, 0, 1 }, { 0, 0, 0, 0, 0, 0, 0 - 1, 0 }, { 0, 0, 0, 0, 0, 0, 0, -1 } };
                //double[] b = { 0, 0, 0, 0, -26, 15, -12, 0 };
                double[] x = gaussSolver(A_1, B_1);

                foreach (double item in x)
                {
                    txtRespostas.Text += item + Environment.NewLine;
                }
                




            }
            else
            {
                MessageBox.Show("Treliça Inválida");
            }
            if (shapes.Count > 0)
            {
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
                    double Angle = (Math.Atan2(shp.pt2.Y - shp.pt1.Y, shp.pt2.X - shp.pt1.X))* 180/Math.PI;
                    shp.Agulo = Angle * -1;
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
        double Maior = 0;

        PointF VB;

        
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
                    if (item.Y == VA.Y && item.X != VA.X && Maior < item.X)
                    {
                        VB = item;
                        Maior = item.X;
                    }

                }
            }

            if (Nosverdade.Count != 0)
            {
              
                Tre_forca.Visible = true;

                V_nos = 1;

                Inicio = Nosverdade[0];


                CB_Nos.DataSource = Nosverdade;

            }

            else
            {
                MessageBox.Show("Nenhum nó foi identificado");
            }

            //flecha.DrawLine(new Pen(Color.Red, flecha.VisibleClipBounds.Width / 100), forca.Inicio, GetScalePtFromClientPt( new PointF(forca.Inicio.X - 15, forca.Inicio.Y - 15)));
        }


        #region Evento_Adiciona_Pega_Forca
        List<Forca> Forca_Trelica = new List<Forca>();
        
        bool Re_apoio_3 = true;
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

                    Forca_Trelica.Add( force);


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
                    //if (Re_apoio_3 == true)
                    //{
                    //    Num_RE_apoios++;
                    //    force.Sentido = "Esquerda";
                    //    force.No_aplicado = VA;
                    //    Forca_Horizontal_Esquerda.Add(VA, force);


                    //    Re_apoio_3 = false;
                    //}

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

                    //if (Re_apoio_3 == true)
                    //{
                    //    Num_RE_apoios++;
                    //    force.Sentido = "Direita";
                    //    force.No_aplicado = VA;
                    //    Forca_Trelica.Add(force);

                    //    Re_apoio_3 = false;
                    //}


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
        #region MetodoCalculaTrelica_PegaInformação
        public static double[] gaussSolver(double[,] A, double[] b)
        {
            double y = Math.Sqrt(A.Length);
            //ETAPA DE ESCALONAMENTO
            for (int k = 0; k < y; k++)
            {
                //procura o maior k-ésimo coeficiente em módulo
                double max = Math.Abs(A[k, k]);
                int maxIndex = k;
                for (int i = k + 1; i < y; i++)
                {
                    if (max < Math.Abs(A[i, k]))
                    {
                        max = Math.Abs(A[i, k]);
                        maxIndex = i;
                    }
                }
                if (maxIndex != k)
                {
                    /*
                    troca a equação k pela equação com o
                    maior k-ésimo coeficiente em módulo
                    */
                    double temp;
                    for (int j = 0; j < y; j++)
                    {
                        temp = A[k, j];
                        A[k, j] = A[maxIndex, j];
                        A[maxIndex, j] = temp;
                    }
                    temp = b[k];
                    b[k] = b[maxIndex];
                    b[maxIndex] = temp;
                }
                //Se A[k][k] é zero, então a matriz dos coeficiente é singular
                //det A = 0
                if (A[k, k] == 0)
                {
                    return null;
                }
                else
                {
                    //realiza o escalonamento
                    for (int m = k + 1; m < y; m++)
                    {
                        double F = -A[m, k] / A[k, k];
                        A[m, k] = 0; //evita uma iteração
                        b[m] = b[m] + F * b[k];
                        for (int l = k + 1; l < y; l++)
                        {
                            A[m, l] = A[m, l] + F * A[k, l];
                        }
                    }
                }
            }
            //ETAPA DE RESOLUÇÃO DO SISTEMA
            int yy = Convert.ToInt32(y);
            double[] X = new double[yy];
            for (int i = yy - 1; i >= 0; i--)
            {
                X[i] = b[i];
                for (int j = i + 1; j < yy; j++)
                {
                    X[i] = X[i] - X[j] * A[i, j];
                }
                X[i] = X[i] / A[i, i];
            }
            return X;
        }


        #endregion

    }


}
