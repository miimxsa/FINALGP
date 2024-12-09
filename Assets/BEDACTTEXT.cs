using UnityEngine;
using TMPro;  

public class BEDACTTEXT : MonoBehaviour
{
    [SerializeField] private TMP_Text textLabel;  

    private void Start()
    {
        GetComponent<TYPEWRITEREFFECT>().Run(" This is my bed. I don't make it at all. \n Real girls in the movies don't \n So why should I? ", textLabel);
    }
}