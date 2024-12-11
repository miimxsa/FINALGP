using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;  // Necessary for the new Input System

public class InteractableObject : MonoBehaviour
{
    public string objectDescription = "BED";
    public TMP_Text descriptionText;
    public GameObject descriptionBox;

    private bool isPlayerNearby = false;

    private PlayerInput playerInput;
    
    private void OnEnable()
    {
        playerInput = GetComponent<PlayerInput>();

        playerInput.actions["Interact"].performed += OnInteract;
        playerInput.actions["HideDescription"].performed += OnHideDescription;
    }

    private void OnDisable()
    {
        playerInput.actions["Interact"].performed -= OnInteract;
        playerInput.actions["HideDescription"].performed -= OnHideDescription;
    }

    private void OnInteract(InputAction.CallbackContext context)
    {
        if (isPlayerNearby)
        {
            ShowDescription();
        }
    }

    private void OnHideDescription(InputAction.CallbackContext context)
    {
        if (descriptionBox.activeSelf)
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

