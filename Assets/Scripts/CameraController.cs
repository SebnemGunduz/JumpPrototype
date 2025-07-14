using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0, 2, -10);
    public float followSpeed = 5f;
    public float cameraYSpeed = 1f; 

    [Header("Zoom Settings")]
    public float normalZoom = 5f;
    public float zoomedIn = 4f;
    public float rollingZoom = 4.5f;
    public float zoomSpeed = 5f;

    private Camera cam;
    private bool isZoomed = false;

    void Start()
    {
        cam = GetComponent<Camera>();
        cam.orthographicSize = normalZoom;
    }

    void FixedUpdate()
    {
        if (target == null) return;

        
        float targetY = target.position.y + offset.y;
        if (targetY > transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, targetY, transform.position.z);
        }
        else
        {
            
            transform.position += new Vector3(0, cameraYSpeed * Time.deltaTime, 0);
        }

        
        float targetZoom = isZoomed ? zoomedIn : normalZoom;
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetZoom, zoomSpeed * Time.deltaTime);
    }

    
    public bool IsPlayerOutOfView()
    {
        if (target == null) return false;
        float camHeight = 2f * cam.orthographicSize;
        float camBottom = transform.position.y - camHeight / 2f;
        return target.position.y < camBottom;
    }

    public void ZoomInDuringJump()
    {
        isZoomed = true;
    }

    public void ResetZoom()
    {
        isZoomed = false;
    }

    public void ZoomInRolling()
    {
        cam.orthographicSize = rollingZoom;
    }

    public void ResetZoomAfterRolling()
    {
        cam.orthographicSize = normalZoom;
    }
}
