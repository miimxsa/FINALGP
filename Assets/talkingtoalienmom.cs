using UnityEngine;
using TMPro;  

public class talkingtoalienmom : MonoBehaviour
{
    [SerializeField] private TMP_Text textLabel;  
    [SerializeField] private Canvas dialogueCanvas;  
    [SerializeField] private string interactionText = "Press 'E' to interact.";  

    private bool playerInRange = false;  

    private void Start()
    {
        dialogueCanvas.enabled = false;
    }

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            dialogueCanvas.enabled = !dialogueCanvas.enabled;
            
            textLabel.text = interactionText;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))  
        {
            playerInRange = true;
            textLabel.text = "Press 'E' to interact";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            textLabel.text = "";
            dialogueCanvas.enabled = false;  
        }
    }
}
