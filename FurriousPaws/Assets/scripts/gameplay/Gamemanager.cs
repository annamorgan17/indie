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

    private void Start()
    {
        SharedData.PlayerScore = 0;
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
    }

    public void GameOver()
    {
        finalScore.text = SharedData.PlayerScore.ToString();
        prevScore.text = PlayerPrefs.GetFloat("score").ToString();
        gameOverScreen.SetActive(true);
    }

    public void BackToMenu()
    {
        SharedData.SaveData();
        SharedData.PlayerScore = 0;
        gameOverScreen.SetActive(false);
        SceneManager.LoadScene(0);
    }
}
