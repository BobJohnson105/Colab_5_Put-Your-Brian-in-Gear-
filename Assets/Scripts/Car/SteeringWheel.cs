using UnityEngine;

public class SteeringWheel : MonoBehaviour
{
    public float steeringValue;
    public float steeringSpeed;
    private void Update()
    {
        steeringValue = transform.rotation.z * steeringSpeed;
    }
}
