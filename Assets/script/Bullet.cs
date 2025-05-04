using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
    public float speed = 0.8f;

    private void Start()
    {
        Destroy(gameObject, 10);
    }

    public void Update()
    {
        transform.position += new Vector3(speed * Time.fixedDeltaTime, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<ZombieScript>(out ZombieScript zombie))
        {
            zombie.Hit(damage);
            Destroy(gameObject);
        }
    }
}
