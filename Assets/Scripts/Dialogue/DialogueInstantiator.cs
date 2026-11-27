using System;
using UnityEngine;

public class DialogueInstantiator : MonoBehaviour
{
    public GameObject dialogueOptionPrefab;

    [Header("Spawn Area (relative to this object)")]
    public Vector3 spawnCenter = Vector3.zero;
    public Vector3 spawnSize = new Vector3(4f, 2f, 0f); 

    private WordData[] policeWordData;
    private WordData[] hitchhikerWordData;

    public EventsManager eventsManager;

    void Start()
    {
        policeWordData = Resources.LoadAll<WordData>("PoliceOptions");
        hitchhikerWordData = Resources.LoadAll<WordData>("HitchikerOptions");

        if (eventsManager == null)
            eventsManager = FindFirstObjectByType<EventsManager>();

        SpawnAllOptions();
    }

    public void SpawnAllOptions()
    {
        

        WordData[] dataToSpawn = null;


        Debug.Log("Spawn Options");

        if (eventsManager.currentEvent == EventsManager.EventType.Police)
            dataToSpawn = policeWordData;
        else if (eventsManager.currentEvent == EventsManager.EventType.Hitchhiker)
            dataToSpawn = hitchhikerWordData;


        if (dataToSpawn == null) return;


        int index = 0;
        foreach (WordData data in dataToSpawn)
        {
            Debug.Log($"Spawning {index + 1}/{dataToSpawn.Length}: {data.name}");
            InstantiateDialogueOption(data);
            index++;
        }
    }

    public void InstantiateDialogueOption(WordData data)
    {
        Debug.Log("Instantiate");
        
        GameObject newOption = Instantiate(dialogueOptionPrefab,GetRandomWorldPosition(),transform.rotation,transform);

        DialogueOptionScript optionScript = newOption.GetComponent<DialogueOptionScript>();
        if (optionScript != null)
        {
            optionScript.wordDataRef = data;
            optionScript.UpdateDialogueOption();
        }
    }

    private Vector3 GetRandomWorldPosition()
    {
        Vector3 half = spawnSize * 0.5f;

        Vector3 localPoint = spawnCenter + new Vector3(
            UnityEngine.Random.Range(-half.x, half.x),
            UnityEngine.Random.Range(-half.y, half.y),
            UnityEngine.Random.Range(-half.z, half.z)
        );

        //Converts to world space
        return transform.TransformPoint(localPoint);
    }

    //Spawn Box debug visuals
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.matrix = transform.localToWorldMatrix;
        Gizmos.DrawWireCube(spawnCenter, spawnSize);
    }
}