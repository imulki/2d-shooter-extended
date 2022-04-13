using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnOrb : MonoBehaviour {

    [SerializeField]
    public GameObject[] orbsPrefab;

    public float spawnTime = 3f;
    private float currentTimeToSpawn = 1f; 
    private Bounds backdrop;
    
    void Start() {
        backdrop = GameObject.Find("Planks").GetComponent<Renderer>().bounds;
    }

    void Update(){
        if(currentTimeToSpawn > 0 ){
            currentTimeToSpawn -= Time.deltaTime;
        } else {
            spawn();
            currentTimeToSpawn = spawnTime; 
        }

    }

    private void spawn(){
        float y = 0.5f;
        float x = Random.Range(backdrop.center.x+15,backdrop.center.z-15);
        float z = Random.Range(backdrop.center.z+15,backdrop.center.z-15);
        Instantiate(orbsPrefab[Random.Range(0, orbsPrefab.Length)], new Vector3(x, y, z), transform.rotation);
    }
}