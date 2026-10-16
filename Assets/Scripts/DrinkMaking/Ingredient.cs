using UnityEngine;

// Script for ingredients. Adds whichever ingredient is assigned to glass contents. 

public class Ingredient : MonoBehaviour
{
    public IngredientType ingredientType;
    public BeerType beer;
    public SpiritType spirit;
    public MixerType mixer;
    private DrinkStation station;


    public enum IngredientType
    {
        Beer,
        Spirit,
        Mixer,
        Ice
    }


    private void Awake()
    {
        station = GetComponentInParent<DrinkStation>();

        if (station != null)
        {
            // All good
        }
        else
        {
            Debug.LogWarning(gameObject.name + " could not find a DrinkStation.");
        }
    }


    public void AddToGlass()
    {
        if (station == null)
        {
            Debug.LogWarning(gameObject.name + " cannot find a DrinkStation.");
            return;
        }

        if (!station.HasGlass())
        {
            Debug.Log("There is no glass at this station.");
            return;
        }

        GlassContents glass = station.CurrentGlass.GetComponent<GlassContents>();

        if (glass == null)
        {
            Debug.LogWarning("Current glass does not have GlassContents.");
            return;
        }

        AddToGlass(glass);
    }


    public void AddToGlass(GlassContents glass)
    {
        if (glass == null)
        {
            Debug.LogWarning("GlassContents is null.");
            return;
        }

        switch (ingredientType)
        {
            case IngredientType.Beer:
            glass.AddBeer(beer, 1);
            break;

            case IngredientType.Spirit:
            glass.AddSpirit(spirit, 1);
            break;

            case IngredientType.Mixer:
            glass.AddMixer(mixer, 1);
            break;

            case IngredientType.Ice:
            glass.AddIce(1);
            break;
        }
    }
}