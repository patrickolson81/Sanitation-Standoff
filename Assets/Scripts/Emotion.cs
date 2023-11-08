using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Emotion : MonoBehaviour
{
    public float publicEmotion = 0;

    private PeopleStateController psc;

    private TrashTrack track;
    private GameObject trashTrack;

    public TextMeshProUGUI textMeshProUGUI;
    private int amountOfTrash;
    private int number;


    [Header("Thresholds")]
    [SerializeField] private int happyThresh = 5;
    [SerializeField] private int averageThresh = 10;
    [SerializeField] private int distraughtThresh = 15;
    [SerializeField] private int madThresh = 20;

    void Start()
    {
        psc = GetComponent<PeopleStateController>();
        textMeshProUGUI = GetComponentInChildren<TextMeshProUGUI>();
        trashTrack = GameObject.Find("Trash Tracker");
        track = trashTrack.GetComponent<TrashTrack>();
    }

    // Update is called once per frame
    void Update()
    {
        amountOfTrash = track.numberOfTaggedObjects;
        if (amountOfTrash >= happyThresh && amountOfTrash  < averageThresh) // set the corrisponding emotion to the amount of trash needed to set it
        {
            Happy();
            publicEmotion = 1;
        }
        else if (amountOfTrash >= averageThresh && amountOfTrash < distraughtThresh)
        {
            Average();
            publicEmotion = 2;
        }
        else if (amountOfTrash >= distraughtThresh && amountOfTrash < madThresh)
        {
            Distraught();
            publicEmotion = 3;
        }
        else if (amountOfTrash >= madThresh)
        {
            Mad();
            publicEmotion = 4;
        }

        if (psc.ragdoll)
        {
            textMeshProUGUI.gameObject.SetActive(false);
        }

    }
    private void Happy()
    {
        textMeshProUGUI.SetText("<sprite=43>");
    }
    private void Average()
    {
        textMeshProUGUI.SetText("<sprite=49>");

    }
    private void Distraught()
    {
        textMeshProUGUI.SetText("<sprite=64>");

    }
    private void Mad()
    {
        textMeshProUGUI.SetText("<sprite=66>");

    }
}
