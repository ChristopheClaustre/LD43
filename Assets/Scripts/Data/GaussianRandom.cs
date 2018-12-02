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

    public static double NextStandardGaussianDouble()
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

    public static double NextGaussianDouble(double mean, double sigma)
    {
        double value = NextStandardGaussianDouble();

        return value * sigma + mean;
    }

    public static double NextNormalizedGaussianDouble(double min, double max)
    {
        double mean = (min + max) / 2;
        double sigma = (max - mean) / 3;

        return NextGaussianDouble(mean, sigma);
    }

    public static void Test(int  p_nbValues, double p_min, double p_max)
    {
        double[] values = new double[p_nbValues];
        string text = "";
        for(int i = 0; i < p_nbValues; ++i)
        {
            values[i] = NextNormalizedGaussianDouble(p_min, p_max);
            text += values[i] + ", ";
        }

        Debug.Log(text.Substring(0, text.Length-2));
    }

    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/

    #endregion
}
