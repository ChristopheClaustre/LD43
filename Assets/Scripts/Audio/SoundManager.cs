/***************************************************/
/***  INCLUDE               ************************/
/***************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/***************************************************/
/***  THE CLASS             ************************/
/***************************************************/
public class SoundManager : MonoBehaviour {

    #region Property
    /***************************************************/
    /***  PROPERTY              ************************/
    /***************************************************/

    /********  PUBLIC           ************************/

    public static SoundManager Instance
    {
        get
        {
            return m_instance;
        }
    }

    #endregion
    #region Attributes
    /***************************************************/
    /***  ATTRIBUTES            ************************/
    /***************************************************/

    public static SoundManager m_instance = null;
    public AudioSource m_music;

    #endregion
    #region Methods
    /***************************************************/
    /***  METHODS               ************************/
    /***************************************************/

    /********  UNITY MESSAGES   ************************/

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }


    // Use this for initialization
    void Start ()
    {
        if (m_instance != null)
            Destroy(gameObject);
        else
            m_instance = this;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    /********  OUR MESSAGES     ************************/

    /********  PUBLIC           ************************/

    public void PlaySingle(AudioClip clip)
    {
        m_music.clip = clip;
        m_music.loop = true;
        m_music.Play();
    }

    public void FadeOut(float FadeTime)
    {
        float startVolume = m_music.volume;

        while (m_music.volume > 0)
        {
            m_music.volume -= startVolume * Time.deltaTime / FadeTime;
            return;
        }
        m_music.Stop();
        m_music.volume = startVolume;
    }

    public void FadeIn(float FadeTime)
    {
        m_music.volume = 0;
        m_music.Play();
        while (m_music.volume < 1)
        {
            m_music.volume += Time.deltaTime / FadeTime;
            return;
        }
    }

    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/
    #endregion
}
