using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    [SerializeField] private List<Transform> points = new List<Transform>();
    [SerializeField] private float objectSpeed;
    [SerializeField] private GameObject checkPointsHolder;

    int nextPointIndex;
    Transform nextPoint;

    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i<checkPointsHolder.transform.childCount; i++)
        {
            points.Add(checkPointsHolder.transform.GetChild(i));
        }
        nextPoint = points[0];  
    }

    // Update is called once per frame
    void Update()
    {
        MoveCustomer();
    }

    void MoveCustomer()
    {
        if(transform.position == nextPoint.position)
        {
            nextPointIndex++;
            if(nextPointIndex >= points.Count)
            {
                Debug.Log("Reached ending point");
                transform.LookAt(new Vector3(0, 0.75f, 0.25f), Vector3.up);
                return;
            }
            nextPoint = points[nextPointIndex];
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, nextPoint.position, objectSpeed * Time.deltaTime);
            transform.LookAt(nextPoint.position, Vector3.up);
        }
    }
}