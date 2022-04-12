using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;

public static class GameData
{
    public static UserData userData = new UserData();
    public static UnityEvent<float> OnDeliveryPointUpdate = new UnityEvent<float>();

    #region SetGet
    public static float deliveryPoint
    {
        set
        {
            userData.deliveryPoint = value;
            OnDeliveryPointUpdate.Invoke(value);
        }
        get
        {
            return userData.deliveryPoint;
        }
    }
    #endregion
}