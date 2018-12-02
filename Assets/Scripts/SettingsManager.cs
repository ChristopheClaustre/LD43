/***************************************************/
/***  INCLUDE               ************************/
/***************************************************/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

/***************************************************/
/***  THE CLASS             ************************/
/***************************************************/
public class SettingsManager :
    MonoBehaviour
{
    #region Sub-classes/enum
    /***************************************************/
    /***  SUB-CLASSES/ENUM      ************************/
    /***************************************************/

    [System.Serializable]
    public class Settings
    {
        public int[] categoriePrices;

        /* percent of categoriePrices */

        public double buyerPrice;
        public double buyerPriceMaxDerivation;

        // buyerIntriguedPrice = actual buyerPrice + buyerIntriguedPriceMaxDerivation
        public double buyerIntriguedPriceMaxDerivation;

        // buyerHighestPrice = (intrigued ? actual intrigued buyer price : actual buyer price) + buyerHighestPriceMaxDerivation
        public double buyerHighestPriceMaxDerivation;

        public double grandpaPrice;
        public double grandpaPriceMaxDerivation;
    }

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

    public static Settings Inst
    {
        get
        {
            return m_settings;
        }
    }

    #endregion
    #region Attributes
    /***************************************************/
    /***  ATTRIBUTES            ************************/
    /***************************************************/


    private static Settings m_settings = null;

    [SerializeField]
    private TextAsset m_settingsFile;

    #endregion
    #region Methods
    /***************************************************/
    /***  METHODS               ************************/
    /***************************************************/

    /********  UNITY MESSAGES   ************************/

    // Use this for initialization
    private void Start()
    {
        Debug.Assert(m_settingsFile != null, "Settings file not found...");

        string clearedString = Regex.Replace(m_settingsFile.text, "//.*\\n", "\n");
        clearedString = Regex.Replace(clearedString, "/\\**/", "");
        clearedString = Regex.Replace(clearedString, "/\\*+[^*]*\\*+(?:[^/*][^*]*\\*+)*/", "");
        
        m_settings = JsonUtility.FromJson<Settings>(clearedString);
    }

    // Update is called once per frame
    private void Update()
    {

    }

    /********  OUR MESSAGES     ************************/

    /********  PUBLIC           ************************/

    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/

    #endregion
}
