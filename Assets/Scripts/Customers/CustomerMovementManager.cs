using UnityEngine;

// Script for managing customer physical movement. Responsible for controlling movement of individual character (not reallty a manager).

public class CustomerMovementManager : MonoBehaviour
{
    public float walkSpeed = 3f;
    public float scaleSpeed = 0.025f;

    [Header("Movement Points")]
    public Transform barPosition;
    public Transform leavePosition;

    [Header("Managers")]
    public CustomerFlowManager customerFlowManager;

    [Header("Customer Visual")]
    public Vector3 finalScale = new Vector3(0.075f, 0.075f, 0f);

    [Header("Animation")]
    public Animator animator;

    private bool walkingIn;
    private bool walkingOut;
    private bool scaling;

    private void Update()
    {
        if (walkingIn)
        {
            WalkTowards(barPosition);

            if (HasReached(barPosition))
            {
                walkingIn = false;
                scaling = true;

                animator.SetBool("IsWalking", false);
                animator.SetBool("IsScaling", true);
            }
        }

        if (scaling)
        {
            transform.localScale = Vector3.MoveTowards(transform.localScale,finalScale,scaleSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.localScale, finalScale) < 0.001f)
            {
                transform.localScale = finalScale;
                scaling = false;

                animator.SetBool("IsScaling", false);

                CustomerArrived();
            }
        }

        if (walkingOut)
        {
            WalkTowards(leavePosition);

            if (HasReached(leavePosition))
            {
                walkingOut = false;

                CustomerLeft();
            }
        }
    }

    private void WalkTowards(Transform target)
    {
        transform.position = Vector3.MoveTowards(transform.position,target.position,walkSpeed * Time.deltaTime);
    }

    private bool HasReached(Transform target)
    {
        return Vector3.Distance(transform.position, target.position) < 0.01f;
    }

    public void WalkIn()
    {
        walkingIn = true;
        walkingOut = false;
        scaling = false;

        animator.SetBool("IsWalking", true);
        animator.SetBool("IsScaling", false);
    }

    public void WalkOut()
    {
        walkingIn = false;
        scaling = false;
        walkingOut = true;

        animator.SetBool("IsWalking", true);
    }

    private void CustomerArrived()
    {
        if (customerFlowManager != null)
        {
            customerFlowManager.CustomerArrived();
        }
        else
        {
            Debug.LogError("CustomerMovementManager has NO CustomerFlowManager assigned!");
        }
    }

    private void CustomerLeft()
    {
        if (customerFlowManager != null)
        {
            customerFlowManager.CustomerLeft();
        }
    }
}