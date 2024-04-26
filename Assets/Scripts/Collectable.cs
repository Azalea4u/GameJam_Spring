using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] public CollectableType type;
    [SerializeField] public Sprite icon;
    [SerializeField] public Rigidbody2D rb2D;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();

        if (player)
        {
            player.inventory.Add(this);

            Destroy(this.gameObject);
        }
    }
}

public enum CollectableType
{
    NONE, WHEAT_SEED
}