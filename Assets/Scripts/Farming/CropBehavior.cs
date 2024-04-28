using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Tilemaps;



public class CropBehavior : MonoBehaviour
{
    TileManager tileManager;
    TimeManager timeManager;
    Item crop;

    private SeedData seedData;
    private Vector3Int tilePosition;
    private int daysGrown = 0;

    public bool IsHarvestable { get; private set; }

    [Header("Growth Stages")]
    [SerializeField] public List<Tile> growthStageTiles = new List<Tile>();

    private void Update()
    {
        if (GameManager.instance.timeManager.timestamp.hour == 23)
            Grow();
    }

    public void PlantSeed(Vector3Int tilePosition, SeedData seedData)
    {
        //this.seedData = seedData;
        //this.tileManager.interactableMap = interactableMap;
        //this.tilePosition = tilePosition;
        //tileManager.interactableMap.SetTile(tilePosition, seedData.seedlingSprite);
        //tileManager.PlantSeed(tilePosition, seedData);
        this.daysGrown = 0;

    }

    public void Plant(Vector3Int tilePosition, Tilemap interactableMap)
    {

        this.tileManager.interactableMap = interactableMap;
        this.tilePosition = tilePosition;
        this.daysGrown = 0;

        interactableMap.SetTile(tilePosition, seedData.seedlingSprite);
    }

    public void Grow()
    {
        daysGrown++;
        Debug.Log(daysGrown);

        // if days 
        int growthStageIndex = Mathf.CeilToInt((int)daysGrown / ((int)seedData.daysToGrow / growthStageTiles.Count));

        TileBase tileToSet = GetTileForGrowthStage(growthStageIndex);

        tileManager.interactableMap.SetTile(tilePosition, tileToSet);

        if (growthStageIndex == seedData.daysToGrow)
        {
            IsHarvestable = true;
        }
    }

    private TileBase GetTileForGrowthStage(int stage)
    {
        Debug.Log("stage: " + stage + "growthStageTile: " + growthStageTiles[stage].name);
        return growthStageTiles[stage];
    }

    public void Harvest()
    {
        if (IsHarvestable)
        {
            for (int i = 0; i < seedData.yieldAmount; i++)
            {
                // add crop to inventory
                GameManager.instance.player.DropItem(crop);
            }

            tileManager.interactableMap.SetTile(tilePosition, tileManager.dirtTile);
        }
    }
}
