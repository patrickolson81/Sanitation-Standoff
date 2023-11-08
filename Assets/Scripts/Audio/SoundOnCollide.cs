using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOnCollide : MonoBehaviour
{
    public AudioSource[] soundsToPlay;

    private void OnCollisionEnter(Collision collision)
    {
        int length = soundsToPlay.Length;
        if (!collision.gameObject.CompareTag("Player"))
        {
            int random = Random.Range(0, length);
            soundsToPlay[random].Play();
        }
    }
}
