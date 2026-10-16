using UnityEngine;

// Script for pourable ingredients. Adds whichever ingredient is assigned when button is held, adds one unit per sedond, stops adding when button is released or glass is full.
public class PourIngredient : MonoBehaviour
{
    // Script for ingredients that are poured and add multiple units over time.
    public Ingredient ingredient;

    [Header("Pour Settings")]
    public float unitsPerSecond = 2f;

    private bool clickable;
    private bool pouring;

    private float unitTimer = 0f;

    private void Awake()
    {
        if (ingredient == null)
        {
            ingredient = GetComponent<Ingredient>();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Mouse"))
        {
            clickable = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Mouse"))
        {
            clickable = false;
            pouring = false;
        }
    }

    private void Update()
    {
        if (!clickable || ingredient == null)
        {
            return;
        }

        // Mouse button pressed
        if (Input.GetMouseButtonDown(0))
        {
            pouring = true;
            unitTimer = 0f;

            Debug.Log("Started pouring " + ingredient.gameObject.name);
        }

        // Mouse button released
        if (Input.GetMouseButtonUp(0))
        {
            pouring = false;
            unitTimer = 0f;

            Debug.Log("Stopped pouring");
        }

        // Continue pouring while held
        if (pouring)
        {
            Pour();
        }
    }

    private void Pour()
    {
        DrinkStation station = ingredient.GetComponentInParent<DrinkStation>();

        if (station == null)
        {
            Debug.LogWarning("Pour button cannot find DrinkStation.");
            return;
        }

        if (!station.HasGlass())
        {
            return;
        }

        GlassContents glass = station.CurrentGlass.GetComponent<GlassContents>();

        if (glass == null)
        {
            return;
        }

        unitTimer += unitsPerSecond * Time.deltaTime;

        if (unitTimer >= 1f)
        {
            unitTimer -= 1f;

            // GlassContents decides whether the unit can actually be added.
            ingredient.AddToGlass(glass);
        }
    }
}