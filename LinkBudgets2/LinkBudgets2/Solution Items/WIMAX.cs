using System;

public class WIMAX
{
    #region Properties
    public float A1 { get; }  //Power amplifier output power
    public float A2 { get; }  //Number of tx antennas
    public float A3 { get; }  //Transmit antenna gain
    public float A4 { get; }  //Transmitter loss
    public float A5 { get; }  //Effective isotropic radiated power
    public float A6 { get; }  //Channel bandwidth
    public float A7 { get; }  //Number of subchannels
    public float A8 { get; }  //Receiver noise level
    public float A9 { get; }  //Receiver noise figure
    public float A10 { get; } //Required SNR
    public float A11 { get; } //Macro diversity gain
    public float A12 { get; } //Subchannelization gain
    public float A13 { get; } //Receiver sensitivity
    public float A14 { get; } //Receiver antenna gain
    public float A15 { get; } //Receiver loss
    public float A16 { get; } //System gain
    public float A17 { get; } //Shadow-fade margin
    public float A18 { get; } //Building penetratrion loss
    public float A19 { get; } //Link margin
    #endregion


    public WIMAX(float a1, float a2, float a3, float a4, float a6, float a7, float a9, float a10, float a11, float a14, float a15, float a17, float a18)
	{

        A1 = a1;
        A2 = a2;
        A3 = a3;
        A4 = a4;
        A5 = CalculateA5(a1, a2, a3, a4);
        A6 = a6;
        A7 = a7;
        A8 = CalculateA8(A6);
        A9 = a9;
        A10 = a10;
        A11 = a11;
        A12 = CalculateA12(A7);
        A13 = CalculateA13(A8, A9, A10, A11, A12);
        A14 = a14;
        A15 = a15;
        A16 = CalculateA16(A5, A13, A14, A15);
        A17 = a17;
        A18 = a18;
        A19 = CalculateA19(A16, A17, A18);

    }


    #region Methods

    private float CalculateA5(float A1, float A2, float A3, float A4)
    {
        return (float)(A1 + (10 * Math.Log10(A2) + A3 - A4));
    }
    
    private float CalculateA8(float A6)
    {
        return (float)(-174 + (10 * Math.Log10(A6 * Math.Pow(10, 6))));
    }

    private float CalculateA12(float A7)
    {
        return (float)(10 * Math.Log10(A7));
    }

    private float CalculateA13(float A8, float A9, float A10, float A11, float A12)
    {
        return A8 + A9 + A10 + A11 - A12;
    }

    private float CalculateA16(float A5, float A13, float A14, float A15)
    {
        return A5 - A13 + A14 - A15;
    }

    private float CalculateA19(float A16, float A17, float A18)
    {
        return A5 - A13 + A14 - A15;
    }
    
    #endregion
}
