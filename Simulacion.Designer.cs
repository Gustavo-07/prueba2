namespace BackpropagationAndPerceptron
{
    partial class Simulacion
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
            this.Menu = new System.Windows.Forms.MenuStrip();
            this.inicioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informaciónDelDesarrolladorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaTécnicaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.BtnCargarPesos = new System.Windows.Forms.Button();
            this.BtnSimular = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.grillaSimulacion = new System.Windows.Forms.DataGridView();
            this.BtnCargarRed = new System.Windows.Forms.Button();
            this.grillaVectorUmbrales = new System.Windows.Forms.DataGridView();
            this.grillaMatrizPesos = new System.Windows.Forms.DataGridView();
            this.BtnCargarUmbrales = new System.Windows.Forms.Button();
            this.Menu.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grillaSimulacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grillaVectorUmbrales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grillaMatrizPesos)).BeginInit();
            this.SuspendLayout();
            // 
            // Menu
            // 
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inicioToolStripMenuItem,
            this.ayudaToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.Menu.Location = new System.Drawing.Point(0, 0);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(686, 24);
            this.Menu.TabIndex = 0;
            this.Menu.Text = "menuStrip1";
            // 
            // inicioToolStripMenuItem
            // 
            this.inicioToolStripMenuItem.Name = "inicioToolStripMenuItem";
            this.inicioToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.inicioToolStripMenuItem.Text = "Inicio";
            this.inicioToolStripMenuItem.Click += new System.EventHandler(this.inicioToolStripMenuItem_Click);
            // 
            // ayudaToolStripMenuItem
            // 
            this.ayudaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.informaciónDelDesarrolladorToolStripMenuItem,
            this.ayudaTécnicaToolStripMenuItem});
            this.ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            this.ayudaToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.ayudaToolStripMenuItem.Text = "Ayuda";
            this.ayudaToolStripMenuItem.Click += new System.EventHandler(this.ayudaToolStripMenuItem_Click);
            // 
            // informaciónDelDesarrolladorToolStripMenuItem
            // 
            this.informaciónDelDesarrolladorToolStripMenuItem.Name = "informaciónDelDesarrolladorToolStripMenuItem";
            this.informaciónDelDesarrolladorToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.informaciónDelDesarrolladorToolStripMenuItem.Text = "Información del desarrollador";
            // 
            // ayudaTécnicaToolStripMenuItem
            // 
            this.ayudaTécnicaToolStripMenuItem.Name = "ayudaTécnicaToolStripMenuItem";
            this.ayudaTécnicaToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.ayudaTécnicaToolStripMenuItem.Text = "Ayuda técnica";
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(234, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 55);
            this.label1.TabIndex = 1;
            this.label1.Text = "Simulación";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(171, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tipo de red a simular";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Perceptrón Multicapa",
            "Backpropagation"});
            this.comboBox1.Location = new System.Drawing.Point(339, 92);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(158, 21);
            this.comboBox1.TabIndex = 3;
            // 
            // BtnCargarPesos
            // 
            this.BtnCargarPesos.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCargarPesos.Location = new System.Drawing.Point(39, 236);
            this.BtnCargarPesos.Name = "BtnCargarPesos";
            this.BtnCargarPesos.Size = new System.Drawing.Size(132, 33);
            this.BtnCargarPesos.TabIndex = 5;
            this.BtnCargarPesos.Text = "Cargar Pesos";
            this.BtnCargarPesos.UseVisualStyleBackColor = true;
            this.BtnCargarPesos.Click += new System.EventHandler(this.BtnCargarPesos_Click);
            // 
            // BtnSimular
            // 
            this.BtnSimular.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSimular.Location = new System.Drawing.Point(39, 284);
            this.BtnSimular.Name = "BtnSimular";
            this.BtnSimular.Size = new System.Drawing.Size(132, 33);
            this.BtnSimular.TabIndex = 6;
            this.BtnSimular.Text = "Simular";
            this.BtnSimular.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.grillaSimulacion);
            this.groupBox3.Location = new System.Drawing.Point(197, 142);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(420, 280);
            this.groupBox3.TabIndex = 38;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Simule sus entradas";
            // 
            // grillaSimulacion
            // 
            this.grillaSimulacion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grillaSimulacion.BackgroundColor = System.Drawing.Color.White;
            this.grillaSimulacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaSimulacion.Location = new System.Drawing.Point(27, 37);
            this.grillaSimulacion.Name = "grillaSimulacion";
            this.grillaSimulacion.Size = new System.Drawing.Size(369, 200);
            this.grillaSimulacion.TabIndex = 25;
            this.grillaSimulacion.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grillaSimulacion_CellContentClick);
            // 
            // BtnCargarRed
            // 
            this.BtnCargarRed.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCargarRed.Location = new System.Drawing.Point(39, 158);
            this.BtnCargarRed.Name = "BtnCargarRed";
            this.BtnCargarRed.Size = new System.Drawing.Size(132, 33);
            this.BtnCargarRed.TabIndex = 39;
            this.BtnCargarRed.Text = "Cargar Red";
            this.BtnCargarRed.UseVisualStyleBackColor = true;
            this.BtnCargarRed.Click += new System.EventHandler(this.BtnCargarRed_Click);
            // 
            // grillaVectorUmbrales
            // 
            this.grillaVectorUmbrales.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grillaVectorUmbrales.BackgroundColor = System.Drawing.Color.White;
            this.grillaVectorUmbrales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaVectorUmbrales.Location = new System.Drawing.Point(742, 223);
            this.grillaVectorUmbrales.Name = "grillaVectorUmbrales";
            this.grillaVectorUmbrales.Size = new System.Drawing.Size(182, 171);
            this.grillaVectorUmbrales.TabIndex = 35;
            this.grillaVectorUmbrales.Visible = false;
            // 
            // grillaMatrizPesos
            // 
            this.grillaMatrizPesos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grillaMatrizPesos.BackgroundColor = System.Drawing.Color.White;
            this.grillaMatrizPesos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaMatrizPesos.Location = new System.Drawing.Point(725, 208);
            this.grillaMatrizPesos.Name = "grillaMatrizPesos";
            this.grillaMatrizPesos.Size = new System.Drawing.Size(179, 171);
            this.grillaMatrizPesos.TabIndex = 34;
            this.grillaMatrizPesos.Visible = false;
            // 
            // BtnCargarUmbrales
            // 
            this.BtnCargarUmbrales.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCargarUmbrales.Location = new System.Drawing.Point(39, 197);
            this.BtnCargarUmbrales.Name = "BtnCargarUmbrales";
            this.BtnCargarUmbrales.Size = new System.Drawing.Size(132, 33);
            this.BtnCargarUmbrales.TabIndex = 4;
            this.BtnCargarUmbrales.Text = "Cargar Umbrales";
            this.BtnCargarUmbrales.UseVisualStyleBackColor = true;
            this.BtnCargarUmbrales.Click += new System.EventHandler(this.BtnCargarUmbrales_Click);
            // 
            // Simulacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 485);
            this.Controls.Add(this.grillaMatrizPesos);
            this.Controls.Add(this.BtnCargarUmbrales);
            this.Controls.Add(this.grillaVectorUmbrales);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.BtnCargarPesos);
            this.Controls.Add(this.BtnCargarRed);
            this.Controls.Add(this.BtnSimular);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Menu);
            this.MainMenuStrip = this.Menu;
            this.Name = "Simulacion";
            this.Text = "Simulacion";
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grillaSimulacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grillaVectorUmbrales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grillaMatrizPesos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip Menu;
        private System.Windows.Forms.ToolStripMenuItem inicioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem informaciónDelDesarrolladorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ayudaTécnicaToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button BtnCargarPesos;
        private System.Windows.Forms.Button BtnSimular;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView grillaSimulacion;
        private System.Windows.Forms.Button BtnCargarRed;
        private System.Windows.Forms.DataGridView grillaVectorUmbrales;
        private System.Windows.Forms.DataGridView grillaMatrizPesos;
        private System.Windows.Forms.Button BtnCargarUmbrales;
    }
}