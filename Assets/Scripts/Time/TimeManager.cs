using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TimeManager : MonoBehaviour
{
    public TimeManager Instance { get; private set; }

    [Header("Internal Clock")]
    [SerializeField] public GameTimestamp timestamp;
    [SerializeField] public float timeScale = 1.0f;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
       // timestamp = new GameTimestamp(1, 1, 1, 0);
        StartCoroutine(TimeUpdate());
    }

    IEnumerator TimeUpdate()
    {
        while (true)
        {
            yield return new WaitForSeconds(1/timeScale);
            Tick();
        }

    }

    private void Tick()
    {
        timestamp.UpdateClock();
    }
}
