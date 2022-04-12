using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ComponentInfo : MonoBehaviour
{
    public TMP_Text valueText;
    public TMP_Text costText;
    public TMP_Text levelText;

    public Button componentButton;
    public RectTransform componentContainer;

    public LTDescr tweenValueScale;
    public LTDescr tweenContainerScale;

    public bool UpdateContainer(float cost, float dPoint)
    {
        if (dPoint >= cost) { EnableContainer(); }
        if (dPoint < cost) { DisableContainer(); }

        return dPoint >= cost;
    }

    public void Animate()
    {
        if (tweenValueScale != null) LeanTween.cancel(tweenValueScale.uniqueId);

        RectTransform valueRectTransform = valueText.rectTransform;
        valueRectTransform.localScale = Vector3.one;
        valueRectTransform.LeanScale(Vector3.one * 1.1f, 1f).setEasePunch();
    }

    public LTDescr TweenContainerScale(Vector3 targetScale, float duration = 0, LeanTweenType leanTweenType = LeanTweenType.linear)
    {
        if (tweenContainerScale != null) LeanTween.cancel(tweenContainerScale.uniqueId);

        RectTransform containerRectTransform = componentContainer.GetComponent<RectTransform>();

        return containerRectTransform.LeanScale(targetScale, duration).setEase(leanTweenType).setOnUpdate((float i) => ShipInfo.UpdateLayoutGroup());
    }

    public void EnableContainer()
    {
        componentButton.interactable = true;
        TweenContainerScale(Vector3.one, 1, LeanTweenType.easeOutExpo);
    }

    public void DisableContainer()
    {
        componentButton.interactable = false;
        TweenContainerScale(Vector3.one * 0.8f, 1, LeanTweenType.easeOutExpo);
    }

}