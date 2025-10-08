using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource sfxAudioSoruce;
    [SerializeField] private SfxData sfxData;

    private void OnEnable()
    {
        ActionHandler.ObjectSnapped += OnObjectSnapped;
    }

    private void OnDisable()
    {
        ActionHandler.ObjectSnapped -= OnObjectSnapped;
    }

    public void OnObjectSnapped()
    {
        sfxAudioSoruce.PlayOneShot(sfxData.snapSfx);
    }
}