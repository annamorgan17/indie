using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    private AudioSource music;
    private void Start()
    {
        music = GetComponent<AudioSource>();
    }
    private void Update()
    {
        music.volume = SharedData.MusicVol;
    }
}
