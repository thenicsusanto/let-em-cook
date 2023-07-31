using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{

    public int health = 100;
    public bool middleThreeFingers;
    public bool indexFinger;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTrigHold(InputValue inputValue)
    {
        Debug.Log("middleFiner");
        middleThreeFingers = true;
    }

    void OnGripHold(InputValue inputValue)
    {
        Debug.LogError("indexFinger");
        indexFinger = true;
    }

    void OnRestart() { SceneManager.LoadScene(SceneManager.GetActiveScene().name); }
}
