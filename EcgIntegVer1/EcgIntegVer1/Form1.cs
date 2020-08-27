using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EcgViewer;
using ECGConversion;
using ECGConversion.ECGSignals;
using ECGConversion.ECGDemographics;
using System.Security.AccessControl;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Drawing.Imaging;

namespace EcgIntegVer1
{
    public partial class ECGInteg : Form
    {
        public ECGInteg()
        {
            InitializeComponent();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void callEcgButton_Click(object sender, EventArgs e)
        {
            UnknownECGReader _ECGReader = null;
            EcgViewer.EcgViewer ecg = new EcgViewer.EcgViewer();
            //ecg.CurrentEcg;
            //IECGFormat _CurrentECG = null;
            //IECGFormat currentECG;
            //Signals _CurrentSignal = null;

            string filePath = "C:/Users/NGUYENPHUC/OneDrive - Vmed Group Mail/R&D - Infomed/" +
                "Integration/telemedicine-trial-integ-ecg/EcgIntegVer1/Example.scp"; //Directory.GetCurrentDirectory();
            if (_ECGReader == null)
                _ECGReader = new UnknownECGReader();
            IECGFormat ecgFormat = _ECGReader.Read(filePath);
            bool success = false;
            
            if (ecgFormat != null)
            {
                ecg.CurrentEcg = ecgFormat;
                if (ecg.CurrentEcg != null)
                    success = true;
            }
            else
            {
                ecg.CurrentEcg = null;
            }

            //ecg.CurrentEcg.
            //temp.setSignals();
            var temp = ecg.TelCurrentSignal;
            Signal[] temp3 = temp.GetLeads();
            var x = temp3.Length;
            var y = temp3[0];

            Signals temp2 = null;
            var result = ecgFormat.Signals.getSignals(out temp2);
            //temp2.

            MessageBox.Show(success.ToString());
        }

        private void tryOpenFile_Click(object sender, EventArgs e)
        {
            string filePath = "D:\\EcgInteg\\EcgIntegVer1\\Example.scp";
            Stream ecgFile = new FileStream(filePath, FileMode.Open, FileAccess.Read);


            MessageBox.Show(ecgFile.Length.ToString());
            MessageBox.Show(ecgFile.ToString());
            //MessageBox.Show(ecgFile.s)
            //Encoding.GetEncoding
            ecgFile.Close();
        }

        private void createFile_Click(object sender, EventArgs e)
        {
            string uri = "https://ehealth-dev.pt-infra.net/uaa/oauth/token";
            var client = new RestClient(uri);
            client.Timeout = 5000;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded; charset=utf-8");
            request.AddHeader("Authorization", "Basic YnJvd3NlcjpLM2s5U2FHa0hyM0dTeXJT");
            request.AlwaysMultipartFormData = true;
            request.AddParameter("username", "nvdang");
            request.AddParameter("password", "12345678x@X");
            request.AddParameter("grant_type", "password");
            IRestResponse response = client.Execute(request);

            var temp = (JObject)JsonConvert.DeserializeObject(response.Content);
            var token = temp["access_token"];

            uri = "https://ehealth-dev.pt-infra.net/health-data-service/caring/ecg?" +
                "device_id=5eef8330610b803fc3f15d89&start=1589095437&end=1590480422";
            client = new RestClient(uri);
            client.Timeout = 5000;
            request = new RestRequest(Method.GET);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", $"Bearer {token}");
            IRestResponse response2 = client.Execute(request);

            var temp2 = JToken.FromObject(JsonConvert.DeserializeObject(response2.Content)).Last;// JsonConvert.DeserializeObject(response2.Content);
            //var temp3 = temp2.Last;
            
            string[] temp3 = temp2.Value<string>("filterSigns").Split(',');
            double[] sigs2 = temp3.Select(double.Parse).ToArray();

            // get an empty ECG format file
            string type = "SCP-ECG";
            
            IECGFormat format = ECGConverter.Instance.getFormat(type);
            if (format != null)
            {
                // five required actions for the demographic info
                format.Demographics.Init();
                format.Demographics.PatientID = "Test082020";
                format.Demographics.LastName = "Trinh";
                format.Demographics.TimeAcquisition = DateTime.Now;
                //Make an AcquiringDeviceID object
                AcquiringDeviceID acqID = new AcquiringDeviceID(true);

                // can specify your own acquiring device info
                Communication.IO.Tools.BytesTool.writeString("MYDEVICE", acqID.ModelDescription,
                    0, acqID.ModelDescription.Length);
                // set the Acquiring Device ID (required)
                format.Demographics.AcqMachineID = acqID;


                // declare the signals part
                LeadType[] lt = new LeadType[] { LeadType.I };
                Signals sigs = new Signals((byte)lt.Length);
                sigs.RhythmAVM = 0.1;
                int rhythmSPS = 250;
                int rhythmSecs = (int)(sigs2.Length / rhythmSPS);
                sigs.RhythmSamplesPerSecond = rhythmSPS;
                for (int i = 0; i < sigs.NrLeads; i++)
                {
                    // ignore this part (Making some ECG data)

                    /*
                    for (int k = 0; k < sigs2.Length; k++)
                    {
                        sigs2[k] = sigs2[k] / sigs.RhythmAVM;
                    }

                    short[] rhythm = Array.ConvertAll(sigs2, input => (short)input);// (short[])sigs2;
                    */

                    short[] rhythm = new short[rhythmSPS * rhythmSecs];

                    for (int j = 0; j < rhythm.Length; j++)
                    {
                        rhythm[j] = (short)(sigs2[j] / 1);
                    }
                    
                    /*
                    for (int j = 0; j < rhythm.Length; j++)
                    {
                        rhythm[j] = (short)
                            ((1000.0 / ((rhythmSPS >> 1) - (j % (rhythmSPS >> 1)))) / sigs.RhythmAVM);
                        if ((i & 1) != 0)
                        {
                            rhythm[j] = (short)(-rhythm[j]);
                        }
                        if ((i % 3) == 1)
                        {
                            rhythm[j] *= 1;
                        }
                    }
                    */

                    // very important to assign signal
                    sigs[i] = new Signal();
                    sigs[i].Type = lt[i];
                    sigs[i].Rhythm = rhythm;
                    sigs[i].RhythmStart = 0;
                    sigs[i].RhythmEnd = rhythm.Length - 1;
                }

                // store signals to the format
                if (format.Signals.setSignals(sigs) != 0)
                {
                    MessageBox.Show("setSignals failed!");
                }
                // write the file
                ECGWriter.Write(format, "D:\\EcgInteg\\EcgIntegVer1\\test2.scp", true);
                if (ECGWriter.getLastError() != 0)
                {
                    MessageBox.Show("Writing failed: {0}!", ECGWriter.getLastErrorMessage());
                }

                int n = 0;
                int[,] s = { { 782, 492 }, { 1042, 657 }, { 1302, 822 } };

                int w = 1362;
                int h = 541;

                for (; n < s.GetLength(0); n++)
                    if ((s[n, 0] > w)
                    || (s[n, 1] > h))
                        break;

                n += 2;

                Bitmap ecgBitmap = new Bitmap(w, h);

                ECGDraw.DpiX = ECGDraw.DpiY = 25.4f * n;
                ECGDraw.DisplayGrid = ECGDraw.GridType.OneMillimeters;
                ECGDraw.BackColor = Color.White;
                ECGDraw.GraphColor = Color.FromArgb(255, 187, 187);
                ECGDraw.GraphSecondColor = Color.FromArgb(255, 229, 229);
                ECGDraw.SignalColor = Color.Black;
                ECGDraw.TextColor = Color.Black;
                for (int l = 0; l < sigs.NrLeads; l++)
                {
                    ECGTool.NormalizeSignal(sigs[l].Rhythm, sigs.RhythmSamplesPerSecond);
                }
                Signals temp4 = sigs.CalculateTwelveLeads();
                if (temp4 == null)
                    temp4 = sigs.CalculateFifteenLeads();

                if (temp4 != null)
                    sigs = temp4;

                int ret = ECGDraw.DrawECG(Graphics.FromImage(ecgBitmap), sigs, ECGDraw.ECGDrawType.Regular, 0, 25.0f, 10.0f);
                if (ret < 0)
                {
                    MessageBox.Show("Fail to create bitmap.");
                }
                else
                {
                    string imageFile = "D:\\EcgInteg\\EcgIntegVer1\\test2.png";
                    
                    ecgBitmap.Save(imageFile, ImageFormat.Png);
                    //ecgBitmap.Dispose();
                    MessageBox.Show("OK!");
                }
            }
        }
    }
}
