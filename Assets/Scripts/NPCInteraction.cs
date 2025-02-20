using UnityEngine;

public class NPCInteraction : MonoBehaviour // npc�� player �� ��ȣ�ۿ��� ���� Ŭ����
{
    public DialogueUI dialogueUI;

    private void OnTriggerEnter2D(Collider2D other) // �÷��̾ npc�� box collider �κп� ������ ��
    {
        if (other.CompareTag("Player"))
        {
            dialogueUI.ShowDialogue(); // ��ȭâ �����ֱ�
        }
    }

    private void OnTriggerExit2D(Collider2D collision) // ������
    {
        if (collision.CompareTag("Player"))
        {
            dialogueUI.HideDialogue(); //�� ���̰� ������ֱ�
        }
    }

}
