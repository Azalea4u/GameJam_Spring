using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManager : MonoBehaviour
{
    [SerializeField] public Tilemap interactableMap;
    [SerializeField] public Tilemap backgroundMap;
    [SerializeField] public Tile hiddenInteractableTile;
    [SerializeField] public Tile dirtTile;
    [SerializeField] public Tile plowedTile;
    [SerializeField] public Tile wateredTile;

    [Header("Growth Stages")]
    [SerializeField] public List<Tile> growthStageTiles = new List<Tile>();
    
    private int daysGrown = 0;

    public bool IsHarvestable { get; private set; }

    void Start()
    {
        foreach (var position in interactableMap.cellBounds.allPositionsWithin)
        {
            TileBase tile = interactableMap.GetTile(position);

            if (tile != null && tile.name == "Interactable")
            {
                interactableMap.SetTile(position, hiddenInteractableTile);
            }
        }
    }

    public void SetPlowed(Vector3Int position)
    {
        interactableMap.SetTile(position, plowedTile);
    }

    public void SetWatered(Vector3Int position)
    {
        backgroundMap.SetTile(position, wateredTile);
    }

    public void PlantSeed(Vector3Int position, SeedData seedData)
    {
        interactableMap.SetTile(position, seedData.seedlingSprite);
    }

    public string GetTileName(Vector3Int position)
    {
        if (interactableMap != null)
        {
            TileBase tile = interactableMap.GetTile(position);

            if (tile != null)
            {
                return tile.name;
            }
        }

        return "";
    }

    public void ResetWateredTiles()
    {
        foreach (var position in backgroundMap.cellBounds.allPositionsWithin)
        {
            TileBase tile = backgroundMap.GetTile(position);
            if (tile != null && tile == wateredTile)
            {
                backgroundMap.SetTile(position, dirtTile);
            }
        }
    }

    public void Grow()
    {
        daysGrown++;
        Debug.Log("Days Grown: " + daysGrown);
    }

    public void GetAllPlantedTiles()
    {
        
    }
}
