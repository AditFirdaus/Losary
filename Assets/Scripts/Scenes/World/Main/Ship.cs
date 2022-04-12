using UnityEngine;

public class Ship : MonoBehaviour
{
    #region GlobalVariables
    public bool engineActive = true;
    public Collider triggerPort;
    public float enginePower = 1;
    public float engineAccelerationTime = 5;
    #endregion
}