/// <summary>
/// Class to instantiate UMTS links budget calculations
/// </summary>
public class UMTS
{
    #region Properties

    public float A1 { get; } // < Data rate
    public float A2 { get; } // < Power amplifier output power
    public float A3 { get; } // < Transmit antenna gain
    public float A4 { get; } // < Transmitter loss
    public float A5 { get; } // < Effective isotropic radiated power
    public float A6 { get; } // < Receiver antenna gain
    public float A7 { get; } // < Receiver loss
    public float A8 { get; } // < Receiver noise figure
    public float A9 { get; } // < Receiver noise level
    public float A10 { get; } // < Interference margin
    public float A11 { get; } // < Required SNR
    public float A12 { get; } // < Receiver sensitivity (dBm)
    public float A13 { get; } // < Macro diversity gain
    public float A14 { get; } // < Shadow-fade margin
    public float A15 { get; } // < Building penetration loss
    public float A16 { get; } // < Loss by the body
    public float A17 { get; } // < Link margin

    #endregion

    #region Initialization

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="A1"></param>
    /// <param name="A2"></param>
    /// <param name="A3"></param>
    /// <param name="A4"></param>
    /// <param name="A6"></param>
    /// <param name="A7"></param>
    /// <param name="A8"></param>
    /// <param name="A10"></param>
    /// <param name="A11"></param>
    /// <param name="A13"></param>
    /// <param name="A14"></param>
    /// <param name="A15"></param>
    /// <param name="A16"></param>
    public UMTS(float A1, float A2, float A3, float A4, float A6, float A7, float A8, float A10, float A11, float A13, float A14, float A15, float A16)
	{
        this.A1 = A1;
        this.A2 = A2;
        this.A3 = A3;
        this.A4 = A4;
        A5 = CalculateA5();
        this.A6 = A6;
        this.A7 = A7;
        this.A8 = A8;
        A9 = CalculateA9();
        this.A10 = A10;
        this.A11 = A11;
        A12 = CalculateA12();
        this.A13 = A13;
        this.A14 = A14;
        this.A15 = A15;
        this.A16 = A16;
        A17 = CalculateA17();
    }

    #endregion

    #region Methods

    /// <summary>
    /// Calculate effective isotropic radiated power
    /// </summary>
    /// <returns></returns>
    private float CalculateA5()
    {
        return A2 + A3 - A4;
    }

    /// <summary>
    /// Calculate receiver noise level
    /// </summary>
    /// <returns></returns>
    private float CalculateA9()
    {
        return -174 + A8;
    }

    /// <summary>
    /// Calculate the receiver sensitivity (dbm)
    /// </summary>
    /// <returns></returns>
    private float CalculateA12()
    {
        return CalculateA9() + 10 * MathUtils.Log10Float(A1) + A10 + A11;
    }

    /// <summary>
    /// Calculate the link margin
    /// </summary>
    /// <returns></returns>
    private float CalculateA17()
    {
        return CalculateA5() + A6 - A7 - CalculateA12() + A13 - A14;
    }

    #endregion
}
