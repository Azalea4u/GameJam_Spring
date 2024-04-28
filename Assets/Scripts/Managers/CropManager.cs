using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CropTile
{
    public int growTimer;
    public CropData cropData;
}

public class CropManager : MonoBehaviour
{
    SeedData seedData;

    [Header("Growth Stages")]
    [SerializeField] public List<Tile> growthStageTiles = new List<Tile>();
    [SerializeField] public bool isHarvestable = false;
}
