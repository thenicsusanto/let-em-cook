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
    string cheese = "";
    string lettuce = "";
    string tomato = "";
    string onion = "";

    public override string CheckOrders()
    {
        if (hasCheese)
        {
            cheese = "with cheese";
        }
        if (hasLettuce)
        {
            lettuce = "with lettuce";
        }
        if(hasTomatoes)
        {
            tomato = "with tomatoes";
        }
        if(hasOnions)
        {
            tomato = "with onion";
        }

        return "1x " + "Hotdog " + cheese + lettuce + tomato + onion;
    }
}
