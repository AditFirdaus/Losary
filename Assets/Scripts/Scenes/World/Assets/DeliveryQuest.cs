using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Delivey Quest", menuName = "Game/Delivery Quest")]
public class DeliveryQuest : ScriptableObject
{

    public GameObject[] startHarbors { get => World.main.startHarbors; }
    public GameObject[] endHarbors { get => World.main.endHarbors; }
    public PerlinData[] perlinDatas;

    #region GlobalVariables
    public GameObject startHarbor;
    public GameObject endHarbor;
    public PerlinData perlinData;
    #endregion


    public void UP()
    {
        Debug.Log("DeliveryQuest Updated");
        startHarbor = startHarbors[Random.Range(0, startHarbors.Length)];
        endHarbor = endHarbors[Random.Range(0, endHarbors.Length)];

        perlinData = perlinDatas[Random.Range(0, perlinDatas.Length)];
    }

}
