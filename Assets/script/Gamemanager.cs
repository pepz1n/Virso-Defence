using System;
using TMPro;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    public GameObject currentPlant;
    public Sprite CurrentPlantSprite;
    public Transform tiles;
    public LayerMask TileMask;
    public int suns;
    public TextMeshProUGUI sunText;

    public LayerMask sunMask;
    
    public void BuyPlant(GameObject plant, Sprite sprite)
    {
        currentPlant = plant;
        CurrentPlantSprite = sprite;
    }

    private void Update()
    {
        sunText.text = suns.ToString();
        
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero,
            Mathf.Infinity, TileMask);

        foreach (Transform tile in tiles)
        {
            tile.GetComponent<SpriteRenderer>().enabled = false;
        }
        
        if (hit.collider && currentPlant)
        {
            hit.collider.GetComponent<SpriteRenderer>().sprite = CurrentPlantSprite;
            hit.collider.GetComponent<SpriteRenderer>().enabled = true;

            if (Input.GetMouseButtonDown(0) &&  hit.collider.GetComponent<Tile>().hasPlant == false)
            {
                Instantiate(currentPlant, hit.collider.transform.position, Quaternion.identity, hit.collider.transform);
                hit.collider.GetComponent<Tile>().hasPlant = true;
                currentPlant = null;
                CurrentPlantSprite = null;
            }
        }
        
        
        RaycastHit2D sunHit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero,
            Mathf.Infinity, sunMask);
        if (sunHit.collider)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Destroy(sunHit.collider.gameObject);
                suns += 25;
            }
        }
    }
}