using UnityEngine;

public class InputReciever : MonoBehaviour
{
    public float xValue;
    public float zyValue;
    public float depthChoiceValue;
    public float grabValue;

    public virtual void ReadInputValues(float x, float zy, float depth, float grab)
    {
        // xValue = x * 20;
        // zyValue = zy * 20;
        // depthChoiceValue = depth;
        // grabValue = grab;

        xValue = x * 20;
        zyValue = zy * 20;
        depthChoiceValue = depth;
        grabValue = grab;
    }
}
