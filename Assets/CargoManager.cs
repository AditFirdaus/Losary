using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class CargoManager : MonoBehaviour
{
    #region GlobalVariables
    public GameObject[] items;
    [Range(0, 1)] public float fillAmount;
    #endregion
    #region HiddenVariables
    [System.NonSerialized] public int itemVisible;
    #endregion
    #region MainMethods
    private void Update()
    {
        InitializeCargo();
    }
    #endregion
    #region ScriptMethods
    [ContextMenu("Initialize Cargo")]
    public void InitializeCargo()
    {

        if (items.Length <= 0) return;

        itemVisible = Mathf.RoundToInt(items.Length * fillAmount);

        for (int i = 0; i < items.Length; i++)
        {
            GameObject item = items[i];

            if (i < itemVisible)
            {
                item.SetActive(true);
            }
            else
            {
                item.SetActive(false);
            }
        }
    }
    #endregion
}
