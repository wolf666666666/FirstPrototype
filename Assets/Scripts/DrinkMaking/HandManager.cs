using UnityEngine;

// Script for hand manager. Keepts track of picking up objects, dropping them and wether or not the players hand is full. 

public class HandManager : MonoBehaviour
{
    public static HandManager Instance;
    public Transform heldObject;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public bool HandIsFull()
    {
        return heldObject != null;
    }

    public void PickUp(Transform objectToHold)
    {
        heldObject = objectToHold;
    }

    public void Drop()
    {
        heldObject = null;
    }
}
