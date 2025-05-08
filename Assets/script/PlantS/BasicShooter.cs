using System;
using UnityEngine;

public class BasicShooter : MonoBehaviour
{
    public GameObject bullet;
    public Transform shootOrigin;
    public float cooldown;
    public float range;
    public LayerMask shootMask;
    
    private bool canShoot;
    private GameObject target;
    private Animator animator; 

    private void Start()
    {
        animator = GetComponent<Animator>(); 
        Invoke("ResetCooldown", cooldown);
    }

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, range, shootMask);
        if (hit.collider)
        {
            target = hit.collider.gameObject;
            Shoot();
        }
    }

    void ResetCooldown()
    {
        canShoot = true;
            animator.enabled = false;
    }

    void Shoot()
    {
        if (!canShoot)
        {
            Debug.LogWarning("NAO ATIRA");
            animator.enabled = true;
            return;
        }
        
        canShoot = false;
        Invoke("ResetCooldown", cooldown);
        
        GameObject myBullet = Instantiate(bullet, shootOrigin.position, Quaternion.identity);
        
    }
}