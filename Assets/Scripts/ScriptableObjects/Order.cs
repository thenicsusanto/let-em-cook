using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Order", menuName = "Order/Order")]
public class Order : ScriptableObject
{
    public string orderNumber;
    public OrderItem[] menuItems;
    public float totalCost;
}
