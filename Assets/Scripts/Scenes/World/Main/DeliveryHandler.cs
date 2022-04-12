using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DeliveryHandler : MonoBehaviour
{
    public static DeliveryHandler main;
    #region GlobalVariables
    public DeliveryQuest[] deliveryQuests;
    #endregion
    #region HiddenVariables
    [System.NonSerialized] public DeliveryQuest deliveryQuest;
    #endregion
    #region MainMethods
    private void Awake()
    {
        main = this;
    }
    #endregion
    #region ScriptMethods
    public void SetRandomDeliveryQuest()
    {
        deliveryQuest = GetRandomDeliveryQuest();
    }
    public DeliveryQuest GetRandomDeliveryQuest()
    {
        int index = Random.Range(0, deliveryQuests.Length);
        return deliveryQuests[index];
    }
    #endregion
}
