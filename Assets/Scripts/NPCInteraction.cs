using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    // DialogueUI ��ũ��Ʈ�� ���� ������Ʈ�� Inspector���� �����մϴ�.
    public DialogueUI dialogueUI;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("�浹�ν�");
        // �÷��̾� �±װ� "Player"�� �����Ǿ� �־�� �մϴ�.
        if (other.CompareTag("Player"))
        {
            Debug.Log("�÷��̾� �ν�");
            dialogueUI.ShowDialogue();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("�÷��̾� �ν�");
            dialogueUI.HideDialogue();
        }
    }
}
