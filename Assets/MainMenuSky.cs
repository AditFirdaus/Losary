using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuSky : MonoBehaviour
{
    public Vector3 skyPosition;

    private void Start()
    {
        skyPosition.x = Random.Range(0, 30);
        skyPosition.y = Random.Range(0, 360);
        transform.eulerAngles = skyPosition;
    }

}
