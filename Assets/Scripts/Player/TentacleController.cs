using System.Collections;
using UnityEngine;

public class TentacleController : MonoBehaviour
{



    public int axis;
    public ConstantForce extremityConstForce;
    public Transform tentacleEndTransform;
    public BrainManager brainManager;
    public InputReciever currentInputReciever;
    public int playerNumber;

    private float xValue;
    private float zyValue;
    public float depthChoiceValue;
    public float grabValue;
    public float possessValue;

    public bool isLatched;
    public bool canLatch;

    private void Start()
    {
        
    }

    public void ReadInputValues(float x, float zy, float depth, float grab, float possess)
    {
        xValue = x;
        zyValue = zy;
        depthChoiceValue = depth;
        grabValue = grab;
        possessValue = possess;
    }

    public void TryPossessBrainSection()
    {
        RaycastHit hit;

        if (Physics.Raycast(tentacleEndTransform.position, -transform.up, out hit, 50))
        {
            Debug.Log(hit.collider.gameObject);

           
            if (hit.collider.TryGetComponent(out BrainSection brainSection))
            {
                brainManager.ToggleSelection(brainSection.brainPartName);

                currentInputReciever = brainSection.partReciever;

                isLatched = !isLatched;

                Debug.Log(brainSection.partReciever);
            }
            
            
          
        }
    }

    private void Update()
    {
        if (!isLatched)
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
        else
        {
            currentInputReciever.ReadInputValues(xValue, zyValue, depthChoiceValue, grabValue);
        }
        

        if (possessValue == 1 && canLatch)
        {
            TryPossessBrainSection();

            StartCoroutine(LatchCooldown());
        }
    }

    private IEnumerator LatchCooldown()
    {
        canLatch = false;

        yield return new WaitForSeconds(1);

        canLatch = true;
    }
            
    
}
