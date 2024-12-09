using System.Collections;
using TMPro;
using UnityEngine;
using System.Text;  

public class TYPEWRITEREFFECT : MonoBehaviour
{
    public Coroutine Run(string textToType, TMP_Text textLabel)
    {
        return StartCoroutine(typetext(textToType, textLabel));
    }

    private IEnumerator typetext(string textToType, TMP_Text textLabel)
    {
        float timeBetweenLetters = 0.1f;
        int charIndex = 0;
        StringBuilder typedText = new StringBuilder();  

        while (charIndex < textToType.Length)
        {
            typedText.Append(textToType[charIndex]);  
            textLabel.text = typedText.ToString();  

            charIndex++;

            yield return new WaitForSeconds(timeBetweenLetters);
        }

        textLabel.text = textToType;  
    }
}
