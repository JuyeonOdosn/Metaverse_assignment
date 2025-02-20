using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueUI : MonoBehaviour // NPC���� ��ȭ�� ���� Ŭ����
{
    
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public Button nextButton;  

    public string[] dialogues;
    private int currentDialogueIndex = 0;

    void Start()
    {
        dialoguePanel.SetActive(false); //�⺻������ �� ���̴� ����
    }

    public void ShowDialogue() // ��ȭâ �����ֱ�
    {
        currentDialogueIndex = 0;
        dialoguePanel.SetActive(true);
        dialogueText.text = dialogues[currentDialogueIndex];
    }

    public void OnNextButtonClicked() //���� ��ȭ�� �Ѿ��
    {
        currentDialogueIndex++;
        if (currentDialogueIndex < dialogues.Length)
        {
            dialogueText.text = dialogues[currentDialogueIndex];
        }
        else
        {
            HideDialogue(); // NPC�� �غ��� ��ȭ�� ���ٸ� ����
        }
    }

    public void HideDialogue() //��ȭ ����
    {
        dialoguePanel.SetActive(false); 
    }

}


