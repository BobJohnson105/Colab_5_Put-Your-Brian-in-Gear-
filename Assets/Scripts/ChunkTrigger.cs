using Unity.VisualScripting;
using UnityEngine;

public class ChunkTrigger : MonoBehaviour
{
    public GameObject chunk;
    [SerializeField] private GameObject newChunk;
    [SerializeField] private GameObject lastChunk;
    public EventSystem eventSys;

    private void Start()
    {
        newChunk = null;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Trigger"))
        {
            if (newChunk)
            {
                Destroy(lastChunk);
            }
            lastChunk = other.gameObject.transform.parent.gameObject;
            newChunk = Instantiate(eventSys.GetNextChunk(), new Vector3(-25, 0, 350), Quaternion.identity);
           
        }
    }


}
