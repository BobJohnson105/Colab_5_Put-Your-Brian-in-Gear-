
using UnityEngine;

public class PedalController : MonoBehaviour
{
    // Reference to the Hinge Joint controlling the pedal
    public HingeJoint pedalJoint;

    [Header("Pedal Settings")]
    public float restAngle = 0f;
    public float pressedAngle = -25f;

    // The final pedal reading between 0 and 1
    [Header("Pedal Output")]
    [Range(0f, 1f)]
    public float pedalValue;

    // Reference to our pedal controller
    public PedalController pedalController;

    // Maximum acceleration force
    public float maxAcceleration = 100f;

    private void Start()
    {
       

        // Configure the return spring
        JointSpring spring = pedalJoint.spring;
        spring.spring = 10f;
        spring.damper = 1f;
        spring.targetPosition = restAngle;

        pedalJoint.spring = spring;
        pedalJoint.useSpring = true;
        pedalJoint.useLimits = true;
    }

    private void Update()
    {
        // Read the current pedal angle
        float currentAngle = pedalJoint.angle;

        // Convert angle into a value between 0 and 1
        pedalValue = Mathf.InverseLerp(
            restAngle,
            pressedAngle,
            currentAngle
        );

        pedalValue = Mathf.Clamp01(pedalValue);

        // Read how far the pedal is pressed
        float accelerationInput = pedalController.pedalValue;

        // Calculate the acceleration force
        float acceleration = accelerationInput * maxAcceleration;
    }
}
