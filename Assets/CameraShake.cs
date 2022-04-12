using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    #region GlobalVariables
    public Vector3 localPosition;
    public float yshakeDistance;
    public float xshakeDistance;
    public PerlinComponent perlinComponentMovement;
    #endregion
    #region MainMethods
    private void Update()
    {
        if (MusicHandler.main.audioSource.isPlaying)
        {
            perlinComponentMovement.PerlinIn.seed = MusicHandler.main.audioSource.time;
            perlinComponentMovement.PerlinOut.seed = MusicHandler.main.audioSource.time;

            transform.localPosition = localPosition + (Vector3)((perlinComponentMovement.perlinCoordinate - (Vector2.one / 2)) * new Vector2(xshakeDistance, yshakeDistance));
        }
    }
    #endregion
}
