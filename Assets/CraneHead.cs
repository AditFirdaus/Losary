using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]

public class CraneHead : MonoBehaviour
{

    private void Start()
    {
        gameObject.LeanRotateY(Random.Range(0, 360), 0);
        StartCoroutine(CraneClock());
    }

    IEnumerator CraneClock()
    {
        while (true)
        {
            float duration = Random.Range(10, 30);
            gameObject.LeanRotateY(Random.Range(0, 360), duration).setEaseInOutSine();
            yield return new WaitForSeconds(duration);
            yield return new WaitForSeconds(Random.Range(0, 5));
        }
    }
}
