using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class GrabController : MonoBehaviour
{
    public InputAction grabInput;

    public Transform handPos;

    public LimbPlaneMovement limbMover;

    private float grabValue;

    private void OnEnable()
    {
        grabInput.Enable();
    }

    private void OnDisable()
    {
        grabInput.Disable();
    }

    private void Update()
    {
        grabValue = grabInput.ReadValue<float>();

        if (grabValue != 0)
        {
            TryGrab();
        }
    }

    private void TryGrab()
    {
        Collider[] grabCheck = Physics.OverlapSphere(handPos.position, 1.5f); // Check for grabbable objects around the hand

       

        //RaycastHit[] grabCheck = Physics.SphereCastAll(handPos.position, 1, handPos.forward, 5);

        Debug.Log("TryGrab");

        foreach (Collider col in grabCheck)
        {
            if (col.GetComponent<MoveObject>()) // Can the object be grabbed
            {
              
                col.GetComponent<MoveObject>().Grabbed(handPos);   

            }
            else if (col.GetComponent<GrabObject>())
            {
                Vector3 closestPoint = col.ClosestPoint(handPos.position);

                StartCoroutine(MoveTowardsObject(closestPoint));

                Debug.Log(closestPoint);

                Debug.Log("GrabObject");
            }
        }
    }

    private IEnumerator MoveTowardsObject(Vector3 objectPos)
    {
        while (Vector3.Distance(handPos.position, objectPos) > 0.2f)
        {
            limbMover.extremityConstForce.force = (objectPos - handPos.position) * 25 * Time.fixedDeltaTime;

            yield return new WaitForSeconds(0.1f *  Time.deltaTime);
        }
        
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(handPos.position, 1.5f);

    }
}
