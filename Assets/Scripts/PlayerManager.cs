using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //Player manager singleton to store key game variables and information

    public static PlayerManager instance { get; private set; }
    public float speed;

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



}
