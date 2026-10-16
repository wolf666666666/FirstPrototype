using UnityEngine;

// Script for managing flow of events for customers. Enter -> Dialogue -> Recieve order -> Dialogue -> Leave -> Next customer.

public class CustomerFlowManager : MonoBehaviour
{
    public static CustomerFlowManager Instance;

    public CustomerOrderManager orderManager;
    public WinScreen winScreen;

    [Header("Timing")]
    public float nextCustomerDelay = 1.5f;

    private void Awake()
    {
        Instance = this;
    }

    public void CustomerArrived()
    {
        Customer customer = orderManager.currentCustomer;

        if (customer == null)
        {
            Debug.LogWarning("There is no current customer.");
            return;
        }

        // Give this customer their predetermined order.
        orderManager.GiveCurrentOrder();

        // Set up this customer's dialogue.
        customer.dialogueTrigger.inkJSON = customer.preOrderDialogue;

        // Show their dialogue indicator.
        customer.dialogueTrigger.ShowVisualCue();
    }

    public void CustomerDrinkServed()
    {
        Customer customer = orderManager.currentCustomer;

        if (customer == null)
        { 
            Debug.LogWarning("There is no current customer.");
            return;
        }

        // Automatically start post-order dialogue.
        DialogueManager.GetInstance().EnterDialogueMode(customer.postOrderDialogue,
        
            // Dialogue finished
            () =>
            {
                if (customer.dialogueAnimator != null)
                {
                    customer.dialogueAnimator.StopTalking();
                }

                CustomerDialogueFinished();
            },

            // Dialogue started
            () =>
            {
                if (customer.dialogueAnimator != null)
                {
                    customer.dialogueAnimator.StartTalking();
                }
            }
        );
    }

    public void CustomerDialogueFinished()
    {
        Customer customer = orderManager.currentCustomer;

        if (customer == null)
        {
            Debug.LogWarning("There is no current customer.");
            return;
        }

        // Tell this customer's own movement manager to leave.
        customer.movementManager.WalkOut();    
    }

    public void CustomerLeft()
    {
        if (orderManager.IsLastCustomer())
        {
            Debug.Log("FINAL CUSTOMER HAS LEFT. DAY COMPLETE!");

            winScreen.ShowWinScreen();
            return;
        }

        orderManager.MoveToNextCustomer();

        orderManager.currentCustomer.movementManager.WalkIn();
    }

    private void StartNextCustomer()
    {
        Customer customer = orderManager.currentCustomer;

        if (customer == null)
        {
            Debug.LogWarning("Cannot start next customer. No current customer.");
            return;
        }

        customer.movementManager.WalkIn();
    }
}