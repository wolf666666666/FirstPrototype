using UnityEngine;

// Script for virtual cocktail glass. Keeps track of ingredients added to virtual glass and relays this to glass contents. 

public class CocktailGlassTarget : MonoBehaviour
{
    public DrinkStation cocktailStation;

    public bool HasGlass()
    {
        return cocktailStation != null && cocktailStation.HasGlass();
    }


    public void AddIngredient(Ingredient ingredient)
    {
        if (ingredient == null)
        {
            Debug.LogWarning("Ingredient is NULL");
            return;
        }

        if (!HasGlass())
        {
            Debug.LogWarning("There is no glass at the cocktail station.");
            return;
        }

        GlassContents glassContents =
        cocktailStation.CurrentGlass.GetComponent<GlassContents>();

        if (glassContents == null)
        {
            Debug.LogWarning("Cocktail glass has no GlassContents.");
            return;
        }
        
        ingredient.AddToGlass(glassContents);
    }
}