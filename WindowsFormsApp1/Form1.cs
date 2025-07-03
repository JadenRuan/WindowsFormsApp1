using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;
using Tesseract;
//using IronOcr;

using CoreScanner;
namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        static CCoreScannerClass cCoreScannerClass;
        public Form1()
        {
            InitializeComponent();
            button1.Click += new EventHandler(click);
        }
        private void click(object sender, EventArgs e)
        {
            try
            {
                // Instantiate CoreScanner Class
     
                cCoreScannerClass = new CCoreScannerClass();

                // Call Open API
                short[] scannerTypes = new short[1];    
                scannerTypes[0] = 1;                  
                short numberOfScannerTypes = 1;          
                int status;                             
                short numberOfScanners;                         
                int[] connectedScannerIDList = new int[255];     
                string outXMl;                                  
             
                cCoreScannerClass.Open(0, scannerTypes, numberOfScannerTypes, out status);
                cCoreScannerClass.GetScanners(out numberOfScanners, connectedScannerIDList, out outXMl, out status);
        
                int opcode = 1001;  // Method for Subscribe events 
                string outXML;
                string inXML = "<inArgs>" +
                                    "<cmdArgs>" +
                                        "<arg-int>1</arg-int>" + 
                                        "<arg-int>2</arg-int>" + 
                                    "</cmdArgs>" +
                                "</inArgs>";

                cCoreScannerClass.ExecCommand(opcode, ref inXML, out outXML, out status);
                cCoreScannerClass.ImageEvent += new _ICoreScannerEvents_ImageEventEventHandler(OnImageEvent);
        
            }
            catch (Exception exp)
            {
                Console.WriteLine("Something wrong please check... " + exp.Message);
            }

        }

        private static void OnImageEvent(short eventType, int size, short imageFormat, ref object pimageData, ref string pscanData)
        {
            MessageBox.Show("running ocr");
            byte[] byteArray = pimageData as byte[];
            MemoryStream ms = new MemoryStream(byteArray);
            Image i = Image.FromStream(ms);
            i.Save("temp.png");


            string pythonPath = "C:/Users/ruanj5/AppData/Local/Microsoft/WindowsApps/python.exe";
            string scriptPath = "C:/Users/ruanj5/OneDrive - Baxter/Desktop/ocr_project/eocr.py";


            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = pythonPath,
                Arguments = scriptPath,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = true,
                CreateNoWindow = true
            };

            try
            {
                using (Process process = Process.Start(psi))
                {
                    // Read the output
                    string output = process.StandardOutput.ReadToEnd();
                    string errors = process.StandardError.ReadToEnd();

                    process.WaitForExit();

                    // Display results
                    MessageBox.Show("Output:\n" + output);
                    if (!string.IsNullOrEmpty(errors))
                    {
                        Console.WriteLine("Errors:\n" + errors);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }

            //IronOcr.License.LicenseKey = "IRONSUITE.JADEN.N.RUAN.GMAIL.COM.29711-5995088002-DZDO5-XKFVA5ZL6437-VGBWXMZHJN2W-QF2XQW5IDONY-UY4JVRBHFWMJ-7D46L2HP5KXV-NG5G3WUWSMVJ-DCAEDR-TPWVCHFA33OPUA-DEPLOYMENT.TRIAL-JZJJFR.TRIAL.EXPIRES.31.JUL.2025";
            /*
             var ocr = new IronTesseract();
             using (OcrInput input = new OcrInput())
             {
                 input.LoadImage("./temp2.png");


                 input.Contrast();
                 var result = ocr.Read(input);

                 MessageBox.Show("finished ocr");
                 MessageBox.Show(result.Text);
                 MessageBox.Show("finished ocr");


             }*/
        }
        /*
        static SKBitmap LoadImage(string path)
        {
            if (!System.IO.File.Exists(path))
            {
                return null;
            }

            using (var stream = new SKFileStream(path))
            {
                return SKBitmap.Decode(stream);
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
        */
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
