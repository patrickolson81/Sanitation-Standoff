using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTrack : MonoBehaviour
{
    [Header("People")]
    [SerializeField] private Emotion[] people;

    [Header("Sliders")]
    [SerializeField] private Slider trash;
    [SerializeField] private Slider pressure;

    [Header("Filth needed to beat level")]
    [SerializeField] private int goal;


    private float[] peopleEmotions;
    private float emotionSum;
    private float averageEmotion;
    private TrashTrack track;
    private GameObject trashTrack;

    private int amountOfTrash;




    void Start()
    {
        trashTrack = GameObject.Find("Trash Tracker");
        track = trashTrack.GetComponent<TrashTrack>();
        trash.maxValue = goal;
        peopleEmotions = new float[people.Length];
        pressure.value = 0;
        trash.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        emotionSum = 0;
        amountOfTrash = track.numberOfTaggedObjects; // get amount of trash pieces in scene
        trash.value = amountOfTrash; // set trash value to amount of trash pieces
        for (int i = 0;i < people.Length; i++) // get the emotion values of each player, then assign them to the local variables of people emoitons
        {
            peopleEmotions[i] = people[i].publicEmotion;
            emotionSum += peopleEmotions[i]; // make emotionSum the value of all the emotion values compined
        }
        averageEmotion = emotionSum / people.Length; // get the average value
        pressure.value = averageEmotion; // display the average
    }
}
