using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CropBehavior : MonoBehaviour
{
    TileManager tileManager;
    Item crop;

    private SeedData seedData;
    private Vector3Int tilePosition;
    private int daysGrown;

    public bool IsHarvestable { get; private set; }

    [Header("Growth Stages")]
    [SerializeField] public List<TileBase> growthStageTiles = new List<TileBase>();
    [SerializeField] TileBase seedlingTile;
    [SerializeField] TileBase sproutTile;
    [SerializeField] TileBase growthTile;
    [SerializeField] TileBase harvestableTile;

    public enum CropState
    {
        SEEDLING,
        SPROUT,
        GROWTH,
        HARVESTABLE
    }
    public CropState eState;

    public void Plant(SeedData seedToGrow, Tilemap interactableMap, Vector3Int tilePosition)
    {
        this.seedData = seedToGrow;
        this.tileManager.interactableMap = interactableMap;
        this.tilePosition = tilePosition;
        this.daysGrown = 0;

        interactableMap.SetTile(tilePosition, seedData.seedlingSprite);
    }

    public void Grow()
    {
        daysGrown++;

        int growthStageIndex = Mathf.CeilToInt((float)daysGrown / ((float)seedData.daysToGrow / growthStageTiles.Count));
        TileBase tileToSet = GetTileForGrowthStage(growthStageIndex);

        tileManager.interactableMap.SetTile(tilePosition, tileToSet);

        if (growthStageIndex == seedData.daysToGrow)
        {
            IsHarvestable = true;
        }
    }

    private TileBase GetTileForGrowthStage(int stage)
    {
        switch (stage)
        {
            case 1:
                return seedlingTile;
            case 2:
                return sproutTile;
            case 3:
                return growthTile;
            case 4:
                return harvestableTile;
            default:
                return null;
        }
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
