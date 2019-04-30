using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ParticleLauncher : MonoBehaviour
{

	public ParticleSystem particles;
	public SteamVR_Behaviour_Pose trackedObj;
	public int numParticles = 1;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Space))
		{
			particles.Emit(1);
		}

		if (SteamVR_Actions._default.Draw.GetState(trackedObj.inputSource))
		{
			particles.Emit(numParticles);
		}
	}
}
