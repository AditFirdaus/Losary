using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    public TMP_Text jabatan;
    public TMP_Text nama;
    public Credit[] credits;
    public float updateDuration = 1;

    public int index = 0;
    public ADModule adModule;

    private void Start()
    {
        index = Random.Range(0, credits.Length - 1);
        UpdateCredit();
    }

    public void UpdateCredit()
    {
        if (adModule == null) return;

        Credit credit = credits[index];

        jabatan.text = credit.jabatan;
        nama.text = credit.nama;

        gameObject.LeanDelayedCall(adModule.outScaleDuration + updateDuration, UpdateCredit);

        index = (index + 1) % credits.Length;

        adModule.Appear();
    }


    [System.Serializable]
    public class Credit
    {
        public string jabatan;
        public string nama;
    }

}
