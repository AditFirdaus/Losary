using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerResourceUI))]
public class CargoHandler : MonoBehaviour
{
    #region StaticVariables
    public static UserData userData { get => GameData.userData; }
    public static PlayerData playerData { get => PlayerData.playerData; }
    #endregion
    #region SetGet
    public PlayerResourceUI playerResourceUI { get => GetComponent<PlayerResourceUI>(); }
    public static int level { set => playerData.cargoLevel = value; get => playerData.cargoLevel; }
    public static float value { get => level; }
    public static float cost { get => level * level * level * 20; }
    #endregion

    #region GlobalVariables
    public bool autoLoad = true;
    #endregion

    #region MainMethods
    public void Start()
    {
        UpdateUI();
    }
    #endregion

    #region ScriptMethods

    [ContextMenu("Update UI")]
    public void UpdateUI()
    {
        if (autoLoad) { UserData.Save(); UserData.Load(); }

        playerResourceUI.UpdateUI(
                $"{level.ToString()}",
                $"{value.ToString()} Box"
                );
    }
    #endregion
}