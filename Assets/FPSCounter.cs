using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FPSCounter : MonoBehaviour
{
    public TMP_Text fpsText;
    public float fpsUpdateTime = 1;


    private void Start()
    {
        StartCoroutine(FPSClock());
    }

    public IEnumerator FPSClock()
    {
        while (true)
        {
            yield return new WaitForSeconds(fpsUpdateTime);
            yield return new WaitForEndOfFrame();
            if (GameData.userData.showFPS)
            {
                fpsText.gameObject.SetActive(true);
                int fps = (int)(1.0 / Time.smoothDeltaTime);
                fpsText.text = $"{fps} fps";
            }
            else
            {
                fpsText.gameObject.SetActive(false);
            }
        }
    }
}
