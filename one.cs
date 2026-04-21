using System;
using ZXing;
using ZXing.Common;
using ZXing.Rendering;
namespace Barcode
{
    public partial class Form1 : Form
    {
        private object pictureBox1;
        private string barcodeText;

        public Form1()
        {
            InitializeComponent();
        }

        private void TextHere_Click(object sender, EventArgs e)
        {
            var writer = new BarcodeWriterPixelData
            {
                Format = BarcodeFormat.CODE_128,
                Options = new EncodingOptions
                {
                    Height = (int)25.93,
                    Width = (int)22.85,
                    Margin = (int)3.63,
                
                    PureBarcode= false,

                }

            };
            var pixelData = writer.Write(barcodeText);

            using (var bitmap = new Bitmap(pixelData.Width, pixelData.Height,
                   System.Drawing.Imaging.PixelFormat.Format32bppRgb))
            {
                var bitmapData = bitmap.LockBits(
                    new Rectangle(0, 0, pixelData.Width, pixelData.Height),
                    System.Drawing.Imaging.ImageLockMode.WriteOnly,
                    System.Drawing.Imaging.PixelFormat.Format32bppRgb);

                System.Runtime.InteropServices.Marshal.Copy(
                    pixelData.Pixels, 0, bitmapData.Scan0, pixelData.Pixels.Length);

                
            }
        }
        

        private void GENERATE_Click(object sender, EventArgs e)
        {
            Zen.Barcode.Code128BarcodeDraw ObjBarcode = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
            Barcode.Image = ObjBarcode.Draw(Code.Text, 100);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
