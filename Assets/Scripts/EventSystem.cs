using System.Collections;
using UnityEngine;

public class EventSystem : MonoBehaviour {
    [Header("Chunks")]
    [SerializeField] private ChunkSet[] baseSetArray;
    [SerializeField] private ChunkSet[] eventSetArray;
    private ChunkSet selectedSet;
    private float[] baseSetWeights;
    private float[] eventSetWeights;
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
    private int chunkIndex;
    private int chunkSetLength;

    void Start() {
        StartCoroutine(EventDelayTimer(startDelay));
        baseSetWeights = new float[baseSetArray.Length];
        eventSetWeights = new float[eventSetArray.Length];
        for(int X = 0; X < baseSetArray.Length; X++) {
            baseSetWeights[X] = baseSetArray[X].chunkSetProbability;
        }
        for(int X = 0; X < eventSetWeights.Length; X++) {
            eventSetWeights[X] = eventSetArray[X].chunkSetProbability;
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
        int SelectedChunk;
        if(selectedSet != null && chunkIndex < chunkSetLength - 1) {
            chunkIndex++;
            if(debugToggle) {
                Debug.Log("Spawning Chunk from set: "+selectedSet.chunks[chunkIndex].chunkName);
            }
            return selectedSet.chunks[chunkIndex].chunk;
        } else if(toggleEvents && !eventActive) { //Check if next chunk will be event.
            eventProbabilty = Mathf.Lerp(baseEventProbabilty, 1.0f, waitTime);
            if(Random.value < eventProbabilty) {
                eventProbabilty = 0.0f;
                toggleEvents = false;
                //eventActive = true;
                EventDelayTimer(eventDelay);
                SelectedChunk = GetRandonChunk(eventSetWeights);
                selectedSet = eventSetArray[SelectedChunk];
                chunkIndex = 0;
                chunkSetLength = selectedSet.chunks.Length;
                if(debugToggle) {
                    Debug.Log("New Chunk Set: "+selectedSet.chunkSetName);
                    Debug.Log("Spawning Chunk from set: "+selectedSet.chunks[0].chunkName);
                }
                return selectedSet.chunks[chunkIndex].chunk; //EVENT chunk
            } else {
                SelectedChunk = GetRandonChunk(baseSetWeights);
                selectedSet = baseSetArray[SelectedChunk];
                chunkIndex = 0;
                chunkSetLength = selectedSet.chunks.Length;
                if(debugToggle) {
                    Debug.Log("New Chunk Set: "+selectedSet.chunkSetName);
                    Debug.Log("Spawning Chunk from set: "+selectedSet.chunks[0].chunkName);
                }
                return selectedSet.chunks[chunkIndex].chunk; //BASE chunk
            }
        } else {
            SelectedChunk = GetRandonChunk(baseSetWeights);
            selectedSet = baseSetArray[SelectedChunk];
            chunkIndex = 0;
            chunkSetLength = selectedSet.chunks.Length;
            if(debugToggle) {
                Debug.Log("New Chunk Set: "+selectedSet.chunkSetName);
                Debug.Log("Spawning Chunk from set: "+selectedSet.chunks[0].chunkName);
            }
            return selectedSet.chunks[chunkIndex].chunk; //BASE chunk
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
