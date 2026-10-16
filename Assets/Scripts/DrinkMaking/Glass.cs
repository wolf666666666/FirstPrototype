using UnityEngine;

// Script for glass. Can be picked up and dragged around with mouse, informs drink station when placed on it, informs bin when placed on it, returns to start position when dropped elsewhere.

public class Glass : DraggableObject
{
    private DrinkStation currentStation;
    private Bin currentBin;


    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);

        // Check for a drink station
        DrinkStation station = collision.GetComponent<DrinkStation>();
        if (station != null)
        {
            currentStation = station;
        }

        // Check for the bin
        Bin bin = collision.GetComponent<Bin>();
        if (bin != null)
        {
            currentBin = bin;
        }
    }


    protected override void OnTriggerExit2D(Collider2D collision)
    {
        base.OnTriggerExit2D(collision);

        // Check for drink station
        DrinkStation station = collision.GetComponent<DrinkStation>();
        if (station != null && station == currentStation)
        {
            currentStation = null;
        }

        // Check for bin
        Bin bin = collision.GetComponent<Bin>();
        if (bin != null && bin == currentBin)
        {
            currentBin = null;
        }
    }

    protected override void OnPickedUp()
    {
        // If the glass was on a station, tell the station that the glass has been removed.
        if (currentStation != null)
        {
            currentStation.RemoveGlass();
            currentStation = null;
        }

        // Return the glass to its original parent while it is being carried.
        ReturnToOriginalParent();
    }

    protected override void OnDropped()
    {
        // Bin
        if (currentBin != null)
        {
            currentBin.EmptyGlass(this);
            currentBin = null;
            return;
        }

        // Drink station
        if (currentStation != null)
        {
            currentStation.PlaceGlass(this);
            return;
        }

        // Anywhere else
        ReturnToStart();
    }

    public void ReturnToStart()
    {
        if (currentStation != null)
        {
            currentStation.RemoveGlass();
            currentStation = null;
        }

        transform.SetParent(originalParent);
        transform.position = objectStart.transform.position;
    }
}