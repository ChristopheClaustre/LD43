/***************************************************/
/***  INCLUDE               ************************/
/***************************************************/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/***************************************************/
/***  THE CLASS             ************************/
/***************************************************/
public class Dora :
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

    public static Dora Inst
    {
        get
        {
            return m_instance;
        }
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

    private static Dora m_instance;

    private int m_dayBeforeEviction;
    private int m_capital;
    private int m_grandpaLove;
    private int m_currentItem;
    private bool m_pickingStep;

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

        m_capital = 0;
        m_grandpaLove = 0;
        for (int i = 0; i < Stock.Inst.m_someStuff.Length; i++)
        {
            m_capital -= Stock.Inst.m_someStuff[i].m_buyerMean;
            m_grandpaLove +=
                Stock.Inst.m_someStuff[i].m_grandpaPrice -
                    (Stock.Inst.m_someStuff[i].m_buyerMean + Stock.Inst.m_someStuff[i].m_buyerIntriguedMaxDerivation);
        }

        m_currentItem = Random.Range(0, Stock.Inst.m_someStuff.Length-1);
        m_pickingStep = false;
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    /********  OUR MESSAGES     ************************/

    /********  PUBLIC           ************************/

    public void SellCurrentItem(int p_sellingPrice)
    {
        Stock.Stuff stuff = Stock.Inst.m_someStuff[m_currentItem];
        m_grandpaLove -= System.Math.Max(stuff.m_grandpaPrice - p_sellingPrice, 0);
        m_capital += p_sellingPrice;
    }

    public void SelectAnItem()
    {
        List<int> availableIndices = new List<int>();

        for (int i = 0; i < Stock.Inst.m_someStuff.Length; i++)
        {
            if (!Stock.Inst.m_someStuff[i].m_sold)
                availableIndices.Add(i);
        }

        m_currentItem = availableIndices[Random.Range(0, availableIndices.Count)];
    }

    public int CurrentIndex()
    {
        return m_currentItem;
    }

    public int GetCapital()
    {
        return m_capital;
    }

    public bool GetPickingStep()
    {
        return m_pickingStep;
    }

    public void SetPickingStep(bool p_PickingStep)
    {
        m_pickingStep = p_PickingStep;
    }

    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/

    #endregion
}
