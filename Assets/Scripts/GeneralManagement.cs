/***************************************************/
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
    public Animator m_animatorPapy;
    public Buyer m_buyer;
    public AuctionUI m_auctionUI;


    private bool m_pickingStep;
    public int m_pickIndex;
    public GameObject m_pickObject;

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
        m_pickingStep = false;
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
        m_animatorGeneral.SetTrigger(p_name+"Finished");
    }

    public void CustomerArrival()
    {
        m_animatorGeneral.SetInteger("remainingCustomers", 5);
        m_animatorCustomers.SetInteger("remainingCustomers", 4);
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
        m_animatorGeneral.SetInteger("remainingPropositions", 3);

        m_animatorGeneral.SetBool("stuffSold", false);
        m_animatorGeneral.SetBool("hasPlayerRefused", false);
        m_animatorGeneral.SetBool("intriguable", Stock.Inst.m_someStuff[Dora.Inst.CurrentIndex()].m_buyerIntrigued);
    }

    public void ResetHasPlayerChoose()
    {
        m_animatorGeneral.SetBool("hasPlayerChoose", false);
    }

    public void Refuse()
    {
        m_animatorGeneral.SetBool("hasPlayerRefused", true);
    }

    public void Sold()
    {
        m_animatorGeneral.SetBool("stuffSold", true);
        m_animatorGeneral.SetBool("hasPlayerChoose", true);
    }

    public void NotSold()
    {
        m_animatorGeneral.SetInteger("remainingPropositions", m_animatorGeneral.GetInteger("remainingPropositions") - 1);
        m_animatorGeneral.SetBool("stuffSold", false);
        m_animatorGeneral.SetBool("hasPlayerChoose", true);
    }

    public bool GetPickingStep()
    {
        return m_pickingStep;
    }

    public void SetPickingStep(bool p_PickingStep)
    {
        m_pickingStep = p_PickingStep;
        m_animatorGeneral.SetBool("isPicking", m_pickingStep);
    }

    public void SetPickingStepTrue()
    {
        SetPickingStep(true);
    }

    public void SetPickObject(GameObject p_pickObject)
    {
        m_pickObject = p_pickObject;
        SetPickingStep(false);
    }

    public void SetPickIndex(int p_pickIndex)
    {
        m_pickIndex = p_pickIndex;

        if (Stock.Inst.m_someStuff[m_pickIndex].m_buyerIntrigued)
            Stock.Inst.m_someStuff[m_pickIndex].m_grandpaPriceKnown = true;
        else
            Stock.Inst.m_someStuff[m_pickIndex].m_buyerIntrigued = true;
    }

    public void PapyInFront()
    {
        m_animatorPapy.SetBool("inFront", true);
    }

    public void PapyNotInFront()
    {
        m_animatorPapy.SetBool("inFront", false);
    }

    public void Wait()
    {

    }

    public void DecrementDays()
    {
        m_animatorGeneral.SetInteger("remainingDays", m_animatorGeneral.GetInteger("remainingDays") - 1);
    }

    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/

    #endregion
}
