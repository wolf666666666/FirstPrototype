using UnityEngine;

// Script for managing animation relating to dialogue. 

public class DialogueAnimator : MonoBehaviour
{
    public Animator animator;

    public void StartTalking()
    {
        if (animator != null)
        {
            animator.SetBool("IsSpeaking", true);
        }
    }

    public void StopTalking()
    {
        if (animator != null)
        {
            animator.SetBool("IsSpeaking", false);
        }
    }
}
