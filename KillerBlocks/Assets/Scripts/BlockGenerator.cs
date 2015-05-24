using UnityEngine;
using System.Collections;
using System;

public class BlockGenerator : MonoBehaviour
{
     public GameObject SqaurePrefab = null;
     public GameObject LPrefab = null;
     public GameObject PlusPrefab = null;
     public GameObject IPrefab = null;
     System.Random RandomPrefabGenerator = new System.Random();
     int typeOfPrefab;
     int count = 0;
     Vector3 spawnLocation;
     public GameObject Player = null;


     // Update is called once per frame
     void Update()
     {

          //StartCoroutine(GenerateBlocks());
          if (count == 50)
          {
               spawnPrefab();
               count = 0;
          }
          count++;
     }
     IEnumerator GenerateBlocks()
     {
          
          yield return new WaitForSeconds(5f);
         

     }
     void spawnPrefab()
     {
          spawnLocation = Player.transform.position;
          spawnLocation.y += 15;
          typeOfPrefab = RandomPrefabGenerator.Next(1, 4);
          if (typeOfPrefab == 1)
          {
               Instantiate(SqaurePrefab, spawnLocation, Quaternion.identity);
          }
          else if (typeOfPrefab == 2)
          {

               Instantiate(LPrefab, spawnLocation, Quaternion.identity);
          }
          else if (typeOfPrefab == 3)
          {
               Instantiate(PlusPrefab, spawnLocation, Quaternion.identity);
          }
          else if (typeOfPrefab == 4)
          {
               Instantiate(IPrefab, spawnLocation, Quaternion.identity);
          }
     }
}
