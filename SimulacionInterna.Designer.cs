namespace BackpropagationAndPerceptron
{
    partial class SimulacionInterna
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.grilladesimulacion = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grilladedatos = new System.Windows.Forms.DataGridView();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grilladesimulacion)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grilladedatos)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.grilladesimulacion);
            this.groupBox3.Location = new System.Drawing.Point(75, 230);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(651, 210);
            this.groupBox3.TabIndex = 39;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Simule sus entradas";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // grilladesimulacion
            // 
            this.grilladesimulacion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grilladesimulacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grilladesimulacion.Location = new System.Drawing.Point(11, 21);
            this.grilladesimulacion.Name = "grilladesimulacion";
            this.grilladesimulacion.Size = new System.Drawing.Size(631, 177);
            this.grilladesimulacion.TabIndex = 25;
            this.grilladesimulacion.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grilladesimulacion_CellContentClick_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grilladedatos);
            this.groupBox1.Location = new System.Drawing.Point(254, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(291, 212);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Entradas, salidas y patrones";
            // 
            // grilladedatos
            // 
            this.grilladedatos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grilladedatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grilladedatos.Location = new System.Drawing.Point(11, 24);
            this.grilladedatos.Name = "grilladedatos";
            this.grilladedatos.Size = new System.Drawing.Size(267, 172);
            this.grilladedatos.TabIndex = 24;
            // 
            // SimulacionInterna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "SimulacionInterna";
            this.Text = "SimulacionInterna";
            this.Load += new System.EventHandler(this.SimulacionInterna_Load);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grilladesimulacion)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grilladedatos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView grilladesimulacion;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView grilladedatos;
    }
}