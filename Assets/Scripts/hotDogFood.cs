using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hotDogFood : MonoBehaviour
{

    public List<Material> materials;


    public bool underCooked;
    public bool cookedProperly;
    public bool overCooked;

    // Start is called before the first frame update
    void Start()
    {
        underCooked = false;
        cookedProperly = false;
        overCooked = false;

        //this.gameObject.GetComponentInChildren<DogAttack>().enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        //if (GetComponent<HotDogEnemy>().isActiveAndEnabled)
        //{
        //    this.GetComponentInChildren<MeshRenderer>().material = materials[0];
        //    this.gameObject.GetComponentInChildren<DogAttack>().enabled = true;
        //}
        //else
        //{
        //    this.GetComponentInChildren<MeshRenderer>().material = materials[1];
        //    this.gameObject.GetComponentInChildren<DogAttack>().enabled = true;
        //}

        Debug.Log(GetComponent<Rigidbody>().isKinematic + " kinematic");
            
    }

    public void SetRigidbody()
    {
        Debug.Log("Settubg rigidbody");
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Rigidbody>().useGravity = true;
    }
}
