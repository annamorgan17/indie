using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class SharedData 
{
    static float vol = PlayerPrefs.GetFloat("music volume");
    static float milk = PlayerPrefs.GetFloat("milk amount");
    static float score = PlayerPrefs.GetFloat("score");
    static float currentSkin = PlayerPrefs.GetFloat("current skin");
    static int[] unlockedSkins = { PlayerPrefs.GetInt("pink"), PlayerPrefs.GetInt("blue"), PlayerPrefs.GetInt("egypt"), PlayerPrefs.GetInt("robot"), PlayerPrefs.GetInt("unicorn") };
    public static float MusicVol { get { return vol; } set { vol = value; } }
    public static float MilkAmount { get { return milk; } set { milk = value; } }
    public static float PlayerScore { get { return score; } set { score = value; } }
    public static float CatSkin { get { return currentSkin; } set { currentSkin = value; } }
    public static int[] UnlockSkin { get { return unlockedSkins; } set { unlockedSkins = value; } }

    public static bool WasHit { get; set; }

    public static bool PowerUp { get; set; }

    public static void SaveData()
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

    public static void ResetData()
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
