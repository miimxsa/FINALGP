using UnityEngine;
using UnityEngine.UI;  
using System.Collections;

public class ScreenFade : MonoBehaviour
{
    [SerializeField] private Image fadeImage;  
    [SerializeField] private float fadeDuration = 1f;  

    private bool isFading = false;  

    private void Start()
    {
        fadeImage.color = new Color(0, 0, 0, 0);  
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isFading)
        {
            StartCoroutine(FadeToBlack());  
        }
    }

    private IEnumerator FadeToBlack()
    {
        isFading = true;  

        float timeElapsed = 0f;
        while (timeElapsed < fadeDuration)
        {
            timeElapsed += Time.deltaTime;
            fadeImage.color = new Color(0, 0, 0, Mathf.Lerp(0, 1, timeElapsed / fadeDuration));  
            yield return null;
        }

        fadeImage.color = new Color(0, 0, 0, 1);  

    }
}