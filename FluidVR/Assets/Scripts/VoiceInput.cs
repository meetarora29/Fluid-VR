using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class VoiceInput : MonoBehaviour
{
    private AudioSource _audio;

    public float loudness = 0;
    public float sensitivity=100;
    public SteamVR_Behaviour_Pose trackedObj;
    public GameObject obj;

    public GameObject head;
    // Start is called before the first frame update
    void Start()
    {
        _audio = GetComponent<AudioSource>();
        _audio.clip = Microphone.Start(null,true,1,44100);
        _audio.loop = true;
        _audio.mute = true;
        while (!(Microphone.GetPosition(null) > 0))
        {
            _audio.Play();
            print("play hua");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SteamVR_Actions._default.Mute.GetState(trackedObj.inputSource))
        {
            _audio.mute = false;
        }
        else
        {
            _audio.mute = true;

        }
        loudness = GetAveragedVolume() * sensitivity;
//        print(loudness);
        if (loudness > 0.5f)
        {
            print("Loud hai");
            obj.SetActive(true);
            obj.transform.position = head.transform.position-new Vector3(0,0.05f,0);

            obj.transform.rotation = head.transform.rotation;
            obj.GetComponent<Rigidbody>().velocity=head.transform.forward;
            
        }
    }
    

    float GetAveragedVolume()
    {
        print("kuch toh hua");
        float[] data = new float[256];
        float a = 0;
        _audio.GetOutputData(data, 0);
        foreach (var s in data)
        {
            a += Mathf.Abs(s);
        }
        return a / 256f ;
    }
}
