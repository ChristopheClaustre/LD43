/***************************************************/
/***  INCLUDE               ************************/
/***************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/***************************************************/
/***  THE CLASS             ************************/
/***************************************************/
public class ObjectGigantificator : MonoBehaviour
{

    #region Property
    /***************************************************/
    /***  PROPERTY              ************************/
    /***************************************************/

    /********  PUBLIC           ************************/

    #endregion
    #region Attributes
    /***************************************************/
    /***  ATTRIBUTES            ************************/
    /***************************************************/

    public Vector3 oldGoodScale;

    #endregion
    #region Methods
    /***************************************************/
    /***  METHODS               ************************/
    /***************************************************/

    /********  UNITY MESSAGES   ************************/

    void Awake()
    {
    }

    // Use this for initialization
    void Start()
    {
        oldGoodScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnMouseEnter()
    {
        int index = transform.GetSiblingIndex();
        bool valid = (! Stock.Inst.m_someStuff[index].m_buyerIntrigued || ! Stock.Inst.m_someStuff[index].m_grandpaPriceKnown);

        if (valid && GeneralManagement.Inst.GetPickingStep())
        {
            oldGoodScale = transform.localScale;
            this.transform.localScale = this.transform.localScale * 1.1f;
        }
        else
        {
            this.transform.localScale = oldGoodScale;
        }
    }

    void OnMouseExit()
    {
        transform.localScale = oldGoodScale;
    }

    /********  OUR MESSAGES     ************************/

    /********  PUBLIC           ************************/

    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/
    #endregion
}