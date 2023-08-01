using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotDogEnemy : MonoBehaviour
{
    public GameObject attackDog;
    public GameObject player;

    bool toFire;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(shootHotDog());
    }

    // Update is called once per frame
    void Update()
    {
        if(toFire)
        {
            toFire = false;
            Instantiate(attackDog, transform.position, Quaternion.identity);
        }
    }

    IEnumerator shootHotDog()
    {
        yield return new WaitForSeconds(3);
        toFire = true;
    }
}
