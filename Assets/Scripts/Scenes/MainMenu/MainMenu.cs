using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static MainMenu main;

    private void Awake()
    {
        main = this;
    }

    private void Start()
    {
        ScreenFade.main.Out();
    }

    public void Play()
    {
        LeanAudio.play(ShipInfo.main.playSound);
        ScreenFade.main.In();
        LeanTween.delayedCall(ScreenFade.main.inDuration, () => SceneManager.LoadScene("World"));
    }

    public void Exit()
    {
        LeanAudio.play(ShipInfo.main.exitSound);
        ScreenFade.main.In();
        LeanTween.delayedCall(ScreenFade.main.inDuration, Application.Quit);
    }

}
