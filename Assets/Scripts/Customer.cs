using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    [SerializeField] private List<Transform> orderPoints = new List<Transform>();
    [SerializeField] private List<Transform> waitPoints = new List<Transform>();
    [SerializeField] private float objectSpeed;
    [SerializeField] private GameObject checkPointsOrderPrefab;
    [SerializeField] private GameObject checkPointsWaitPrefab;
    [SerializeField] private float rotationSpeed;
    int nextPointIndex;
    public Transform nextPoint;
    Quaternion lookRotation;
    Vector3 direction;

    public Order order;

    private State state;

    private enum State
    {
        WalkingToOrder,
        WalkingToWait,
        WaitingForFood,
        WaitingToOrder
    }

    // Start is called before the first frame update
    void Start()
    {
        state = State.WalkingToOrder;

        for (int i = 0; i < checkPointsOrderPrefab.transform.childCount; i++)
        {
            orderPoints.Add(checkPointsOrderPrefab.transform.GetChild(i));
        }

        for (int i = 0; i < checkPointsWaitPrefab.transform.childCount; i++)
        {
            waitPoints.Add(checkPointsWaitPrefab.transform.GetChild(i));
        }

        nextPoint = orderPoints[0];  
    }

    // Update is called once per frame
    void Update()
    {
        if(state == State.WalkingToOrder)
        {
            MoveCustomerToOrder();
        }
        else if(state == State.WalkingToWait)
        {
            MoveCustomerToWait();
        }
        RotateCustomer();
    }

    #region Movement
    void MoveCustomerToOrder()
    {
        if(transform.position == nextPoint.position)
        {
            nextPointIndex++;
            if(nextPointIndex >= orderPoints.Count)
            {
                Debug.Log("Reached ending point for order");
                state = State.WaitingToOrder;
                return;
            }
            nextPoint = orderPoints[nextPointIndex];
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, nextPoint.position, objectSpeed * Time.deltaTime);
            //transform.LookAt(nextPoint.position, Vector3.up);
        }
    }

    void MoveCustomerToWait()
    {
        if (transform.position == nextPoint.position)
        {
            nextPointIndex++;
            if (nextPointIndex >= waitPoints.Count)
            {
                Debug.Log("Reached ending point for wait");
                state = State.WaitingForFood;
                return;
            }
            nextPoint = waitPoints[nextPointIndex];
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, nextPoint.position, objectSpeed * Time.deltaTime);
            //transform.LookAt(nextPoint.position, Vector3.up);
        }
    }

    void RotateCustomer()
    {
        direction = (nextPoint.position - transform.position).normalized;

        //create the rotation we need to be in to look at the target
        lookRotation = Quaternion.LookRotation(direction);

        //rotate us over time according to speed until we are in the required rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
    }
    #endregion

    public void TakeOrder()
    {
        Debug.Log("Order taken");
        //Write code for customer to walk back and wait for food
        state = State.WalkingToWait;
        nextPoint = waitPoints[0];
        nextPointIndex = 0;
    }
}