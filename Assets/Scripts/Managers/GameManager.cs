using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public ItemManager itemManager;
    public TileManager tileManager;
    public UI_Manager uiManager;
    public TimeManager timeManager;
    public InventoryManager inventoryManager;

    public Player player;

    [Header("GameMenu")]
    public GameObject startMenu;

    public bool isGamePaused = true;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }        
        DontDestroyOnLoad(this.gameObject);
        
        itemManager = GetComponent<ItemManager>();
        tileManager = GetComponent<TileManager>();
        uiManager = GetComponent<UI_Manager>();
        timeManager = GetComponent<TimeManager>();

        player = FindAnyObjectByType<Player>();
    }

    public void Start()
    {
        startMenu.SetActive(true);
        PauseGame();
    }

    private void Update()
    {
        if (!isGamePaused && timeManager.timestamp.hour == 23)
        {
            if (tileManager.seededTiles.Count > 0)
                tileManager.UpdateSeededTiles();
            tileManager.ResetWateredTiles();
        }
    }

    public void StartGame()
    {
        // Hide the start menu
        startMenu.SetActive(false);

        // Resume the game
        ResumeGame();
        timeManager.StartTimer();
    }

    public void EnterStore()
    {
        // Pause the game when entering the store
        PauseGame();
    }

    public void ExitStore()
    {
        // Resume the game when exiting the store
        ResumeGame();

    }

    public void PauseGame()
    {
        isGamePaused = true;
        timeManager.PauseTime();
    }

    public void ResumeGame()
    {
        isGamePaused = false;
        timeManager.ResumeTime();
    }
}
