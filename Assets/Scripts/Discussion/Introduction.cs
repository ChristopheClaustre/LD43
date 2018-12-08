/***************************************************/
/***  INCLUDE               ************************/
/***************************************************/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/***************************************************/
/***  THE CLASS             ************************/
/***************************************************/
public class Introduction :
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
        new Discussions.Discussion( Discussions.Who.eYou, "Hello Grandpa how are you ?" ),
        new Discussions.Discussion( Discussions.Who.eGrandpa, "Fine Dear... fine..." ),
        new Discussions.Discussion( Discussions.Who.eGrandpa, "Your father told me that you are here to help me face my [tu]debt[/tu] but..." ),
        new Discussions.Discussion( Discussions.Who.eGrandpa, "But please don't [tu]dilapidate[/tu] all my memories for [tu]cheap[/tu]" ),
        new Discussions.Discussion( Discussions.Who.eGrandpa, "My [tu]heart[/tu] will not endure it..." ),
        new Discussions.Discussion( Discussions.Who.eYou, "Eviction day is in only [tu]5 days[/tu] grandpa" ),
        new Discussions.Discussion( Discussions.Who.eYou, "[tu]Sacrifices[/tu] must be made to save your shop" ),
        new Discussions.Discussion( Discussions.Who.eGrandpa, "Please... Take care of your grandpa... I love you dear" ),
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

    public void NextIntroduction()
    {
        if (m_round >= m_discussion.Length)
            Discussions.Inst.EndDiscussion();
        else
        {
            Discussions.Inst.ChangeText(m_discussion[m_round]);
            m_round++;
        }
    }

    public void BeginIntroduction()
    {
        m_round = 0;
    }

    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/

    #endregion
}
