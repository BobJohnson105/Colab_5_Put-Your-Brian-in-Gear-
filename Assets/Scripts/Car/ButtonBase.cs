
using UnityEngine;
using UnityEngine.Events;

public class PhysicalButton : MonoBehaviour
{
    public Transform buttonTop;

    public float pressDepth = 0.05f;
    public float pressSpeed = 5f;

    public UnityEvent onPressed;

    private Vector3 startPosition;
    private bool isPressed;

    void Start()
    {
        startPosition = buttonTop.localPosition;
    }

    void Update()
    {
        float targetY = isPressed
            ? startPosition.y - pressDepth
            : startPosition.y;

        Vector3 targetPosition = new Vector3(
            startPosition.x,
            targetY,
            startPosition.z
        );

        buttonTop.localPosition = Vector3.Lerp(
            buttonTop.localPosition,
            targetPosition,
            Time.deltaTime * pressSpeed
        );
    }

    public void Press()
    {
        if (!isPressed)
        {
            isPressed = true;
            onPressed.Invoke();
        }
    }

    public void Release()
    {
        isPressed = false;
    }
}
