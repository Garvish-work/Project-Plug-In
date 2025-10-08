using UnityEngine;

public class PerformanceHandler : MonoBehaviour
{
    private void Awake()
    {
        Application.targetFrameRate = 60;
    }
}
