using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    [HideInInspector]
    public static int dayCount = 0;

    //1 day = 144 seconds;
    [HideInInspector]
    public static float time = 12 * 6;


    // Update is called once per frame
    void Update()
    {
        //rotate moon/sun
        transform.RotateAround(Vector3.zero, Vector3.right,5.0f * Time.deltaTime);

        //set rotation origin to zero vector
        transform.LookAt(Vector3.zero);

        time += 1 * Time.deltaTime ;

        //if one day passed
        if (time >= 144)
        {
            dayCount++;
            time = 0;
        }
        
    }
}
