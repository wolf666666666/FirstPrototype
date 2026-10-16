using System.Collections.Generic;
using UnityEngine;

public enum GlassType
{
    None,
    Pint1,
    Pint2,
    Pint3,
    Cocktail1,
    Cocktail2,
    Shot
}

public enum BeerType
{
    None,
    Lager,
    Ale,
    Stout
}

public enum SpiritType
{
    None,
    Vodka,
    Gin,
    Rum
}

public enum MixerType
{
    None,
    Cola,
    Lemonade
}

[CreateAssetMenu(fileName = "New Drink", menuName = "Bartending/Drink Recipe")]
public class DrinkRecipe : ScriptableObject
{
    public string drinkName;
    public GlassType glass;
    public BeerType beer;
    public int beerUnits;
    public SpiritType spirit;
    public int spiritUnits;
    public MixerType mixer;
    public int mixerUnits;
    public int iceUnits;
}
