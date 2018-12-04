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
        if (GeneralManagement.Inst.GetPickingStep())
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
        /*if (GeneralManagement.Inst.GetPickingStep())
        {
            this.transform.localScale = this.transform.localScale / 1.1f;
        }
        else
        {
            this.transform.localScale = oldGoodScale;
        }*/
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