using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Manipulate : MonoBehaviour
{
    public SteamVR_Behaviour_Pose trackedObj;

    public GameObject windsys;

    private ParticleLauncher particleLauncher;
    
    // Start is called before the first frame update
    void Start()
    {
        windsys.SetActive(false);
        particleLauncher = GetComponent<ParticleLauncher>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SteamVR_Actions._default.Manipulate.GetState(trackedObj.inputSource))
        {
            windsys.SetActive(true);
            particleLauncher.ChangeState(false);
        }
        else
        {
            windsys.SetActive(false);
            particleLauncher.ChangeState(true);
        }
    }
}
