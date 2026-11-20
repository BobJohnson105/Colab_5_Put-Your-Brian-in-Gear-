using UnityEngine;

public class SusMeter : MonoBehaviour
{
    private float suspicion;
    [SerializeField] private float decayTimer;
    private bool timerToggle;
    private bool decayToggle;
    private float value;
    void Start()
    {
        //Start stuff here.
    }
    void Update()
    {
        //Update and Update and Update and Update and Update and Update and Update and Update and Update and Update and Update and Update and...
        if (decayToggle) {
            DecaySuspicion();
        }
    }

    private void LateUpdate()
    {
        //Late Update and Late Update and Late Update and Late Update and Late Update and Late Update and Late Update and Late Update and Late Update and Late Update and...
        if (timerToggle) {
            Timer();
        }
    }

    public void IncreaseSuspicion(float amount, float duration = 0.0f) {
        //Sus go up.
        timerToggle = false;
        decayToggle = false;
        value = decayTimer;
        if (duration! > 0.0f)
        {
            suspicion = Mathf.Clamp(value += amount, 0.0f, 100.0f);
        }
        else { 
            //Increase over time
        }
    }

    public void DecreaseSuspicion(float amount, float duration = 0.0f) {
        //Sus go down.
        if (duration! > 0.0f)
        {
            suspicion = Mathf.Clamp(value -= amount, 0.0f, 100.0f);
        }
        else
        {
            //Decrease over time
        }
    }

    private void DecaySuspicion() {
        //Sus go down, but over time.
        if (suspicion > 0.0f) {
            DecreaseSuspicion(Time.deltaTime);
        }
    }

    private void Timer() {
        //Timer
        if (value > 0.1f)
        {
            value -= Time.deltaTime;
        }
        else {
            timerToggle = false;
            decayToggle = true;
        }
    }

    public float GetSuspicion() {
        return suspicion;
    }
}
