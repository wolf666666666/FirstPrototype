using UnityEditor.Search;
using UnityEngine;
using UnityEngine.InputSystem;

// Script for managiing mouse position. Keeps track of mouse position relative to screen.

public class MousePos : MonoBehaviour
{
    public Vector3 MousePosition;
    [SerializeField] private Camera MainCamera;
    
    void Update()
    {
        var MouseScreenPos = MainCamera.ScreenToWorldPoint(Input.mousePosition);

        MousePosition = new Vector3(MouseScreenPos.x, MouseScreenPos.y, 0);

        gameObject.transform.position = MousePosition;
    }
}
