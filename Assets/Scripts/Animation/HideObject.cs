/***************************************************/
/***  INCLUDE               ************************/
/***************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/***************************************************/
/***  THE CLASS             ************************/
/***************************************************/
public class HideObject : MonoBehaviour
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
    }

    void OnMouseEnter()
    {
        if (GeneralManagement.Inst.GetPickingStep())
        {
            this.transform.localScale = this.transform.localScale * 1.1f;
        }
        else
        {
            this.transform.localScale = new Vector3(1f,1f,1f);
        }
    }

    void OnMouseExit()
    {
        if (GeneralManagement.Inst.GetPickingStep())
        {
            this.transform.localScale = this.transform.localScale / 1.1f;
        }
        else
        {
            this.transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    /********  OUR MESSAGES     ************************/

    /********  PUBLIC           ************************/

    public void Hide()
    {
        this.GetComponent<PolygonCollider2D>().enabled = false;
        this.GetComponent<Animator>().SetBool("Hide", true);
    }

    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/
    #endregion
}