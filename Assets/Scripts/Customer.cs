using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    [SerializeField] private List<Transform> points = new List<Transform>();
    [SerializeField] private float objectSpeed;
    [SerializeField] private GameObject checkPointsHolder;
    [SerializeField] private float rotationSpeed;
    int nextPointIndex;
    Transform nextPoint;
    Quaternion lookRotation;
    Vector3 direction;

    public Order order;

    private State state;

    private enum State
    {
        Walking,
        Waiting,
    }

    // Start is called before the first frame update
    void Start()
    {
        state = State.Walking;

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
        RotateCustomer();
    }

    #region Movement
    void MoveCustomer()
    {
        if(transform.position == nextPoint.position)
        {
            nextPointIndex++;
            if(nextPointIndex >= points.Count)
            {
                Debug.Log("Reached ending point");
                state = State.Waiting;
                return;
            }
            nextPoint = points[nextPointIndex];
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, nextPoint.position, objectSpeed * Time.deltaTime);
            //transform.LookAt(nextPoint.position, Vector3.up);
        }
    }

    void RotateCustomer()
    {
        if (nextPointIndex >= points.Count)
        {
            direction = (new Vector3(0, 0.75f, 0.25f) - transform.position).normalized;
            lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
            return;
        }
        direction = (nextPoint.position - transform.position).normalized;

        //create the rotation we need to be in to look at the target
        lookRotation = Quaternion.LookRotation(direction);

        //rotate us over time according to speed until we are in the required rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
    }
    #endregion

    public void TakeOrder()
    {
        Debug.Log("Take order");
    }
}