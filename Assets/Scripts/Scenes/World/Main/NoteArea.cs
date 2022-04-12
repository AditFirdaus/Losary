using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteArea : MonoBehaviour
{
    public static NoteArea main;
    #region GlobalVariables
    public RectTransform spawnArea;
    public Collider areaCollider;
    public Vector3 startPosition;
    public Vector3 endPosition;
    #endregion
    #region MainMethods
    private void Awake()
    {
        main = this;
    }
    #endregion
    #region ScriptMethods
    [ContextMenu("Update Spawn Area")]
    public void UpdateSpawnArea()
    {
        startPosition = GetLocalAreaPoint(Vector2.zero);
        endPosition = GetLocalAreaPoint(Vector2.one);
    }
    public Vector3 GetLocalAreaPoint(Vector2 normalizedPoint)
    {
        Vector3 point =
        (
            ScreenRayCast(
                spawnArea.TransformPoint(
                    Rect.NormalizedToPoint(
                        spawnArea.rect,
                        normalizedPoint
                    )
                )
            )
        );

        point = transform.InverseTransformPoint(point);

        return point;
    }
    public Vector3 ScreenRayCast(Vector2 position)
    {
        if (!Camera.main) return Vector3.zero;

        RaycastHit raycastHit;
        Ray ray = Camera.main.ScreenPointToRay(position);
        areaCollider.Raycast(ray, out raycastHit, 100);

        return ray.GetPoint(raycastHit.distance);
    }
    public Vector3 GetLerpPoint(Vector3 lerpVector)
    {
        Vector3 lerpPosition = Vector3.zero;

        lerpPosition.x = Mathf.LerpUnclamped(startPosition.x, endPosition.x, lerpVector.x);
        lerpPosition.y = Mathf.LerpUnclamped(startPosition.y, endPosition.y, lerpVector.y);

        return lerpPosition;
    }

    #endregion
}
