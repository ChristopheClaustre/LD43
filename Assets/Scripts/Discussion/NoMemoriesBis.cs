/***************************************************/
/***  INCLUDE               ************************/
/***************************************************/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/***************************************************/
/***  THE CLASS             ************************/
/***************************************************/
public class NoMemoriesBis :
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
        new Discussions.Discussion( Discussions.Who.eYou, "[th]GrandPa told me another of his great stories[/th]" ),
        new Discussions.Discussion( Discussions.Who.eYou, "...... Wow no wonder you didn't want to sell it" ),
        new Discussions.Discussion( Discussions.Who.eYou, "[th]I'll be able to sell it for much more now[/th]" ),
        new Discussions.Discussion( Discussions.Who.eYou, "Grandpa there was another intriguing object..." ),
        new Discussions.Discussion( Discussions.Who.eGrandpa, "Oh you know I think I told you everything" ),
        new Discussions.Discussion( Discussions.Who.eGrandpa, "Every memories I have with these old things at least." ),
        new Discussions.Discussion( Discussions.Who.eYou, "Maybe... You told me more than I could ever store" ),
        new Discussions.Discussion( Discussions.Who.eGrandpa, "I'll leave you now, okay ...?" ),
        new Discussions.Discussion( Discussions.Who.eGrandpa, "I have to sleep dear, see you tomorrow." ),
        new Discussions.Discussion( Discussions.Who.eYou, "See you tomorrow Grandpa" ),
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

    public void NextNoMemoriesBis()
    {
        if (m_round >= m_discussion.Length)
            Discussions.Inst.EndDiscussion();
        else
        {
            Discussions.Inst.ChangeText(m_discussion[m_round]);
            m_round++;
        }
    }

    public void BeginNoMemoriesBis()
    {
        m_round = 0;
    }

    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/

    #endregion
}
