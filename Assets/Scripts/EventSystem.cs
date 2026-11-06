using System.Collections;
using UnityEngine;

public class EventSystem : MonoBehaviour {
    [Header("Chunks")]
    [SerializeField] private ChunkData[] baseChunkArray;
    [SerializeField] private ChunkData[] eventChunkArray;
    private float[] baseChunkWeights;
    private float[] eventChunkWeights;
    [Header("Timers & Delays")]
    [SerializeField] private float startDelay;
    [SerializeField] private float eventDelay;
    [Header("Probability")]
    [SerializeField] private float baseEventProbabilty;
    [SerializeField] private float maxEventWaitTime;
    [Header("Debug")]
    [SerializeField] private bool debugToggle;
    [SerializeField] private bool debugEventsToggle;
    [Header("Other Variables")]
    private float eventProbabilty;
    private float eventWaitTime;
    private float waitTime;
    private bool toggleEvents;
    private bool eventActive;

    void Start() {
        StartCoroutine(EventDelayTimer(startDelay));
        baseChunkWeights = new float[baseChunkArray.Length];
        eventChunkWeights = new float[eventChunkArray.Length];
        for(int X = 0; X < baseChunkWeights.Length; X++) {
            baseChunkWeights[X] = baseChunkArray[X].ChunkProbabilty;
        }
        for(int X = 0; X < eventChunkWeights.Length; X++) {
            eventChunkWeights[X] = eventChunkArray[X].ChunkProbabilty;
        }
    }

    void Update() {
        if(toggleEvents && !eventActive) {
            EventTimer();
        }
        if(debugToggle) {
            LogDebug();
        }
    }

    public GameObject GetNextChunk() {
        int SelectedChunk = 0;
        if(toggleEvents && !eventActive) { //Check if next chunk will be event.
            eventProbabilty = Mathf.Lerp(baseEventProbabilty, 1.0f, waitTime);
            if(Random.value < eventProbabilty) {
                eventProbabilty = 0.0f;
                toggleEvents = false;
                //eventActive = true;
                EventDelayTimer(eventDelay);
                SelectedChunk = GetRandonChunk(eventChunkWeights);
                if(debugToggle) {
                    Debug.Log("Spawning Chunk: "+eventChunkArray[SelectedChunk].ChunkName);
                }
                return eventChunkArray[SelectedChunk].Chunk; //EVENT chunk
            } else {
                SelectedChunk = GetRandonChunk(baseChunkWeights);
                if(debugToggle) {
                    Debug.Log("Spawning Chunk: "+baseChunkArray[SelectedChunk].ChunkName);
                }
                return baseChunkArray[SelectedChunk].Chunk; //BASE chunk
            }
        } else {
            SelectedChunk = GetRandonChunk(baseChunkWeights);
            if(debugToggle) {
                Debug.Log("Spawning Chunk: "+baseChunkArray[SelectedChunk].ChunkName);
            }
            return baseChunkArray[SelectedChunk].Chunk; //BASE chunk
        }
    }

    private IEnumerator EventDelayTimer(float delayTime) {
        yield return new WaitForSeconds(delayTime);
        eventWaitTime = 0.0f;
        toggleEvents = true;
    }

    private int GetRandonChunk(float[] weights) { //Picks a random chunk, based on each chunks provided probabilty. Can be adjusted in the future, to use Chunk Arrays in Chunk Data, and work through them if we wanted biomes, multichunk events etc.
        float totalWeight = 0.0f;
        for(int X = 0; X < weights.Length; X++) {
            totalWeight += weights[X];
        }
        if(totalWeight == 0.0f) {
            Debug.LogError("No Weights Added");
        }
        float randomNum = Random.Range(0.0f, totalWeight);
        for(int X = 0; X < weights.Length; X++) {
            randomNum -= weights[X];
            if(randomNum <= 0.0f) {
                return X;
            }
        }
        Debug.LogWarning("Failed to select a Random Chunk, returning 0");
        return 0;
    }

    private void EventTimer() {
        eventWaitTime += Time.deltaTime;
        waitTime = Mathf.Clamp01(eventWaitTime / maxEventWaitTime);
    }
    
    public void EventOver() { //Currently not used. Call once event is complete, to allow for spawning more events.
        eventActive = false;
        EventDelayTimer(eventDelay);
    }

    private void LogDebug() {
        if(debugEventsToggle) {
            if(toggleEvents) {
                Debug.Log("Toggle Events: "+toggleEvents);
                Debug.Log("Event Probabilty: "+eventProbabilty);
            } else {
                Debug.Log("Toggle Events: "+toggleEvents);
                //Debug.Log("Event Status: "+eventActive);
            }
        }
    }
}
