/***************************************************/
/***  INCLUDE               ************************/
/***************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/***************************************************/
/***  THE CLASS             ************************/
/***************************************************/
public class SonVieux : MonoBehaviour
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

    public AudioClip[] m_CoughSounds;
    public AudioClip m_HitSounds;
    public float m_TimerMaxCough;
    public float m_TimerMinCough;

    public bool m_EnableCough;
    private float m_TimeNextCough;
    private float m_TimeFromLastCough;


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
        m_EnableCough = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(m_EnableCough)
        {

            if(m_TimeFromLastCough < m_TimeNextCough)
            {
                m_TimeFromLastCough += Time.deltaTime;
            }
            else
            {
                m_TimeFromLastCough = 0;
                m_TimeNextCough = Random.Range(m_TimerMinCough, m_TimerMaxCough);
                Debug.Log(m_TimeNextCough);
                PlayRandCough();
            }
        }
    }


    /********  OUR MESSAGES     ************************/

    /********  PUBLIC           ************************/

    public void SetEnableCough(bool p_Enable)
    {
        m_EnableCough = p_Enable;
        if(!m_EnableCough)
        {
            //Reset value for next valid cough
            m_TimeNextCough = Random.Range(m_TimerMinCough, m_TimerMaxCough);
            m_TimeFromLastCough = 0f;
        }
    }

    protected void PlayHit()
    {
        AudioSource audioSource = this.GetComponent<AudioSource>();
        audioSource.clip = m_HitSounds;
        audioSource.Play();
    }

    /********  PROTECTED        ************************/

    protected void PlayRandCough()
    {
        AudioClip audio = m_CoughSounds[Random.Range(0, m_CoughSounds.Length)];
        AudioSource audioSource = this.GetComponent<AudioSource>();
        audioSource.clip = audio;
        audioSource.Play();
    }

    /********  PRIVATE          ************************/
    #endregion
}
