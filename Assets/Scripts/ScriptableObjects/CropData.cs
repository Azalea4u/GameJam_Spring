using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Crop Data", menuName = "Items/Crops")]
public class CropData : ItemData
{
    [SerializeField] public int sellPrice;
}
