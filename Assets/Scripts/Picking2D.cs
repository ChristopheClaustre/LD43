﻿/***************************************************/
/***  INCLUDE               ************************/
/***************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/***************************************************/
/***  THE CLASS             ************************/
/***************************************************/
public class Picking2D : MonoBehaviour
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
    }

    // Update is called once per frame
    void Update()
    {
        if(GeneralManagement.Inst.GetPickingStep())
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 rayPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
                RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, 0f);
                if (hit.collider != null)
                {
                    GameObject hitGO = hit.collider.gameObject;

                    if (hitGO.tag == "Object" || hitGO.transform.parent.gameObject.tag == "Object")
                    {
                        int index = hitGO.tag == "Object" ? hitGO.transform.GetSiblingIndex() : hitGO.transform.parent.GetSiblingIndex();
                        if (! Stock.Inst.m_someStuff[index].m_buyerIntrigued || ! Stock.Inst.m_someStuff[index].m_grandpaPriceKnown)
                        {
                            GeneralManagement.Inst.SetPickObject(hitGO);
                            GeneralManagement.Inst.SetPickIndex(index);
                        }
                    }
                }
            }
        }
    }


    /********  OUR MESSAGES     ************************/

    /********  PUBLIC           ************************/

    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/
    #endregion
}