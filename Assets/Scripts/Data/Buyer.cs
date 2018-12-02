/***************************************************/
/***  INCLUDE               ************************/
/***************************************************/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/***************************************************/
/***  THE CLASS             ************************/
/***************************************************/
public class Buyer :
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

    int m_round = 3;
    public Stock.AuctionStuff m_currentStuff;
    
    #endregion
    #region Methods
    /***************************************************/
    /***  METHODS               ************************/
    /***************************************************/

    /********  UNITY MESSAGES   ************************/

    // Use this for initialization
    private void Start()
    {
        Init(Stock.Inst.m_someStuff[Random.Range(0, Stock.Inst.m_someStuff.Length-1)]);
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    /********  OUR MESSAGES     ************************/

    /********  PUBLIC           ************************/

    public void Init(Stock.Stuff p_auctionStuff)
    {
        m_currentStuff = p_auctionStuff.StartAuction();
    }

    public bool ProposeAPrice(int p_proposition)
    {
        if (IsPropositionValid(p_proposition))
            Debug.Log("YEAH :)");
        else
        {
            Debug.Log("NO :/");
            m_round--;
            if (m_round <= 0)
                Debug.Log("Tayoo");
        }

        return IsPropositionValid(p_proposition);
    }

    public int ActualBuyerPrice()
    {
        return (IsBuyerIntrigued() ? m_currentStuff.m_buyerIntriguedPrice : m_currentStuff.m_buyerPrice);
    }

    public int ActualBuyerMaxPrice()
    {
        return (IsBuyerIntrigued() ? m_currentStuff.m_buyerIntriguedHighestPrice : m_currentStuff.m_buyerHighestPrice);
    }

    public int GranpaPrice()
    {
        return m_currentStuff.m_stuff.m_grandpaPrice;
    }

    public bool IsGranpaPriceKnow()
    {
        return m_currentStuff.m_stuff.m_grandpaPriceKnown;
    }

    public bool IsBuyerIntrigued()
    {
        return m_currentStuff.m_stuff.m_buyerIntrigued;
    }

    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/

    private bool IsPropositionValid(int p_proposition)
    {
        return p_proposition <= ActualBuyerMaxPrice();
    }

    #endregion
}
