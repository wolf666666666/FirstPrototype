using UnityEngine;

// Script for managing customer orders as a whole. Decides sequence of orders, what current order is, and moving from one order to next. 

public class CustomerOrderManager : MonoBehaviour
{
    [Header("Customer Sequence")]
    public Customer[] customerSequence;

    [Header("Order Sequence")]
    public DrinkRecipe[] orderSequence;

    public int currentOrderIndex = 0;

    public Customer currentCustomer;

    private void Start()
    {
        SetCurrentCustomer();
    }

    public DrinkRecipe CurrentOrder
    {
        get
        {
            if (orderSequence == null || orderSequence.Length == 0)
            {
                return null;
            }

            if (currentOrderIndex >= orderSequence.Length)
            {
                return null;
            }

            return orderSequence[currentOrderIndex];
        }
    }

    public void SetCurrentCustomer()
    {
        if (customerSequence == null ||
            currentOrderIndex >= customerSequence.Length)
        {
            currentCustomer = null;
            Debug.Log("There are no more customers.");
            return;
        }

        currentCustomer = customerSequence[currentOrderIndex];
    }

    public void GiveCurrentOrder()
    {
        if (CurrentOrder == null)
        {
            Debug.LogWarning("There is no current order.");
            return;
        }

        if (currentCustomer == null)
        {
            Debug.LogWarning("There is no current customer.");
            return;
        }

        currentCustomer.ReceiveOrder(CurrentOrder);

        Debug.Log("Customer wants: " + CurrentOrder.drinkName);
    }

    public void MoveToNextCustomer()
    {
        currentOrderIndex++;

        if (currentOrderIndex >= orderSequence.Length ||
            currentOrderIndex >= customerSequence.Length)
        {
            currentCustomer = null;
            Debug.Log("There are no more customers.");
            return;
        }

        SetCurrentCustomer();
        GiveCurrentOrder();
    }

    public bool IsLastCustomer()
    {
        return currentOrderIndex >= customerSequence.Length - 1;
    }
}