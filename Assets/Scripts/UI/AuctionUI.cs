/***************************************************/
/***  INCLUDE               ************************/
/***************************************************/
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;

/***************************************************/
/***  THE CLASS             ************************/
/***************************************************/
public class AuctionUI :
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

    private int m_gpPrice;
    private int m_proposition;
    private int m_init;
    private int m_max;

    public Sprite m_good;
    public Image m_goodImage;
    public TextMeshProUGUI m_propositionText;
    public TextMeshProUGUI m_gpPriceText;
    public TextMeshProUGUI m_initText;
    public Button m_upButton;
    public Button m_downButton;

    #endregion
    #region Methods
    /***************************************************/
    /***  METHODS               ************************/
    /***************************************************/

    /********  UNITY MESSAGES   ************************/

    // Use this for initialization
    private void Start()
    {
        Init(Random.Range(45,55), 110, m_good);
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    /********  OUR MESSAGES     ************************/

    /********  PUBLIC           ************************/

    public void Up()
    {
        m_proposition = Mathf.Max(Mathf.Min(m_proposition+1, m_max), m_init);

        UpdateUI();
    }

    public void Down()
    {
        m_proposition = Mathf.Max(Mathf.Min(m_proposition-1, m_max), m_init);

        UpdateUI();
    }

    public void Validate()
    {
        Debug.Log("OK");
    }

    public void Init(int p_init, int p_gpPrice, Sprite p_sprite)
    {
        m_gpPrice = p_gpPrice;
        m_init = p_init;

        m_proposition = m_init;
        m_max = 4 * m_init;

        m_goodImage.sprite = p_sprite;

        InitUI();
    }

    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/

    private void InitUI()
    {
        m_gpPriceText.text = m_gpPrice + " $";
        m_initText.text = m_init + " $";

        UpdateUI();
    }

    private void UpdateUI()
    {
        m_propositionText.text = m_proposition + " $";

        m_upButton.interactable = m_proposition < m_max;
        m_downButton.interactable = m_proposition > m_init;
    }

    #endregion
}
