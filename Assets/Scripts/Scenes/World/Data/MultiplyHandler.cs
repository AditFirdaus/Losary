using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerResourceUI))]
public class MultiplyHandler : MonoBehaviour
{
    #region StaticVariables
    public static UserData userData { get => GameData.userData; }
    public static PlayerData playerData { get => PlayerData.playerData; }
    #endregion
    #region SetGet
    public PlayerResourceUI playerResourceUI { get => GetComponent<PlayerResourceUI>(); }
    public static int level { set => playerData.multiplyLevel = value; get => playerData.multiplyLevel; }
    public static float value { get => 1 + (level * 0.1f); }
    public static float cost { get => level * level * level * 10; }
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
                $"{value.ToString()}x"
                );
    }
    #endregion
}