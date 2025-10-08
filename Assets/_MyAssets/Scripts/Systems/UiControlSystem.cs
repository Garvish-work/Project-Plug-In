using UnityEngine;

public class UiControlSystem : MonoBehaviour
{
    [SerializeField] public GameData gameData;

    public void B_AttachableChange(int desireAttachable)
    {
        if (gameData.attachables == (Attachables)desireAttachable) return;

        gameData.attachables = (Attachables)desireAttachable;
        ActionHandler.ChangeScene?.Invoke("GameplayScene");
    }
}
