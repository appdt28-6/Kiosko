using AForge.Video;
using AForge.Video.DirectShow;
using BarcodeLib.BarcodeReader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KioskoDesk
{
    public partial class CurpScan : Form
    {
        private FilterInfoCollection DispositivoDeVideo;
        private VideoCaptureDevice FuenteDeVideo = null;
        private bool ExisteDispositivo = false;

        public void CargarDispositivos(FilterInfoCollection Dispositivos)
        {
            for (int i = 0; i < Dispositivos.Count; i++) ;

            cbxDispositivos.Items.Add(Dispositivos[0].Name.ToString());
            cbxDispositivos.Text = cbxDispositivos.Items[0].ToString();

        }

        public void BuscarDispositivos()
        {
            DispositivoDeVideo = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (DispositivoDeVideo.Count == 0)
            {
                ExisteDispositivo = false;
            }

            else
            {
                ExisteDispositivo = true;
                CargarDispositivos(DispositivoDeVideo);

            }
        }

        public CurpScan()
        {
            InitializeComponent();
            BuscarDispositivos();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            FuenteDeVideo = new VideoCaptureDevice(DispositivoDeVideo[cbxDispositivos.SelectedIndex].MonikerString);
            FuenteDeVideo.NewFrame += new NewFrameEventHandler(Video_NuevoFrame);

            FuenteDeVideo.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            TerminarFuenteDeVideo();

        }

        public void TerminarFuenteDeVideo()
        {
            if (!(FuenteDeVideo == null))
                if (FuenteDeVideo.IsRunning)
                {
                    FuenteDeVideo.SignalToStop();

                    FuenteDeVideo = null;
                }

        }

        public void Video_NuevoFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap Imagen = (Bitmap)eventArgs.Frame.Clone();
            EspacioCamara.Image = Imagen;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (EspacioCamara.Image != null)
            {
                //IBTENER IMAGEN DE LA WEBCAM
                Bitmap img = new Bitmap(EspacioCamara.Image);
                //UTILIZAR LA LIBRERIA Y LEER EL CÓDIGO
                string[] resultados = BarcodeReader.read(img, BarcodeReader.QRCODE);
                //QUITAR LA IMAGEN DE MEMORIA
                img.Dispose();
                //OBTENER LAS LECTURAS CUANDO SE LEA ALGO
                if (resultados != null && resultados.Count() > 0)
                {
                    //AGREGAR EL TEXTO OBTENIDO A LA LISTA
                    if (resultados[0].IndexOf("1111") != -1)
                    {
                        //QUITAR EL CODIGO DE VERIFICACION
                        resultados[0] = resultados[0].Replace("1111", "");
                        listBox1.Items.Add(resultados[0]);
                    }
                }
            }
        }
    }
}
