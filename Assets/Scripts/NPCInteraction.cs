using UnityEngine;

public class NPCInteraction : MonoBehaviour // npc와 player 간 상호작용을 위한 클래스
{
    public DialogueUI dialogueUI;

    private void OnTriggerEnter2D(Collider2D other) // 플레이어가 npc의 box collider 부분에 들어왔을 때
    {
        if (other.CompareTag("Player"))
        {
            dialogueUI.ShowDialogue(); // 대화창 보여주기
        }
    }

    private void OnTriggerExit2D(Collider2D collision) // 나갈때
    {
        if (collision.CompareTag("Player"))
        {
            dialogueUI.HideDialogue(); //안 보이게 만들어주기
        }
    }

}
