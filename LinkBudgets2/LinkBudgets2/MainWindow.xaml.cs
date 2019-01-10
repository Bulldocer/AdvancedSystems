using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LinkBudgets2
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<TextBox> wimaxFields;
        List<TextBox> gsmFields;
        List<TextBox> umtsFields;

        public MainWindow()
        {
            InitializeComponent();
            
            GetFieldsWIMAX();
            GetFieldsGSM();
            GetFieldsUMTS();
        }

        private void GetFieldsWIMAX()
        {
            wimaxFields = new List<TextBox>();

            wimaxFields.Add(WA1);
            wimaxFields.Add(WA2);
            wimaxFields.Add(WA3);
            wimaxFields.Add(WA4);
            wimaxFields.Add(WA5);
            wimaxFields.Add(WA6);
            wimaxFields.Add(WA7);
            wimaxFields.Add(WA8);
            wimaxFields.Add(WA9);
            wimaxFields.Add(WA10);
            wimaxFields.Add(WA11);
            wimaxFields.Add(WA12);
            wimaxFields.Add(WA13);
            wimaxFields.Add(WA14);
            wimaxFields.Add(WA15);
            wimaxFields.Add(WA16);
            wimaxFields.Add(WA17);
            wimaxFields.Add(WA18);
            wimaxFields.Add(WA1D);
            wimaxFields.Add(WA2D);
            wimaxFields.Add(WA3D);
            wimaxFields.Add(WA4D);
            wimaxFields.Add(WA5D);
            wimaxFields.Add(WA6D);
            wimaxFields.Add(WA7D);
            wimaxFields.Add(WA8D);
            wimaxFields.Add(WA9D);
            wimaxFields.Add(WA10D);
            wimaxFields.Add(WA11D);
            wimaxFields.Add(WA12D);
            wimaxFields.Add(WA13D);
            wimaxFields.Add(WA14D);
            wimaxFields.Add(WA15D);
            wimaxFields.Add(WA16D);
            wimaxFields.Add(WA17D);
            wimaxFields.Add(WA18D);
            wimaxFields.Add(Wfrequency);
            wimaxFields.Add(WhStation);
            wimaxFields.Add(WhMobile);
        }

        private void GetFieldsGSM()
        {
            gsmFields = new List<TextBox>();

            gsmFields.Add(GA1);
            gsmFields.Add(GA2);
            gsmFields.Add(GA3);
            gsmFields.Add(GA4);
            gsmFields.Add(GA5);
            gsmFields.Add(GA6);
            gsmFields.Add(GA7);
            gsmFields.Add(GA8);
            gsmFields.Add(GA9);
            gsmFields.Add(GA10);
            gsmFields.Add(GA11);
            gsmFields.Add(GA12);
            gsmFields.Add(GA13);
            gsmFields.Add(GA14);
            gsmFields.Add(GA15);
            gsmFields.Add(GA16);
            gsmFields.Add(GA1D);
            gsmFields.Add(GA2D);
            gsmFields.Add(GA3D);
            gsmFields.Add(GA4D);
            gsmFields.Add(GA5D);
            gsmFields.Add(GA6D);
            gsmFields.Add(GA7D);
            gsmFields.Add(GA8D);
            gsmFields.Add(GA9D);
            gsmFields.Add(GA10D);
            gsmFields.Add(GA11D);
            gsmFields.Add(GA12D);
            gsmFields.Add(GA13D);
            gsmFields.Add(GA14D);
            gsmFields.Add(GA15D);
            gsmFields.Add(GA16D);
            gsmFields.Add(Gfrequency);
            gsmFields.Add(GhMobile);
            gsmFields.Add(GhStation);
        }

        private void GetFieldsUMTS()
        {
            umtsFields = new List<TextBox>();

            umtsFields.Add(UA1);
            umtsFields.Add(UA2);
            umtsFields.Add(UA3);
            umtsFields.Add(UA4);
            umtsFields.Add(UA5);
            umtsFields.Add(UA6);
            umtsFields.Add(UA7);
            umtsFields.Add(UA8);
            umtsFields.Add(UA9);
            umtsFields.Add(UA10);
            umtsFields.Add(UA11);
            umtsFields.Add(UA12);
            umtsFields.Add(UA13);
            umtsFields.Add(UA14);
            umtsFields.Add(UA15);
            umtsFields.Add(UA16);
            umtsFields.Add(UA1D);
            umtsFields.Add(UA2D);
            umtsFields.Add(UA3D);
            umtsFields.Add(UA4D);
            umtsFields.Add(UA5D);
            umtsFields.Add(UA6D);
            umtsFields.Add(UA7D);
            umtsFields.Add(UA8D);
            umtsFields.Add(UA9D);
            umtsFields.Add(UA10D);
            umtsFields.Add(UA11D);
            umtsFields.Add(UA12D);
            umtsFields.Add(UA13D);
            umtsFields.Add(UA14D);
            umtsFields.Add(UA15D);
            umtsFields.Add(UA16D);
            umtsFields.Add(Ufrequency);
            umtsFields.Add(UhMobile);
            umtsFields.Add(UhStation);
        }

        void CalculateWIMAX(object sender, RoutedEventArgs e)
        {
            try
            {
                bool missingValue = false;

                //Check that the values are alright
                foreach (TextBox tb in wimaxFields)
                {
                    if (tb.Text.Length > 0) { float.Parse(tb.Text); } //Will be catched as error if wrong
                    else if (tb.IsEnabled) missingValue = true;
                }

                //Check fields occupied
                if (!missingValue)
                {
                    if (float.Parse(Wfrequency.Text) >= Formula.OkumuraHataMinThresholdFreqMhz && float.Parse(Wfrequency.Text) <= Formula.Cost231HataMaxThresholdFreqMhz)
                    {
                        //Uplink
                        WIMAX wimax = new WIMAX(float.Parse(WA1.Text),
                            float.Parse(WA2.Text),
                            float.Parse(WA3.Text),
                            float.Parse(WA4.Text),
                            float.Parse(WA6.Text),
                            float.Parse(WA7.Text),
                            float.Parse(WA9.Text),
                            float.Parse(WA10.Text),
                            float.Parse(WA11.Text),
                            float.Parse(WA14.Text),
                            float.Parse(WA15.Text),
                            float.Parse(WA17.Text),
                            float.Parse(WA18.Text),
                            float.Parse(Wfrequency.Text),
                            float.Parse(WhStation.Text),
                            float.Parse(WhMobile.Text)
                            );

                        WA5.Text = wimax.A5.ToString();
                        WA8.Text = wimax.A9.ToString();
                        WA12.Text = wimax.A12.ToString();
                        WA13.Text = wimax.A13.ToString();
                        WA16.Text = wimax.A16.ToString();
                        WLinkBudget.Text = wimax.A19.ToString();

                        //Downlink
                        WIMAX wimaxD = new WIMAX(float.Parse(WA1D.Text),
                            float.Parse(WA2D.Text),
                            float.Parse(WA3D.Text),
                            float.Parse(WA4D.Text),
                            float.Parse(WA6D.Text),
                            float.Parse(WA7D.Text),
                            float.Parse(WA9D.Text),
                            float.Parse(WA10D.Text),
                            float.Parse(WA11D.Text),
                            float.Parse(WA14D.Text),
                            float.Parse(WA15D.Text),
                            float.Parse(WA17D.Text),
                            float.Parse(WA18D.Text),
                            float.Parse(Wfrequency.Text),
                            float.Parse(WhStation.Text),
                            float.Parse(WhMobile.Text)
                            );

                        WA5D.Text = wimaxD.A5.ToString();
                        WA8D.Text = wimaxD.A9.ToString();
                        WA12D.Text = wimaxD.A12.ToString();
                        WA13D.Text = wimaxD.A13.ToString();
                        WA16D.Text = wimaxD.A16.ToString();
                        WLinkBudgetD.Text = wimaxD.A19.ToString();

                        WLinkBudgetT1.Visibility = Visibility.Visible;
                        WLinkBudgetT2.Visibility = Visibility.Visible;

                        if (wimax.A19 < wimaxD.A19)
                        {
                            WCoverageRangeB.Text = "Coverage range (Big city): " + wimax.BigRange.ToString() + " km";
                            WCoverageRangeMS.Text = "Coverage range (Medium/Small city): " + wimax.MediumRange.ToString() + " km";
                            WcoverageRangeS.Text = "Coverage range (Suburban): " + wimax.SuburbanRange.ToString() + " km";
                            WcoverageRangeR.Text = "Coverage range (Rural): " + wimax.RuralRange.ToString() + " km";

                            WLinkBudget.Background = new SolidColorBrush(Color.FromArgb(255, 0, 255, 0));
                            WLinkBudgetD.Background = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
                        }
                        else
                        {
                            WCoverageRangeB.Text = "Coverage range (Big city): " + wimaxD.BigRange.ToString() + " km";
                            WCoverageRangeMS.Text = "Coverage range (Medium/Small city): " + wimaxD.MediumRange.ToString() + " km";
                            WcoverageRangeS.Text = "Coverage range (Suburban): " + wimaxD.SuburbanRange.ToString() + " km";
                            WcoverageRangeR.Text = "Coverage range (Rural): " + wimaxD.RuralRange.ToString() + " km";

                            if (wimax.A19 == wimaxD.A19)
                            {
                                WLinkBudget.Background = new SolidColorBrush(Color.FromArgb(255, 0, 255, 0));
                                WLinkBudgetD.Background = new SolidColorBrush(Color.FromArgb(255, 0, 255, 0));
                            }
                            else
                            {
                                WLinkBudget.Background = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
                                WLinkBudgetD.Background = new SolidColorBrush(Color.FromArgb(255, 0, 255, 0));
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Frequency is out of bounds, it should be a value in the range of 150-2300 MHz","Out of bounds", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("Missing fields, please fill all the fields available", "Missing fields", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
            catch
            {
                MessageBox.Show("Wrong values detected, please insert numbers in the fields", "Wrong values", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        void CalculateGSM(object sender, RoutedEventArgs e)
        {
            try
            {
                bool missingValue = false;

                //Check that the values are alright
                foreach (TextBox tb in gsmFields)
                {
                    if (tb.Text.Length > 0) { float.Parse(tb.Text); } //Will be catched as error if wrong
                    else if (tb.IsEnabled) missingValue = true;
                }

                //Check fields occupied
                if (!missingValue)
                {
                    if (float.Parse(Gfrequency.Text) >= Formula.OkumuraHataMinThresholdFreqMhz && float.Parse(Gfrequency.Text) <= Formula.Cost231HataMaxThresholdFreqMhz)
                    {
                        //Uplink
                        GSM gsm = new GSM(float.Parse(GA1.Text),
                        float.Parse(GA2.Text),
                        float.Parse(GA3.Text),
                        float.Parse(GA5.Text),
                        float.Parse(GA7.Text),
                        float.Parse(GA8.Text),
                        float.Parse(GA9.Text),
                        float.Parse(GA11.Text),
                        float.Parse(GA12.Text),
                        float.Parse(GA14.Text),
                        float.Parse(GA15.Text),
                        float.Parse(GA16.Text),
                        float.Parse(Gfrequency.Text),
                        float.Parse(GhStation.Text),
                        float.Parse(GhMobile.Text)
                        );

                        GA4.Text = gsm.A4.ToString();
                        GA6.Text = gsm.A6.ToString();
                        GA10.Text = gsm.A10.ToString();
                        GA13.Text = gsm.A13.ToString();
                        GLinkBudget.Text = gsm.A17.ToString();

                        //Downlink
                        GSM gsmD = new GSM(float.Parse(GA1D.Text),
                            float.Parse(GA2D.Text),
                            float.Parse(GA3D.Text),
                            float.Parse(GA5D.Text),
                            float.Parse(GA7D.Text),
                            float.Parse(GA8D.Text),
                            float.Parse(GA9D.Text),
                            float.Parse(GA11D.Text),
                            float.Parse(GA12D.Text),
                            float.Parse(GA14D.Text),
                            float.Parse(GA15D.Text),
                            float.Parse(GA16D.Text),
                            float.Parse(Gfrequency.Text),
                            float.Parse(GhStation.Text),
                            float.Parse(GhMobile.Text));

                        GA4D.Text = gsmD.A4.ToString();
                        GA6D.Text = gsmD.A6.ToString();
                        GA10D.Text = gsmD.A10.ToString();
                        GA13D.Text = gsmD.A13.ToString();
                        GLinkBudgetD.Text = gsmD.A17.ToString();

                        GLinkBudgetT1.Visibility = Visibility.Visible;
                        GLinkBudgetT2.Visibility = Visibility.Visible;

                        if (gsm.A17 < gsmD.A17)
                        {
                            GCoverageRangeB.Text = "Coverage range (Big city): " + gsm.BigRange.ToString() + " km";
                            GCoverageRangeMS.Text = "Coverage range (Medium/Small city): " + gsm.MediumRange.ToString() + " km";
                            GcoverageRangeS.Text = "Coverage range (Suburban): " + gsm.SuburbanRange.ToString() + " km";
                            GcoverageRangeR.Text = "Coverage range (Rural): " + gsm.RuralRange.ToString() + " km";

                            GLinkBudget.Background = new SolidColorBrush(Color.FromArgb(255,0,255,0));
                            GLinkBudgetD.Background = new SolidColorBrush(Color.FromArgb(255,255,0,0));
                        }
                        else
                        {
                            GCoverageRangeB.Text = "Coverage range (Big city): " + gsmD.BigRange.ToString() + " km";
                            GCoverageRangeMS.Text = "Coverage range (Medium/Small city): " + gsmD.MediumRange.ToString() + " km";
                            GcoverageRangeS.Text = "Coverage range (Suburban): " + gsmD.SuburbanRange.ToString() + " km";
                            GcoverageRangeR.Text = "Coverage range (Rural): " + gsmD.RuralRange.ToString() + " km";

                            if (gsm.A17 == gsmD.A17)
                            {
                                GLinkBudget.Background = new SolidColorBrush(Color.FromArgb(255, 0, 255, 0));
                                GLinkBudgetD.Background = new SolidColorBrush(Color.FromArgb(255, 0, 255, 0));
                            }
                            else
                            {
                                GLinkBudget.Background = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
                                GLinkBudgetD.Background = new SolidColorBrush(Color.FromArgb(255, 0, 255, 0));
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Frequency is out of bounds, it should be a value in the range of 150-2300 MHz", "Out of bounds", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("Missing fields, please fill all the fields available", "Missing fields", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
            catch
            {
                MessageBox.Show("Wrong values detected, please insert numbers in the fields", "Wrong values", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        void CalculateUMTS(object sender, RoutedEventArgs e)
        {
            try
            {
                bool missingValue = false;

                //Check that the values are alright
                foreach (TextBox tb in umtsFields)
                {
                    if (tb.Text.Length > 0) { float.Parse(tb.Text); } //Will be catched as error if wrong
                    else if (tb.IsEnabled) missingValue = true;
                }

                //Check fields occupied
                if (!missingValue)
                {
                    if (float.Parse(Ufrequency.Text) >= Formula.OkumuraHataMinThresholdFreqMhz && float.Parse(Ufrequency.Text) <= Formula.Cost231HataMaxThresholdFreqMhz)
                    {
                        //Uplink
                        UMTS umts = new UMTS(float.Parse(UA1.Text),
                        float.Parse(UA2.Text),
                        float.Parse(UA3.Text),
                        float.Parse(UA4.Text),
                        float.Parse(UA6.Text),
                        float.Parse(UA7.Text),
                        float.Parse(UA8.Text),
                        float.Parse(UA10.Text),
                        float.Parse(UA11.Text),
                        float.Parse(UA13.Text),
                        float.Parse(UA14.Text),
                        float.Parse(UA15.Text),
                        float.Parse(UA16.Text),
                        float.Parse(Ufrequency.Text),
                        float.Parse(UhStation.Text),
                        float.Parse(UhMobile.Text));

                        UA5.Text = umts.A5.ToString();
                        UA9.Text = umts.A9.ToString();
                        UA12.Text = umts.A12.ToString();
                        ULinkBudget.Text = umts.A17.ToString();

                        //Downlink
                        UMTS umtsD = new UMTS(float.Parse(UA1D.Text),
                            float.Parse(UA2D.Text),
                            float.Parse(UA3D.Text),
                            float.Parse(UA4D.Text),
                            float.Parse(UA6D.Text),
                            float.Parse(UA7D.Text),
                            float.Parse(UA8D.Text),
                            float.Parse(UA10D.Text),
                            float.Parse(UA11D.Text),
                            float.Parse(UA13D.Text),
                            float.Parse(UA14D.Text),
                            float.Parse(UA15D.Text),
                            float.Parse(UA16D.Text),
                            float.Parse(Ufrequency.Text),
                            float.Parse(UhStation.Text),
                            float.Parse(UhMobile.Text));

                        UA5D.Text = umtsD.A5.ToString();
                        UA9D.Text = umtsD.A9.ToString();
                        UA12D.Text = umtsD.A12.ToString();
                        ULinkBudgetD.Text = umtsD.A17.ToString();

                        ULinkBudgetT1.Visibility = Visibility.Visible;
                        ULinkBudgetT2.Visibility = Visibility.Visible;

                        if (umts.A17 < umtsD.A17)
                        {
                            UCoverageRangeB.Text = "Coverage range (Big city): " + umts.BigCityResult.ToString() + " km";
                            UCoverageRangeMS.Text = "Coverage range (Medium/Small city): " + umts.MediumSmallCityResult.ToString() + " km";
                            UcoverageRangeS.Text = "Coverage range (Suburban): " + umts.Suburban.ToString() + " km";
                            UcoverageRangeR.Text = "Coverage range (Rural): " + umts.Rural.ToString() + " km";

                            ULinkBudget.Background = new SolidColorBrush(Color.FromArgb(255, 0, 255, 0));
                            ULinkBudgetD.Background = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
                        }
                        else
                        {
                            UCoverageRangeB.Text = "Coverage range (Big city): " + umtsD.BigCityResult.ToString() + " km";
                            UCoverageRangeMS.Text = "Coverage range (Medium/Small city): " + umtsD.MediumSmallCityResult.ToString() + " km";
                            UcoverageRangeS.Text = "Coverage range (Suburban): " + umtsD.Suburban.ToString() + " km";
                            UcoverageRangeR.Text = "Coverage range (Rural): " + umtsD.Rural.ToString() + " km";

                            if (umts.A17 == umtsD.A17)
                            {
                                ULinkBudget.Background = new SolidColorBrush(Color.FromArgb(255, 0, 255, 0));
                                ULinkBudgetD.Background = new SolidColorBrush(Color.FromArgb(255, 0, 255, 0));
                            }
                            else
                            {
                                ULinkBudget.Background = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
                                ULinkBudgetD.Background = new SolidColorBrush(Color.FromArgb(255, 0, 255, 0));
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Frequency is out of bounds, it should be a value in the range of 150-2300 MHz", "Out of bounds", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("Missing fields, please fill all the fields available", "Missing fields", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
            catch
            {
                MessageBox.Show("Wrong values detected, please insert numbers in the fields", "Wrong values", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
