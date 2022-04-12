using UnityEngine;


public class ScreenFade : MonoBehaviour
{
    public static ScreenFade main;
    #region GlobalVariables
    public CanvasGroup canvasGroup;
    #region In
    [Header("Fade In")]
    [Range(0, 1)] public float inValue = 1;
    public float inDuration = 1;
    #endregion
    #region Out
    [Header("Fade Out")]
    [Range(0, 1)] public float outValue = 0;
    public float outDuration = 1;
    #endregion
    #endregion
    #region HiddenVariables
    public LTDescr tweenAlpha;
    #endregion
    #region MainMethods
    private void Awake()
    {
        main = this;
    }
    #endregion
    #region ScriptMethods
    [ContextMenu("Fade In")]
    public void In()
    {
        canvasGroup.blocksRaycasts = true;
        TweenAlpha(inValue, inDuration).setEaseInOutExpo().setOnComplete(() => canvasGroup.blocksRaycasts = false); ;
    }

    [ContextMenu("Fade Out")]
    public void Out()
    {
        TweenAlpha(outValue, outDuration).setEaseInOutExpo();
    }

    #region Tween
    public LTDescr TweenAlpha(float value, float duration = 0)
    {

        if (tweenAlpha != null) LeanTween.cancel(tweenAlpha.uniqueId);
        tweenAlpha = canvasGroup.LeanAlpha(value, duration);
        return tweenAlpha;
    }
    #endregion

    #endregion
}
