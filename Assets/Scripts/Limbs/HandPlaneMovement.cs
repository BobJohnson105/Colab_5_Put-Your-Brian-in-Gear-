using UnityEngine;
using UnityEngine.InputSystem;


public class HandPlaneMovement : MonoBehaviour
{
    public InputAction xMovement;
    public InputAction zyMovement;
    public InputAction depthChoice;


    private ConstantForce force;

    private float xValue;
    private float zyValue;
    public float depthChoiceValue;

    private void Start()
    {
        force = GetComponent<ConstantForce>();
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

        if (depthChoiceValue == 1)
        {
            force.force = new Vector3(xValue, 0, zyValue);
        }
        else
        {
            force.force = new Vector3(xValue, zyValue, 0);
        }
            
    }
}
