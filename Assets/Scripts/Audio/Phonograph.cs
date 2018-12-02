/***************************************************/
/***  INCLUDE               ************************/
/***************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

/***************************************************/
/***  THE CLASS             ************************/
/***************************************************/
public class Phonograph : MonoBehaviour
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

    public AudioMixer m_AudioMixer;
    public AudioSource m_Vinyl;
    public AudioSource m_Music;
    public AudioClip[] m_Disks;
    public int m_StartTime;
    public int m_WaitTime;

    private float m_DeltaTime;
    private bool m_FadeOutDone;
    private enum State { Start, Playing, Waiting, Sold };
    private State m_State;
    private bool m_IsNight;

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
        m_State = State.Start;
        m_DeltaTime = 0;
        m_FadeOutDone = false;
        m_Vinyl.Play();
        m_Vinyl.loop = true;
    }

    // Update is called once per frame
    void Update()
    {
        switch (m_State)
        {
            case State.Start:
                if (m_DeltaTime < m_StartTime)
                {
                    m_DeltaTime += Time.deltaTime;
                }
                else
                {
                    PlayRandMusic();
                }
                break;
            case State.Waiting:
                if (m_DeltaTime < m_WaitTime)
                {
                    m_DeltaTime += Time.deltaTime;
                }
                else
                {
                    PlayRandMusic();
                }
                break;
            case State.Playing:
                if (m_Music.time > (m_Music.clip.length - 2.0f) && !m_FadeOutDone)
                {
                    SoundManager.Instance.m_music = m_Music;
                    StartCoroutine(SoundManager.Instance.FadeOut(2.0f));
                    m_FadeOutDone = true;
                }
                if (m_Music.time >= m_Music.clip.length)
                {
                    m_FadeOutDone = false;
                    m_DeltaTime = 0;
                    m_State = State.Waiting;
                }
                break;
            case State.Sold:
                m_Vinyl.Stop();
                m_Music.Stop();
                break;
        }
    }

    public void NightMode(bool isNight)
    {
        if (m_IsNight == isNight)
        {
            return;
        }

        float variationDb = 10f;
        m_IsNight = isNight;
        if (isNight)
        {
            float currentValue;
            m_AudioMixer.GetFloat("MusicVolume", out currentValue);
            m_AudioMixer.SetFloat("MusicVolume", currentValue - variationDb);
        }
        else
        {
            float currentValue;
            m_AudioMixer.GetFloat("MusicVolume", out currentValue);
            m_AudioMixer.SetFloat("MusicVolume", currentValue + variationDb);
        }
    }

    /********  OUR MESSAGES     ************************/

    /********  PUBLIC           ************************/
    
    /********  PROTECTED        ************************/

    private void PlayRandMusic()
    {
        m_Music.clip = m_Disks[Random.Range(0, m_Disks.Length)];
        //Use sound manager
        SoundManager.Instance.m_music = m_Music;
        StartCoroutine(SoundManager.Instance.FadeIn(2.0f));
        m_State = State.Playing;
    }

    /********  PRIVATE          ************************/
    #endregion
}