
using UnityEngine;

public class PedalController : MonoBehaviour
{
    public HingeJoint pedalJoint;

    [Header("Pedal Settings")]
    public float restAngle = 0f;
    public float pressedAngle = -25f;

    [Header("Pedal Output")]
    [Range(0f, 1f)]
    public float pedalValue;

    private void Start()
    {
        if (pedalJoint == null)
            pedalJoint = GetComponent<HingeJoint>();

        // Configure the return spring
        JointSpring spring = pedalJoint.spring;
        spring.spring = 100f;
        spring.damper = 5f;
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
    }
}
