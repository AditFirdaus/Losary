using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DPointPanel : MonoBehaviour
{
    public TMP_Text dPointText;
    public LTDescr TweenTextScaleX;

    private void Start()
    {
        UserData.Load();
        GameData.OnDeliveryPointUpdate.AddListener((f) => UpdatePoint());
        UpdatePoint();
    }

    private void Update()
    {
        if (Input.GetAxis("Horizontal") != 0) GameData.deliveryPoint += Input.GetAxis("Horizontal");
    }

    public void UpdatePoint()
    {
        dPointText.text = ((int)GameData.deliveryPoint).ToString();
        if (TweenTextScaleX != null) LeanTween.cancel(TweenTextScaleX.uniqueId);
        RectTransform dPointRectTransform = dPointText.rectTransform;
        dPointRectTransform.localScale = Vector3.one;
        TweenTextScaleX = dPointRectTransform.LeanScaleX(1.25f, 0.5f).setEasePunch();
    }
}
