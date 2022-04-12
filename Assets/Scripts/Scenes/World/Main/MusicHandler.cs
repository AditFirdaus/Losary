using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class MusicHandler : MonoBehaviour
{
    public static MusicHandler main;
    #region SetGet

    public float time { get => audioSource.time; }
    public float timeLeft { get => audioClip.length - time; }

    public float clipLength { get { return audioClip.length; } }
    public AudioClip audioClip { set { audioSource.clip = value; } get { return audioSource.clip; } }
    public float progress { get { return audioSource.time / audioClip.length; } }

    #endregion
    #region GlobalVariables
    public bool autoPlay = true;
    public bool invokeEvent = true;
    public bool pickRandom = true;
    public bool autoSet = false;
    public string[] clipNames;
    public AudioSource audioSource;
    public UnityEvent OnStart = new UnityEvent();
    public UnityEvent OnEnd = new UnityEvent();
    #endregion
    #region HiddenVariables
    [System.NonSerialized] public bool complete;
    #endregion
    #region MainMethods
    private void Awake()
    {
        main = this;
    }
    private void Update()
    {
        EventManager();
    }
    #endregion
    #region ScriptMethods
    [ContextMenu("Play")]
    public void Play()
    {
        if (!audioClip && autoSet) SetRandomAudioClip();

        audioSource.Play();
        OnAudioStart();
    }
    [ContextMenu("Stop")]
    public void Stop()
    {
        audioSource.Stop();
        OnAudioEnd();
    }
    public void OnAudioStart()
    {
        complete = false;
        OnStart.Invoke();
    }
    public void OnAudioEnd()
    {
        complete = true;
        OnEnd.Invoke();

        if (pickRandom) SetRandomAudioClip();
        if (autoPlay) Play();
    }
    public void EventManager()
    {
        if (invokeEvent)
        {
            if (complete)
            {
                if (audioSource.isPlaying)
                {
                    OnAudioStart();
                }
            }

            if (!complete)
            {
                if (!audioSource.isPlaying)
                {
                    OnAudioEnd();
                }
            }
        }
    }

    [ContextMenu("Set Random Audio Clip")]
    public void SetRandomAudioClip()
    {
        if (audioClip) Resources.UnloadAsset(audioClip);

        GameData.userData.musicIndex = GameData.userData.musicIndex % clipNames.Length;

        int index = GameData.userData.musicIndex;

        audioClip = Resources.Load<AudioClip>($"Musics/{clipNames[index]}");

        GameData.userData.musicIndex++;

        if (autoPlay) Play();

    }

    [ContextMenu("Update Clip Names")]
    public void UpdateClipNames()
    {
        clipNames = Directory.GetFiles($"{Application.dataPath}/Resources/Musics", "*.mp3");
        for (int i = 0; i < clipNames.Length; i++)
        {
            clipNames[i] = Path.GetFileNameWithoutExtension(clipNames[i]);
        }
    }
    #endregion
}
