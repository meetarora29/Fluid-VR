using System.Collections;
using System.Collections.Generic;
using Leap.Unity.Animation;
using UnityEngine;

public class PlayTweenAnimation : MonoBehaviour
{
    private bool hasPlayed = false;
    private TransformTweenBehaviour tweenBehaviour;

    private void Start()
    {
        tweenBehaviour = GetComponent<TransformTweenBehaviour>();
    }

    public void Play()
    {
        if (hasPlayed)
        {
            tweenBehaviour.PlayBackward();
            hasPlayed = false;
        }
        else
        {
            tweenBehaviour.PlayForward();
            hasPlayed = true;
        }
    }
}
