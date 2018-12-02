/***************************************************/
/***  INCLUDE               ************************/
/***************************************************/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/***************************************************/
/***  THE CLASS             ************************/
/***************************************************/
public class GaussianRandom :
    MonoBehaviour
{
    #region Sub-classes/enum
    /***************************************************/
    /***  SUB-CLASSES/ENUM      ************************/
    /***************************************************/

    /********  PUBLIC           ************************/

    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/

    #endregion
    #region Property
    /***************************************************/
    /***  PROPERTY              ************************/
    /***************************************************/



    #endregion
    #region Constants
    /***************************************************/
    /***  CONSTANTS             ************************/
    /***************************************************/



    #endregion
    #region Attributes
    /***************************************************/
    /***  ATTRIBUTES            ************************/
    /***************************************************/



    #endregion
    #region Methods
    /***************************************************/
    /***  METHODS               ************************/
    /***************************************************/

    /********  UNITY MESSAGES   ************************/
    
    /********  OUR MESSAGES     ************************/

    /********  PUBLIC           ************************/

    public static double Value()
    {
        double u, v, S;

        do
        {
            u = 2.0 * Random.value - 1.0;
            v = 2.0 * Random.value - 1.0;
            S = u * u + v * v;
        }
        while (S >= 1.0);

        double fac = System.Math.Sqrt(-2.0 * System.Math.Log(S) / S);
        return u * fac;
    }

    public static double NextDouble(double p_mean, double p_sigma)
    {
        return Value() * p_sigma + p_mean;
    }

    public static double NextClampedDouble(double p_min, double p_max)
    {
        double mean = (p_min + p_max) / 2;
        double sigma = (p_max - mean) / 3;

        return NextDouble(mean, sigma);
    }

    public static void TestDouble(int  p_nbValues, double p_min, double p_max)
    {
        double[] values = new double[p_nbValues];
        string text = "";
        for(int i = 0; i < p_nbValues; ++i)
        {
            values[i] = NextClampedDouble(p_min, p_max);
            text += values[i] + ", ";
        }

        Debug.Log(text.Substring(0, text.Length-2));
    }

    public static int NextInt(double p_mean, double p_sigma)
    {
        return (int) System.Math.Round(Value() * p_sigma + p_mean);
    }

    public static int NextClampedInt(int p_min, int p_max)
    {
        double mean = (p_min + p_max) / 2.0;
        double sigma = (p_max - mean) / 3.0;

        return NextInt(mean, sigma);
    }

    public static void TestInt(int p_nbValues, int p_min, int p_max)
    {
        double[] values = new double[p_nbValues];
        string text = "";
        for (int i = 0; i < p_nbValues; ++i)
        {
            values[i] = NextClampedDouble(p_min, p_max);
            text += values[i] + ", ";
        }

        Debug.Log(text.Substring(0, text.Length - 2));
    }

    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/

    #endregion
}
