﻿using System;
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
            //temp.NrLeads.

            MessageBox.Show(success.ToString());
        }
    }
}
