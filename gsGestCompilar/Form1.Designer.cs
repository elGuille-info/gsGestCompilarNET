
namespace gsGestCompilar
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
#region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.chkMostrarDesigner = new System.Windows.Forms.CheckBox();
            this.btnCompilar = new System.Windows.Forms.Button();
            this.btnEjecutar = new System.Windows.Forms.Button();
            this.btnMostrarCodigo = new System.Windows.Forms.Button();
            this.btnSelFichs = new System.Windows.Forms.Button();
            this.LabelStatus = new System.Windows.Forms.Label();
            this.btnSelProyecto = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.txtProyecto = new System.Windows.Forms.TextBox();
            this.labelProj = new System.Windows.Forms.Label();
            this.labelDotnet = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // chkMostrarDesigner
            // 
            this.chkMostrarDesigner.AutoSize = true;
            this.chkMostrarDesigner.Checked = true;
            this.chkMostrarDesigner.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMostrarDesigner.Location = new System.Drawing.Point(135, 82);
            this.chkMostrarDesigner.Name = "chkMostrarDesigner";
            this.chkMostrarDesigner.Size = new System.Drawing.Size(291, 29);
            this.chkMostrarDesigner.TabIndex = 8;
            this.chkMostrarDesigner.Text = "Mostrar \'.Designer.\' y \'Program.\'";
            this.toolTip1.SetToolTip(this.chkMostrarDesigner, "Para mostar (o no) los ficheros con el código de diseño de los formularios\r\ny los" +
        " ficheros Program.*");
            this.chkMostrarDesigner.UseVisualStyleBackColor = true;
            // 
            // btnCompilar
            // 
            this.btnCompilar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCompilar.Location = new System.Drawing.Point(687, 129);
            this.btnCompilar.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnCompilar.Name = "btnCompilar";
            this.btnCompilar.Size = new System.Drawing.Size(167, 44);
            this.btnCompilar.TabIndex = 6;
            this.btnCompilar.Text = "Compilar";
            this.toolTip1.SetToolTip(this.btnCompilar, "Solo compilar el proyecto");
            this.btnCompilar.UseVisualStyleBackColor = true;
            this.btnCompilar.Click += new System.EventHandler(this.btnCompilar_Click);
            // 
            // btnEjecutar
            // 
            this.btnEjecutar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEjecutar.Location = new System.Drawing.Point(687, 185);
            this.btnEjecutar.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnEjecutar.Name = "btnEjecutar";
            this.btnEjecutar.Size = new System.Drawing.Size(167, 44);
            this.btnEjecutar.TabIndex = 7;
            this.btnEjecutar.Text = "Ejecutar";
            this.toolTip1.SetToolTip(this.btnEjecutar, "Compilar y ejecutar el proyecto");
            this.btnEjecutar.UseVisualStyleBackColor = true;
            this.btnEjecutar.Click += new System.EventHandler(this.btnEjecutar_Click);
            // 
            // btnMostrarCodigo
            // 
            this.btnMostrarCodigo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMostrarCodigo.Location = new System.Drawing.Point(510, 73);
            this.btnMostrarCodigo.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnMostrarCodigo.Name = "btnMostrarCodigo";
            this.btnMostrarCodigo.Size = new System.Drawing.Size(167, 44);
            this.btnMostrarCodigo.TabIndex = 3;
            this.btnMostrarCodigo.Text = "Mostrar código";
            this.toolTip1.SetToolTip(this.btnMostrarCodigo, "Muestra los ficheros de código de la carpeta del proyecto");
            this.btnMostrarCodigo.UseVisualStyleBackColor = true;
            this.btnMostrarCodigo.Click += new System.EventHandler(this.btnMostrarCodigo_Click);
            // 
            // btnSelFichs
            // 
            this.btnSelFichs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelFichs.Location = new System.Drawing.Point(687, 73);
            this.btnSelFichs.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnSelFichs.Name = "btnSelFichs";
            this.btnSelFichs.Size = new System.Drawing.Size(167, 44);
            this.btnSelFichs.TabIndex = 4;
            this.btnSelFichs.Text = "Seleccionar...";
            this.toolTip1.SetToolTip(this.btnSelFichs, "Seleccionar los ficheros a mostrar");
            this.btnSelFichs.UseVisualStyleBackColor = true;
            this.btnSelFichs.Click += new System.EventHandler(this.btnSelFichs_Click);
            // 
            // LabelStatus
            // 
            this.LabelStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelStatus.BackColor = System.Drawing.SystemColors.Info;
            this.LabelStatus.Location = new System.Drawing.Point(14, 272);
            this.LabelStatus.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.LabelStatus.Name = "LabelStatus";
            this.LabelStatus.Size = new System.Drawing.Size(1017, 44);
            this.LabelStatus.TabIndex = 8;
            this.LabelStatus.Text = "info";
            this.LabelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSelProyecto
            // 
            this.btnSelProyecto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelProyecto.Location = new System.Drawing.Point(864, 23);
            this.btnSelProyecto.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnSelProyecto.Name = "btnSelProyecto";
            this.btnSelProyecto.Size = new System.Drawing.Size(167, 44);
            this.btnSelProyecto.TabIndex = 2;
            this.btnSelProyecto.Text = "Seleccionar...";
            this.btnSelProyecto.UseVisualStyleBackColor = true;
            this.btnSelProyecto.Click += new System.EventHandler(this.btnSelProyecto_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // txtProyecto
            // 
            this.txtProyecto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProyecto.Location = new System.Drawing.Point(135, 30);
            this.txtProyecto.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtProyecto.Name = "txtProyecto";
            this.txtProyecto.Size = new System.Drawing.Size(719, 31);
            this.txtProyecto.TabIndex = 1;
            // 
            // labelProj
            // 
            this.labelProj.Location = new System.Drawing.Point(14, 23);
            this.labelProj.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.labelProj.Name = "labelProj";
            this.labelProj.Size = new System.Drawing.Size(111, 44);
            this.labelProj.TabIndex = 0;
            this.labelProj.Text = "Proyecto:";
            this.labelProj.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelDotnet
            // 
            this.labelDotnet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelDotnet.BackColor = System.Drawing.Color.GhostWhite;
            this.labelDotnet.Location = new System.Drawing.Point(135, 129);
            this.labelDotnet.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.labelDotnet.Name = "labelDotnet";
            this.labelDotnet.Size = new System.Drawing.Size(542, 100);
            this.labelDotnet.TabIndex = 5;
            this.labelDotnet.Text = "Se puede compilar/ejecutar el proyecto.";
            this.labelDotnet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1045, 331);
            this.Controls.Add(this.btnSelFichs);
            this.Controls.Add(this.chkMostrarDesigner);
            this.Controls.Add(this.btnMostrarCodigo);
            this.Controls.Add(this.btnCompilar);
            this.Controls.Add(this.labelDotnet);
            this.Controls.Add(this.btnEjecutar);
            this.Controls.Add(this.LabelStatus);
            this.Controls.Add(this.btnSelProyecto);
            this.Controls.Add(this.txtProyecto);
            this.Controls.Add(this.labelProj);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1060, 365);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Compilar y ejecutar código de dotnet (.NET Core 5.0 o superior)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        #endregion

        private System.Windows.Forms.Label LabelStatus;
        private System.Windows.Forms.TextBox txtProyecto;
        private System.Windows.Forms.Label labelProj;
        private System.Windows.Forms.Button btnSelProyecto;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnCompilar;
        private System.Windows.Forms.Label labelDotnet;
        private System.Windows.Forms.Button btnEjecutar;
        private System.Windows.Forms.Button btnMostrarCodigo;
        private System.Windows.Forms.CheckBox chkMostrarDesigner;
        private System.Windows.Forms.Button btnSelFichs;
    }
}

