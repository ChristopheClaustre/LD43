/***************************************************/
/***  INCLUDE               ************************/
/***************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/***************************************************/
/***  THE CLASS             ************************/
/***************************************************/
public class ObjectsManager : MonoBehaviour
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
    public List<GameObject> m_objects;
    public List<Sprite> m_sprites;

    private List<int> m_FreeIndexList;

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
        m_FreeIndexList = new List<int>();
        int i = 0;
        foreach (Sprite sprite in m_sprites)
        {
            m_FreeIndexList.Add(i);
            i++;
        }
        generateObjectSprite();
    }

    // Update is called once per frame
    void Update()
    {
    }


    /********  OUR MESSAGES     ************************/

    /********  PUBLIC           ************************/

    /********  PROTECTED        ************************/
    public void generateObjectSprite()
    {
        foreach(GameObject stuff in m_objects)
        {
            if(m_FreeIndexList.Count > 0)
            {
                int randIndex = Random.Range(0, m_FreeIndexList.Count);
                int spriteIndex = m_FreeIndexList[randIndex];
                m_FreeIndexList.RemoveAt(randIndex);
                SpriteRenderer sprite = stuff.GetComponent<SpriteRenderer>();
                sprite.sprite = m_sprites[spriteIndex];
            }
        }
    }

    /********  PRIVATE          ************************/
    #endregion
}
