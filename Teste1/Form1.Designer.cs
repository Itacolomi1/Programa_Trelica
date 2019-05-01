namespace Teste1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btn_Valida = new System.Windows.Forms.Button();
            this.Flecha = new System.Windows.Forms.Button();
            this.txtForca = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CB_Nos = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_sentido = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Tre_forca = new System.Windows.Forms.GroupBox();
            this.btn_addForca = new System.Windows.Forms.Button();
            this.Erro = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtRespostas = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.Tre_forca.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Erro)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(297, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(357, 324);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            this.pictureBox1.Resize += new System.EventHandler(this.pictureBox1_Resize);
            // 
            // btnLimpar
            // 
            this.btnLimpar.Location = new System.Drawing.Point(141, 218);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpar.TabIndex = 1;
            this.btnLimpar.Text = "Corrigir";
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // btn_Valida
            // 
            this.btn_Valida.Location = new System.Drawing.Point(117, 143);
            this.btn_Valida.Name = "btn_Valida";
            this.btn_Valida.Size = new System.Drawing.Size(75, 23);
            this.btn_Valida.TabIndex = 2;
            this.btn_Valida.Text = "Validar";
            this.btn_Valida.UseVisualStyleBackColor = true;
            this.btn_Valida.Click += new System.EventHandler(this.btn_Valida_Click);
            // 
            // Flecha
            // 
            this.Flecha.Location = new System.Drawing.Point(24, 211);
            this.Flecha.Name = "Flecha";
            this.Flecha.Size = new System.Drawing.Size(75, 37);
            this.Flecha.TabIndex = 3;
            this.Flecha.Text = "Identificar Nós";
            this.Flecha.UseVisualStyleBackColor = true;
            this.Flecha.Click += new System.EventHandler(this.Conta_Nos);
            // 
            // txtForca
            // 
            this.txtForca.Location = new System.Drawing.Point(17, 117);
            this.txtForca.Name = "txtForca";
            this.txtForca.Size = new System.Drawing.Size(75, 20);
            this.txtForca.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Força";
            // 
            // CB_Nos
            // 
            this.CB_Nos.FormattingEnabled = true;
            this.CB_Nos.Location = new System.Drawing.Point(27, 56);
            this.CB_Nos.Name = "CB_Nos";
            this.CB_Nos.Size = new System.Drawing.Size(121, 21);
            this.CB_Nos.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Nós";
            // 
            // cb_sentido
            // 
            this.cb_sentido.FormattingEnabled = true;
            this.cb_sentido.Location = new System.Drawing.Point(109, 117);
            this.cb_sentido.Name = "cb_sentido";
            this.cb_sentido.Size = new System.Drawing.Size(101, 21);
            this.cb_sentido.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(114, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Sentido";
            // 
            // Tre_forca
            // 
            this.Tre_forca.Controls.Add(this.btn_addForca);
            this.Tre_forca.Controls.Add(this.CB_Nos);
            this.Tre_forca.Controls.Add(this.btn_Valida);
            this.Tre_forca.Controls.Add(this.label3);
            this.Tre_forca.Controls.Add(this.txtForca);
            this.Tre_forca.Controls.Add(this.cb_sentido);
            this.Tre_forca.Controls.Add(this.label1);
            this.Tre_forca.Controls.Add(this.label2);
            this.Tre_forca.Location = new System.Drawing.Point(24, 12);
            this.Tre_forca.Name = "Tre_forca";
            this.Tre_forca.Size = new System.Drawing.Size(240, 177);
            this.Tre_forca.TabIndex = 10;
            this.Tre_forca.TabStop = false;
            this.Tre_forca.Text = "Forças";
            // 
            // btn_addForca
            // 
            this.btn_addForca.Location = new System.Drawing.Point(17, 143);
            this.btn_addForca.Name = "btn_addForca";
            this.btn_addForca.Size = new System.Drawing.Size(75, 23);
            this.btn_addForca.TabIndex = 10;
            this.btn_addForca.Text = "Add Força";
            this.btn_addForca.UseVisualStyleBackColor = true;
            this.btn_addForca.Click += new System.EventHandler(this.btn_addForca_Click);
            // 
            // Erro
            // 
            this.Erro.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.Erro.ContainerControl = this;
            // 
            // txtRespostas
            // 
            this.txtRespostas.Location = new System.Drawing.Point(24, 291);
            this.txtRespostas.Multiline = true;
            this.txtRespostas.Name = "txtRespostas";
            this.txtRespostas.Size = new System.Drawing.Size(192, 162);
            this.txtRespostas.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 265);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Respostas :";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 465);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtRespostas);
            this.Controls.Add(this.Tre_forca);
            this.Controls.Add(this.Flecha);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.Tre_forca.ResumeLayout(false);
            this.Tre_forca.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Erro)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btn_Valida;
        private System.Windows.Forms.Button Flecha;
        private System.Windows.Forms.TextBox txtForca;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CB_Nos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cb_sentido;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox Tre_forca;
        private System.Windows.Forms.Button btn_addForca;
        private System.Windows.Forms.ErrorProvider Erro;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRespostas;
    }
}

