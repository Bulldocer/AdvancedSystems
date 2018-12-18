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
                    //Check frequency range (150 MHz - 2300 MHz)
                    if (float.Parse(WA6.Text) >= 150 && float.Parse(WA6.Text) <= 2300.0f)
                    {
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
                            float.Parse(WA18.Text)
                            );

                        WA5.Text = wimax.A5.ToString();
                        WA8.Text = wimax.A9.ToString();
                        WA12.Text = wimax.A12.ToString();
                        WA13.Text = wimax.A13.ToString();
                        WA16.Text = wimax.A16.ToString();
                        WLinkBudget.Text = "Link Budget: " + wimax.A19.ToString() + "dB";
                    }
                    else
                    {
                        MessageBox.Show("The channel bandwidth must be a value between 150 - 2300 MHz", "Out of Bounds", MessageBoxButton.OK, MessageBoxImage.Exclamation);
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
                    //Check frequency range (150 MHz - 2300 MHz)
                    if (float.Parse(GA5.Text) >= 150000.0f && float.Parse(GA5.Text) <= 2300000.0f)
                    {
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
                            float.Parse(GA16.Text));

                        GA4.Text = gsm.A4.ToString();
                        GA6.Text = gsm.A6.ToString();
                        GA10.Text = gsm.A10.ToString();
                        GA13.Text = gsm.A13.ToString();
                        GLinkBudget.Text = "Link Budget: " + gsm.A17.ToString() + "dB";

                    }
                    else
                    {
                        MessageBox.Show("The channel bandwidth must be a value between 150 000 - 2 300 000 KHz", "Out of Bounds", MessageBoxButton.OK, MessageBoxImage.Exclamation);
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
                        float.Parse(UA16.Text));

                    UA5.Text = umts.A5.ToString();
                    UA9.Text = umts.A9.ToString();
                    UA12.Text = umts.A12.ToString();
                    ULinkBudget.Text = "Link Budget: " + umts.A17.ToString() + "dB";
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
