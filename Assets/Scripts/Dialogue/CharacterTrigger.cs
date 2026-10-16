using UnityEngine;
using TMPro;
using Ink.Runtime;
using System.Collections.Generic;

// Script for visual trigger for Character 1. Starts dialogue and destroys itself. 

public class CharacterTrigger : MonoBehaviour
{
    public GameObject visualCue;
    public TextAsset inkJSON;
    public bool clickable;

    public DialogueAnimator dialogueAnimator;

    private void Start()
    {
        visualCue.SetActive(false);
    }

    private void Update()
    {
        if (clickable && Input.GetKeyDown(KeyCode.Mouse0))
        {
            visualCue.SetActive(false);

            DialogueManager.GetInstance().EnterDialogueMode(
                inkJSON,

                // Dialogue finished
                () =>
                {
                    if (dialogueAnimator != null)
                    {
                        dialogueAnimator.StopTalking();
                    }
                },

                // Dialogue started
                () =>
                {
                    if (dialogueAnimator != null)
                    {
                        dialogueAnimator.StartTalking();
                    }
                }
            );

            Destroy(gameObject);
        }
    }

    public void ShowVisualCue()
    {
        visualCue.SetActive(true);
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
        }
    }
}