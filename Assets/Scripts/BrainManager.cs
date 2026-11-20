using System;
using UnityEngine;

public class BrainManager : MonoBehaviour
{
    public bool leftArmSelected;
    public bool rightArmSelected;
    public bool rightLegSelected;
    public bool speechSelected;

    public LimbPlaneMovement leftArm;
    public LimbPlaneMovement rightArm;
    public LimbPlaneMovement leftLeg;
    public LimbPlaneMovement rightLeg;

    [SerializeField] private int limbsSelected;



    public void ToggleSelection(string brainPartName)
    {
        if (limbsSelected < 2)
        {
            bool isSelected = false;

            switch (brainPartName)
            {
                case "Left Arm":
                    leftArmSelected = !leftArmSelected;
                    isSelected = leftArmSelected;

                    leftArm.isPossessed = true;

                    break;

                case "Right Arm":
                    rightArmSelected = !rightArmSelected;
                    isSelected = rightArmSelected;

                    rightArm.isPossessed = true;

                    break;

                case "Right Leg":
                    rightLegSelected = !rightLegSelected;
                    isSelected = rightLegSelected;

                    rightLeg.isPossessed = true;
                    break;

                case "Speech":
                    speechSelected = !speechSelected;
                    isSelected = speechSelected;

                    leftLeg.isPossessed = true;

                    break;

                default:
                    Debug.LogWarning("Umm, What is this section?:" + brainPartName);
                    break;
            }
                
            if (isSelected)
            {
                Debug.Log("Ahh that was clicky: " + brainPartName);

                limbsSelected += 1;
            }
            else
            {
                Debug.Log(brainPartName + "Part deselected");

                limbsSelected -= 1;
            }
        }
        

    }
    
    public void ClearSelections()
    {
        leftArmSelected = false;
        rightArmSelected = false;
        rightLegSelected = false;
        speechSelected = false;

        leftArm.isPossessed = false;
        rightArm.isPossessed = false;
        rightLeg.isPossessed = false;
        leftLeg.isPossessed = false;
    }

}
