using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    public float interactionRange = 3f;
    public KeyCode interactKey = KeyCode.Z;
    private GameObject interactableObject;
    public Text interactionPrompt; 
    
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, interactionRange);

        if (hit.collider != null && hit.collider.CompareTag("Interactable"))
        {
            interactableObject = hit.collider.gameObject;
            interactionPrompt.text = "Press Z to interact"; 

            if (Input.GetKeyDown(interactKey))
            {
                InteractWithObject(interactableObject);
            }
        }
        else
        {
            interactableObject = null;
            interactionPrompt.text = ""; 
        }
    }

    void InteractWithObject(GameObject obj)
    {
        SpriteRenderer objectSprite = obj.GetComponent<SpriteRenderer>();
        if (objectSprite != null)
        {
            objectSprite.color = Color.green;
        }

        Debug.Log("Interacted with: " + obj.name);
    }
}
