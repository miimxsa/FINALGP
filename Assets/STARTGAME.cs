using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private PlayerInput playerInput;           
    private InputAction loadBedroomAction;    

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();

        if (playerInput == null)
        {
            Debug.LogError("PlayerInput component not found on this GameObject. Please attach it.");
            return;
        }

        loadBedroomAction = playerInput.actions["LoadBedroom"];  

        if (loadBedroomAction == null)
        {
            Debug.LogError("Input action 'LoadBedroom' not found. Ensure the action is defined in the Input Actions asset.");
            return; 
        }
    }

    private void OnEnable()
    {
        if (loadBedroomAction != null)
        {
            loadBedroomAction.Enable();
        }
    }

    private void OnDisable()
    {
        if (loadBedroomAction != null)
        {
            loadBedroomAction.Disable();
        }
    }

    private void Update()
    {
        if (loadBedroomAction != null && loadBedroomAction.triggered)
        {
            SceneManager.LoadScene("BEDROOM");
        }
    }
}
