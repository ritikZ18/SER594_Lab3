using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEditor.FilePathAttribute;

public class SpawnerScript : MonoBehaviour
{
    public GameObject healObj;
    public GameObject hazardObj;
    public List<Vector3> positionArray = new List<Vector3> { };

    public int spawnCount = 0;
    public int minSpawnCount = 2;

    public float delay = 5f;
    public float targetTime;

    // Start is called before the first frame update
    void Start()
    {
        targetTime = delay;
        healObj = Resources.Load<GameObject>("prefabs/health");
        hazardObj = Resources.Load<GameObject>("prefabs/hazard");
    }

    void Awake()
    {
        
        positionArray[0] = new Vector3(-65, 1, -67);
        positionArray[1] = new Vector3(-6, 1, -67);
        positionArray[2] = new Vector3(28, 1, -67);
        positionArray[3] = new Vector3(-32, 1, -34);
        positionArray[4] = new Vector3(7, 1, -18);
        positionArray[5] = new Vector3(4, 1, -25);
        positionArray[6] = new Vector3(5, 1, 65);
        positionArray[7] = new Vector3(-55, 1, 4);
        positionArray[8] = new Vector3(44, 1, 13);
        positionArray[9] = new Vector3(54, 1, -2);
    }

    public void spawnHealth(Vector3 location)
    {
        GameObject obj = Instantiate(healObj, location, Quaternion.identity);
        spawnCount++;
        AddGlowLight(obj, Color.green);
    }
    
    public void spawnHazard(Vector3 location)
    {
        GameObject obj = Instantiate(hazardObj, location, Quaternion.identity);
        spawnCount++;
        AddGlowLight(obj, Color.red);
    }

    public void AddGlowLight(GameObject target, Color color)
    {
        Light glow = target.AddComponent<Light>();
        glow.color = color;
        glow.range = 8f;              // how far the light reaches
        glow.intensity = 3f;          // brightness
        glow.type = LightType.Point;  // point light = spherical glow
        glow.shadows = LightShadows.None;

        // Optional: auto-destroy light after 10 seconds if desired
        Destroy(glow, 10f);
    }

    public void randomSpawn()
    {
        int seedValue = DateTime.Now.Second;
        UnityEngine.Random.InitState(seedValue);
        int randomValue = UnityEngine.Random.Range(0, positionArray.Count);
        

        if (DateTime.Now.Millisecond * Time.deltaTime % 2 == 0 )
        {
            spawnHealth(positionArray[randomValue]);
            positionArray.RemoveAt(randomValue);

        }
        else
        {
            spawnHazard(positionArray[randomValue]);
            positionArray.RemoveAt(randomValue);

        }
    }

    void Update()
    {
        targetTime -= Time.deltaTime;
        if (spawnCount < minSpawnCount)
        {
            if (DateTime.Now.Millisecond % 2 == 0)
            {
                spawnHealth(positionArray[0]);
                positionArray.RemoveAt(0);

            }
            else
            {
                spawnHazard(positionArray[0]);
                positionArray.RemoveAt(0);

            }
            
        }
        

        else if (spawnCount < 10 && targetTime <= 0f)
        {
            randomSpawn();
            targetTime = delay;
        }

    }
}
