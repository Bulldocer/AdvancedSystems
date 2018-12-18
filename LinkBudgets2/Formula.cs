using System;

/// <summary>
/// The possible formulas used
/// </summary>
public enum FormulaType
{
    Invalid = -1,

    OkumuraHata,
    Cost231Hata,

    Count
}

/// <summary>
/// The possible area types in which to operate
/// </summary>
public enum AreaType
{
    BigCity = 1,
    MediumSmallCity,
    Suburban,
    Rural,

    Count
}

/// <summary>
/// The main class to do the required calculations by the exercise
/// </summary>
public static class Formula
{
    #region Public Attributes

    public const float OkumuraHataMinThresholdFreqMhz = 150;
    public const float OkumuraHataMaxThresholdFreqMhz = 1500;

    public const float Cost231HataMinThresholdFreqMhz = 1500;
    public const float Cost231HataMaxThresholdFreqMhz = 2300;
    public const float Cost231GTermBigCities = 3.0f;
    public const float Cost231GTermOtherAreas = 0.0f;

    public const float MinThresholdHbMeters = 30;
    public const float MaxThresholdHbMeters = 200;

    public const float MinThresholdHmMeters = 1;
    public const float MaxThresholdHmMeters = 10;

    public const float MinThresholdDistKm = 1;
    public const float MaxThresholdDistKm = 20;

    public const float BigCityCTermFreqThresholdInMhz = 300;

    #endregion

    #region Public Methods

    /// <summary>
    /// Calculate the loss in dB with the given parameters. The correct formula is automatically chosen depending on the values
    /// </summary>
    /// <param name="areaType">The area type</param>
    /// <param name="f">The frequency in Mhz</param>
    /// <param name="hb">The effective height of the base station antenna in meters</param>
    /// <param name="hm">The height over the ground of the mobile in meters</param>
    /// <param name="d">The distance between the mobile and the base station in Km</param>
    /// <param name="usedFormula">Outputs the formula that was used</param>
    /// <returns></returns>
    public static float CalculatePropagationLoss(AreaType areaType, float f, float hb, float hm, float d, out FormulaType usedFormula)
    {
        float result = 0.0f;
        usedFormula = FormulaType.Invalid;

        // TODO: what at exactly 1500 Mhz? probably the result is the same...
        if (f >= OkumuraHataMinThresholdFreqMhz && f <= OkumuraHataMaxThresholdFreqMhz)
        {
            result = CalculateOkumuraHataPropLoss(areaType, f, hb, hm, d);
            usedFormula = FormulaType.OkumuraHata;
        }
        else if (f >= Cost231HataMinThresholdFreqMhz && f <= Cost231HataMaxThresholdFreqMhz)
        {
            result = CalculateCost231HataPropLoss(areaType, f, hb, hm, d);
            usedFormula = FormulaType.Cost231Hata;
        }

        return result;
    }

    /// <summary>
    /// Calculate the maximum allowed distance given the parameters. The correct formula is automatically chosen depending on the values
    /// </summary>
    /// <param name="areaType">The area type</param>
    /// <param name="lossDb">The propagation loss margin</param>
    /// <param name="f">The frequency in Mhz</param>
    /// <param name="hb">The effective height of the base station antenna in meters</param>
    /// <param name="hm">The height over the ground of the mobile in meters</param>
    /// <param name="usedFormula">Outputs the formula that was used</param>
    /// <returns></returns>
    public static float CalculateMaxDistance(AreaType areaType, float lossDb, float f, float hb, float hm, out FormulaType usedFormula)
    {
        float result = 0.0f;
        usedFormula = FormulaType.Invalid;

        // TODO: what at exactly 1500 Mhz? probably the result is the same...
        if (f >= OkumuraHataMinThresholdFreqMhz && f <= OkumuraHataMaxThresholdFreqMhz)
        {
            result = CalculateOkumuraHataMaxDist(areaType, lossDb, f, hb, hm);
            usedFormula = FormulaType.OkumuraHata;
        }
        else if (f >= Cost231HataMinThresholdFreqMhz && f <= Cost231HataMaxThresholdFreqMhz)
        {
            result = CalculateCost231HataMaxDist(areaType, lossDb, f, hb, hm);
            usedFormula = FormulaType.Cost231Hata;
        }

        return result;
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Calculate the loss in dB with the given parameters using the Okumura-Hata formula
    /// </summary>
    /// <param name="areaType">The area type</param>
    /// <param name="f">The frequency in Mhz</param>
    /// <param name="hb">The effective height of the base station antenna in meters</param>
    /// <param name="hm">The height over the ground of the mobile in meters</param>
    /// <param name="d">The distance between the mobile and the base station in Km</param>
    /// <returns></returns>
    private static float CalculateOkumuraHataPropLoss(AreaType areaType, float f, float hb, float hm, float d)
    {
        float a = CalculateATerm(f, hb);
        float b = CalculateBTerm(hb);
        float c = CalculateCTerm(areaType, f, hm);

        return a + b * MathUtils.Log10Float(d) - c;
    }

    /// <summary>
    /// Calculate the loss in dB with the given parameters using the Cost231-Hata formula
    /// </summary>
    /// <param name="areaType">The area type</param>
    /// <param name="f">The frequency in Mhz</param>
    /// <param name="hb">The effective height of the base station antenna in meters</param>
    /// <param name="hm">The height over the ground of the mobile in meters</param>
    /// <param name="d">The distance between the mobile and the base station in Km</param>
    /// <returns></returns>
    private static float CalculateCost231HataPropLoss(AreaType areaType, float f, float hb, float hm, float d)
    {
        float fTerm = CalculateFTerm(f, hb);
        float b = CalculateBTerm(hb);
        float c = CalculateCTerm(areaType, f, hm);
        float g = CalculateGTerm(areaType);

        return fTerm + b * MathUtils.Log10Float(d) - c + g;
    }

    /// <summary>
    /// Calculate the maximum distance in kilometers with the given parameters using the Okumura-Hata formula
    /// </summary>
    /// <param name="areaType">The area type</param>
    /// <param name="lossDb">The propagation loss margin</param>
    /// <param name="f">The frequency in Mhz</param>
    /// <param name="hb">The effective height of the base station antenna in meters</param>
    /// <param name="hm">The height over the ground of the mobile in meters</param>
    /// <returns></returns>
    private static float CalculateOkumuraHataMaxDist(AreaType areaType, float lossDb, float f, float hb, float hm)
    {
        float a = CalculateATerm(f, hb);
        float b = CalculateBTerm(hb);
        float c = CalculateCTerm(areaType, f, hm);

        return MathUtils.TenPowXFloat((lossDb - a + c) / b);
    }

    /// <summary>
    /// Calculate the maximum distance in kilometers with the given parameters using the Cost231-Hata formula
    /// </summary>
    /// <param name="areaType">The area type</param>
    /// <param name="lossDb">The propagation loss margin</param>
    /// <param name="f">The frequency in Mhz</param>
    /// <param name="hb">The effective height of the base station antenna in meters</param>
    /// <param name="hm">The height over the ground of the mobile in meters</param>
    /// <returns></returns>
    private static float CalculateCost231HataMaxDist(AreaType areaType, float lossDb, float f, float hb, float hm)
    {
        float fTerm = CalculateFTerm(f, hb);
        float b = CalculateBTerm(hb);
        float c = CalculateCTerm(areaType, f, hm);
        float g = CalculateGTerm(areaType);

        return MathUtils.TenPowXFloat((lossDb - fTerm + c - g) / b);
    }

    /// <summary>
    /// Calculate the A term in the Okumura-Hata method given the parameters
    /// </summary>
    /// <param name="f">The frequency in Mhz</param>
    /// <param name="hb">The effective height of the base station antenna in meters</param>
    /// <returns></returns>
    private static float CalculateATerm(float f, float hb)
    {
        return 69.55f + 26.16f * MathUtils.Log10Float(f) - 13.82f * MathUtils.Log10Float(hb);
    }

    /// <summary>
    /// Calculate the B term in the Okumura-Hata or Cost231-Hata method given the parameters
    /// </summary>
    /// <param name="hb">The effective height of the base station antenna in meters</param>
    /// <returns></returns>
    private static float CalculateBTerm(float hb)
    {
        return 44.90f - 6.55f * MathUtils.Log10Float(hb);
    }

    /// <summary>
    /// Calculate the C term in the Okumura-Hata or Cost231-Hata method given the parameters
    /// </summary>
    /// <param name="areaType">The area type</param>
    /// <param name="f">The frequency in Mhz</param>
    /// <param name="hm">The height over the ground of the mobile in meters</param>
    /// <returns></returns>
    private static float CalculateCTerm(AreaType areaType, float f, float hm)
    {
        float c = 0.0f;

        switch (areaType)
        {
            case AreaType.BigCity:
                float x = f < BigCityCTermFreqThresholdInMhz ? 8.29f : 3.2f;
                float y = f < BigCityCTermFreqThresholdInMhz ? 1.54f : 11.75f;
                float z = f < BigCityCTermFreqThresholdInMhz ? 1.1f : 4.97f;
                c = x * MathUtils.Pow2Float(MathUtils.Log10Float(y * hm)) - z;
                break;
            case AreaType.MediumSmallCity:
                c = (1.1f * MathUtils.Log10Float(f) - 0.7f) * hm - 1.56f * MathUtils.Log10Float(f) + 0.8f;
                break;
            case AreaType.Suburban:
                c = 2.0f * MathUtils.Pow2Float(MathUtils.Log10Float(f / 28.0f)) + 5.4f;
                break;
            case AreaType.Rural:
                c = 4.78f * MathUtils.Pow2Float(MathUtils.Log10Float(f)) - 18.33f * MathUtils.Log10Float(f) + 40.94f;
                break;
            default:
                Console.WriteLine("The area type " + areaType.ToString() + " is not valid !");
                break;
        }

        return c;
    }

    /// <summary>
    /// Calculate the F term in the Cost231-Hata method given the parameters
    /// </summary>
    /// <param name="f">The frequency in Mhz</param>
    /// <param name="hb">The effective height of the base station antenna in meters</param>
    /// <returns></returns>
    private static float CalculateFTerm(float f, float hb)
    {
        return 46.3f + 33.9f * MathUtils.Log10Float(f) - 13.82f * MathUtils.Log10Float(hb);
    }

    /// <summary>
    /// Calculate the G term in the Cost231-Hata method given the parameters
    /// </summary>
    /// <param name="areaType">The area type</param>
    /// <returns></returns>
    private static float CalculateGTerm(AreaType areaType)
    {
        return areaType == AreaType.BigCity ? Cost231GTermBigCities : Cost231GTermOtherAreas;
    }

    #endregion
}
