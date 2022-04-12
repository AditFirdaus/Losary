using UnityEngine;

[System.Serializable]
public class PerlinComponent
{
    #region SetGet
    public Vector2 perlinCoordinate
    {
        get
        {
            Vector2 perlinCoord = Vector2.zero;
            Vector2 offsetCoordTop = Vector2.zero;
            Vector2 offsetCoordBottom = Vector2.zero;

            if (PerlinIn.size != 0) offsetCoordTop = new Vector2(PerlinIn.seed / PerlinIn.size, PerlinIn.seed / PerlinIn.size);
            if (PerlinOut.size != 0) offsetCoordBottom = new Vector2(PerlinOut.seed / PerlinOut.size, PerlinOut.seed / PerlinOut.size);

            perlinCoord.x = Mathf.PerlinNoise(offsetCoordTop.x, offsetCoordBottom.y);
            perlinCoord.y = Mathf.PerlinNoise(offsetCoordBottom.x, offsetCoordTop.y);
            return perlinCoord;
        }
    }

    #endregion
    #region GlobalVariables
    public Perlin PerlinIn;
    public Perlin PerlinOut;
    #endregion
    #region ScriptMethods
    #region Add
    public void Add()
    {
        AddPerlinIn();
        AddPerlinOut();
    }
    public void AddPerlinIn()
    {
        PerlinIn.seed += PerlinIn.speed * Time.deltaTime * PerlinIn.multiplyer;
    }
    public void AddPerlinOut()
    {
        PerlinOut.seed += PerlinOut.speed * Time.deltaTime * PerlinOut.multiplyer;
    }
    #endregion
    #region Reset
    public void Reset()
    {
        ResetPerlinIn();
        ResetPerlinOut();
    }
    public void ResetPerlinIn()
    {
        PerlinIn.seed = 0;
    }
    public void ResetPerlinOut()
    {
        PerlinOut.seed = 0;
    }

    #endregion
    #endregion
}
