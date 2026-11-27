using UnityEngine;
using UnityEngine.InputSystem;


public class LimbPlaneMovement : InputReceiver
{
    public bool isPossessed;





    public ConstantForce extremityConstForce;
    public GrabController grabController;

    public PlayerController player1;
    public PlayerController player2;

    

    private void Update()
    {
        if (!isPossessed)


        if (depthChoiceValue == 1)
        {
            // original XY 
            extremityConstForce.force = new Vector3(xValue, 0, zyValue);
        }
        else
        {
            // original XZ 
            extremityConstForce.force = new Vector3(xValue, zyValue, 0);
        }
        if(grabController != null)
        {
            grabController.GetGrabInput(grabValue);
        }
    }
}
