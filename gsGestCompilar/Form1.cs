using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;

//using gsUtilidadesNET;
using elGuille.Util;
using System.Diagnostics;

namespace gsGestCompilar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Config cfg;
        private string dotnetPath;
        private bool hayDotNet;

        private void Form1_Load(object sender, EventArgs e)
        {
            //this.Left = (Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2;
            this.CenterToScreen();

            timer1.Interval = 5000;
            timer1.Enabled = false;

            btnCompilar.Enabled = false;
            btnEjecutar.Enabled = false;

            LabelStatus.Text = $"{Application.ProductName} v{Application.ProductVersion} - {My.Application.Info.Copyright}";
            LabelStatus.Tag = LabelStatus.Text;

            //string ficConfig = My.Application.Info.NombreEnsamblado + ".cfg";

            //string ficConfig = System.Reflection.Assembly.GetExecutingAssembly().Location + ".cfg";

            // Esto es preferible a usar GetExecutingAssembly, ver:
            // https://docs.microsoft.com/en-us/dotnet/api/system.reflection.assembly.getexecutingassembly#remarks
            System.Reflection.Assembly assem = typeof(Form1).Assembly;
            string ficConfig = assem.Location + ".cfg";

            cfg = new Config(ficConfig);
            cfg.Read();
            leerCfg();

            hayDotNet = TieneDotNet();
            btnSelProyecto.Enabled = hayDotNet;
            labelDotnet.Text = dotnetPath;

            comprobarProyecto();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            guardarCfg();
        }

        private void comprobarProyecto()
        {
            var proj = txtProyecto.Text.ToLower();
            if (proj.Contains(".csproj") || proj.Contains(".vbproj") || proj.Contains(".sln"))
            {
                btnCompilar.Enabled = hayDotNet;
                btnEjecutar.Enabled = hayDotNet;
            }
            else
            {
                btnCompilar.Enabled = false;
                btnEjecutar.Enabled = false;
            }
        }

        private void guardarCfg()
        {
            cfg.SetValue("GestCompilar", "Proyecto", txtProyecto.Text);
            cfg.SetValue("GestCompilar", "MostrarDesigner", chkMostrarDesigner.Checked);

            cfg.Save();
        }

        private void leerCfg()
        {
            txtProyecto.Text = cfg.GetValue("GestCompilar", "Proyecto", "");
            chkMostrarDesigner.Checked = cfg.GetValue("GestCompilar", "MostrarDesigner", false);
        }

        /// <summary>
        /// Comprueba si existe la carpeta dotnet.
        /// </summary>
        /// <returns></returns>
        private bool TieneDotNet()
        {
            try
            {
                var s = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
                dotnetPath = Path.Join(s, "dotnet");

                if (Directory.Exists(dotnetPath))
                {
                    dotnetPath = "Se puede compilar/ejecutar el proyecto.";
                    return true;
                }
                else
                {
                    dotnetPath = "No existe el directorio de 'dotnet'.";
                    return false;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                dotnetPath = ex.Message;
                return false;
            }
        }

        private void btnSelProyecto_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog
            {
                FileName = txtProyecto.Text,
                Filter = "Proyectos (*.csproj; *.vbproj)|*.csproj; *.vbproj|Soluciones (*.sln)|*.sln|Todos los ficheros (*.*)|*.*",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer),
                Multiselect = false,
                RestoreDirectory = true,
                Title = "Selecciona el proyecto a compilar/ejecutar"
            };
            if (ofd.ShowDialog() == DialogResult.OK)
                txtProyecto.Text = ofd.FileName;

            comprobarProyecto();
        }

        private void btnCompilar_Click(object sender, EventArgs e)
        {
            // dotnet build --force projectFile
            LabelStatus.Text = "Compilando el proyecto...";
            Application.DoEvents();

            var projectPath = txtProyecto.Text;
            if (projectPath.Contains(" "))
                projectPath = '\"' + projectPath + '\"';

            //Process.Start("dotnet", $"build --force {projectPath}");
            Process.Start("dotnet", $"build {projectPath}");
        }

        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            // dotnet run -p projectFile --force
            LabelStatus.Text = "Ejecutando el proyecto...";
            Application.DoEvents();

            var projectPath = txtProyecto.Text;
            if (projectPath.Contains(" "))
                projectPath = '\"' + projectPath + '\"';

            //Process.Start("dotnet", $"run -p {projectPath} --force");
            Process.Start("dotnet", $"run -p {projectPath}");
        }

        private void btnMostrarCodigo_Click(object sender, EventArgs e)
        {
            LabelStatus.Text = "Mostrando los ficheros del proyecto...";
            Application.DoEvents();

            // Abrir todos los ficheros con la extensión del lenguaje
            var proj = txtProyecto.Text.ToLower();
            var lenguaje = "";

            if (proj.Contains(".vbproj"))
                lenguaje = "vb";
            else if (proj.Contains(".csproj"))
                lenguaje = "cs";

            if (string.IsNullOrEmpty(lenguaje))
            {
                LabelStatus.Text = "El proyecto debe ser de Visual Basic o C#.";
                timer1.Enabled = true;
                return;
            }

            var dirProj = Path.GetDirectoryName(txtProyecto.Text);
            var files = Directory.GetFiles(dirProj, "*." + lenguaje);

            mostrarCodigo(files, lenguaje);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;

            LabelStatus.Text = LabelStatus.Tag.ToString();
        }

        private void btnSelFichs_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog
            {
                FileName = "",
                Filter = "Código (*.cs; *.vb)|*.cs; *.vb|Todos los ficheros (*.*)|*.*",
                InitialDirectory = Path.GetDirectoryName(txtProyecto.Text),
                Multiselect = true,
                RestoreDirectory = true,
                Title = "Selecciona los ficheros a mostrar/editar"
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                mostrarCodigo(ofd.FileNames);
            }
        }

        private void mostrarCodigo(string[] files, string lenguaje = "")
        {
            if (string.IsNullOrEmpty(lenguaje))
                lenguaje = Path.GetExtension(files[0]);

            LabelStatus.Text = $"Mostrando {files.Length} ficheros de {lenguaje}.";

            foreach (var fi in files)
            {
                bool mostrar;

                if (fi.Contains(".Designer.") || fi.Contains("Program."))
                    mostrar = chkMostrarDesigner.Checked;
                else
                    mostrar = true;

                if (mostrar)
                {
                    Process.Start("notepad.exe", fi);
                    Application.DoEvents();
                }
            }

            timer1.Enabled = true;
        }
    }
}
