using UnityEngine;

// Script for individual customers. Keeps traack of their individual orders. 

public class Customer : MonoBehaviour
{
    public DrinkRecipe currentOrder;

    [Header("Customer Components")]
    public CustomerMovementManager movementManager;
    public CharacterTrigger dialogueTrigger;
    public DialogueAnimator dialogueAnimator;

    [Header("Customer Dialogue")]
    public TextAsset preOrderDialogue;
    public TextAsset postOrderDialogue;

    public DialogueAnimator DialogueAnimator
    {
        get
        {
            return dialogueAnimator;
        }
    }

    public void ReceiveOrder(DrinkRecipe recipe)
    {
        currentOrder = recipe;
    }
}