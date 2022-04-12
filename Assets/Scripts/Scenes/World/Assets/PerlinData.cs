using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

[CreateAssetMenu(fileName = "Perlin Data", menuName = "Game/Perlin Data")]
public class PerlinData : ScriptableObject
{
    #region SetGet
    public Vector2 perlinCoordinate
    {
        get
        {
            Vector2 coord = Vector2.zero;

            foreach (PerlinComponent perlin in perlinComponents)
            {
                coord += perlin.perlinCoordinate;
            }

            return coord / perlinComponents.Length;
        }
    }
    #endregion
    #region GlobalVariables
    public PerlinComponent[] perlinComponents;
    #endregion
    #region ScriptMethods
    public void Add()
    {
        foreach (PerlinComponent perlin in perlinComponents)
        {
            perlin.Add();
        }
    }
    public void Reset()
    {
        foreach (PerlinComponent perlin in perlinComponents)
        {
            perlin.Reset();
        }
    }
    #endregion
}




