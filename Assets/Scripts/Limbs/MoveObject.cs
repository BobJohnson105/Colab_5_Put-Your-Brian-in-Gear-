using UnityEngine;

public class MoveObject : MonoBehaviour
{
    // This is an object that can be grabbed and moved around, not attached to anything, like a liscense

    private bool isGrabbed = false;

    //public Collider myCollider;

    public void ToggleGrab(Transform newParent)
    {
        if (isGrabbed)
        {
            transform.SetParent(null);
            isGrabbed = false;
        }
        else
        {
            transform.SetParent(newParent);
            isGrabbed = true;
        }

    }

    private void Update()
    {
        if (isGrabbed)
        {
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
        }
    }
}
