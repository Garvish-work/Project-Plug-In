using UnityEngine;
using UnityEngine.EventSystems;

public class CameraRotationSystem : MonoBehaviour, IPointerDownHandler, IPointerMoveHandler, IPointerUpHandler
{
    [SerializeField] private Transform cameraHolder;
    [SerializeField] private GameData gameData;


    bool isDragging = false;
    Vector3 dragDelta = Vector3.zero;
    Vector3 cameraRotation = Vector3.zero;
    public void OnPointerDown(PointerEventData eventData)
    {
        isDragging = true;
    }

    public void OnPointerMove(PointerEventData eventData)
    {
        if (!isDragging || !gameData.cameraCanRotate) return;
         
        dragDelta = eventData.delta;
        cameraRotation.y += (dragDelta.x * 5) * Time.deltaTime;
        cameraHolder.rotation = Quaternion.Euler(cameraRotation);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isDragging = false;
    }
}
