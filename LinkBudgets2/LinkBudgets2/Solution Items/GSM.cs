using System;

public class GSM
{
    #region Public Variables
    public float A1 = 0;  //Power amplifier output power
    public float A2 = 0;  //Transmit antenna gain
    public float A3 = 0;  //Transmitter loss
    public float A4 = 0;  //Effective isotropic radiated power
    public float A5 = 0;  //Channel bandwidth
    public float A6 = 0;  //Receiver noise level
    public float A7 = 0;  //Receiver noise figure
    public float A8 = 0;  //Required SNR
    public float A9 = 0;  //Macro diversity gain
    public float A10 = 0; //Reciever sensitivity
    public float A11 = 0; //Receiver antenna gain
    public float A12 = 0; //Receiver loss
    public float A13 = 0; //System gain
    public float A14 = 0; //Shadow-fade margin
    public float A15 = 0; //Building penetration loss
    public float A16 = 0; //Loss by the body
    public float A17 = 0; //Link margin
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

        CalculateA4();
        CalculateA6();
        CalculateA10();
        CalculateA13();
        CalculateA17();
    }

    void CalculateA4()
    {
        A4 = A1 + A2 - A3;
    }

    void CalculateA6()
    {
        float log10A5103 = (float)Math.Log10(A5 * (10 ^ 3));
        A6 = -174 + 10 * log10A5103;
    }

    void CalculateA10()
    {
        A10 = A6 + A7 + A8 + A9;
    }

    void CalculateA13()
    {
        A13 = A4 - A10 + A11 - A12;
    }

    void CalculateA17()
    {
        A17 = A13 - A14 - A15 - A16;
    }
}
