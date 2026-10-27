using UnityEngine;

public class BrainSection : MonoBehaviour
{
    public string brainPartName;

    public float moveUpAmount = 0.2f;
    public float moveSpeed = 8f;

    private Vector3 startingPos;
    private bool isHovered;
    private bool isSelected;

    private BrainManager brainManager;

    private void Start()
    {
        startingPos = transform.localPosition;

        // tell the manager when we click sorry for find object by type lmao
        brainManager = FindFirstObjectByType<BrainManager>();
    }

    private void Update()
    {
        Vector3 targetPos = startingPos;

        if (isHovered || isSelected)
        {
            targetPos += Vector3.up * moveUpAmount;
        }

        transform.localPosition = Vector3.Lerp( transform.localPosition, targetPos, Time.deltaTime * moveSpeed);
    
    }

    private void OnMouseEnter()
    {
        isHovered = true;
    }

    private void OnMouseExit()
    {
        isHovered = false;
    }

    private void OnMouseDown()
    {
        if (brainManager != null)
        {
            brainManager.ToggleSelection(brainPartName);

            isSelected = GetSelectionState();
        }
    }

    private bool GetSelectionState()
    {
        switch (brainPartName)
        {
            case "Left Arm":
                return brainManager.leftArmSelected;
            
            case "Right Arm":
                return brainManager.rightArmSelected;

            case "Right Leg":
                return brainManager.rightLegSelected;

            case "Speech":
                return brainManager.speechSelected;

            default:
                return false;
        }
    }
}
