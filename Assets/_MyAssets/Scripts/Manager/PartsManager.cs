using UnityEngine;
using System.Collections.Generic;

public class PartsManager : MonoBehaviour
{
    public static PartsManager instance;

    [SerializeField] private GameData gameData;
    [SerializeField] private List<GameObject> partsList = new List<GameObject>();  

    public void Awake()
    {
        instance = this;
    }

    public void AddPart(GameObject part)
    {
         partsList.Add(part);
        gameData.partsInGame = partsList.Count;
    }

    public void RemovePart(GameObject part)
    {
        partsList.Remove(part);
        gameData.partsInGame = partsList.Count;
    }
}
