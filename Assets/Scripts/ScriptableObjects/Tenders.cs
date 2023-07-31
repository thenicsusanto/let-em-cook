using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Order", menuName = "Order/Tenders")]
public class Tenders : OrderItem
{
    public int tenderAmount;
    public float cookTime = 60f;
}
