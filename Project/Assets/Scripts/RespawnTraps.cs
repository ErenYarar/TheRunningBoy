using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnTraps : MonoBehaviour
{
    public float maxTime = 5f;
    public float minTime = 2;
    //current time
    private float time;
    //public GameObject respawnTrap;
    public GameObject spawnObject;
    //The time to spawn the object
     private float spawnTime;
    void Start()
    {
        //InvokeRepeating("respawnLocation",1,2.5f);
        SetRandomTime();
        time = minTime;
    }

    void FixedUpdate(){
 
        //Counts up
        time += Time.deltaTime;

        //Check if its the right time to spawn the object
        if(time >= spawnTime){
            SpawnObject();
            SetRandomTime();
        }

    }
 
 
    //Spawns the object and resets the time
    void SpawnObject()
    {
        time = 0;
        Instantiate (spawnObject, transform.position, spawnObject.transform.rotation);
    }
 
    //Sets the random time between minTime and maxTime
    void SetRandomTime(){
        spawnTime = Random.Range(minTime, maxTime);
    }

    /*
    void respawnLocation()
    {
        Instantiate(respawnTrap, transform.position, Quaternion.identity) as GameObject;
    }*/
}
