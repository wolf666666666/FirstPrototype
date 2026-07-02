using UnityEngine;
using TMPro;
using Ink.Runtime;
using System.Collections.Generic;

public class LandladyTrigger : MonoBehaviour
{
    [SerializeField] private GameObject visualCue;
    [SerializeField] private TextAsset inkJSON;
    public bool clickable;

    private void Start()
    {
        visualCue.SetActive(false);
        
        Invoke("Wait", 2f); // Call the Wait method after 2 seconds
    }

    private void Update()
    {
        if (clickable && Input.GetKeyDown(KeyCode.Mouse0))
        {
            visualCue.SetActive(false);
            LandladyDialogueManager.GetInstance().EnterDialogueMode(inkJSON); 
            Destroy(gameObject);
        }
    }

    private void Wait()
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
