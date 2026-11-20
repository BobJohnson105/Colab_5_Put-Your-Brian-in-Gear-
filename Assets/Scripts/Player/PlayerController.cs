using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public InputAction xMovement;
    public InputAction zyMovement;
    public InputAction depthChoice;

    public int axis;


    public float xValue;
    public float zyValue;
    public float depthChoiceValue;

    public int playerNumber;

    private void Start()
    {

    }

    private void OnEnable()
    {
        xMovement.Enable();
        zyMovement.Enable();
        depthChoice.Enable();
    }

    private void OnDisable()
    {
        xMovement.Disable();
        zyMovement.Disable();
        depthChoice.Disable();
    }

    private void Update()
    {
        
        xValue = xMovement.ReadValue<float>() * 20;
        zyValue = zyMovement.ReadValue<float>() * 20;
        depthChoiceValue = depthChoice.ReadValue<float>();

    }
}
