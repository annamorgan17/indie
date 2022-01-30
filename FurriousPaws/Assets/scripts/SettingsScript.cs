using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour //handles the audio chnages made in setting, as its currently the only setting
{
    private Slider slider;//get the slider in th ui
    private void Start()
    {
        slider = transform.GetChild(7).GetComponent<Slider>(); //connect it to the slider
        slider.value = SharedData.MusicVol; //set the slider to the current saved volume
    }
    public void MusicVolume() //on the use of slider
    {
        if (slider != null) //if there is a slider
        {
            SharedData.MusicVol = slider.value; //set the saved volume to the slider value
            SharedData.SaveData(); //save the game
        }
    }
}
