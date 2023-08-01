using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogAttack : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        transform.eulerAngles = player.transform.position - transform.position;
        GetComponent<Rigidbody>().velocity = (player.transform.position - transform.position) * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(Mathf.Abs(player.transform.position.x - transform.position.x) < 0.5 ||
            Mathf.Abs(player.transform.position.y - transform.position.y) < 0.5)
        {
            player.GetComponent<Movement>().health -= 5;
            Destroy(this.gameObject);
        }

        if (Time.time > 7)
            Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }
}
