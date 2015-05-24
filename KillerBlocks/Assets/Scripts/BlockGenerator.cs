using UnityEngine;
using System.Collections;
using System;

public class BlockGenerator : MonoBehaviour
{
     GameObject SqaurePrefab = null;
     GameObject LPrefab = null;
     GameObject PlusPrefab = null;
     System.Random RandomPrefabGenerator = new System.Random();


     // Update is called once per frame
     void Update()
     {
          int typeOfPrefab = RandomPrefabGenerator.Next(1, 3);

          if(typeOfPrefab == 1)
          {
               Instantiate(SqaurePrefab);
          }
          else if (typeOfPrefab == 2)
          {
               Instantiate(LPrefab);
          }
          else if (typeOfPrefab == 3)
          {
               Instantiate(PlusPrefab);
          }

     }
}
