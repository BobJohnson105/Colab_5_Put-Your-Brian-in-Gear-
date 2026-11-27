using System;
using TMPro;
using UnityEngine;

public class DialogueInstantiator : MonoBehaviour
{
    public GameObject dialogueOptionPrefab;
    private WordData[] policeWordData;
    private WordData[] hitchhikerWordData;

    private EventsManager eventsManager;

    void Start()
    {
        policeWordData = Resources.LoadAll<WordData>("PoliceOptions");
        policeWordData = Resources.LoadAll<WordData>("HitchikerOptions");

        eventsManager = GetComponent<EventsManager>();
        InstantiateCard();
    }


    public void InstantiateCard()
    {


        GameObject newOption = Instantiate(dialogueOptionPrefab, transform, false);

        WordData randomData;
        
        if(eventsManager.currentEvent == EventsManager.EventType.Police && policeWordData.Length > 0)
        {
            randomData = policeWordData[UnityEngine.Random.Range(0, policeWordData.Length)];

            newOption.GetComponent<DialogueOptionScript>().wordDataRef = randomData;
            newOption.GetComponent<DialogueOptionScript>().UpdateDialogueOption();
        }

       

    }
}
