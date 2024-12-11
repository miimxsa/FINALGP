using UnityEngine;
using TMPro;  
using System.Collections;
using UnityEngine.SceneManagement;  

public class INTRODUCTION : MonoBehaviour
{
    [SerializeField] private TMP_Text textLabel;  
    [SerializeField] private Canvas dialogueCanvas;  

    private bool hasGameStarted = false;  

    private void Start()
    {
        if (!hasGameStarted)
        {
            dialogueCanvas.enabled = true;

            GetComponent<TYPEWRITEREFFECT>().Run("ALIEN GIRL: Recently I've been studying how humans live.. I've decided I'm going to be a teen human girl! Now where did I leave all my stuff?", textLabel);

            StartCoroutine(HideDialogueAfterTime(15f));

            hasGameStarted = true;
        }
        else
        {
            dialogueCanvas.enabled = false;
        }
    }

    private void OnEnable()
    {
        if (hasGameStarted)
        {
            dialogueCanvas.enabled = false;
        }
    }

    private IEnumerator HideDialogueAfterTime(float time)
    {
        yield return new WaitForSeconds(time);  
        dialogueCanvas.enabled = false;  
    }
}
