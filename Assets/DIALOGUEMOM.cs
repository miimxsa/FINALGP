using UnityEngine;
using TMPro;
using System.Collections;

public class DIALOGUEMOM : MonoBehaviour
{
    [SerializeField] private TMP_Text textLabel;
    [SerializeField] private Canvas dialogueCanvas;
    private const string dialogueShownKey = "DialogueShown";

    private void Start()
    {
        if (PlayerPrefs.GetInt(dialogueShownKey, 0) == 1)
        {
            dialogueCanvas.enabled = false;  
            return;
        }

        GetComponent<TYPEWRITEREFFECT>().Run(" MOM ALIEN: Gleep glorp glorp gleep gleep... cereal \n glorp? ", textLabel);

        StartCoroutine(HideDialogueAfterTime(10f)); 
    }

    private IEnumerator HideDialogueAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        
        dialogueCanvas.enabled = false;
        
        PlayerPrefs.SetInt(dialogueShownKey, 1);
        PlayerPrefs.Save(); 
    }
}
