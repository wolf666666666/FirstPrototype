using UnityEngine;
using TMPro;
using Ink.Runtime;
using System.Collections.Generic;

// Script for managing dialogue. Begins dialogue, shows dialogue UI, handles choices, ends dialogue, hides UI.

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;

    
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;

    private static DialogueManager instance;
    private Story currentStory;
    private bool dialogueIsPlaying;
    public GameObject continueButton;
    private System.Action onDialogueFinished;
    private System.Action onDialogueStarted;

    private void Awake()
    {
        instance = this;
    }

    public static DialogueManager GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        continueButton.SetActive(false);

        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach (GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
    }

    private void Update()
    {
        if (!dialogueIsPlaying)
        {
            return;
        }
    }

    public void EnterDialogueMode(TextAsset inkJSON, System.Action onFinished = null, System.Action onStarted = null)
    {
        currentStory = new Story(inkJSON.text);

        onDialogueFinished = onFinished;
        onDialogueStarted = onStarted;

        dialogueIsPlaying = true;

        dialoguePanel.SetActive(true);
        continueButton.SetActive(true);

        onDialogueStarted?.Invoke();

        ContinueStory();
    }

    public void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            dialogueText.text = currentStory.Continue();
            continueButton.SetActive(true);
            DisplayChoices();
        }
        else
        {
            ExitDialogueMode();
        }
    }

    public void MakeChoice(int choiceIndex)
    {
        currentStory.ChooseChoiceIndex(choiceIndex);
        ContinueStory();
        continueButton.SetActive(true);

        if (currentStory.currentChoices.Count == 0 && !currentStory.canContinue)
        {
            ExitDialogueMode();
        }
    }

    private void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;

        if (currentChoices.Count > choices.Length)
        {
            Debug.LogError("More choices than UI elements");
        }

        int index = 0;
        foreach (Choice choice in currentChoices)
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
            continueButton.SetActive(false);
        }

        for (int i = index; i < choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);
        }
    }

    private void ExitDialogueMode()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        continueButton.SetActive(false);
        dialogueText.text = "";

        onDialogueFinished?.Invoke();
        onDialogueFinished = null;
    }
}

