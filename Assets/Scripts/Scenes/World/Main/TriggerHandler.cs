using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Events;

public class TriggerHandler : MonoBehaviour
{
    #region GlobalVariables
    public Collider targetCollider;
    public UnityEvent OnEnter = new UnityEvent();
    public UnityEvent OnExit = new UnityEvent();
    #endregion
    #region MainMethods
    private void OnTriggerEnter(Collider other) { if (other == targetCollider) OnEnter.Invoke(); }
    private void OnTriggerExit(Collider other) { if (other == targetCollider) OnExit.Invoke(); }
    #endregion
}
