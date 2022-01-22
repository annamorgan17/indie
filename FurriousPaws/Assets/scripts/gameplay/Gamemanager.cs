using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gamemanager : MonoBehaviour
{
    private AudioSource music;
    private float currentSkinCount;

    public GameObject pink;
    public GameObject blue;
    public GameObject egypt;
    public GameObject robot;
    public GameObject unicorn;

    public GameObject gameOverScreen;
    public Text finalScore;
    public Text prevScore;

    public GameObject advert;
    public Text advertTimer;
    private float timer = 5;

    private void Start()
    {
        SharedData.PlayerScore = 0;
        SharedData.WasHit = false;
        currentSkinCount = SharedData.CatSkin;
        music = GetComponent<AudioSource>();
        switch(currentSkinCount)
        {
            case 0:
                {
                    pink.SetActive(true);
                    blue.SetActive(false);
                    egypt.SetActive(false);
                    robot.SetActive(false);
                    unicorn.SetActive(false);
                    break;
                }
            case 1:
                {
                    pink.SetActive(false);
                    blue.SetActive(true);
                    egypt.SetActive(false);
                    robot.SetActive(false);
                    unicorn.SetActive(false);
                    break;
                }
            case 2:
                {
                    pink.SetActive(false);
                    blue.SetActive(false);
                    egypt.SetActive(true);
                    robot.SetActive(false);
                    unicorn.SetActive(false);
                    break;
                }
            case 3:
                {
                    pink.SetActive(false);
                    blue.SetActive(false);
                    egypt.SetActive(false);
                    robot.SetActive(true);
                    unicorn.SetActive(false);
                    break;
                }
            case 4:
                {
                    pink.SetActive(false);
                    blue.SetActive(false);
                    egypt.SetActive(false);
                    robot.SetActive(false);
                    unicorn.SetActive(true);
                    break;
                }
        }
        
    }
    private void Update()
    {
        music.volume = SharedData.MusicVol;
        if(SharedData.WasHit == true)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        finalScore.text = SharedData.PlayerScore.ToString();
        prevScore.text = PlayerPrefs.GetFloat("score").ToString();
        gameOverScreen.SetActive(true);
        Advert();
    }

    public void BackToMenu()
    {
        SharedData.SaveData();
        gameOverScreen.SetActive(false);
        SharedData.WasHit = false;
        SharedData.PlayerScore = 0;
        SceneManager.LoadScene(0);
    }

    private void Advert()
    {
        if(advert != null)
        {
            timer -= Time.deltaTime;
            advert.SetActive(true);
            advertTimer.text = ((int)timer).ToString();
            if (timer <= 0)
            {
                timer = 0;
            }
        }
    }

    public void SkipAdvert()
    {
        if(timer <= 0)
        {
            Destroy(advert);
            timer = 5;
        }
    }
}
