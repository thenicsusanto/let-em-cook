using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{

    public int health = 100;
    public bool middle3Fingers;
    public bool indexFinger;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*void OnActivate(InputValue inputValue)
    {
        if(inputValue.isPressed())
        {
            middleThreeFingers = true;
        }
        else
            middle3Fingers = false;
    }

    void OnSelect(InputValue inputvalue)
    {
        if (inputValue.isPressed())
        {
            indexFinger = true;
        }
        else
            indexFinger = false;
    }*/
}
