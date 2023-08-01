using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Order", menuName = "Order/HotDog")]
public class HotDog : OrderItem
{
    public bool hasKetchup;
    public bool hasMustard;
    string ketchup = "";
    string mustard = "";

    public override string CheckOrders()
    {   
        if(hasKetchup)
        {
            ketchup = "with ketchup";
        }
        else
        {
            ketchup = "";
        }

        if(hasMustard)
        {
            mustard = "with mustard";
        }
        else
        {
            mustard = "";
        }

        return "1x " + "Hotdog " + ketchup + mustard;
    }
}