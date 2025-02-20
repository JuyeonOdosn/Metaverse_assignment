using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    public DialogueUI dialogueUI;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            dialogueUI.ShowDialogue();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            dialogueUI.HideDialogue();
        }
    }

    private void Update()
    {
        
    }
}
