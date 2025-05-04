using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class sunScript : MonoBehaviour
{
    public float dropToYPos;
    private float speed = .15f;
    private void Start()
    {
        
        Destroy(gameObject, Random.Range(6f, 12f));
    }

    private void Update()
    {
        if (transform.position.y > dropToYPos)
            transform.position -= new Vector3(0, speed * Time.fixedDeltaTime, 0);
    }
}
