using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Order", menuName = "Order/HotDog")]
public class HotDog : ScriptableObject
{
    public bool hasKetchup;
    public bool hasMustard;
    public float cookTime = 60f;
}
