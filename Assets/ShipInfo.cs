using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;

public class ShipInfo : MonoBehaviour
{
    public static ShipInfo main;
    public ComponentInfo rate;
    public ComponentInfo cargo;
    public ComponentInfo multiply;

    public AudioClip buySound;
    public AudioClip playSound;
    public AudioClip exitSound;
    public LayoutGroup layoutGroup;

    private void Awake()
    {
        main = this;
    }

    private void Start()
    {
        UserData.Load();
        InitializeButtonCallback();
        InitializeDPCallback();
        UpdateRate();
        UpdateCargo();
        UpdateMultiplyer();
        UpdateContainers();
    }

    public static void UpdateLayoutGroup()
    {
        main.layoutGroup.CalculateLayoutInputHorizontal();
        main.layoutGroup.SetLayoutHorizontal();
    }

    public void BuyRate()
    {


        if (!rate.UpdateContainer(RateHandler.cost, GameData.deliveryPoint)) return;

        GameData.deliveryPoint -= RateHandler.cost;
        RateHandler.level += 1;
        UserData.Save();
        UpdateRate();

        LeanAudio.play(buySound);

        UpdateContainers();
    }

    public void BuyCargo()
    {

        if (!cargo.UpdateContainer(CargoHandler.cost, GameData.deliveryPoint)) return;

        GameData.deliveryPoint -= CargoHandler.cost;
        CargoHandler.level += 1;
        UserData.Save();
        UpdateCargo();

        LeanAudio.play(buySound);

        UpdateContainers();
    }
    public void BuyMultiplyer()
    {

        if (!multiply.UpdateContainer(MultiplyHandler.cost, GameData.deliveryPoint)) return;

        GameData.deliveryPoint -= MultiplyHandler.cost;
        MultiplyHandler.level += 1;
        UserData.Save();
        UpdateMultiplyer();

        LeanAudio.play(buySound);

        UpdateContainers();
    }

    public void UpdateContainers()
    {
        rate.UpdateContainer(RateHandler.cost, GameData.deliveryPoint);
        cargo.UpdateContainer(CargoHandler.cost, GameData.deliveryPoint);
        multiply.UpdateContainer(MultiplyHandler.cost, GameData.deliveryPoint);
    }

    public void UpdateRate()
    {
        rate.valueText.text = $"{RateHandler.value}/s";
        rate.costText.text = $"DP. {RateHandler.cost}";
        rate.levelText.text = $"Lv. {RateHandler.level}";
    }
    public void UpdateCargo()
    {
        cargo.valueText.text = $"{CargoHandler.value} Box";
        cargo.costText.text = $"DP. {CargoHandler.cost}";
        cargo.levelText.text = $"Lv. {CargoHandler.level}";
    }
    public void UpdateMultiplyer()
    {
        multiply.valueText.text = $"{MultiplyHandler.value}x";
        multiply.costText.text = $"DP. {MultiplyHandler.cost}";
        multiply.levelText.text = $"Lv. {MultiplyHandler.level}";
    }

    public void InitializeDPCallback()
    {
        GameData.OnDeliveryPointUpdate.AddListener((i) => UpdateContainers());
    }

    public void InitializeButtonCallback()
    {
        rate.componentButton.onClick.AddListener(BuyRate);
        cargo.componentButton.onClick.AddListener(BuyCargo);
        multiply.componentButton.onClick.AddListener(BuyMultiplyer);
    }
}