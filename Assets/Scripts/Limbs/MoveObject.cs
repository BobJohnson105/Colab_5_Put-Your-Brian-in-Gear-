using UnityEngine;

public class MoveObject : MonoBehaviour
{
    // This is an object that can be grabbed and moved around, not attached to anything, like a liscense

    private bool isGrabbed = false;

    public void ToggleGrab(Transform newParent)
    {
        transform.SetParent(newParent);
        isGrabbed = true; 
    }

    public void UnGrabbed()
    {
        transform.SetParent(null);
        isGrabbed = false;
    }

    private void Update()
    {
        if (isGrabbed)
        {
            transform.localPosition = Vector3.zero;
        }
    }
}
