using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //Player manager singleton to store key game variables and information

    public static PlayerManager instance { get; private set; }
    public float speed;
    public float yaw;
    public float yaw_speed;

    private void Awake()
    {
        //Check there is only one static reference in the scene
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    private void Update()
    {
        yaw = Mathf.Clamp(yaw,-1,1);
        transform.position += new Vector3(yaw * yaw_speed,0, 0) * Time.deltaTime;
    }



}
