using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deactivate : MonoBehaviour
{
    private float c;
    // Start is called before the first frame update
    void Start()
    {
        c = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (c > 0)
        {
            c = c - Time.deltaTime;
        }
        else
        {
            this.gameObject.SetActive(false);
            c = 2;
        }
    }
}
