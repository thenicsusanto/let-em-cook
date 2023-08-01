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
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<HotDogEnemy>().isActiveAndEnabled)
        {
            this.GetComponent<MeshRenderer>().material = materials[0];
        }
        else
        {
            this.GetComponent<MeshRenderer>().material = materials[1];
        }
            
    }
}
