using UnityEngine;
using UnityEngine.InputSystem;  

public class NotebookScript : MonoBehaviour
{
    [SerializeField] private Vector2 minSpawnPos;   
    [SerializeField] private Vector2 maxSpawnPos;   

    [SerializeField] private GameObject notebook;    
    private bool isPickedUp = false;  
    private const string notebookPickedUpKey = "NotebookPickedUp";  

    private PlayerInput playerInput;  

    private void Awake()
    {
        
        playerInput = FindObjectOfType<PlayerInput>();  
    }

    private void Start()
    {
        if (PlayerPrefs.GetInt(notebookPickedUpKey, 0) == 1)
        {
            notebook.SetActive(false); 
        }
        else
        {
            SpawnNotebookAtRandomLocation();
        }
    }

    private void Update()
    {
        
    }

    private void SpawnNotebookAtRandomLocation()
    {
        float randomX = Random.Range(minSpawnPos.x, maxSpawnPos.x);
        float randomY = Random.Range(minSpawnPos.y, maxSpawnPos.y);
        Vector2 randomPosition = new Vector2(randomX, randomY);

        notebook.transform.position = randomPosition;

        notebook.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (playerInput.actions["Interact"].triggered)  
            {
                isPickedUp = true;

                notebook.SetActive(false);

                PlayerPrefs.SetInt(notebookPickedUpKey, 1); 
                PlayerPrefs.Save();  
            }
        }
    }
}
