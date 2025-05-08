using System;
using UnityEngine;

public class Plant : MonoBehaviour
{
    public int health;
    private Tile tile;  

    private void Start()
    {
        gameObject.layer = 9;

        tile = transform.parent?.GetComponent<Tile>();
    }

    public void Hit(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (tile != null)
        {
            tile.hasPlant = false;
            Debug.Log("Planta morreu e tile foi liberado");
        }
        else
        {
            Debug.LogWarning("Planta morreu mas não encontrou o Tile pai");
        }
        Destroy(gameObject);
    }
}