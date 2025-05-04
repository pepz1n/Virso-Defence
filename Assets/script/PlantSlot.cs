using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlantSlot : MonoBehaviour
{
    public Sprite PlantSprite;
    
    public GameObject plantObject;
    
    public int preco;

    public Image icon;
    public TextMeshProUGUI priceText;

    private Gamemanager gms;

    private void Start()
    {
        gms = GameObject.Find("Gamemanager").GetComponent<Gamemanager>();
        GetComponent<Button>().onClick.AddListener(BuyPlant);
    }

    private void BuyPlant()
    {
        if (gms.suns >= preco && !gms.currentPlant)
        {
            gms.BuyPlant(plantObject, PlantSprite);
            gms.suns -= preco;
        }
    }

    private void OnValidate()
    {
        if (PlantSprite)
        {
            icon.enabled = true;
            icon.sprite = PlantSprite;
            priceText.text = preco.ToString();
        }
        else
        {
            icon.enabled = false;
        }
    }
}
