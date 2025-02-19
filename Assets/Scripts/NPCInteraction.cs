using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    public DialogueUI dialogueUI;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("충돌인식");
        // 플레이어 태그가 "Player"로 설정되어 있어야 합니다.
        if (other.CompareTag("Player"))
        {
            Debug.Log("플레이어 인식");
            dialogueUI.ShowDialogue();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("플레이어 인식");
            dialogueUI.HideDialogue();
        }
    }

    private void Update()
    {
        
    }
}
