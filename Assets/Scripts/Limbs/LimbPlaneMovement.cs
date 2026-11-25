using UnityEngine;
using UnityEngine.InputSystem;


public class LimbPlaneMovement : MonoBehaviour
{
    public bool isPossessed;




    public int axis;
    public ConstantForce extremityConstForce;
    public GrabController grabController;

    private float xValue;
    private float zyValue;
    public float depthChoiceValue;
    public float grabValue;

    private void Start()
    {
        
    }

    public void ReadInputValues(float x, float zy, float depth, float grab)
    {
        xValue = x * 20;
        zyValue = zy * 20;
        depthChoiceValue = depth;
        grabValue = grab;
    }

    private void Update()
    {
        if (isPossessed)
        {
            if (depthChoiceValue == 1)
            {
                extremityConstForce.force = new Vector3(xValue, 0, zyValue);
            }
            else
            {
                extremityConstForce.force = new Vector3(xValue, zyValue, 0);
            }

            if (grabController != null)
            {
                grabController.GetGrabInput(grabValue);
            }
        }
            
    }
}
