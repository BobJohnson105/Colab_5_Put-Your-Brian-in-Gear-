using TMPro;
using UnityEngine;

public class DialogueDisplayManager : MonoBehaviour
{
    public TextMeshProUGUI speechText;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speechText.text = "hi";
    }

   public void UpdateSpeechText(string newText)
   {
        speechText.text = newText;
    }
}
