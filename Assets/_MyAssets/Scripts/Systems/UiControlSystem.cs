using TMPro;
using UnityEngine;

public class UiControlSystem : MonoBehaviour
{
    [SerializeField] public GameData gameData;
    [SerializeField] public TMP_Text partsCountText;
    CanvasGroup partsCountCG;

    private void Awake()
    {
        partsCountCG = partsCountText.GetComponent<CanvasGroup>();
        partsCountCG.alpha = 0;
    }

    private void OnEnable()
    {
        ActionHandler.ObjectSpawned += OnbjectSpawned;
        ActionHandler.ObjectSnapped += UpdatePartsCountUI;
    }

    private void OnDisable()
    {
        ActionHandler.ObjectSpawned -= OnbjectSpawned;
        ActionHandler.ObjectSnapped -= UpdatePartsCountUI;
    }

    public void B_AttachableChange(int desireAttachable)
    {
        if (gameData.attachables == (Attachables)desireAttachable) return;

        gameData.attachables = (Attachables)desireAttachable;
        ActionHandler.ChangeScene?.Invoke("GameplayScene");
    }

    public void OnbjectSpawned()
    {
        LeanTween.alphaCanvas(partsCountCG, 1, .25f).setEaseInOutSine();
        partsCountText.text = $"Remaining parts: {gameData.partsInGame}";
    }

    public void UpdatePartsCountUI()
    {
        if (gameData.partsInGame == 0) partsCountText.text = $"Level complete";
        else partsCountText.text = $"Remaining parts: {gameData.partsInGame}";

        LeanTween.scale(partsCountText.gameObject, Vector3.one * 1.2f, 0.1f).setLoopPingPong(1);
    }
}
