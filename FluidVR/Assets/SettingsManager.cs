using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public GameObject brushSettings;
    public GameObject particleSettings;

    private bool brush = false, particle = false;

    private void Start()
    {
        particle = true;
    }

    public void ShowSettings(String name)
    {
        if (name == "Brush")
        {
            particleSettings.SetActive(false);
            particle = false;
            brushSettings.SetActive(true);
            brush = true;
        }

        if (name == "Particle")
        {
            brushSettings.SetActive(false);
            brush = false;
            particleSettings.SetActive(true);
            particle = true;
        }
    }

    public void ShowCurrent()
    {
        if (brush)
        {
            ShowSettings("Brush");
        }
        
        if (particle)
        {
            ShowSettings("Particle");
        }
    }
}
