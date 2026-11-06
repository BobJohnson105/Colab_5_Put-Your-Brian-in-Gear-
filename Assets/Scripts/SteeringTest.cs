using UnityEngine;

public class SteeringTest : MonoBehaviour
{
    public float direction;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hand"))
        {
            Debug.Log("STEERING!");
            PlayerManager.instance.yaw = direction;
        }
    }
}
