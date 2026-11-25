using UnityEngine;

public class TentacleController : MonoBehaviour
{



    public int axis;
    public ConstantForce extremityConstForce;
    public Transform tentacleEndTransform;
    public BrainManager brainManager;

    private float xValue;
    private float zyValue;
    public float depthChoiceValue;
    public float grabValue;
    public float possessValue;

    private void Start()
    {
        
    }

    public void ReadInputValues(float x, float zy, float depth, float grab, float possess)
    {
        xValue = x * 20;
        zyValue = zy * 20;
        depthChoiceValue = depth;
        grabValue = grab;
        possessValue = possess;
    }

    public void TryPossessBrainSection()
    {
        RaycastHit hit;

        if (Physics.Raycast(tentacleEndTransform.position, -transform.up, out hit, 50))
        {
            if (hit.collider.TryGetComponent(out BrainSection brainSection))
            {
                brainManager.ToggleSelection(brainSection.brainPartName);
            }
        }
    }

    private void Update()
    {
        if (depthChoiceValue == 1)
        {
            extremityConstForce.force = new Vector3(xValue, 0, zyValue);
        }
        else
        {
            extremityConstForce.force = new Vector3(xValue, zyValue, 0);
        }
    }
            
    
}
