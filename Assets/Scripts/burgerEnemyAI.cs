using System.Collections;
using System.Collections.Generic;
using Oculus.Platform.Models;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class burgerEnemyAI : MonoBehaviour
{

    public GameObject player;
    public Animator anim;

    int health = 10;

    // Start is called before the first frame update
    void Start()
    {
        anim.SetBool("Coming Closer", true);
    }

    // Update is called once per frame
    void Update()
    {
        if(Mathf.Abs(player.transform.position.x - transform.position.x) > 5 &&
            Mathf.Abs(player.transform.position.z - transform.position.z) > 5)
        {
            anim.SetBool("Attacking", true);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, player.transform.position, Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            player.GetComponent<Movement>().health -= 10;

        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("rightHand"))
        {
            health -= 3;
            if (health < 1)
                Destroy(this.gameObject);
        }

    }
}
