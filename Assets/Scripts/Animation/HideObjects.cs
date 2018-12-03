/***************************************************/
/***  INCLUDE               ************************/
/***************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/***************************************************/
/***  THE CLASS             ************************/
/***************************************************/
public class HideObjects : MonoBehaviour
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
    public List<GameObject> m_Objects;

    public int index = -1;

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
        m_Objects = new List<GameObject>();
        foreach (Transform child in transform)
        {
            m_Objects.Add(child.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        HideObject(index);
    }

    /********  OUR MESSAGES     ************************/

    /********  PUBLIC           ************************/
    public List<GameObject> getObjectList()
    {
        return m_Objects;
    }

    public void HideObject(int index)
    {
        if(index >= 0 && index < m_Objects.Count )
        {
            m_Objects[index].GetComponent<Animator>().SetBool("Hide", true);
        }
    }

    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/
    #endregion
}