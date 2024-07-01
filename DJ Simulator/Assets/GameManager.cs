using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float globalBPM; //defines the bpm that is used for sensing calculations (master bpm)
    public float globalBPM_TimeTick;  //stores the result of actual time duration of events based on master bpm

    // Start is called before the first frame update
    void Start()
    {
        globalBPM = 128;
    }

    // Update is called once per frame
    void Update()
    {
        calcTimeTick();
        //Debug.Log(globalBPM_TimeTick);
    }

    void calcTimeTick()
    {
        globalBPM_TimeTick = (globalBPM/60);
    }
}
