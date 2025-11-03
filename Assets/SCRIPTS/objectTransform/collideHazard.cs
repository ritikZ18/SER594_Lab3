using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideSphere : MonoBehaviour
{

    public SpawnerScript spawnerScript;
    public healthSystem health;

    private void Start()
    {
        spawnerScript = FindObjectOfType<SpawnerScript>();
        health = FindObjectOfType<healthSystem>();
    }
    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("HITTTT");
            health.takeDamage(1);
            var count = spawnerScript.spawnCount;
            spawnerScript.spawnCount = count -1;
            spawnerScript.positionArray.Add(gameObject.transform.position);
            Destroy(gameObject);
        }
    }
}
