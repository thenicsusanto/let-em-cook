using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Order", menuName = "Order/Burger")]
public class Burger : OrderItem
{
    public bool hasCheese;
    public bool hasLettuce;
    public bool hasTomatoes;
    public bool hasOnions;
    public float cookTime = 60f;
}
