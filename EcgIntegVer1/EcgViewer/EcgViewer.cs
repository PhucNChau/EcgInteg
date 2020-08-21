using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECGConversion;
using ECGConversion.ECGSignals;

namespace EcgViewer
{
    public class EcgViewer
    {
        //public UnknownECGReader TelEcgReader = null;
        private IECGFormat TelCurrentEcg = null;
        public Signals TelCurrentSignal = null;
        public IECGFormat CurrentEcg
        {
            get
            {
                lock (this)
                {
                    return TelCurrentEcg;
                }
            }
            set
            {
                lock (this)
                {
                    //_Zoom = 1;
                    //menuZoomIn.Enabled = true;
                    //menuZoomOut.Enabled = false;

                    //_OffsetX = 0;
                    //_OffsetY = 0;

                    if ((TelCurrentEcg != null) && (TelCurrentEcg != value))
                        TelCurrentEcg.Dispose();
                    if (value == null)
                    {
                        if (TelCurrentEcg != null)
                            TelCurrentEcg.Dispose();

                        TelCurrentEcg = null;
                        TelCurrentSignal = null;
                        //ECGTimeScrollbar.Visible = false;
                        //ECGTimeScrollbar.Enabled = false;
                    }
					else
					{
						//ECGTimeScrollbar.Visible = true;
						//ECGTimeScrollbar.Enabled = false;

						//Gain = 10f;
						TelCurrentEcg = value;

						if (TelCurrentEcg.Signals.getSignals(out TelCurrentSignal) != 0)
						{
							//this.statusBar.Text = "Failed to get signal!";
							
							TelCurrentEcg.Dispose();
							TelCurrentEcg = null;
						}
						else
						{
							if (TelCurrentSignal != null)
							{
								for (int i = 0, e = TelCurrentSignal.NrLeads; i < e; i++)
								{
									ECGTool.NormalizeSignal(TelCurrentSignal[i].Rhythm, TelCurrentSignal.RhythmSamplesPerSecond);
								}
							}

							Signals sig = TelCurrentSignal.CalculateTwelveLeads();
							if (sig == null)
								sig = TelCurrentSignal.CalculateFifteenLeads();

							if (sig != null)
								TelCurrentSignal = sig;

							if (TelCurrentSignal.IsBuffered)
							{
								BufferedSignals bs = TelCurrentSignal.AsBufferedSignals;

								bs.LoadSignal(bs.RealRhythmStart, bs.RealRhythmStart + 60 * bs.RhythmSamplesPerSecond);

								//ECGTimeScrollbar.Minimum = 0;
								//ECGTimeScrollbar.Maximum = bs.RealRhythmEnd - bs.RealRhythmStart;
								//ECGTimeScrollbar.Value = 0;
								//ECGTimeScrollbar.SmallChange = _CurrentSignal.RhythmSamplesPerSecond;
								//ECGTimeScrollbar.LargeChange = _CurrentSignal.RhythmSamplesPerSecond;
							}
							else
							{
								int start, end;

								TelCurrentSignal.CalculateStartAndEnd(out start, out end);

								//ECGTimeScrollbar.Minimum = 0;
								//ECGTimeScrollbar.Maximum = end - start;
								//ECGTimeScrollbar.Value = 0;
								//ECGTimeScrollbar.SmallChange = _CurrentSignal.RhythmSamplesPerSecond;
								//ECGTimeScrollbar.LargeChange = _CurrentSignal.RhythmSamplesPerSecond;
							}
						}

						ECGDraw.ECGDrawType dt = ECGDraw.PossibleDrawTypes(TelCurrentSignal);

						//menuLeadFormatRegular.Enabled = (dt & ECGDraw.ECGDrawType.Regular) != 0;
						//menuLeadFormatThreeXFour.Enabled = (dt & ECGDraw.ECGDrawType.ThreeXFour) != 0;
						//menuLeadFormatThreeXFourPlusOne.Enabled = (dt & ECGDraw.ECGDrawType.ThreeXFourPlusOne) != 0;
						//menuLeadFormatThreeXFourPlusThree.Enabled = (dt & ECGDraw.ECGDrawType.ThreeXFourPlusThree) != 0;
						//menuLeadFormatSixXTwo.Enabled = (dt & ECGDraw.ECGDrawType.SixXTwo) != 0;
						//menuLeadFormatMedian.Enabled = (dt & ECGDraw.ECGDrawType.Median) != 0;

						//if ((menuLeadFormatThreeXFour.Checked && !menuLeadFormatThreeXFour.Enabled)
						//|| (menuLeadFormatThreeXFourPlusOne.Checked && !menuLeadFormatThreeXFourPlusOne.Enabled)
						//|| (menuLeadFormatThreeXFourPlusThree.Checked && !menuLeadFormatThreeXFourPlusThree.Enabled)
						//|| (menuLeadFormatSixXTwo.Checked && !menuLeadFormatSixXTwo.Enabled)
						//|| (menuLeadFormatMedian.Checked && !menuLeadFormatMedian.Enabled))
						//{
						//	CheckLeadFormat(ECGDraw.ECGDrawType.Regular, false);
						//}
					}

				}

			}
        }

    }
}
