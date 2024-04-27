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
        // get tile from data
        TileBase seedTile = seedData.seedlingSprite;
        interactableMap.SetTile(position, seedTile);
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
}
