﻿/***************************************************/
/***  INCLUDE               ************************/
/***************************************************/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/***************************************************/
/***  THE CLASS             ************************/
/***************************************************/
public class GeneralManagement :
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

    public static GeneralManagement Inst
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

    private static GeneralManagement m_instance;

    public Animator m_animatorGeneral;
    public Animator m_animatorDayNightCycle;
    public Animator m_animatorGrandpaBubble;
    public Animator m_animatorYouBubble;
    public Animator m_animatorBuyerBubble;
    public Animator m_animatorPropalBubble;
    public Animator m_animatorCustomers;
    public Animator m_animatorSelling;
    public Buyer m_buyer;
    public AuctionUI m_auctionUI;

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
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    /********  OUR MESSAGES     ************************/

    /********  PUBLIC           ************************/

    public void IsNight()
    {
        m_animatorDayNightCycle.SetBool("isNight", true);
    }

    public void IsDay()
    {
        m_animatorDayNightCycle.SetBool("isNight", false);
    }

    public void ShowDiscussionBubble()
    {
        m_animatorGrandpaBubble.SetBool("Hide", false);
        m_animatorYouBubble.SetBool("Hide", false);
    }

    public void HideDiscussionBubble()
    {
        m_animatorGrandpaBubble.SetBool("Hide", true);
        m_animatorYouBubble.SetBool("Hide", true);
    }

    public void BeginDiscussion(string p_name)
    {
        Discussions.Inst.BeginDiscussion(p_name);
    }

    public void EndDiscussion(string p_name)
    {
        m_animatorGeneral.SetBool(p_name+"IsFinished", true);
    }

    public void CustomerArrival()
    {
        m_animatorGeneral.SetInteger("remainingCustomers", 6);
        m_animatorCustomers.SetInteger("remainingCustomers", 5);
    }

    public void DecrementCustomers()
    {
        int remaining = m_animatorGeneral.GetInteger("remainingCustomers");
        m_animatorGeneral.SetInteger("remainingCustomers", remaining-1);
        m_animatorCustomers.SetBool("showCurrent", false);
    }

    public void DecrementWaitingCustomers()
    {
        int remaining = m_animatorCustomers.GetInteger("remainingCustomers");
        m_animatorCustomers.SetInteger("remainingCustomers", remaining - 1);
    }

    public void CustomerIncomming()
    {
        m_animatorCustomers.SetBool("showCurrent", true);
    }

    public void ShowBuyerBubble()
    {
        m_animatorBuyerBubble.SetBool("Hide", false);
    }

    public void ShowPropalBubble()
    {
        m_animatorPropalBubble.SetBool("Hide", false);
    }

    public void HideBuyerBubble()
    {
        m_animatorBuyerBubble.SetBool("Hide", true);
    }

    public void HidePropalBubble()
    {
        m_animatorPropalBubble.SetBool("Hide", true);
    }

    public void SellingAnimation()
    {
        m_animatorSelling.SetBool("vente", true);
    }

    public void InitBuyer()
    {
        Dora.Inst.SelectAnItem();
        m_buyer.Init(Stock.Inst.m_someStuff[Dora.Inst.CurrentIndex()]);
        m_auctionUI.Init();
    }

    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/

    #endregion
}
