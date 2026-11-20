using UnityEngine;
using UnityEngine.InputSystem;


public class LimbPlaneMovement : MonoBehaviour
{
    public bool isPossessed;


    public InputAction xMovement;
    public InputAction zyMovement;
    public InputAction depthChoice;

    public int axis;
    public ConstantForce extremityConstForce;

    private float xValue;
    private float zyValue;
    public float depthChoiceValue;

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
        if (isPossessed)
        {
            xValue = xMovement.ReadValue<float>() * 20;
            zyValue = zyMovement.ReadValue<float>() * 20;
            depthChoiceValue = depthChoice.ReadValue<float>();

            if (depthChoiceValue == 1)
            {
                extremityConstForce.force = new Vector3(xValue, 0, zyValue);
            }
            else
            {
                extremityConstForce.force = new Vector3(xValue, zyValue, 0);
            }
        }
            
    }
}
