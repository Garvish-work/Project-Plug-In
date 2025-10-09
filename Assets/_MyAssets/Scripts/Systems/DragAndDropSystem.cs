using UnityEngine;

public class DragAndDropSystem : MonoBehaviour, IAttachable
{
    PartsManager partsManager;

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
    [SerializeField] private GameData gameData;

    void Start()
    {
        AnimatePosition();

        partsManager = PartsManager.instance;
        InitilisePart();

        cam = Camera.main;
        lockedX = animeEndPostion.x; // lock X position at scene start
        finalPosition = finalObjectTransform.position;
        objCollider = GetComponent<BoxCollider>();  
    }

    void OnMouseDown()
    {
        gameData.cameraCanRotate = false;

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


    void OnMouseUp()
    {
        gameData.cameraCanRotate = true;

        isDragging = false;
        distance = Vector3.Distance(transform.position, finalPosition);
        if (distance < .6f)
        {
            snapped = true;
            objCollider.enabled =false;

            LeanTween.move(gameObject, finalPosition, .1f).setEaseLinear().setOnComplete(()=>
            {
                transform.position = finalPosition;
                RemovePart();

                ActionHandler.ObjectSnapped?.Invoke();
            });
        }
    }

    public void InitilisePart()
    {
        partsManager.AddPart(gameObject);
    }

    public void RemovePart()
    {
        partsManager.RemovePart(gameObject);
    }

    [SerializeField] private Vector3 animeStartPostion;
    [SerializeField] private Vector3 animeEndPostion;
    private void AnimatePosition()
    {
        float randomTime = Random.Range(.5f, 2f);
        LeanTween.moveLocal(gameObject, animeEndPostion, randomTime).setEaseInOutSine();
    }

    [ContextMenu ("Set end position")]
    private void SetEndPosition()
    {
        animeEndPostion = transform.localPosition;
    }

    [ContextMenu("Get to end position")]
    private void GetEndPosition()
    {
        transform.localPosition = animeEndPostion;
    }
}
