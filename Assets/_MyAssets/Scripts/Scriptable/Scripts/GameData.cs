using UnityEngine;

[CreateAssetMenu (fileName = "Game data", menuName = "Scriptable/Game data")]
public class GameData : ScriptableObject
{
    public Attachables attachables;
    public bool cameraCanRotate = false;
    public int partsInGame = 0;
}


public enum Attachables
{
    BIKE,
    F1,
    GP,
    RACING_CAR
};