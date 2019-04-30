using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityScript.Lang;
using Valve.VR;

public class ParticleLauncher : MonoBehaviour
{

	private ParticleSystem particles;
	public SteamVR_Behaviour_Pose trackedObj;
	public int numParticles = 1;

	private Manager manager;
	private bool isActive = true;
	
	// Use this for initialization
	void Start ()
	{
		manager = GetComponent<Manager>();
		particles = manager.GetCurrentParticleSystem();
	}

	public void UpdateParticleSystem()
	{
		particles = manager.GetCurrentParticleSystem();
	}

	public void ChangeState(bool value)
	{
		isActive = value;
	}
	
	// Update is called once per frame
	void Update () {

		if (isActive)
		{
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
}
