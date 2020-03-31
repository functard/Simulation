using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MapGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject[] building;

    [SerializeField]
    private GameObject xStreets;

    [SerializeField]
    private GameObject zStreets;

    [SerializeField]
    private GameObject crossRoads;


    [SerializeField]
    private int mapWidht = 20;

    [SerializeField]
    private int mapHeight = 20;

    private bool guideNpcSpawned;

    private int[,] mapGrid;

    private int buildingFootPrint = 5;

    [SerializeField]
    private GameObject guideNpc;

    [SerializeField]
    private GameObject npc;

    bool test = false;
    // Start is called before the first frame update
    void Start()
    {
        guideNpcSpawned = false;
        GenerateMap();
    }

    private void GenerateMap()
    {
        mapGrid = new int[mapWidht, mapHeight];
        float seed = Random.Range(0, 100);

        //generate map data
        for (int h = 0; h < mapHeight; h++)
        {
            for (int w = 0; w < mapWidht; w++)
            {
                mapGrid[w, h] = (int)(Mathf.PerlinNoise(w / 10.0f + seed, h / 10.0f + seed) * 10);
            }
        }

        int x = 0;
        //build streets
        for (int n = 0; n < 50; n++)
        {
            for (int h = 0; h < mapHeight; h++)
            {
                mapGrid[x, h] = -1;
            }
            
            x += Random.Range(3, 3);
            if (x >= mapWidht)
                break;
        }

        int z = 0;
        for (int n = 0; n < 50; n++)
        {
            for (int w = 0; w < mapWidht; w++)
            {
                //put crossroad
                if (mapGrid[w, z] == -1)
                    mapGrid[w, z] = -3;
                else
                    mapGrid[w, z] = -2;
            }

            z += Random.Range(5, 20);
            if (z >= mapHeight)
                break;
        }

        //generate city
        for (int h = 0; h < mapHeight; h++)
        {
            for (int w = 0; w < mapWidht; w++)
            {
                int result = mapGrid[w, h];
                Vector3 pos = new Vector3(w * buildingFootPrint, 0, h * buildingFootPrint);


                if (result < -2)
                    Instantiate(crossRoads, pos, crossRoads.transform.rotation);

                else if (result < -1)
                    Instantiate(xStreets, pos, xStreets.transform.rotation);


                else if (result < 0)
                    Instantiate(zStreets, pos, zStreets.transform.rotation);

                else if (result < 1)
                    Instantiate(building[0], pos, building[0].transform.rotation);

                else if (result < 2)
                    Instantiate(building[1], pos, building[1].transform.rotation);

                else if (result < 3)
                    Instantiate(building[2], pos, building[2].transform.rotation);

                else if (result < 5)
                    Instantiate(building[3], pos, building[3].transform.rotation);

                else if (result < 6)
                    Instantiate(building[4], pos, building[4].transform.rotation);


                else if (result < 10)
                {
                    Instantiate(building[6], pos, Quaternion.identity);
                    Instantiate(npc, pos, Quaternion.identity);
                    if(!guideNpcSpawned)
                    {
                        Instantiate(guideNpc, pos, Quaternion.identity);
                        guideNpcSpawned = true;
                    }
                }


            }
        }
    }
}
  
