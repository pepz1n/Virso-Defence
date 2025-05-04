using System;
using UnityEngine;

public class ZombieScript : MonoBehaviour
{
    private float speed;

    private int health;

    private float range;
    public ZombieTypes type;
    public LayerMask plantMask;
    public Plant targetPlant;
    private float eatCooldown;
    private bool canEat = true;
    public int damage;

    private void Start()
    {
        speed = type.speed;
        health = type.health;
        range = type.range;
        eatCooldown = type.eatCooldown;
        
        GetComponent<SpriteRenderer>().sprite = type.sprite;
    }
    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, range, plantMask);

        if (hit.collider)
        {
            targetPlant = hit.collider.gameObject.GetComponent<Plant>();
            Eat();
        }
        
        if (health == 2)
            GetComponent<SpriteRenderer>().sprite = type.DeathSprite;
    }

    void Eat()
    {
        if (!canEat || !targetPlant)
            return;
        canEat = false;
        Invoke("ResetEatCooldown", eatCooldown);
        
        targetPlant.Hit(damage);
    }

    void ResetEatCooldown()
    {
        canEat = true;
    }
    
    private void FixedUpdate()
    {
        if (!targetPlant)
            transform.position -= new Vector3(speed, 0, 0);
    }

    public void Hit(int damage)
    {
        health -= damage;
        if (health <= 0)
            Destroy(gameObject);
    }
}
