using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public static PlayerData playerData { get { return GameData.userData.playerData; } }
    #region GlobalVariables
    public int cargoLevel = 1;
    public int rateLevel = 1;
    public int multiplyLevel = 1;
    #endregion
}