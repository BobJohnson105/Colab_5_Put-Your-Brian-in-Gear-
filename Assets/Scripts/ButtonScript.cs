using UnityEngine;
using UnityEngine.Events;

public class NewMonoBehaviourScript : MonoBehaviour
{

    public Transform ButtonTop;
    public Transform ButtonLowerLimit;
    public Transform ButtonUpperLimit;
    public float ThresHold;
    public float Forces = 10;
    public float UpperLowerDiff;
    public bool IsPressed;
    private bool PressedState;
    public AudioSource PressedSound;
    public AudioSource releasedSound;
    public UnityEvent OnPressed;
    public UnityEvent OnReleased; 
    
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Collider localCollider = GetComponent<Collider>();
        if (localCollider != null)
        {
            Physics.IgnoreCollision(localCollider, ButtonTop.GetComponentInChildren<Collider>());

            foreach (Collider singleCollider in CollidersToIgnore)
            {
                Physics.IgnoreCollision(localCollider, singleCollider);
            }
        }

        if (transform.eulerAngles != Vector3.zero)
        {
            Vector3 savedAngle = transform.eulerAngles;
            transform.eulerAngles = Vector3.zero;
            UpperLowerDiff = ButtonUpperLimit.position.y - ButtonLowerLimit.position.y;
            transform.eulerAngles = savedAngle;
        }
        else
            UpperLowerDiff = ButtonUpperLimit.position.y - ButtonLowerLimit.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        ButtonTop.transform.localPosition = new Vector3(0, ButtonTop.transform.localPosition.y, 0);
        ButtonTop.transform.localEulerAngles = new Vector3(0, 0, 0);
        if (ButtonTop.localPosition.y >= 0)
            ButtonTop.transform.position = new Vector3(buttonUpperLimit.position.x, buttonUpperLimit.position.y, buttonUpperLimit.position.z);
        else
            ButtonTopRigid.AddForce(ButtonTop.transform.up * force * Time.deltaTime);

        if (ButtonTop.localPosition.y <= buttonLowerLimit.localPosition.y)
            ButtonTop.transform.position = new Vector3(buttonLowerLimit.position.x, buttonLowerLimit.position.y, buttonLowerLimit.position.z);


        if (Vector3.Distance(ButtonTop.position, buttonLowerLimit.position) < upperLowerDiff * threshHold)
            isPressed = true;
        else
            isPressed = false;

        if (isPressed && prevPressedState != isPressed)
            Pressed();
        if (!isPressed && prevPressedState != isPressed)
            Released();
    }
    void Pressed()
    {
        prevPressedState = isPressed;
        pressedSound.pitch = 1;
        pressedSound.Play();
        onPressed.Invoke();
    }

    void Released()
    {
        prevPressedState = isPressed;
        releasedSound.pitch = Random.Range(1.1f, 1.2f);
        releasedSound.Play();
        onReleased.Invoke();
    }

}
