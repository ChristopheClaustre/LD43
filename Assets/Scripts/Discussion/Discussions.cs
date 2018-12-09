/***************************************************/
/***  INCLUDE               ************************/
/***************************************************/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

/***************************************************/
/***  THE CLASS             ************************/
/***************************************************/
public class Discussions :
    MonoBehaviour
{
    #region Sub-classes/enum
    /***************************************************/
    /***  SUB-CLASSES/ENUM      ************************/
    /***************************************************/

    /********  PUBLIC           ************************/

    public enum Who
    {
        eGrandpa,
        eGrandpaPicking,
        eBuyer,
        eYou
    }

    public struct Discussion
    {
        public Who who;
        public string text;

        public Discussion(Who p_who, string p_text)
        {
            who = p_who;
            text = p_text;
        }
    }

    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/

    #endregion
    #region Property
    /***************************************************/
    /***  PROPERTY              ************************/
    /***************************************************/

    public static Discussions Inst
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

    private static Discussions m_instance;
    public TextMeshProUGUI textMesh_grandpa;
    public UnityEngine.UI.Image image_grandpaPicking;
    public TextMeshProUGUI textMesh_grandpaPicking;
    public TextMeshProUGUI textMesh_you;

    public Animator m_animator;
    public string m_actualDiscussionName;

    string tutorialBeginBalise = "[tu]";
    string tutorialEndBalise = "[/tu]";
    string thoughtBeginBalise = "[th]";
    string thoughtEndBalise = "[/th]";

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

    public void ChangeText(Discussion p_discussion)
    {
        p_discussion.text = PimpingText(p_discussion.text);

        if (p_discussion.who == Who.eGrandpa)
        {
            textMesh_grandpa.text = p_discussion.text;
            textMesh_grandpa.enabled = true;

            textMesh_grandpaPicking.enabled = false;

            image_grandpaPicking.sprite = null;
            image_grandpaPicking.enabled = false;
        }
        else if (p_discussion.who == Who.eYou)
            textMesh_you.text = p_discussion.text;
        else if (p_discussion.who == Who.eGrandpaPicking)
        {
            textMesh_grandpaPicking.text = p_discussion.text;
            textMesh_grandpaPicking.enabled = true;

            textMesh_grandpa.enabled = false;

            GameObject picked = GeneralManagement.Inst.m_pickObject;
            image_grandpaPicking.sprite = picked ? picked.GetComponent<SpriteRenderer>().sprite : null;
            image_grandpaPicking.enabled = picked != null;
        }
        else if (p_discussion.who == Who.eBuyer)
        {
            textMesh_grandpaPicking.text = Buyer.Inst.NotIntriguedBuyerPrice() + " $";
            textMesh_grandpaPicking.enabled = true;

            textMesh_grandpa.enabled = false;
            
            image_grandpaPicking.sprite = Stock.Inst.GetStuffSprite(Dora.Inst.CurrentIndex());
            image_grandpaPicking.enabled = true;
        }
    }

    public void ClearDiscussion()
    {
        ChangeText(new Discussion(Who.eGrandpaPicking, ""));
        ChangeText(new Discussion(Who.eGrandpa, ""));
        ChangeText(new Discussion(Who.eYou, ""));
    }

    public void NextDiscussion()
    {
        if (m_actualDiscussionName == "") return;

        m_animator.SetTrigger("NextText");
    }

    public void ShowNextText()
    {
        if (m_actualDiscussionName == "") return;

        gameObject.SendMessage("Next"+m_actualDiscussionName);
    }

    public void BeginDiscussion(string p_name)
    {
        m_actualDiscussionName = p_name;

        m_animator.ResetTrigger("NextText");
        m_animator.SetBool("DiscussionRunning", true);

        gameObject.SendMessage("Begin" + m_actualDiscussionName);
    }

    public void EndDiscussion()
    {
        m_animator.SetBool("DiscussionRunning", false);

        GeneralManagement.Inst.EndDiscussion(m_actualDiscussionName);

        m_actualDiscussionName = "";
    }

    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/

    private string PimpingText(string text)
    {
        text = text.Replace(tutorialBeginBalise, "<color=#9C2914><b>").Replace(tutorialEndBalise, "</b></color>");
        return text.Replace(thoughtBeginBalise, "<color=#6E4614aa><i>").Replace(thoughtEndBalise, "</i></color>");
    }

    #endregion
}
