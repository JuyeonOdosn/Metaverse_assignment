using TMPro;
using UnityEngine;
using UnityEngine.UI; // Text, Button �� UI ������Ʈ�� ���

public class DialogueUI : MonoBehaviour
{
    // Panel ������Ʈ�� �巡�� �� ������� �Ҵ�
    public GameObject dialoguePanel;
    // Text ������Ʈ (TextMeshProUGUI�� ����� ��� �ش� ���ӽ����̽��� ��ü)
    public TextMeshProUGUI dialogueText;
    // ��ư�� ������ ��簡 �Ѿ���� ������ �� ����
    public Button nextButton;  

    // ��� �迭 ����
    public string[] dialogues;
    private int currentDialogueIndex = 0;

    void Start()
    {
        // ���� ���� �� ��ȭâ�� ����ϴ�.
        dialoguePanel.SetActive(false);
        Debug.Log("�޼��� ��ŸƮ");
    }

    // NPC�� ��ȣ�ۿ� �� ȣ�� (��: NPC ��ũ��Ʈ���� ȣ��)
    public void ShowDialogue()
    {
        currentDialogueIndex = 0;
        dialoguePanel.SetActive(true);
        dialogueText.text = dialogues[currentDialogueIndex];
    }

    // "����" ��ư Ŭ�� �� ȣ��Ǵ� �޼���
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


