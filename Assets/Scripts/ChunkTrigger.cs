using UnityEngine;

public class ChunkTrigger : MonoBehaviour
{
    public GameObject chunk;



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Trigger"))
        {
            Instantiate(chunk, new Vector3(0, 0, 70), Quaternion.identity);
        }
    }


}
