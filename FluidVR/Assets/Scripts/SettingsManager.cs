using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public GameObject brushSettings;
    public GameObject particleSettings;
    public GameObject firebrushSettings;
    public GameObject fireparticleSettings;

    private bool brush = false, particle = false;
    private bool firebrush = false, fireparticle = false;

    private void Start()
    {
        particle = true;
        fireparticle = true;
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
        
        if (name == "Fire Brush")
        {
            fireparticleSettings.SetActive(false);
            fireparticle = false;
            firebrushSettings.SetActive(true);
            firebrush = true;
        }

        if (name == "Fire Particle")
        {
            firebrushSettings.SetActive(false);
            firebrush = false;
            fireparticleSettings.SetActive(true);
            fireparticle = true;
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
        
        if (firebrush)
        {
            ShowSettings("Fire Brush");
        }
        
        if (fireparticle)
        {
            ShowSettings("Fire Particle");
        }
    }
}
