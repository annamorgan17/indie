using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gamemanager : MonoBehaviour //script which manages the main game scene
{
    private AudioSource music; //music audio
    private float currentSkinCount; //a float which indicates which skin is active

    public GameObject pink; //cat skin
    public GameObject blue;//cat skin
    public GameObject egypt;//cat skin
    public GameObject robot;//cat skin
    public GameObject unicorn;//cat skin

    public GameObject gameOverScreen;//object holding the game over screen
    public Text finalScore;//text for the final score
    public Text prevScore;//text for the score of the last game

    public GameObject advert;//object holding the advert screen
    public Text advertTimer;//displays the counter
    private float timer = 5; //counts down before the player can skip advert

    private void Start()
    {
        SharedData.PlayerScore = 0;//set the current score to 0 before the game starts
        SharedData.WasHit = false;//reset whether it was hit before start
        SharedData.PowerUp = false;//set any power up to not in effect before start
        currentSkinCount = SharedData.CatSkin; //set the current cat skin to the saved skin
        music = GetComponent<AudioSource>(); //get the audio source attached 
        switch(currentSkinCount)//switch on the current skin
        {
            case 0: //pink cat skin, set active and set all the rest inactive
                {
                    pink.SetActive(true);
                    blue.SetActive(false);
                    egypt.SetActive(false);
                    robot.SetActive(false);
                    unicorn.SetActive(false);
                    break;
                }
            case 1: //blue cat skin, set active and set all the rest inactive
                {
                    pink.SetActive(false);
                    blue.SetActive(true);
                    egypt.SetActive(false);
                    robot.SetActive(false);
                    unicorn.SetActive(false);
                    break;
                }
            case 2: //egyptian cat skin, set active and set all the rest inactive
                {
                    pink.SetActive(false);
                    blue.SetActive(false);
                    egypt.SetActive(true);
                    robot.SetActive(false);
                    unicorn.SetActive(false);
                    break;
                }
            case 3: //robot cat skin, set active and set all the rest inactive
                {
                    pink.SetActive(false);
                    blue.SetActive(false);
                    egypt.SetActive(false);
                    robot.SetActive(true);
                    unicorn.SetActive(false);
                    break;
                }
            case 4: //unicorn cat skin, set active and set all the rest inactive
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
        music.volume = SharedData.MusicVol; //set the volume to the same volume in the settings
        if(SharedData.WasHit == true) //if it was hit by an object
        {
            GameOver(); //game over function run
        }
    }

    public void GameOver()//game over function which shows the score, sets the game over canvas to active and then runs the advert
    {
        finalScore.text = SharedData.PlayerScore.ToString();
        prevScore.text = PlayerPrefs.GetFloat("score").ToString();
        gameOverScreen.SetActive(true);
        Advert();
    }

    public void BackToMenu()//for the button on gameover screen
    {
        SharedData.SaveData(); //saves data
        gameOverScreen.SetActive(false); //gets rid of game over screen
        SharedData.WasHit = false; //was hit to false
        SharedData.PlayerScore = 0; //reset score
        SceneManager.LoadScene(0); //load the menu
    }

    private void Advert()
    {
        if(advert != null) //if there is an advert
        {
            timer -= Time.deltaTime; //start timer
            advert.SetActive(true); //set the advert screen to active
            advertTimer.text = ((int)timer).ToString(); //show the timer
            if (timer <= 0)//if at 0
            {
                timer = 0;// set to 0 to make sure it doesnt go into negative
            }
        }
    }

    public void SkipAdvert()
    {
        if(timer <= 0) //if timer at 0
        {
            Destroy(advert); //destory the game object
            timer = 5; //reset timer
        }
    }
}
