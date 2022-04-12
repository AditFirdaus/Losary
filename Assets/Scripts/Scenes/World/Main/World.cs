using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class World : MonoBehaviour
{
    public static World main;
    #region StaticReferences
    public static Player player { get { return Player.main; } }
    public static DeliveryHandler deliveryHandler { get { return DeliveryHandler.main; } }
    public static MusicHandler musicHandler { get { return MusicHandler.main; } }
    public static Ship ship { get { return player.ship; } }
    public static DeliveryQuest deliveryQuest { get { return deliveryHandler.deliveryQuest; } }

    #endregion
    #region SetGet
    public static Transform worldTransform { get => main.transform; }
    public static Vector3 endHarborPosition { get { return player.transform.forward * musicHandler.clipLength * ship.enginePower; } }
    #endregion
    #region GlobalVariables
    public CargoScreen cargoScreen;
    public SkyManager skyManager;
    public GameObject[] startHarbors;
    public GameObject[] endHarbors;
    public GameObject endHarborParent;
    public AudioClip backSound;
    public static Harbor startHarbor;
    public static Harbor endHarbor;

    public NoteSpawner noteSpawner;
    #endregion
    #region MainMethods
    private void Awake()
    {
        main = this;
        UserData.Load();

        skyManager.RandomizeSky();
    }
    private void Start()
    {
        InitWorld();
        if (GameData.userData.limitFps) Application.targetFrameRate = 60;
        ScreenFade.main.Out();
        if (GameData.userData.repeatLevel) cargoScreen.button.onClick.Invoke();
    }

    private void Update()
    {
        if (musicHandler.audioSource.isPlaying) SkyManager.Lerp(musicHandler.progress);
    }
    #endregion
    #region ScriptMethods

    public static void Begin()
    {
        NoteSpawner.spawnNote = true;
        musicHandler.Play();
        player.moving = true;
    }

    public static void End()
    {
        if (GameData.userData.repeatLevel)
        {
            Back("World");
        }
        else
        {
            Back();
        }
    }

    public static void Back(string target = "MainMenu")
    {
        NoteSpawner.spawnNote = false;
        ScreenFade.main.In();
        LeanTween.delayedCall(ScreenFade.main.inDuration, () => SceneManager.LoadScene(target));
        LeanAudio.play(main.backSound);
    }

    [ContextMenu("Init World")]
    public static void InitWorld()
    {
        InitDeliveryHandler();
        InitMusic();
        InitHarbor();
        InitPlayer();
    }

    #region Handlers
    public static void InitDeliveryHandler()
    {
        deliveryHandler.SetRandomDeliveryQuest();
        deliveryQuest.perlinData.Reset();
    }
    public static void InitHarbor()
    {
        DestroyHarbor();
        InstantiateHarbor();
    }
    public static void InitMusic()
    {
        musicHandler.SetRandomAudioClip();
    }
    public static void InitPlayer()
    {
        player.Initialize();
    }

    #endregion
    #region Harbor
    public static void DestroyHarbor()
    {
        if (startHarbor) Destroy(startHarbor.gameObject);
        if (endHarbor) Destroy(endHarbor.gameObject);
    }

    public static void InstantiateHarbor()
    {
        deliveryQuest.UP();

        ship.enginePower = endHarborPosition.magnitude / musicHandler.clipLength;
        //main.endHarborParent.transform.transform.position = endHarborPosition;

        deliveryQuest.startHarbor.SetActive(true);
        deliveryQuest.endHarbor.SetActive(true);

        startHarbor = deliveryQuest.startHarbor.GetComponent<Harbor>();
        endHarbor = deliveryQuest.endHarbor.GetComponent<Harbor>();
    }
    #endregion
    #endregion
}