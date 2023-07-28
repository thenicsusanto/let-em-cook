using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuManager : MonoBehaviour
{
    public GameObject menu;
    public InputActionProperty playButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playButton.action.WasPressedThisFrame())
        {
            Debug.Log("Play Button Clicked");
        }
    }
}
