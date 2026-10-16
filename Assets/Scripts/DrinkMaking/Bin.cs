using UnityEngine;

// Script for bin. Empties glass when you drag glass to bin and returns glass to start position.

public class Bin : MonoBehaviour
{
    public void EmptyGlass(Glass glass)
    {
        if (glass == null)
        {
            Debug.LogWarning("Bin received no glass.");
            return;
        }

        GlassContents contents = glass.GetComponent<GlassContents>();

        if (contents == null)
        {
            Debug.LogWarning("Glass does not have GlassContents.");
            return;
        }

        contents.EmptyGlass();

        glass.ReturnToStart();
    }
}