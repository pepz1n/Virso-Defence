using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawnerScript : MonoBehaviour
{
    public Transform[] SpawnPoints;
    
    public GameObject zombie;
    
    public ZombieTypeProb[] zombieTypes;
    
    private List<ZombieTypes> probList = new List<ZombieTypes>();

    private void Start()
    {
        InvokeRepeating("SpawnZombie", 2, 5);
        foreach (ZombieTypeProb zombieTypeProb in zombieTypes)
        {
            for (int i = 0; i < zombieTypeProb.probability; i++)
            {
                probList.Add(zombieTypeProb.type);
            }
        }
    }
    
    private void SpawnZombie()
    {
        GameObject myZombie = Instantiate(zombie, SpawnPoints[Random.Range(0, SpawnPoints.Length)].position, Quaternion.identity);
        myZombie.GetComponent<ZombieScript>().type = probList[Random.Range(0, probList.Count)];
    }
}

[System.Serializable]
public class ZombieTypeProb
{
    public ZombieTypes type;

    public float probability;
}
