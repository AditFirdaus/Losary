using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CargoScreen : MonoBehaviour
{
    public ADModule adModule;
    public RectTransform backButton;
    public TMP_Text destinationText;
    public Button button;

    public LTDescr leanBackButton;

    private void Start()
    {
        destinationText.text = $"{World.deliveryQuest.startHarbor.name} - {World.deliveryQuest.endHarbor.name}";
    }

    public void Play()
    {
        LeanTween.delayedCall(1.5f, World.Begin);
        adModule.canvasGroup.interactable = false;
        adModule.Dissapear();
    }
}