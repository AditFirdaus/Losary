using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudManager : MonoBehaviour
{
    public GameObject[] cloudPack;
    void Start()
    {
        foreach (GameObject pack in cloudPack)
        {
            bool appear = (Random.Range(0, 100) % 2 == 0);
            pack.SetActive(appear);
        }
    }
}
