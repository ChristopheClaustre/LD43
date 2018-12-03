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
    public TextMeshProUGUI textMesh_you;

    public Animator m_animator;
    public string m_actualDiscussionName;

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
        if (p_discussion.who == Who.eGrandpa)
            textMesh_grandpa.text = p_discussion.text;
        else
            textMesh_you.text = p_discussion.text;
    }

    public void ClearDiscussion()
    {
        ChangeText(new Discussion(Who.eGrandpa, ""));
        ChangeText(new Discussion(Who.eYou, ""));
    }

    public void NextDiscussion()
    {
        if (m_actualDiscussionName == "") return;
        m_animator.SetBool("Next"+ m_actualDiscussionName, true);
    }

    public void ShowNextText()
    {
        if (m_actualDiscussionName == "") return;
        gameObject.SendMessage("Next"+m_actualDiscussionName);
    }

    public void ResetNextDiscussion()
    {
        if (m_actualDiscussionName == "") return;
        m_animator.SetBool("Next"+m_actualDiscussionName, false);
    }

    public void BeginDiscussion(string p_name)
    {
        m_actualDiscussionName = p_name;
        m_animator.SetBool("Launch" + m_actualDiscussionName, true);
    }

    public void EndDiscussion()
    {
        m_animator.SetBool("Launch" + m_actualDiscussionName, false);

        GeneralManagement.Inst.EndDiscussion(m_actualDiscussionName);

        m_actualDiscussionName = "";
    }

    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/

    #endregion
}
