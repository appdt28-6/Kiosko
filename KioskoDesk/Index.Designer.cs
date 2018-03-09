namespace KioskoDesk
{
    partial class Index
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
            this.btnAfiliacion = new System.Windows.Forms.Button();
            this.btnReafiliacion = new System.Windows.Forms.Button();
            this.btnConsulta = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAfiliacion
            // 
            this.btnAfiliacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAfiliacion.Location = new System.Drawing.Point(46, 63);
            this.btnAfiliacion.Name = "btnAfiliacion";
            this.btnAfiliacion.Size = new System.Drawing.Size(781, 142);
            this.btnAfiliacion.TabIndex = 0;
            this.btnAfiliacion.Text = "Afiliacion";
            this.btnAfiliacion.UseVisualStyleBackColor = true;
            // 
            // btnReafiliacion
            // 
            this.btnReafiliacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReafiliacion.Location = new System.Drawing.Point(46, 241);
            this.btnReafiliacion.Name = "btnReafiliacion";
            this.btnReafiliacion.Size = new System.Drawing.Size(781, 153);
            this.btnReafiliacion.TabIndex = 1;
            this.btnReafiliacion.Text = "Reafiliacion";
            this.btnReafiliacion.UseVisualStyleBackColor = true;
            // 
            // btnConsulta
            // 
            this.btnConsulta.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsulta.Location = new System.Drawing.Point(46, 433);
            this.btnConsulta.Name = "btnConsulta";
            this.btnConsulta.Size = new System.Drawing.Size(781, 186);
            this.btnConsulta.TabIndex = 2;
            this.btnConsulta.Text = "Consulta su Poliza";
            this.btnConsulta.UseVisualStyleBackColor = true;
            this.btnConsulta.Click += new System.EventHandler(this.btnConsulta_Click);
            // 
            // Index
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 665);
            this.Controls.Add(this.btnConsulta);
            this.Controls.Add(this.btnReafiliacion);
            this.Controls.Add(this.btnAfiliacion);
            this.Name = "Index";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Index";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAfiliacion;
        private System.Windows.Forms.Button btnReafiliacion;
        private System.Windows.Forms.Button btnConsulta;
    }
}