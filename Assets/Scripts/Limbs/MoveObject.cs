using UnityEngine;

public class MoveObject : GrabObject
{
    // This is an object that can be grabbed and moved around, not attached to anything, like a liscense

    public void Grabbed(Transform newParent)
    {
        transform.SetParent(newParent);
        transform.localPosition = Vector3.zero;
    }

    public void UnGrabbed()
    {
        transform.SetParent(null);
    }
}
