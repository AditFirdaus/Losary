using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameScreen : MonoBehaviour
{

    public float score;

    public Image indicatorTop;
    public Image indicatorBottom;
    public Image musicProgress;

    public static GameScreen main;

    float indicatorValue;

    private void Awake()
    {
        main = this;
    }

    public TMP_Text musicName;
    public TMP_Text dPointText;

    public static void AddScore(float value)
    {
        main.score += value;

        main.score = Mathf.Clamp(main.score, 0, float.MaxValue);

        main.SetDpoint(main.score);
    }

    public void SetDpoint(float value)
    {
        indicatorValue = ((score % (MultiplyHandler.value * RateHandler.value))) / (MultiplyHandler.value * RateHandler.value);

        dPointText.text = ((int)value).ToString();

        if (value == 0) return;

        dPointText.rectTransform.LeanCancel();

        dPointText.rectTransform.localScale = Vector3.one;

        dPointText.rectTransform.LeanScaleX(1.1f, 0.25f).setEasePunch();
    }

    public void Start()
    {
        musicName.text = MusicHandler.main.audioClip.name;
    }

    public void Update()
    {
        float lerpValue = Mathf.Lerp(indicatorTop.fillAmount, indicatorValue, 0.25f);

        indicatorTop.fillAmount = lerpValue;
        indicatorBottom.fillAmount = lerpValue;

        if (MusicHandler.main.audioSource.isPlaying) musicProgress.fillAmount = MusicHandler.main.progress;
    }

}
