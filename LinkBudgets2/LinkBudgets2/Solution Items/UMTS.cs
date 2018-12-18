/// <summary>
/// Class to instantiate UMTS links budget calculations
/// </summary>
public class UMTS
{
    #region Properties

    public float A1 { get; }
    public float A2 { get; }
    public float A3 { get; }
    public float A4 { get; }
    public float A5 { get; }
    public float A6 { get; }
    public float A7 { get; }
    public float A8 { get; }
    public float A9 { get; }
    public float A10 { get; }
    public float A11 { get; }
    public float A12 { get; }
    public float A13 { get; }
    public float A14 { get; }
    public float A15 { get; }
    public float A16 { get; }

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
