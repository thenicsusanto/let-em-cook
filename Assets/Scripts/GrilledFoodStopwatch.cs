using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrilledFoodStopwatch : MonoBehaviour
{
    public bool stopwatchActive;
    float currentTime;
    [SerializeField] private float timeToOvercooked;

    [SerializeField] private Material preGrilledMat, grilledMat, overcookedMat;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (stopwatchActive == true && currentTime < timeToOvercooked)
        {
            currentTime += Time.deltaTime;
            CheckFoodState();
        }
    }

    void CheckFoodState()
    {
        if (currentTime > timeToOvercooked * 0.30f && currentTime < timeToOvercooked * 0.5f)
        {
            GetComponentInChildren<Renderer>().material = preGrilledMat;
        }
        else if (currentTime >= timeToOvercooked * 0.5f && currentTime < timeToOvercooked * 0.85)
        {
            GetComponentInChildren<Renderer>().material = grilledMat;
        }
        else if (currentTime >= timeToOvercooked * 0.9f)
        {
            GetComponentInChildren<Renderer>().material = overcookedMat;
        }
    }
}
