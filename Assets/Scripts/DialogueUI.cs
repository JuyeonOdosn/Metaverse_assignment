using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueUI : MonoBehaviour // NPC와의 대화를 위한 클래스
{
    
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public Button nextButton;  

    public string[] dialogues;
    private int currentDialogueIndex = 0;

    void Start()
    {
        dialoguePanel.SetActive(false); //기본적으로 안 보이는 상태
    }

    public void ShowDialogue() // 대화창 보여주기
    {
        currentDialogueIndex = 0;
        dialoguePanel.SetActive(true);
        dialogueText.text = dialogues[currentDialogueIndex];
    }

    public void OnNextButtonClicked() //다음 대화로 넘어가기
    {
        currentDialogueIndex++;
        if (currentDialogueIndex < dialogues.Length)
        {
            dialogueText.text = dialogues[currentDialogueIndex];
        }
        else
        {
            HideDialogue(); // NPC가 준비한 대화가 없다면 종료
        }
    }

    public void HideDialogue() //대화 종료
    {
        dialoguePanel.SetActive(false); 
    }

}


