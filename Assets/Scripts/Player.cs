using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public InventoryManager inventoryManager;
    private TileManager tileManager;
    private CropBehavior cropBehavior;

    private void Awake()
    {
        inventoryManager = GetComponent<InventoryManager>();
    }

    private void Start()
    {
        tileManager = GameManager.instance.tileManager;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (tileManager != null)
            {
                Vector3Int position = new Vector3Int((int)transform.position.x, (int)transform.position.y - 1, 0);
                string tileName = tileManager.GetTileName(position);

                if (!string.IsNullOrWhiteSpace(tileName))
                {
                    if (tileName.Contains("Interactable"))
                    {
                        if (inventoryManager.hotbar.selectedSlot.itemName == "Hoe" || inventoryManager.hotbar.selectedSlot.itemName == "WateringCan")
                        {
                            switch (inventoryManager.hotbar.selectedSlot.itemName)
                            {
                                case "Hoe":
                                    tileManager.SetPlowed(position);
                                    break;

                                case "WateringCan":
                                    tileManager.SetWatered(position);
                                    break;

                                default:
                                    break;
                            }
                        }
                        else if (inventoryManager.hotbar.selectedSlot.itemName.Contains("Seed"))
                        {
                            // get seed data from selected slot
                            if (inventoryManager.hotbar.selectedSlot.count > 0)
                            {
                                if (tileName.Contains("Plow"))
                                {
                                    tileManager.PlantSeed(position, inventoryManager.hotbar.selectedSlot.seedData);
                                    //cropBehavior.PlantSeed(position, inventoryManager.hotbar.selectedSlot.seedData);

                                    inventoryManager.hotbar.selectedSlot.count--;
                                    
                                    Debug.Log("Planted Seed");
                                }
                                else
                                    Debug.Log("This tile has not been plowed up");

                            }
                            else
                            {
                                Debug.Log("You don't have any seeds to plant!");
                            }

                            inventoryManager.inventoryUI.Refresh();
                        }
                        else
                        {
                            Debug.Log("Cannot interact with tile");
                        }
                    }
                }
            }
        }
    }

    public void DropItem(Item item)
    {
        Vector2 spawmLocation = transform.position;
        Vector2 spawnOffset = Random.insideUnitCircle * 1.5f;

        Item droppedItem = Instantiate(item, spawmLocation + spawnOffset, Quaternion.identity);

        // Makes the dropped item slide
        droppedItem.rb2D.AddForce(spawnOffset * 0.2f, ForceMode2D.Impulse);
    }

    public void DropItem(Item item, int numToDrop)
    {
        for (int i = 0; i < numToDrop; i++)
        {
            DropItem(item);
        }
    }


}