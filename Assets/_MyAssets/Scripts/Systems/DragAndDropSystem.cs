using Unity.VisualScripting;
using UnityEngine;

public class DragAndDropSystem : MonoBehaviour
{
    private Camera cam;
    private float zDistance;
    private Vector3 offset;
    private bool isDragging = false;
    private float lockedX; // to store the original X position
    private Plane dragPlane;

    private Vector3 finalPosition;
    private float distance = 0;
    private bool snapped = false;
    private BoxCollider objCollider;

    [SerializeField] private Transform finalObjectTransform;

    void Start()
    {
        cam = Camera.main;
        lockedX = transform.position.x; // lock X position at scene start
        finalPosition = finalObjectTransform.position;
        objCollider = GetComponent<BoxCollider>();  
    }

    void OnMouseDown()
    {
        zDistance = Vector3.Distance(transform.position, cam.transform.position);
        Vector3 mouseWorld = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, zDistance));
        offset = transform.position - mouseWorld;
        isDragging = true;
    }

    void Update()
    {
        if (isDragging)
        {
            Vector3 mouseWorldPos = GetWorldPosition();
            Vector3 newPos = mouseWorldPos + offset;
            transform.position = new Vector3(lockedX, newPos.y, newPos.z);
        }
    }
    Vector3 GetWorldPosition()
    {
        Vector3 screenMousePos = Input.mousePosition;
        screenMousePos.z = Mathf.Abs(cam.WorldToScreenPoint(transform.position).z);
        return cam.ScreenToWorldPoint(screenMousePos);
    }


    /*
    void OnMouseDrag()
    {
        if (!isDragging) return;

        Vector3 mouseWorld = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, zDistance));
        Vector3 newPos = mouseWorld + offset;

        // Keep X fixed, allow Y and Z to change
        transform.position = new Vector3(lockedX, newPos.y, newPos.z);
    }
    */


    void OnMouseUp()
    {
        isDragging = false;
        distance = Vector3.Distance(transform.position, finalPosition);
        if (distance < .6f)
        {
            transform.position = finalPosition;
            snapped = true;
            objCollider.enabled =false;
            ActionHandler.ObjectSnapped?.Invoke();   
        }
    }
}
