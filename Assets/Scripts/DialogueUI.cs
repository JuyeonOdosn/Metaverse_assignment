using TMPro;
using UnityEngine;
using UnityEngine.UI; // Text, Button 등 UI 컴포넌트를 사용

public class DialogueUI : MonoBehaviour
{
    // Panel 오브젝트를 드래그 앤 드롭으로 할당
    public GameObject dialoguePanel;
    // Text 컴포넌트 (TextMeshProUGUI를 사용할 경우 해당 네임스페이스로 교체)
    public TextMeshProUGUI dialogueText;
    // 버튼을 누르면 대사가 넘어가도록 연결할 수 있음
    public Button nextButton;  

    // 대사 배열 예시
    public string[] dialogues;
    private int currentDialogueIndex = 0;

    void Start()
    {
        // 게임 시작 시 대화창을 숨깁니다.
        dialoguePanel.SetActive(false);
        Debug.Log("메서드 스타트");
    }

    // NPC와 상호작용 시 호출 (예: NPC 스크립트에서 호출)
    public void ShowDialogue()
    {
        currentDialogueIndex = 0;
        dialoguePanel.SetActive(true);
        dialogueText.text = dialogues[currentDialogueIndex];
    }

    // "다음" 버튼 클릭 시 호출되는 메서드
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


