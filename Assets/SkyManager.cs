using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class SkyManager : MonoBehaviour
{
    public static SkyManager main;
    public Material skyMaterial;
    public Color skyColorBegin;
    public Color skyColorEnd;

    Color startColor;
    Color endColor;

    float lerpValue;
    private void Awake()
    {
        main = this;
    }

    public static void Lerp(float value)
    {
        main.LerpSky(value);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) RandomizeSky();
    }

    public void LerpSky(float v = 0)
    {
        lerpValue = v % 1;

        RenderSettings.skybox.SetColor("_SkyTint", Color.Lerp(startColor, endColor, lerpValue * 2));
    }

    public void RandomizeSky()
    {
        int state = Mathf.RoundToInt(Random.value);

        Color start;
        Color end;

        if (state == 1)
        {
            start = skyColorBegin;
            end = skyColorEnd;

        }
        else
        {
            start = skyColorEnd;
            end = skyColorBegin;
        }

        startColor = start;
        endColor = end;

        RenderSettings.skybox.SetColor("_SkyTint", startColor);
    }

    public Color GetRandomColor()
    {
        return Color.Lerp(skyColorBegin, skyColorEnd, Random.value);
    }

}
