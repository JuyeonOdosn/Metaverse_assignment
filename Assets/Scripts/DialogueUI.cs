using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueUI : MonoBehaviour
{
    
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public Button nextButton;  

    public string[] dialogues;
    private int currentDialogueIndex = 0;

    void Start()
    {
        dialoguePanel.SetActive(false);
    }

    public void ShowDialogue()
    {
        currentDialogueIndex = 0;
        dialoguePanel.SetActive(true);
        dialogueText.text = dialogues[currentDialogueIndex];
    }

    public void OnNextButtonClicked()
    {
        currentDialogueIndex++;
        if (currentDialogueIndex < dialogues.Length)
        {
            dialogueText.text = dialogues[currentDialogueIndex];
        }
        else
        {
            HideDialogue();
        }
    }

    public void HideDialogue()
    {
        dialoguePanel.SetActive(false);
    }

}


