/***************************************************/
/***  INCLUDE               ************************/
/***************************************************/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/***************************************************/
/***  THE CLASS             ************************/
/***************************************************/
public class NoWheelchair :
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
        new Discussions.Discussion( Discussions.Who.eYou, "It was a good day grandpa don't you think ?" ),
        new Discussions.Discussion( Discussions.Who.eGrandpa, "Mmmm... yeah yeah good day..." ),
        new Discussions.Discussion( Discussions.Who.eYou, "Grandpa one of the customers was interested in a specific object..." ),
        new Discussions.Discussion( Discussions.Who.eGrandpa, "..." ),
        new Discussions.Discussion( Discussions.Who.eYou, "[th]Since I sold his wheelchair to pay his debts[/th]" ),
        new Discussions.Discussion( Discussions.Who.eYou, "[th]He doesn't seem to be interested in conversation[/th]" ),
        new Discussions.Discussion( Discussions.Who.eYou, "[th]I really wonder why...[/th]" ),
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

    public void NextNoWheelchair()
    {
        if (m_round >= m_discussion.Length)
            Discussions.Inst.EndDiscussion();
        else
        {
            Discussions.Inst.ChangeText(m_discussion[m_round]);
            m_round++;
        }
    }

    public void BeginNoWheelchair()
    {
        m_round = 0;
    }

    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/

    #endregion
}
