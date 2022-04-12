
using System.Collections;
using UnityEngine;


public class NoteSpawner : MonoBehaviour
{
    #region StaticReferences
    public static Player player { get { return Player.main; } }
    public PerlinData perlinData { get { return World.deliveryQuest.perlinData; } }
    #endregion
    #region SetGet
    public float rateLerp { get { return 1; } }
    public float rate { get { return rateLerp * RateHandler.value; } }
    public Vector2 notePosition { get { if (invert) return noteArea.GetLerpPoint(-perlinData.perlinCoordinate + Vector2.one); return noteArea.GetLerpPoint(perlinData.perlinCoordinate); } }
    #endregion
    #region GlobalVariables
    public bool invert;
    public static bool spawnNote;
    public GameObject noteInstance;
    public NoteArea noteArea;

    #endregion
    #region HiddenVariables
    public Coroutine spawnerClockCoroutine;
    #endregion
    #region MainMethods
    private void Start()
    {
        noteArea.UpdateSpawnArea();
        StartClock();
    }

    private void Update()
    {
        perlinData.Add();
    }
    #endregion
    #region ScriptMethods
    [ContextMenu("Start Clock")]
    public void StartClock()
    {
        if (spawnerClockCoroutine != null) StopCoroutine(spawnerClockCoroutine);
        spawnerClockCoroutine = StartCoroutine(SpawnerClock());
    }

    public IEnumerator SpawnerClock()
    {
        while (true)
        {
            if (rate != 0 && MusicHandler.main.audioSource.isPlaying)
            {
                yield return new WaitForSeconds(Mathf.Clamp(1 / rate, 0, 1));
                if (spawnNote)
                {
                    CreateNote();
                }
            }
            yield return null;
        }
    }

    public Note CreateNote()
    {
        Note note = Instantiate(noteInstance, noteArea.transform).GetComponent<Note>();

        note.transform.localPosition = notePosition;
        note.transform.rotation = transform.rotation;

        note.noteAnimator.Play(note.noteAnimation);

        return note;
    }

    #endregion
}

