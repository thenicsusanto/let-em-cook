using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    [SerializeField] private List<Transform> orderPoints = new List<Transform>();
    [SerializeField] private List<Transform> waitPoints = new List<Transform>();
    [SerializeField] private List<Transform> collectPoints = new List<Transform>();
    [SerializeField] private List<Transform> leavePoints = new List<Transform>();
    [SerializeField] private float objectSpeed;
    [SerializeField] private GameObject checkPointsOrderPrefab;
    [SerializeField] private GameObject checkPointsWaitPrefab;
    [SerializeField] private GameObject checkPointsCollectPrefab;
    [SerializeField] private GameObject checkPointsLeavePrefab;
    [SerializeField] private float rotationSpeed;
    int nextPointIndex;
    public Transform nextPoint;
    Quaternion lookRotation;
    Vector3 direction;

    public Order order;
    [SerializeField] private GameObject recipePrefab;

    private State state;

    private enum State
    {
        WalkingToOrder,
        WalkingToWait,
        WaitingForFood,
        WaitingToOrder,
        WalkingToCollect,
        WalkingToLeave,
        Delaying
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

        for(int i = 0; i < checkPointsCollectPrefab.transform.childCount; i++)
        {
            collectPoints.Add(checkPointsCollectPrefab.transform.GetChild(i));
        }

        for (int i = 0; i < checkPointsLeavePrefab.transform.childCount; i++)
        {
            leavePoints.Add(checkPointsLeavePrefab.transform.GetChild(i));
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
        else if(state == State.WalkingToCollect)
        {
            MoveCustomerToCollect();
        }
        else if(state == State.WalkingToLeave)
        {
            MoveCustomerToLeave();
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

    void MoveCustomerToCollect()
    {
        if (transform.position == nextPoint.position)
        {
            nextPointIndex++;
            if (state != State.Delaying && nextPointIndex >= collectPoints.Count)
            {
                StartCoroutine(CollectFood());
                state = State.Delaying;
                return;
            }
            nextPoint = collectPoints[nextPointIndex];
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, nextPoint.position, objectSpeed * Time.deltaTime);
            //transform.LookAt(nextPoint.position, Vector3.up);
        }
    }

    IEnumerator CollectFood()
    {
        yield return new WaitForSeconds(2f);
        GameObject hotDog = GameObject.Find("HotDogBun");
        Destroy(hotDog);
        nextPointIndex = 0;
        state = State.WalkingToLeave;
    }

    void MoveCustomerToLeave()
    {
        if (transform.position == nextPoint.position)
        {
            nextPointIndex++;
            if (nextPointIndex >= leavePoints.Count)
            {
                Destroy(gameObject);
                return;
            }
            nextPoint = leavePoints[nextPointIndex];
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
        GameObject newRecipe = Instantiate(recipePrefab, new Vector3(-0.0140008926f, 0.843999982f, 0.995999992f), Quaternion.Euler(new Vector3(90, 0, 0)));
        newRecipe.GetComponent<Receipt>().order1.text = order.menuItems[0].CheckOrders();
        //newRecipe.GetComponent<Receipt>().order2.text = order.menuItems[1].CheckOrders();
        //Write code for customer to walk back and wait for food
        state = State.WalkingToWait;
        nextPoint = waitPoints[0];
        nextPointIndex = 0;
    }

    public void CollectOrder()
    {
        Debug.Log("Order Getting Collected...");
        //Write code for customer to walk back and collect food
        state = State.WalkingToCollect;
        nextPoint = collectPoints[0];
        nextPointIndex = 0;
    }
}