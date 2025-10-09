using System.Collections;
using UnityEngine;

public class ObjectSpawningSystem : MonoBehaviour
{

    [SerializeField] private GameData gameData;
    [SerializeField] private AttachableData attachableData;
    void Start()
    {
        SpawnStachables();
    }

    // Update is called once per frame
    private void SpawnStachables()
    {
        switch (gameData.attachables)
        {
            case Attachables.BIKE:
                Instantiate(attachableData.attachableBike, Vector3.zero, Quaternion.identity);
                break;
            case Attachables.F1:
                Instantiate(attachableData.attachableF1, Vector3.zero, Quaternion.identity);
                break;
            case Attachables.GP:
                Instantiate(attachableData.attachableGP, Vector3.zero, Quaternion.identity);
                break;
            case Attachables.RACING_CAR:
                Instantiate(attachableData.attachableRacingCar, Vector3.zero, Quaternion.identity);
                break;
        }
        StartCoroutine(nameof(SendSpawnMessage));    
    }

    private IEnumerator SendSpawnMessage()
    {
        yield return new WaitForSeconds(0.5f);
        ActionHandler.ObjectSpawned?.Invoke();
    }
}
