using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    private AudioSource music;
    private void Start()
    {
        music = GetComponent<AudioSource>();

        if(SharedData.UnlockSkin[0] == 0)
        {
            SharedData.ResetData();
        }
    }
    private void Update()
    {
        music.volume = SharedData.MusicVol;
    }
    public void PlayButton()
    {
        SceneManager.LoadScene(3);
    }

    public void StoreButton()
    {
        SceneManager.LoadScene(1);
    }

    public void BackButton()
    {
        SceneManager.LoadScene(0);
    }

    public void SettingsButton()
    {
        SceneManager.LoadScene(2);
    }

    
}
