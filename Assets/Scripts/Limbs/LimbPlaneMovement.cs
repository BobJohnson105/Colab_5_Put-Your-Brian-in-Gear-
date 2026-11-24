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


    public enum LimbType
    {
        Arm,
        Leg
    }

    public LimbType limbType;

    private void Start()
    {
        if (limbType == LimbType.Leg)
        {
            Rigidbody rb = GetComponent<Rigidbody>();

            rb.constraints =
                RigidbodyConstraints.FreezePositionX |
                RigidbodyConstraints.FreezePositionY;
        }
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
        if (!isPossessed)
            return;

        xValue = xMovement.ReadValue<float>() * 20;
        zyValue = zyMovement.ReadValue<float>() * 20;
        depthChoiceValue = depthChoice.ReadValue<float>();

        if (limbType == LimbType.Leg)
        {
            // Leg can only move forward/backward
            extremityConstForce.force = new Vector3(0, 0, zyValue);

           
        }
        else if (depthChoiceValue == 1)
        {
            // original XY 
            extremityConstForce.force = new Vector3(xValue, 0, zyValue);
        }
        else
        {
            // original XZ 
            extremityConstForce.force = new Vector3(xValue, zyValue, 0);
        }
    }
}
