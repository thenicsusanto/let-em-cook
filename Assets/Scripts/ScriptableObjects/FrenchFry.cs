using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Order", menuName = "Order/FrenchFry")]
public class FrenchFry : ScriptableObject
{
    public OrderSize orderSize;
    public float cookTime = 30f;
}

public enum OrderSize
{
    Small,
    Medium,
    Large
}
