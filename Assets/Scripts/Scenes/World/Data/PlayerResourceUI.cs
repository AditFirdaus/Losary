using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerResourceUI : MonoBehaviour
{
    #region GlobalVariables
    #region UIReferences
    [Header("Component")]
    public TMP_Text levelText;
    public TMP_Text valueText;
    #endregion
    #endregion

    #region ScriptMethods
    public void UpdateUI(string level = "", string value = "")
    {
        if (levelText) levelText.text = $"LV.{level}";
        if (valueText) valueText.text = $"{value}";
    }

    #endregion
    //YNTMGA
}
