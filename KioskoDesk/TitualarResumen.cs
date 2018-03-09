using AForge.Video;
using AForge.Video.DirectShow;
using Patagames.Ocr;
using Patagames.Ocr.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KioskoDesk
{
    public partial class TitualarResumen : Form
    {
        private bool ExisteDispositivo = false;
        private FilterInfoCollection DispositivoDeVideo;
        private VideoCaptureDevice FuenteDeVideo = null;

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

        public TitualarResumen()
        {
            InitializeComponent();
            BuscarDispositivos();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            FuenteDeVideo = new VideoCaptureDevice(DispositivoDeVideo[cbxDispositivos.SelectedIndex].MonikerString);
            FuenteDeVideo.NewFrame += new NewFrameEventHandler(Video_NuevoFrame);

             FuenteDeVideo.Start();
     
            
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

        private void button2_Click(object sender, EventArgs e)
        {

            
            TerminarFuenteDeVideo();

            if (EspacioCamara.Image != null)
            {
                //Save First
                Bitmap varBmp = new Bitmap(EspacioCamara.Image);
                Bitmap newBitmap = new Bitmap(varBmp);
                string physicalPath = Path.Combine("C:/root/JuntaFiles/", "a.jpg");
                varBmp.Save(physicalPath, ImageFormat.Jpeg);
                //varBmp.Save(@"C:\a.png", ImageFormat.Png);
                //Now Dispose to free the memory
                varBmp.Dispose();
                varBmp = null;
            }
            else
            { MessageBox.Show("null exception"); }


            using (var api = OcrApi.Create())
            {
                api.Init(Languages.English);
                string plainText = api.GetTextFromImage("C:/captura.png");

                lblOcr.Text = plainText;
            }
        }
    }
}
