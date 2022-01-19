using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour
{
    private Slider slider;
    private void Start()
    {
        slider = transform.GetChild(7).GetComponent<Slider>();
        slider.value = SharedData.MusicVol;
    }
    public void MusicVolume()
    {
        if (slider != null)
        {
            SharedData.MusicVol = slider.value;
        }
    }
}
