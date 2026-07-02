using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Glass : MonoBehaviour
{
    public bool clickable;

    public GameObject mouseGameObject;

    public Vector3 glassPos;


    void Awake()
    {
        glassPos = new Vector3(-6, -4, 0);
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && clickable)
        {
            transform.position = mouseGameObject.transform.position;
        }
        else
        {
            transform.position = glassPos;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Mouse"))
        {
            clickable = true;
            mouseGameObject = collision.gameObject;
        }

        if (collision.CompareTag("Taps"))
        {
            glassPos = collision.gameObject.transform.position;
        }

        if (collision.CompareTag("Cocktails"))
        {
            glassPos = collision.gameObject.transform.position;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Mouse"))
        {
            clickable = false;
            mouseGameObject = null;
        }

        if (collision.CompareTag("Taps"))
        {
            glassPos = new Vector3(-6, -4, 0);
        }

        if (collision.CompareTag("Cocktails"))
        {
            glassPos = new Vector3(-6, -4, 0);
        }
    }
}
