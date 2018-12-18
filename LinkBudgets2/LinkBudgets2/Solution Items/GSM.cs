using System;

public class GSM
{
    #region Properties
    public float A1 { get; }  //Power amplifier output power
    public float A2 { get; }  //Transmit antenna gain
    public float A3 { get; }  //Transmitter loss
    public float A4 { get; }  //Effective isotropic radiated power
    public float A5 { get; }  //Channel bandwidth
    public float A6 { get; }  //Receiver noise level
    public float A7 { get; }  //Receiver noise figure
    public float A8 { get; }  //Required SNR
    public float A9 { get; }  //Macro diversity gain
    public float A10 { get; } //Reciever sensitivity
    public float A11 { get; } //Receiver antenna gain
    public float A12 { get; } //Receiver loss
    public float A13 { get; } //System gain
    public float A14 { get; } //Shadow-fade margin
    public float A15 { get; } //Building penetration loss
    public float A16 { get; } //Loss by the body
    public float A17 { get; } //Link margin
    #endregion

    public GSM(float _A1, float _A2, float _A3, float _A5, float _A7, float _A8, float _A9, float _A11, float _A12, float _A14, float _A15, float _A16)
	{
        A1 = _A1;
        A2 = _A2;
        A3 = _A3;
        A5 = _A5;
        A7 = _A7;
        A8 = _A8;
        A9 = _A9;
        A11 = _A11;
        A12 = _A12;
        A14 = _A14;
        A15 = _A15;
        A16 = _A16;

        A4 = CalculateA4();
        A6 = CalculateA6();
        A10 = CalculateA10();
        A13 = CalculateA13();
        A17 = CalculateA17();
    }

    float CalculateA4()
    {
        return A1 + A2 - A3;
    }

    float CalculateA6()
    {
        float log10A5103 = (float)Math.Log10(A5 * (10 ^ 3));
        return -174 + 10 * log10A5103;
    }

    float CalculateA10()
    {
        return A6 + A7 + A8 + A9;
    }

    float CalculateA13()
    {
        return A4 - A10 + A11 - A12;
    }

    float CalculateA17()
    {
        return A13 - A14 - A15 - A16;
    }
}
