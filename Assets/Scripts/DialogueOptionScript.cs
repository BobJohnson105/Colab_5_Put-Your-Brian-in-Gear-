using UnityEngine;
using UnityEngine.EventSystems;

public class DialogueOptionScript : MonoBehaviour,  IPointerClickHandler, IPointerEnterHandler
{
    private float launchForce = 0.2f;
    private float tumbleForce = 0.1f;

    private Rigidbody rb;

    public WordData wordDataRef;
    private string currentWordNeeded;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PushBox();

        currentWordNeeded = "Hi Officer";
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Destroy(gameObject);
        CheckIsRightWord();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        launchForce = 2f;
        tumbleForce = 1f;
        PushBox();
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
