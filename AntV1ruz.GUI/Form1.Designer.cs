namespace AntV1ruz.GUI
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            btnAnalisis = new Button();
            btnAnalisisCompleto = new Button();
            btnAnalisisPersonalizado = new Button();
            lstResultados = new ListBox();
            lblEstado = new Label();
            SuspendLayout();
            // 
            // btnAnalisis
            // 
            btnAnalisis.Location = new Point(12, 141);
            btnAnalisis.Name = "btnAnalisis";
            btnAnalisis.Size = new Size(166, 53);
            btnAnalisis.TabIndex = 0;
            btnAnalisis.Text = "Análisis Rápido";
            btnAnalisis.UseVisualStyleBackColor = true;
            btnAnalisis.Click += btnAnalisis_Click;
            // 
            // btnAnalisisCompleto
            // 
            btnAnalisisCompleto.Location = new Point(12, 200);
            btnAnalisisCompleto.Name = "btnAnalisisCompleto";
            btnAnalisisCompleto.Size = new Size(166, 53);
            btnAnalisisCompleto.TabIndex = 1;
            btnAnalisisCompleto.Text = "Análisis Completo";
            btnAnalisisCompleto.UseVisualStyleBackColor = true;
            btnAnalisisCompleto.Click += btnAnalisis_Click;
            // 
            // btnAnalisisPersonalizado
            // 
            btnAnalisisPersonalizado.Location = new Point(12, 259);
            btnAnalisisPersonalizado.Name = "btnAnalisisPersonalizado";
            btnAnalisisPersonalizado.Size = new Size(166, 53);
            btnAnalisisPersonalizado.TabIndex = 2;
            btnAnalisisPersonalizado.Text = "Análisis Personalizado";
            btnAnalisisPersonalizado.UseVisualStyleBackColor = true;
            btnAnalisisPersonalizado.Click += btnAnalisisPersonalizado_Click;
            // 
            // lstResultados
            // 
            lstResultados.FormattingEnabled = true;
            lstResultados.ItemHeight = 20;
            lstResultados.Location = new Point(193, 182);
            lstResultados.Name = "lstResultados";
            lstResultados.Size = new Size(710, 304);
            lstResultados.TabIndex = 3;
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Location = new Point(193, 141);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(145, 20);
            lblEstado.TabIndex = 4;
            lblEstado.Text = "Estado de Resultado";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(915, 524);
            Controls.Add(lblEstado);
            Controls.Add(lstResultados);
            Controls.Add(btnAnalisisPersonalizado);
            Controls.Add(btnAnalisisCompleto);
            Controls.Add(btnAnalisis);
            Name = "Form1";
            Text = "AntV1ruz Scanner";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAnalisis;
        private Button btnAnalisisCompleto;
        private Button btnAnalisisPersonalizado;
        private ListBox lstResultados;
        private Label lblEstado;
    }
}
