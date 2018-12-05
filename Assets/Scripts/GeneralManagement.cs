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

    public void ActualisePapyLife(int p_grandPaLifeInPercent)
    {
        m_animatorGeneral.SetInteger("grandpaLifeInPercent", p_grandPaLifeInPercent);
        m_animatorPapy.SetInteger("grandpaLifeInPercent", p_grandPaLifeInPercent);
    }

    public void ActualiseCapital(int p_capital)
    {
        m_animatorGeneral.SetInteger("capital", p_capital);
    }

    public void ShowYourBubble()
    {
        m_animatorYouBubble.SetBool("Hide", false);
    }

    public void HideDiscussionBubble()
    {
        m_animatorGrandpaBubble.SetBool("Hide", true);
        m_animatorYouBubble.SetBool("Hide", true);
    }

    public void BeginDiscussion(string p_name)
    {
        m_animatorGeneral.ResetTrigger("DiscussionHasFinished");
        Discussions.Inst.BeginDiscussion(p_name);
    }

    public void EndDiscussion(string p_name)
    {
        m_animatorGeneral.SetTrigger("DiscussionHasFinished");
    }

    public void CustomerArrival()
    {
        m_animatorGeneral.SetInteger("remainingCustomers", 4);
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

    public void HideAllCustomers()
    {
        m_animatorGeneral.SetInteger("remainingCustomers", 0);
        m_animatorCustomers.SetBool("showCurrent", false);
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

        Stock.Inst.m_someStuff[Dora.Inst.CurrentIndex()].m_sold = true;

        if (Stock.Inst.transform.GetChild(Dora.Inst.CurrentIndex()).name == "wheelchair")
        {
            transform.Find("GrandPa/BgPapy/PapyChair").gameObject.SetActive(true);
            transform.Find("GrandPa/BgPapy/Papy").gameObject.SetActive(false);
            transform.Find("GrandPa/ProTipsPapy/PapyChair2").gameObject.SetActive(true);
            transform.Find("GrandPa/ProTipsPapy/Papy2").gameObject.SetActive(false);

            m_animatorGeneral.SetBool("papyHasWheelchair", false);
        }
        else
            Stock.Inst.transform.GetChild(Dora.Inst.CurrentIndex()).GetComponent<Animator>().SetBool("Hide", true);

        m_animatorGeneral.SetInteger("remainingObjects", m_animatorGeneral.GetInteger("remainingObjects") - 1);

        UpdatePickableObject();
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

    public void ResetIntriguable()
    {
        m_animatorGeneral.SetBool("intriguable", false);
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

        UpdatePickableObject();
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

    public void UpdatePickableObject()
    {
        int nbPickableObject = 0;
        for (int i = 0; i < Stock.Inst.m_someStuff.Length; ++i)
        {
            Stock.Stuff stuff = Stock.Inst.m_someStuff[i];

            if (!stuff.m_sold && (!stuff.m_buyerIntrigued || !stuff.m_grandpaPriceKnown))
                nbPickableObject++;
        }

        if (m_animatorGeneral.GetBool("papyHasWheelchair"))
            // we musn't count the wheelchair in the pickable object
            m_animatorGeneral.SetInteger("remainingPickableObjects", nbPickableObject - 1);
        else
            m_animatorGeneral.SetInteger("remainingPickableObjects", nbPickableObject);
    }

    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/

    #endregion
}
