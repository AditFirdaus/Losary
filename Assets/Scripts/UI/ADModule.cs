using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RectTransform), typeof(CanvasGroup))]
public class ADModule : MonoBehaviour
{
    #region GlobalVariables
    public bool relative = false;
    public RectTransform rectTransform;
    public CanvasGroup canvasGroup;

    #region Appear
    [Header("Apeear")]
    #region Alpha
    [Header("Alpha")]
    [Range(0, 1)] public float inAlpha = 1;
    public float inAlphaDuration = 1;
    public LeanTweenType inAlphaEase = LeanTweenType.linear;
    #endregion
    #region Scale
    [Header("Scale")]
    public Vector3 inScale = Vector3.one;
    public float inScaleDuration = 1;
    public LeanTweenType inScaleEase = LeanTweenType.linear;
    #endregion

    #endregion

    #region Dissapear
    [Header("Dissapear")]
    #region Alpha
    [Header("Alpha")]
    [Range(0, 1)] public float outAlpha = 0;
    public float outAlphaDuration = 1;
    public LeanTweenType outAlphaEase = LeanTweenType.linear;
    #endregion
    #region Scale
    [Header("Scale")]
    public Vector3 outScale = Vector3.zero;
    public float outScaleDuration = 1;
    public LeanTweenType outScaleEase = LeanTweenType.linear;
    #endregion


    #endregion

    #endregion
    #region HiddenVariables
    public LTDescr tweenAlpha;
    public LTDescr tweenScale;
    #endregion
    #region ScriptMethods
    #region AD
    [ContextMenu("Appear")]
    public void Appear()
    {
        if (!relative)
        {
            canvasGroup.alpha = outAlpha;
            rectTransform.localScale = outScale;
        }

        TweenAlpha(inAlpha, inAlphaDuration).setEase(inAlphaEase);
        TweenScale(inScale, inScaleDuration).setEase(inScaleEase);
    }

    [ContextMenu("Dissapear")]
    public void Dissapear()
    {
        if (!relative)
        {
            canvasGroup.alpha = inAlpha;
            rectTransform.localScale = inScale;
        }

        TweenAlpha(outAlpha, outAlphaDuration).setEase(outAlphaEase);
        TweenScale(outScale, outScaleDuration).setEase(outScaleEase);
    }

    #endregion
    #region Tween
    public LTDescr TweenAlpha(float value, float duration = 1)
    {
        if (tweenAlpha != null) LeanTween.cancel(tweenAlpha.uniqueId);
        tweenAlpha = canvasGroup.LeanAlpha(value, duration);
        return tweenAlpha;
    }

    public LTDescr TweenScale(Vector3 value, float duration = 1)
    {
        if (tweenScale != null) LeanTween.cancel(tweenScale.uniqueId);
        tweenScale = rectTransform.LeanScale(value, duration);
        return tweenScale;
    }

    #endregion
    #endregion
}
