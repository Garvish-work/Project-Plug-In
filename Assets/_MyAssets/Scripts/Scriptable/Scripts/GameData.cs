using UnityEngine;

[CreateAssetMenu (fileName = "Game data", menuName = "Scriptable/Game data")]
public class GameData : ScriptableObject
{
    public Attachables attachables;
}


public enum Attachables
{
    BIKE,
    F1,
    GP
};