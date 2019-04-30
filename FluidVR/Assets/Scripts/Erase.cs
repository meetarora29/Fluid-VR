using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Erase : MonoBehaviour
{
    public SteamVR_Behaviour_Pose trackedObj;

    public GameObject eraser;

    private ParticleLauncher particleLauncher;
    
    // Start is called before the first frame update
    void Start()
    {
        eraser.SetActive(false);
        particleLauncher = GetComponent<ParticleLauncher>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SteamVR_Actions._default.Erase.GetState(trackedObj.inputSource))
        {
            eraser.SetActive(true);
            particleLauncher.ChangeState(false);
        }
        else
        {
            eraser.SetActive(false);
            particleLauncher.ChangeState(true);
        }
    }
    
}
