using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class SunSpawner : MonoBehaviour
{
   public GameObject sunObject;

   private void Start()
   {
      SpawnSun();
   }

   void SpawnSun()
   {
      GameObject mySun =  Instantiate(sunObject, new Vector3(Random.Range(-7.10f, 2.2f), 6, 0), Quaternion.identity);
      mySun.GetComponent<sunScript>().dropToYPos = Random.Range(2f, -3f);
      Invoke("SpawnSun", Random.Range(4, 10));
   }
}
