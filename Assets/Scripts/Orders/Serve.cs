using UnityEngine;

public class Serve : MonoBehaviour
{
    public CustomerOrderManager customerManager;
    public DrinkValidator drinkValidator;
    public DrinkStation servingStation;

    public void ServeDrink()
    {
        if (customerManager == null)
        {
            Debug.LogWarning("Serve has no CustomerManager assigned.");
            return;
        }

        if (drinkValidator == null)
        {
            Debug.LogWarning("Serve has no DrinkValidator assigned.");
            return;
        }

        if (servingStation == null)
        {
            Debug.LogWarning("Serve has no serving station assigned.");
            return;
        }

        if (!servingStation.HasGlass())
        {
            Debug.LogWarning("There is no glass on the serving station.");
            return;
        }

        if (customerManager.currentCustomer == null)
        {
            Debug.LogWarning("There is no current customer.");
            return;
        }


        Customer customer = customerManager.currentCustomer;


        if (customer.currentOrder == null)
        {
            Debug.LogWarning("The current customer has no order.");
            return;
        }


        Glass glass = servingStation.CurrentGlass;

        GlassContents contents = glass.GetComponent<GlassContents>();


        if (contents == null)
        {
            Debug.LogWarning("The serving glass has no GlassContents.");
            return;
        }


        Debug.Log("Serving " + customer.currentOrder.drinkName);

        bool correct = drinkValidator.Validate(contents, customer.currentOrder);

        contents.EmptyGlass();
            
        glass.ReturnToStart();

        if (correct)
        {
            Debug.Log("CORRECT ORDER!");

            CustomerFlowManager.Instance.CustomerDrinkServed();
        }
        else
        {
            Debug.Log("INCORRECT ORDER!");

            StrikeManager.Instance.AddStrike();
        }
    }
}