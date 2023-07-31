using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{

    public GameObject winScreen;
    public GameObject loseScreen;

    // Start is called before the first frame update
    void Start()
    {
        winScreen.SetActive(false);
        loseScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<GameLoop>().won)
        {
            winScreen.SetActive(true);
        }
        else if (GetComponent<GameLoop>().lost)
            loseScreen.SetActive(true);
    }
}
