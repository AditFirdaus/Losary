using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Note : MonoBehaviour
{
    #region GlobalVariables

    [Header("Inputs")]
    public bool touch = true;
    public bool mouse = true;

    [Header("Properties")]
    public bool casted = false;
    public float castDistance = 100;

    [Header("References")]
    public Animator noteAnimator;
    public Collider2D noteCollider2D;
    public AudioSource audioSource;


    [Header("Animations")]
    [System.NonSerialized] public string noteAnimation = "Note";
    [System.NonSerialized] public string hitAnimation = "Hit";

    [Header("Events")]
    public UnityEvent<Note> OnHit = new UnityEvent<Note>();
    public UnityEvent<Note> OnRelease = new UnityEvent<Note>();
    #endregion

    RaycastHit2D inputRaycastHit2D;
    #region ScriptMethods
    public void NoteInput()
    {
        MouseInput();
        TouchInput();
    }
    public void NoteBeat()
    {
        if (casted || GameData.userData.autoHit)
        {
            NoteHit();
            GameScreen.AddScore(1 * MultiplyHandler.value);
        }
        else
        {
            GameScreen.AddScore(-1 * MultiplyHandler.value);
        }
    }

    public void NoteHit()
    {
        noteAnimator.Play(hitAnimation);

        audioSource.Play();

        OnHit.Invoke(this);
    }

    public void DestroyNote()
    {
        Destroy(gameObject);
    }

    #endregion
    #region Input 
    public void TouchInput()
    {
        if (touch)
        {
            foreach (Touch touch in Input.touches)
            {
                CastNote(touch.position);
            }
        }
    }

    public void MouseInput()
    {
        if (mouse && !Application.isMobilePlatform)
        {
            CastNote(Input.mousePosition);
        }
    }

    public void CastNote(Vector2 screenPosition)
    {
        if (CastScreen(screenPosition))
        {
            casted = true;
        }
    }

    public bool CastScreen(Vector2 screenPosition)
    {
        bool castState = false;

        Ray inputRay = Camera.main.ScreenPointToRay(screenPosition);

        inputRaycastHit2D = Physics2D.GetRayIntersection(inputRay, castDistance);

        if (noteCollider2D.OverlapPoint(inputRaycastHit2D.point))
        {
            castState = true;
        }

        return castState;
    }

    #endregion
}
