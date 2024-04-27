using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "Seed Data", menuName = "Items/Seeds")]
public class SeedData : ItemData
{
    [SerializeField] public int daysToGrow;
    [SerializeField] public ItemData cropToYield;
    [SerializeField] public Tile seedlingSprite;
    [SerializeField] public int yieldAmount;
    [SerializeField] public int sellPrice;}
