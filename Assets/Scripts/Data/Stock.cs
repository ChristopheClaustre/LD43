/***************************************************/
/***  INCLUDE               ************************/
/***************************************************/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/***************************************************/
/***  THE CLASS             ************************/
/***************************************************/
public class Stock :
    MonoBehaviour
{
    #region Sub-classes/enum
    /***************************************************/
    /***  SUB-CLASSES/ENUM      ************************/
    /***************************************************/

    [System.Serializable]
    public struct Stuff
    {
        public int m_buyerMean;
        public int m_buyerMaxDerivation;
        public int m_buyerIntriguedMaxDerivation;
        public int m_buyerHighestMaxDerivation;
        public int m_grandpaPrice;

        public bool m_buyerIntrigued;
        public bool m_grandpaPriceKnown;
        public bool m_sold;

        public AuctionStuff StartAuction()
        {
            AuctionStuff auction;

            auction.m_buyerPrice = System.Math.Max(GaussianRandom.NextClampedInt(m_buyerMean - m_buyerMaxDerivation, m_buyerMean + m_buyerMaxDerivation), 0);
            auction.m_buyerIntriguedPrice = auction.m_buyerPrice + System.Math.Max(GaussianRandom.NextClampedInt(0, 2 * m_buyerIntriguedMaxDerivation), 0);
            auction.m_buyerHighestPrice = auction.m_buyerPrice + System.Math.Max(GaussianRandom.NextClampedInt(0, 2 * m_buyerHighestMaxDerivation), 0);
            auction.m_buyerIntriguedHighestPrice = auction.m_buyerIntriguedPrice + System.Math.Max(GaussianRandom.NextClampedInt(0, 2 * m_buyerHighestMaxDerivation), 0);

            auction.m_stuff = this;

            return auction;
        }

        public Stuff(int m_initPrice)
        {
            m_buyerMean = (int)System.Math.Round(SettingsManager.Inst.buyerPrice * m_initPrice);
            m_buyerMaxDerivation = (int)System.Math.Round(SettingsManager.Inst.buyerPriceMaxDerivation * m_initPrice);
            m_buyerIntriguedMaxDerivation = (int)System.Math.Round(SettingsManager.Inst.buyerIntriguedPriceMaxDerivation * m_initPrice);
            m_buyerHighestMaxDerivation = (int)System.Math.Round(SettingsManager.Inst.buyerHighestPriceMaxDerivation * m_initPrice);

            m_grandpaPrice = (int)System.Math.Round(SettingsManager.Inst.grandpaPrice * m_initPrice);
            int grandpaDerivation = (int)System.Math.Round(SettingsManager.Inst.grandpaPriceMaxDerivation * m_initPrice);
            m_grandpaPrice += System.Math.Max(GaussianRandom.NextClampedInt(-grandpaDerivation, grandpaDerivation), -grandpaDerivation);

            m_buyerIntrigued = false;
            m_grandpaPriceKnown = false;
            m_sold = false;
        }
    }

    [System.Serializable]
    public struct AuctionStuff
    {
        public Stuff m_stuff;

        public int m_buyerPrice;
        public int m_buyerIntriguedPrice;
        public int m_buyerHighestPrice;
        public int m_buyerIntriguedHighestPrice;
    }

    #endregion
    #region Property
    /***************************************************/
    /***  PROPERTY              ************************/
    /***************************************************/

    public static Stock Inst
    {
        get { return m_instance; }
    }

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

    private static Stock m_instance;

    public Stuff[] m_someStuff;

    #endregion
    #region Methods
    /***************************************************/
    /***  METHODS               ************************/
    /***************************************************/

    /********  UNITY MESSAGES   ************************/

    // Use this for initialization
    private void Start()
    {
        Debug.Assert(m_instance == null);
        m_instance = this;

        m_someStuff = new Stuff[SettingsManager.Inst.elementsPerCategorie[0] + SettingsManager.Inst.elementsPerCategorie[1] + SettingsManager.Inst.elementsPerCategorie[2]];
        int i = 0;

        int max = SettingsManager.Inst.elementsPerCategorie[0];
        int price = SettingsManager.Inst.categoriePrices[0];
        for
            (; i < max; i++)
        {
            m_someStuff[i] = new Stuff(price);
        }
        max = max + SettingsManager.Inst.elementsPerCategorie[1];
        price = SettingsManager.Inst.categoriePrices[1];
        for
            (; i < max; i++)
        {
            m_someStuff[i] = new Stuff(price);
        }
        max = max + SettingsManager.Inst.elementsPerCategorie[2];
        price = SettingsManager.Inst.categoriePrices[2];
        for
            (; i < max; i++)
        {
            m_someStuff[i] = new Stuff(price);
        }
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
