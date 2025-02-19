using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    public GameObject dialogueUI;

    private void Start()
    { 
        dialogueUI.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            dialogueUI.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            dialogueUI.SetActive(true);
        }
    }

}

