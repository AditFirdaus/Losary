using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Player : MonoBehaviour
{
    public static Player main;
    #region StaticReferences
    public MusicHandler musicHandler { get { return MusicHandler.main; } }
    public static Harbor startHarbor { get { return World.startHarbor; } }
    public static Harbor endHarbor { get { return World.endHarbor; } }
    public Transform startHarborPort { get { return startHarbor.triggerPort.transform; } }
    public Transform endHarborPort { get { return endHarbor.triggerPort.transform; } }
    #endregion
    #region SetGet
    public float currentThrustSpeedRatio { get { return velocity.magnitude / ship.enginePower; } }
    public float progress { get => musicHandler.progress; }
    #endregion
    #region GlobalVariables
    public bool moving = true;
    public Ship ship;
    public TriggerHandler playerTriggerHandler;
    public Vector3 velocity;

    #endregion

    #region HiddenVariables
    public Vector3 targetPosition;
    #endregion
    #region MainMethods
    private void Awake()
    {
        main = this;
    }
    private void Update()
    {
        if (moving) MoveShip();
    }
    #endregion
    #region ScriptMethods
    public void Initialize()
    {
        playerTriggerHandler.targetCollider = endHarbor.triggerPort;
    }

    public void MoveShip()
    {
        Vector3 startPosition = startHarborPort.position;
        Vector3 endPosition = endHarborPort.position;

        if (musicHandler.audioSource.isPlaying) targetPosition = Vector3.Lerp(startPosition, endPosition, progress);
        Vector3 dampPosition = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, ship.engineAccelerationTime);

        transform.position = dampPosition;
    }

    #endregion
}
