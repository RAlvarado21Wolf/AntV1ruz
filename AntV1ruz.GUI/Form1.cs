using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using AntV1ruz;

namespace AntV1ruz.GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblEstado.Text = "Esperando acción...";
        }

        private void btnAnalisis_Click(object sender, EventArgs e)
        {
            string[] rutasCriticas = new string[]
            {
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads"
            };

            AnalizarDirectorios(rutasCriticas, "Análisis Rápido");
        }

        private void btnAnalisisCompleto_Click(object sender, EventArgs e)
        {
            DriveInfo[] discos = DriveInfo.GetDrives();
            var rutas = new List<string>();

            foreach (var d in discos)
            {
                if (d.IsReady && d.DriveType == DriveType.Fixed)
                    rutas.Add(d.RootDirectory.FullName);
            }

            AnalizarDirectorios(rutas.ToArray(), "Análisis Completo");
        }

        private void btnAnalisisPersonalizado_Click(object sender, EventArgs e)
        {
            using FolderBrowserDialog dialogo = new FolderBrowserDialog();
            dialogo.Description = "Selecciona una carpeta para analizar";

            if (dialogo.ShowDialog() == DialogResult.OK)
            {
                string ruta = dialogo.SelectedPath;
                AnalizarDirectorios(new string[] { ruta }, "Análisis Personalizado");
            }
        }

        private void AnalizarDirectorios(string[] rutas, string tipoAnalisis)
        {
            lstResultados.Items.Clear();
            lblEstado.Text = $"{tipoAnalisis} en progreso...";

            VirusDatabase db = new VirusDatabase();

            Task.Run(() =>
            {
                foreach (string ruta in rutas)
                {
                    if (Directory.Exists(ruta))
                    {
                        try
                        {
                            foreach (var archivo in Directory.GetFiles(ruta, "*", SearchOption.AllDirectories))
                            {
                                try
                                {
                                    string resultado = Scanner.AnalizarArchivo(archivo, db);
                                    Invoke(() =>
                                    {
                                        lstResultados.Items.Add(resultado);
                                    });
                                }
                                catch (Exception ex)
                                {
                                    Invoke(() =>
                                    {
                                        lstResultados.Items.Add($"[ERROR] {archivo} → {ex.Message}");
                                    });
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Invoke(() =>
                            {
                                lstResultados.Items.Add($"[ERROR] No se pudo acceder a {ruta} → {ex.Message}");
                            });
                        }
                    }
                }

                Invoke(() => lblEstado.Text = $"{tipoAnalisis} finalizado.");
            });
        }
    }
}
