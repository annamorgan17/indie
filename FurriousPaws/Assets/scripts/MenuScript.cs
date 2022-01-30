using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour //handles all the buttons and music for the main menu
{
    private AudioSource music; //music source
    private void Start()
    {
        music = GetComponent<AudioSource>(); //connect attached audio source

        if(SharedData.UnlockSkin[0] == 0) //if there is no skin reset
        {
            SharedData.ResetData();
        }
    }
    private void Update()
    {
        music.volume = SharedData.MusicVol; //set the current volume to the saved volume
    }
    public void PlayButton() //loads game scene
    {
        SceneManager.LoadScene(3);
    }

    public void StoreButton() //loads store scene
    {
        SceneManager.LoadScene(1);
    }

    public void BackButton() //loads menu scene
    {
        SceneManager.LoadScene(0);
    }

    public void SettingsButton() //loads setting scene
    {
        SceneManager.LoadScene(2);
    }

    
}
