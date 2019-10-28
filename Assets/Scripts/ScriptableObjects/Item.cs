using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Item", menuName = "Item")]
public class Item : ScriptableObject
{
    public int ID;
    public string Name;
    public Sprite UIImage;
    public int MaxStack;
    public float Weight;
    //Bool IsSplitable
    //Bool Consumable (if true = one time use)
    //Bool AddHealth
    //int AddHealthAmount
    //Bool AddStamina
    //int AddStaminaAmount
    //Bool AddMoral
    //int AddMoralAmount

    //Equiptable
    //Stats
    //Effect

}
