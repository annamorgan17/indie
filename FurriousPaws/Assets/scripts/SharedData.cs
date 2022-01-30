using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class SharedData //static class which handles data between scenes as well as savinf data
{
    static float vol = PlayerPrefs.GetFloat("music volume"); //value for the saved music volume
    static float milk = PlayerPrefs.GetFloat("milk amount"); //value for the saved milk amount
    static float score = PlayerPrefs.GetFloat("score");//value for the saved score
    static float currentSkin = PlayerPrefs.GetFloat("current skin"); //value for the player skin
    //array holding all the saved unlocked skins
    static int[] unlockedSkins = { PlayerPrefs.GetInt("pink"), PlayerPrefs.GetInt("blue"), PlayerPrefs.GetInt("egypt"), PlayerPrefs.GetInt("robot"), PlayerPrefs.GetInt("unicorn") };
    public static float MusicVol { get { return vol; } set { vol = value; } } //getter and setter for volume
    public static float MilkAmount { get { return milk; } set { milk = value; } } //getter and setter for milk
    public static float PlayerScore { get { return score; } set { score = value; } }//getter and setter for score
    public static float CatSkin { get { return currentSkin; } set { currentSkin = value; } }//getter and setter for players skin
    public static int[] UnlockSkin { get { return unlockedSkins; } set { unlockedSkins = value; } }//getter and setter for the array of unlocked skins

    public static bool WasHit { get; set; }//getter and setter for if the player was hit

    public static bool PowerUp { get; set; } //getter and setter for if the player has a power up in effect

    public static void SaveData() //saves all the variables made above 
    {
        PlayerPrefs.SetFloat("music volume", vol);
        PlayerPrefs.SetFloat("milk amount", milk);
        PlayerPrefs.SetFloat("score", score);
        PlayerPrefs.SetFloat("current skin", currentSkin);
        PlayerPrefs.SetInt("pink", unlockedSkins[0]);
        PlayerPrefs.SetInt("blue", unlockedSkins[1]);
        PlayerPrefs.SetInt("egypt", unlockedSkins[2]);
        PlayerPrefs.SetInt("robot", unlockedSkins[3]);
        PlayerPrefs.SetInt("unicorn", unlockedSkins[4]);
        PlayerPrefs.Save();
    }

    public static void ResetData() //returns all saved data back to default settings
    {
        PlayerPrefs.DeleteAll();
        vol = 1;
        milk = 0;
        score = 0;
        currentSkin = 0;
        unlockedSkins[0] = 1;
        unlockedSkins[1] = 0;
        unlockedSkins[2] = 0;
        unlockedSkins[3] = 0;
        unlockedSkins[4] = 0;
    }

}
