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

    public Player player;

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
}
