using UnityEngine;
using TMPro;
using Ink.Runtime;
using System.Collections.Generic;

// Script for visual trigger for Landlady. Starts dialogue and destroys itself. 

public class LandladyTrigger : MonoBehaviour
{
    public GameObject visualCue;
    public TextAsset inkJSON;
    public bool clickable;
    private bool cueVisible = false;
    public CustomerMovementManager customerMovementManager;

    private void Start()
    {
        visualCue.SetActive(false);

        Invoke(nameof(ShowCue), 2f);
    }

    private void Update()
    {
        if (clickable && cueVisible && Input.GetMouseButtonDown(0))
        {
            visualCue.SetActive(false);
            cueVisible = false;

            DialogueManager.GetInstance().EnterDialogueMode(
                inkJSON,
                () =>
                {
                    Invoke(nameof(Walk), 2f);
                }
            );
        }
    }

    private void ShowCue()
    {
        visualCue.SetActive(true);
        cueVisible = true;
    }

    private void Walk()
    {
        customerMovementManager.WalkIn();
        Destroy(gameObject);
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
