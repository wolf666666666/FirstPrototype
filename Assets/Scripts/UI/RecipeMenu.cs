using UnityEngine;
using UnityEngine.SceneManagement;

public class RecipeMenu : MonoBehaviour
{    
    public static bool inRecipe;
    public GameObject recipeMenuPanel;

    private void Start()
    {
        recipeMenuPanel.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (inRecipe)
            {
                CloseRecipeMenu();
            }
            else
            {
                OpenRecipeMenu();
            }
        }
    }

    public void CloseRecipeMenu()
    {
        recipeMenuPanel.SetActive(false);
        inRecipe = false;
    }

    public void OpenRecipeMenu()
    {
        recipeMenuPanel.SetActive(true);
        inRecipe = true;
    }
}
