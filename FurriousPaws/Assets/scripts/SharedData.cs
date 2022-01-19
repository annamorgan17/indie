using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class SharedData 
{
    static float vol = 1;
    static float milk = 0;
    static float score = 0;
    static float currentSkin = 0;
    static int[] unlockedSkins = {1,0,0,0,0 };
    public static float MusicVol { get { return vol; } set { vol = value; } }
    public static float MilkAmount { get { return milk; } set { milk = value; } }
    public static float PlayerScore { get { return score; } set { score = value; } }
    public static float CatSkin { get { return currentSkin; } set { currentSkin = value; } }
    public static int[] UnlockSkin { get { return unlockedSkins; } set { unlockedSkins = value; } }
}
