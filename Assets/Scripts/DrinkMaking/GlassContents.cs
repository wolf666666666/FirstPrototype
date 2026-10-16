using System.Collections.Generic;
using UnityEngine;

// Script for glass contents. Keeps track of glass type, allows ingredients and ice to be added to glass and keeps track of current units, sets maximum capacity based on glass type. 

public class GlassContents : MonoBehaviour
{
    public static GlassContents Instance;
    public GlassType glassType;

    public List<BeerType> beers = new List<BeerType>();
    public List<SpiritType> spirits = new List<SpiritType>();
    public List<MixerType> mixers = new List<MixerType>();

    public int currentUnits = 0;
    public int iceUnits = 0;

    public int MaxCapacity
    {
        get
        {
            switch (glassType)
            {
                case GlassType.Pint1:
                case GlassType.Pint2:
                case GlassType.Pint3:
                case GlassType.Cocktail1:
                return 8;

                case GlassType.Cocktail2:
                return 4;

                case GlassType.Shot:
                return 2;

                default:
                return 0;
            }
        }
    }

    public bool IsFull()
    {
        return currentUnits >= MaxCapacity;
    }

    public bool CanAddUnits(int units)
    {
        return currentUnits + units <= MaxCapacity;
    }

    public void AddBeer(BeerType beer, int units)
    {
        if (!CanAddUnits(units))
        {
            Debug.Log("Glass is full!");
            return;
        }

        beers.Add(beer);
        currentUnits += units;

        Debug.Log("Added " + units + " units of " + beer);
        Debug.Log("Glass: " + currentUnits + "/" + MaxCapacity);
    }

    public void AddSpirit(SpiritType spirit, int units)
    {
        if (!CanAddUnits(units))
        {
            Debug.Log("Glass is full!");
            return;
        }

        spirits.Add(spirit);
        currentUnits += units;

        Debug.Log("Added " + units + " units of " + spirit);
        Debug.Log("Glass: " + currentUnits + "/" + MaxCapacity);
    }

    public void AddMixer(MixerType mixer, int units)
    {
        if (!CanAddUnits(units))
        {
            Debug.Log("Glass is full!");
            return;
        }

        mixers.Add(mixer);
        currentUnits += units;

        Debug.Log("Added " + units + " units of " + mixer);
        Debug.Log("Glass: " + currentUnits + "/" + MaxCapacity);
    }

    public void AddIce(int units)
    {
        if (!CanAddUnits(units))
        {
            Debug.Log("Glass is full. Cannot add ice.");
            return;
        }

        iceUnits += units;
        currentUnits += units;

        Debug.Log("Added " + units + " unit(s) of ice.");
    }

    public void EmptyGlass()
    {
        beers.Clear();
        spirits.Clear();
        mixers.Clear();

        iceUnits = 0;
        currentUnits = 0;

        Debug.Log("Glass emptied");
    }
}