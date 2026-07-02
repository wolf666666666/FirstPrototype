using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    private float zoom;
    private float velocity = 1f; 
    private float smoothTime = 0.25f;
    [SerializeField] private Camera mainCamera;

    void Start()
    {
        zoom = 4f;
    }

    void Update()
    {
        //if (Input.GetKey(KeyCode.Mouse0))
        {
            //TapsZoom();
        }
    }

    public void TapsZoom()
    {
        mainCamera.orthographicSize = Mathf.SmoothDamp(mainCamera.orthographicSize, zoom, ref velocity, smoothTime);
    }

    public void CocktailsZoom()
    {
        
    }
}
