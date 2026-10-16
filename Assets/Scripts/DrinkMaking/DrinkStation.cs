using UnityEngine;

// Script for drink stations. Keeps track of glass that is on station, shows pop-ups when a glass is on the station and hides it when there is no glass.

public class DrinkStation : MonoBehaviour
{
    // Manages the glass on the drink station and shows pop-ups.

    public Transform snapPoint;
    public GameObject popup;
    public Glass currentGlass;


    public Glass CurrentGlass
    {
        get {return currentGlass;}
    }


    private void Start()
    {
        if (popup != null)
        {
            popup.SetActive(false);
        }
    }


    public void PlaceGlass(Glass glass)
    {
        if (currentGlass != null && currentGlass != glass)
        {
            Debug.LogWarning("This station already has a glass.");
            return;
        }

        currentGlass = glass;

        glass.transform.position = snapPoint.position;
        glass.transform.SetParent(transform);

        if (popup != null)
        {
            popup.SetActive(true);
        }
    }

    public void RemoveGlass()
    {
        currentGlass = null;

        if (popup != null)
        {
            popup.SetActive(false);
        }
    }

    public bool HasGlass()
    {
        return currentGlass != null;
    }
}