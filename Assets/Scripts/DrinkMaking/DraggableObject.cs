using UnityEngine;

// Script for draggable objects. Bass class which other scripts inherit from. 

public class DraggableObject : MonoBehaviour
{
    public bool clickable;
    public GameObject mouseGameObject;
    public GameObject objectStart;
    protected Transform originalParent;


    protected virtual void Awake()
    {
        originalParent = transform.parent;
    }


    protected virtual void Update()
    {
        // Pick up object
        if (Input.GetMouseButtonDown(0) && clickable && !HandManager.Instance.HandIsFull())
        {
            HandManager.Instance.PickUp(transform);
            OnPickedUp();
        }

        // While holding object
        if (HandManager.Instance.heldObject == transform)
        {
            transform.position = mouseGameObject.transform.position;

            // Drop object
            if (Input.GetMouseButtonUp(0))
            {
                OnDropped();
                HandManager.Instance.Drop();
            }
        }
    }


    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Mouse"))
        {
            clickable = true;
            mouseGameObject = collision.gameObject;
        }
    }


    protected virtual void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Mouse"))
        {
            clickable = false;
        }
    }

    protected virtual void OnPickedUp()
    {
        
    }


    protected virtual void OnDropped()
    {
        transform.position = objectStart.transform.position;
        transform.SetParent(originalParent);
    }


    protected void ReturnToOriginalParent()
    {
        transform.SetParent(originalParent);
    }
}