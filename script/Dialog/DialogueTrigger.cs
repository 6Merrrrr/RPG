using UnityEngine;
public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private DialogueData dialogueData;
    [SerializeField] private DialogueManager dialogueManager;
    [SerializeField] private KeyCode interactKey = KeyCode.E; // 交互按键
    [SerializeField] private GameObject interactPrompt; // 交互提示（如"按E对话"）
    
     private bool isPlayerInRange = false;
   private void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
        interactPrompt.SetActive(false);
    }

    private void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(interactKey))
        {
            dialogueManager.StartDialogue(dialogueData.dialogue);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            interactPrompt.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            interactPrompt.SetActive(false);
        }
    }
}