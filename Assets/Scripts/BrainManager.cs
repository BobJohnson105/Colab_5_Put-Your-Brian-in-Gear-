using UnityEngine;

public class BrainManager : MonoBehaviour
{
   public bool leftArmSelected;
   public bool rightArmSelected;
   public bool rightLegSelected;
   public bool speechSelected;

    public LimbPlaneMovement rightArm;
    public LimbPlaneMovement leftArm;


    public void ToggleSelection(string brainPartName)
   {
       
       bool isSelected = false;

       switch (brainPartName)
       {
            case "Left Arm":
            leftArmSelected = !leftArmSelected;
            isSelected = leftArmSelected;
            leftArm.isPossessed = !leftArm.isPossessed;
            break;

            case "Right Arm":
                rightArmSelected = !rightArmSelected;
                isSelected = rightArmSelected;
                rightArm.isPossessed = !rightArm.isPossessed;
                break;

            case "Right Leg":
                rightLegSelected = !rightLegSelected;
                isSelected = rightLegSelected;
                break;

            case "Speech":
                speechSelected = !speechSelected;
                isSelected = speechSelected;
                break;

            default:
                Debug.LogWarning("Umm, What is this section?:" + brainPartName);
                break;
       }
        
        if (isSelected)
        {
            Debug.Log("Ahh that was clicky:" + brainPartName);
        }
        else
        {
            Debug.Log(brainPartName + "Part deselected");

        }

   }
    
    public void ClearSelections()
    {
        leftArmSelected = false;
        rightArmSelected = false;
        rightLegSelected = false;
        speechSelected = false;
    }

}
