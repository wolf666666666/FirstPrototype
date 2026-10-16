using UnityEngine;

public class DrinkValidator : MonoBehaviour
{
    public bool Validate(GlassContents glass, DrinkRecipe recipe)
    {
        if (glass == null || recipe == null)
        {
            return false;
        }

        // Check the glass type
        if (glass.glassType != recipe.glass)
        {
            Debug.Log("Wrong glass.");
            return false;
        }

        // Check beer
        if (recipe.beer != BeerType.None)
        {
            if (glass.beers.Count != recipe.beerUnits)
            {
                Debug.Log("Wrong amount of beer.");
                return false;
            }

            if (!glass.beers.Contains(recipe.beer))
            {
                Debug.Log("Wrong beer.");
                return false;
            }
        }

        // Check spirit
        if (recipe.spirit != SpiritType.None)
        {
            if (glass.spirits.Count != recipe.spiritUnits)
            {
                Debug.Log("Wrong amount of spirit.");
                return false;
            }

            if (!glass.spirits.Contains(recipe.spirit))
            {
                Debug.Log("Wrong spirit.");
                return false;
            }
        }

        // Check mixer
        if (recipe.mixer != MixerType.None)
        {
            if (glass.mixers.Count != recipe.mixerUnits)
            {
                Debug.Log("Wrong amount of mixer.");
                return false;
            }

            if (!glass.mixers.Contains(recipe.mixer))
            {
                Debug.Log("Wrong mixer.");
                return false;
            }
        }

        Debug.Log("Drink is correct!");

        return true;
    }
}