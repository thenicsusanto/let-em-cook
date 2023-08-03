using System.Collections;
using System.Collections.Generic;
using Oculus.Platform.Models;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class burgerEnemyAI : MonoBehaviour
{

    public GameObject player;
    /*public Animator anim;*/

    int health = 10;

    // Start is called before the first frame update
    void Start()
    {
        /*anim.SetBool("Coming Closer", true);*/
        player = GameObject.FindGameObjectsWithTag("Player")[0];
        StartCoroutine(MovePosition(10));
    }


    IEnumerator MovePosition(float sec)
    {
        float timer = 0;
        Vector3 oldPos = this.transform.position;
        Vector3 targetPos = player.transform.position;
        while(timer < sec)
        {
            timer += Time.deltaTime;
            Vector3 playerPos = Vector3.Lerp(oldPos, targetPos, timer / sec);

            transform.position = new Vector3(playerPos.x, transform.position.y, playerPos.z);
            yield return null;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            player.GetComponent<Movement>().health -= 10;

        }
        else if(collision.gameObject.CompareTag("ground"))
        {
            EnemyJump();
        }
    }

    private void EnemyJump()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.up * 5, ForceMode.Impulse);
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
