using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using System.Collections;

public class DialogueOptionScript : MonoBehaviour,  IPointerClickHandler, IPointerEnterHandler
{
    public ParticleSystem tenticleSystem;
    public GameObject optionBox;
    
    private float launchForce = 0.2f;
    private float tumbleForce = 0.1f;

    private DialogueDisplayManager dialogueDisplayManagerScript;

    private Rigidbody rb;

    public WordData wordDataRef;
    private string currentWordNeeded;

    private TextMeshProUGUI optionText;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PushBox();

        currentWordNeeded = "Hi Officer";

        dialogueDisplayManagerScript = FindAnyObjectByType<DialogueDisplayManager>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        tenticleSystem.Play();
        Destroy(optionBox);
        StartCoroutine("DestroyObject");
        CheckIsRightWord();
        dialogueDisplayManagerScript.UpdateSpeechText(wordDataRef.assignedWord);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Hovering");
        launchForce = 2f;
        tumbleForce = 0.5f;
        PushBox();
    }

    public void UpdateDialogueOption()
    {
        optionText.text = wordDataRef.assignedWord;
    }

    private IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }

    private void PushBox()
    {
        if (rb != null)
        {
            // Send in random direction
            Vector3 randomDirection = Random.insideUnitSphere.normalized;
            rb.AddForce(randomDirection * launchForce, ForceMode.Impulse);

            // random rotational spin
            Vector3 randomTorque = Random.insideUnitSphere * tumbleForce;
            rb.AddTorque(randomTorque, ForceMode.Impulse);
        }

        
    }

    private void CheckIsRightWord()
    {
        if (wordDataRef.assignedWord == currentWordNeeded)
        {
            Debug.Log("Correct word");
        }
        else
        {
            Debug.Log("Incorrect Word");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
