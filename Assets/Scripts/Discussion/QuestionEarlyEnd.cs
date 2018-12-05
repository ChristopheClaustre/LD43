﻿/***************************************************/
/***  INCLUDE               ************************/
/***************************************************/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/***************************************************/
/***  THE CLASS             ************************/
/***************************************************/
public class QuestionEarlyEnd:
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

    Discussions.Discussion[] m_discussion =
    {
        new Discussions.Discussion( Discussions.Who.eGrandpaPicking, "Oh yeah I have a lots of story with this object..." ),
        new Discussions.Discussion( Discussions.Who.eYou, "<i>GrandPa told me another of his great stories</i>" ),
        new Discussions.Discussion( Discussions.Who.eYou, "... It was so cool how this object help you in your life" ),
        new Discussions.Discussion( Discussions.Who.eYou, "I'll be able to sell it for much more now" ),
        new Discussions.Discussion( Discussions.Who.eYou, "Grandpa there was another intriguing object..." ),
        new Discussions.Discussion( Discussions.Who.eGrandpa, "No dear, I'm sorry but we will call it a day." ),
        new Discussions.Discussion( Discussions.Who.eGrandpa, "I have to sleep dear, see you tomorrow." ),
        new Discussions.Discussion( Discussions.Who.eYou, "Are you going well grand pa... ?" ),
    };

    int m_round = 0;

    #endregion
    #region Methods
    /***************************************************/
    /***  METHODS               ************************/
    /***************************************************/

    /********  UNITY MESSAGES   ************************/

    // Use this for initialization
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    /********  OUR MESSAGES     ************************/

    /********  PUBLIC           ************************/

    public void NextQuestionEarlyEnd()
    {
        if (m_round >= m_discussion.Length)
            Discussions.Inst.EndDiscussion();
        else
        {
            Discussions.Inst.ChangeText(m_discussion[m_round]);
            m_round++;
        }
    }

    public void BeginQuestionEarlyEnd()
    {
        m_round = 0;
    }

    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/

    #endregion
}
