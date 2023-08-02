using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class HandVelocity : MonoBehaviour
{
    [SerializeField] private InputActionReference rightVelocity;
    [SerializeField] Renderer handRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //This is just an example of how to get the velocity of the hand
        // float R_ratio = Mathf.Min(rightVelocity.action.ReadValue<Vector3>().magnitude, 1f);
        // handRenderer.material.color = new Color(1f, 1f - R_ratio, 1f - R_ratio);
    }
}
