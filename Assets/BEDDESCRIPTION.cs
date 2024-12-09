using UnityEngine;
using TMPro;

public class InteractableObject : MonoBehaviour
{
    public string objectDescription = "BED"; 
    public TMP_Text descriptionText;  
    public GameObject descriptionBox; 

    private bool isPlayerNearby = false;

    private void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            ShowDescription();
        }

        if (descriptionBox.activeSelf && Input.GetKeyDown(KeyCode.Space))
        {
            HideDescription();
        }
    }

    private void ShowDescription()
    {
        descriptionBox.SetActive(true);  
        descriptionText.text = objectDescription;  
    }

    private void HideDescription()
    {
        descriptionBox.SetActive(false);  
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;  
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;  
            HideDescription();  
        }
    }
}
