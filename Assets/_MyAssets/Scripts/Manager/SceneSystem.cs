using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSystem : MonoBehaviour
{
    public void OnEnable()
    {
        ActionHandler.ChangeScene += OnChangeScene;        
    }

    public void OnDisable()
    {
        ActionHandler.ChangeScene -= OnChangeScene;        
    }

    public void OnChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
