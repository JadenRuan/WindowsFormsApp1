using CoreScanner;
using SixLabors.ImageSharp;
using SkiaSharp;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        static CCoreScannerClass cCoreScannerClass;
        static ProcessStartInfo processStartInfo = new ProcessStartInfo()
        {
            FileName = @"C:\Users\ruanj5\AppData\Local\Programs\Python\Python313\python.exe",
            Arguments = @"C:\Users\ruanj5\source\repos\WindowsFormsApp1\WindowsFormsApp1\bin\Debug\eocrsetup.py",
            RedirectStandardOutput = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };
        static Process python = null;

        public Form1()
        {
            // this.FormClosed += OnFormClosing();
            InitializeComponent();
            scriptStatusButton.Click += new EventHandler(pythonProcessStatus);
            button3.Click += new EventHandler(StartOcrProcessIfNeeded);
            portNumberLabel.Font = new Font(portNumberLabel.Font, FontStyle.Bold);
            pictureBox1.Image = System.Drawing.Image.FromFile(@"C:\Users\ruanj5\source\repos\WindowsFormsApp1\WindowsFormsApp1\bin\Debug\cameraLogo.png");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Cursor = Cursors.Hand;
            pictureBox1.Click += enablePhotoMode;

            pictureBox2.Image = System.Drawing.Image.FromFile(@"C:\Users\ruanj5\source\repos\WindowsFormsApp1\WindowsFormsApp1\bin\Debug\qrCode.jpg");
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.Cursor = Cursors.Hand;
            pictureBox2.Click += enableBarcodeMode;
        }
      
        private void enableBarcodeMode(object sender, EventArgs e)
        {
            try
            {
                cCoreScannerClass = new CCoreScannerClass();

                short[] scannerTypes = new short[1];
                scannerTypes[0] = 1;
                int status;
                string outXML;
                string inXML;



                cCoreScannerClass.Open(0, scannerTypes, 1, out status);

                if (status != 0)
                {
                    MessageBox.Show("CoreScanner API: Open Failed");
                    return;
                }

                // Registers for image events
                inXML = "<inArgs>" +
                                   "<cmdArgs>" +
                                       "<arg-int>1</arg-int>" +
                                       "<arg-int>1</arg-int>" +
                                   "</cmdArgs>" +
                       "</inArgs>";

                cCoreScannerClass.ExecCommand(1001, ref inXML, out outXML, out status);
                cCoreScannerClass.BarcodeEvent += new _ICoreScannerEvents_BarcodeEventEventHandler(OnBarcodeEvent);

                inXML = "<inArgs>" +
                                  "<scannerID>1</scannerID>" +
                      "</inArgs>";
                cCoreScannerClass.ExecCommand(3500, ref inXML, out outXML, out status);

                if (status != 0)
                {
                    MessageBox.Show("CoreScanner API: Enable Barcode Mode Failed");
                    return;
                }
                else
                {
                    MessageBox.Show("CoreScanner API: Barcode Mode enabled.");
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show("Error: " + exp.Message);
            }
        }

        private void enablePhotoMode(object sender, EventArgs e)
        {
            try
            {
                cCoreScannerClass = new CCoreScannerClass();

                short[] scannerTypes = new short[1];
                scannerTypes[0] = 1;
                int status;
                string outXML;
                string inXML;


               
                cCoreScannerClass.Open(0, scannerTypes, 1, out status);

                if (status != 0)
                {
                    MessageBox.Show("CoreScanner API: Open Failed");
                    return;
                }

                // Registers for image events
                inXML = "<inArgs>" +
                                   "<cmdArgs>" +
                                       "<arg-int>1</arg-int>" +
                                       "<arg-int>2</arg-int>" +
                                   "</cmdArgs>" +
                       "</inArgs>";

                cCoreScannerClass.ExecCommand(1001, ref inXML, out outXML, out status); 
                cCoreScannerClass.ImageEvent += new _ICoreScannerEvents_ImageEventEventHandler(OnImageEvent);

                inXML = "<inArgs>" +
                                  "<scannerID>1</scannerID>" +
                      "</inArgs>";
                cCoreScannerClass.ExecCommand(3000, ref inXML, out outXML, out status);

                if (status != 0)
                {
                    MessageBox.Show("Enable Photo Mode Failed");
                    return;
                }
                else
                {
                    MessageBox.Show("Photo mode enabled.");
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show("Error: " + exp.Message);
            }
        }
  
        private void StartOcrProcessIfNeeded(object sender, EventArgs e)
        {
            if (python == null || python.HasExited)
            {
                python = new Process();
                python.StartInfo = processStartInfo;
                python.EnableRaisingEvents = true;
                python.OutputDataReceived += Process_OutputDataReceived;
                python.Start();
                python.BeginOutputReadLine(); // Start async read
            }
        }

        private void pythonProcessStatus(object sender, EventArgs e)
        {
            if (python != null && !python.HasExited)
            {
                MessageBox.Show("OCR process is running.");
            }
            else
            {
                MessageBox.Show("OCR process is not running.");
            }
        }

        private void Process_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            
            var form = Application.OpenForms[0] as Form1;
            if (form != null)
            {
               
            }
            char a = ' ';
            char b = ' ';
            char c = ' ';
            if (!string.IsNullOrWhiteSpace(e.Data))
            {
                MessageBox.Show("Python Output: " + e.Data);
            }
            if (e.Data != null && e.Data.Length >= 3)
            {
                string result = e.Data.ToUpper();
                a = result[0];
                b = result[1];
                c = result[2];
            }
            
           
            
            if (a == 'L' && b == 'O' && c == 'T' && e.Data.Length > 3)
            {
                form.BeginInvoke((Action)(() =>
                {
                    if (string.IsNullOrEmpty(form.textBox1.Text))
                    {
                        form.textBox1.Text = e.Data.Substring(4);
                    } 
                }));
            }
            if (a == 'E' && b == 'X' && c == 'P' && e.Data.Length > 3)
            {
                form.BeginInvoke((Action)(() =>
                {
                    form.textBox2.Text = e.Data.Substring(4); 
                }));
            }
        }
        private string HexToAscii(string hex)
        {
            if (string.IsNullOrWhiteSpace(hex))
                return string.Empty;

            var sb = new System.Text.StringBuilder();
            var tokens = hex.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var token in tokens)
            {
                string cleanToken = token.StartsWith("0x", StringComparison.OrdinalIgnoreCase)
                    ? token.Substring(2)
                    : token;
                if (byte.TryParse(cleanToken, System.Globalization.NumberStyles.HexNumber, null, out byte value))
                {
                    sb.Append((char)value);
                }
            }
            return sb.ToString();
        }

        private void OnBarcodeEvent(short eventType, ref string pscanData)
        {
            string barcodeValue = "";
            var form = Application.OpenForms[0] as Form1;
            try
            {
                var doc = new XmlDocument();
                doc.LoadXml(pscanData);


                var dataLabelNode = doc.SelectSingleNode("//datalabel");
                if (dataLabelNode != null && !string.IsNullOrWhiteSpace(dataLabelNode.InnerText))
                {
                    barcodeValue = HexToAscii(dataLabelNode.InnerText);
                }
                else
                {
                    barcodeValue = pscanData; 
                }

            }
            catch
            {
                barcodeValue = pscanData; 
            }
            form.BeginInvoke((Action)(() =>
            {
                form.textBox1.Text = barcodeValue.Substring(26);
            }));
            MessageBox.Show("Barcode: " + barcodeValue);

        }   
        private void OnImageEvent(short eventType, int size, short imageFormat, ref object pimageData, ref string pscanData)
        { 
            MessageBox.Show("Image Event Triggered");
            if (python != null && !python.HasExited)
            {
                MessageBox.Show("OCR process is running.");
            }
            else
            {
                MessageBox.Show("OCR process is not running.");
            }
            
            byte[] byteArray = pimageData as byte[];

            blurring blur = new blurring();
            thresholding thresh = new thresholding();


            SKBitmap inputBitmap;
            using (var ms = new MemoryStream(byteArray))
            {
                inputBitmap = SKBitmap.Decode(ms);
            }
            SKBitmap contrastEnhancedImage = thresh.EnhanceContrast(inputBitmap, 1.2f);
            SaveImage(contrastEnhancedImage, "image_to_ocr.png");
            try
            {
                if (cCoreScannerClass != null)
                {
                    short[] scannerTypes = new short[1];
                    scannerTypes[0] = 1;
                    int status;
                    string outXML;
                    string inXML = "<inArgs>" +
                                       "<scannerID>1</scannerID>" +
                                   "</inArgs>";
                    cCoreScannerClass.ExecCommand(3000, ref inXML, out outXML, out status);
                    // Optionally check status and log or show a message if needed
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to re-enable photo mode: " + ex.Message);
            }
        }
        static void SaveImage(SKBitmap bitmap, string path)
        {
            using (var image = SKImage.FromBitmap(bitmap))
            using (var data = image.Encode(SKEncodedImageFormat.Png, 100))
            using (var stream = System.IO.File.OpenWrite(path))
            {
                data.SaveTo(stream);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            int status = 0;
            base.OnFormClosing(e);

            if (cCoreScannerClass != null)
            {
                cCoreScannerClass.Close(0, out status); 


            }

            if (python != null && !python.HasExited)
            {
                python.Kill();
                python.Dispose();
                python = null;
            }
        }
    }
}
