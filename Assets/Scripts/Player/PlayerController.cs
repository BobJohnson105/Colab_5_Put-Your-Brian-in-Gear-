using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public InputAction xMovement;
    public InputAction zyMovement;
    public InputAction depthChoice;
    public InputAction grabInput;
    public InputAction possessInput;

    public int axis;


    public float xValue;
    public float zyValue;
    public float depthChoiceValue;
    public float grabValue;
    public float possessValue;

    public int playerNumber;


    public TentacleController tentacleController;

    private void OnEnable()
    {
        xMovement.Enable();
        zyMovement.Enable();
        depthChoice.Enable();
        grabInput.Enable();
        possessInput.Enable();
    }

    private void OnDisable()
    {
        xMovement.Disable();
        zyMovement.Disable();
        depthChoice.Disable();
        grabInput.Disable();
        possessInput.Disable();
    }

    private void Update()
    {
        
        xValue = xMovement.ReadValue<float>();
        zyValue = zyMovement.ReadValue<float>();

        depthChoiceValue = depthChoice.ReadValue<float>();
        grabValue = grabInput.ReadValue<float>();
        possessValue = possessInput.ReadValue<float>();

        tentacleController.ReadInputValues(xValue, zyValue, depthChoiceValue, grabValue, possessValue);

    }
}
