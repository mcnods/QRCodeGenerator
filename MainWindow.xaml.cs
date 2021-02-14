using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Media.Imaging;
using ZXing;
using BarcodeWriter = ZXing.Presentation.BarcodeWriter;

namespace QRCodeGenerator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Populate_Values();
        }
        private void Populate_Values()
        {
            foreach (var format in MultiFormatWriter.SupportedWriters)
            {
                if (format.ToString().Equals("QR_CODE"))
                {
                    cmbEncoderType.Items.Add(format);
                }
            }
            cmbEncoderType.SelectedItem = BarcodeFormat.QR_CODE;
            //cmbRendererType.Items.Add("WriteableBitmap");
            //cmbRendererType.SelectedItem = "WriteableBitmap";
        }
        private int Check_Input()
        {
            int i = 0;
            if (txtBarcodeContentEncode.Text == null
                || txtBarcodeContentEncode.Text.Equals(""))
            {
                MessageBox.Show("Enter text to convert first.");
                i = 1;
            }
            return i;
        }
        private void btnEncode_Click(object sender, RoutedEventArgs e)
        {
            if (Check_Input() == 0)
            {
                Generate_Image();
            }
        }
        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
            if (Check_Input() == 0)
            {
                Generate_Image();
                Save_Image();
            }
        }
        private void Generate_Image()
        {
            imageBarcodeEncoder.Visibility = Visibility.Hidden;
            
            var writer = new BarcodeWriter
            {
                Format = (BarcodeFormat)cmbEncoderType.SelectedItem,
                Options = new ZXing.Common.EncodingOptions
                {
                    Height = 500,
                    Width = 500,
                    Margin = 1
                }
            };
            var image = writer.Write(txtBarcodeContentEncode.Text);
            imageBarcodeEncoder.Source = image;
            imageBarcodeEncoder.Visibility = Visibility.Visible;
        }
        private void Save_Image()
        {
            SaveFileDialog mySavePrompt = new SaveFileDialog();
            mySavePrompt.Filter = "Bitmap Image|*.bmp";
            mySavePrompt.Title = "Save your barcode";
            mySavePrompt.FileName = Generate_File_Name();
            mySavePrompt.DefaultExt = "bmp";

            if (mySavePrompt.ShowDialog() == true)
            {
                System.IO.FileStream fs = (System.IO.FileStream)mySavePrompt.OpenFile();

                var encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create((BitmapSource)imageBarcodeEncoder.Source));
                using (fs)
                {
                    encoder.Save(fs);
                    fs.Close();
                }
            }
        }
        private string Generate_File_Name()
        {
            DateTime myDate = DateTime.Now;
            
            int year = myDate.Year;
            int month = myDate.Month;
            int day = myDate.Day;
            int hour = myDate.Hour;
            int minute = myDate.Minute;
            int second = myDate.Second;

            string myFileName = $"{year}-{month}-{day} {hour}-{minute}-{second} QR Code.bmp";
            return myFileName;
        }
    }
}
