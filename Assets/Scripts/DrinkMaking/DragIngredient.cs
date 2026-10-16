using UnityEngine;

// Script for draggable ingredients. Can be picked up with mouse, adds its ingredient when dragged to glass, returns ingredient to start when dropped elsewhere.

public class BottleIngredient : DraggableObject
{
    private Ingredient ingredient;
    private CocktailGlassTarget currentTarget;

    protected override void Awake()
    {
        base.Awake();

        ingredient = GetComponent<Ingredient>();
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);

        CocktailGlassTarget target = collision.GetComponent<CocktailGlassTarget>();

        if (target != null)
        {
            currentTarget = target;
        }
    }

    protected override void OnTriggerExit2D(Collider2D collision)
    {
        base.OnTriggerExit2D(collision);

        // IMPORTANT:
        // Do not clear currentTarget here.
        // The bottle may leave the target because it is
        // returning to its starting position after being dropped.
    }

    protected override void OnDropped()
    {
        if (currentTarget != null)
        {
            currentTarget.AddIngredient(ingredient);
        }
        else
        {
            Debug.LogWarning("Bottle was not dropped onto cocktail glass");
        }

        base.OnDropped();

        currentTarget = null;
    }
}