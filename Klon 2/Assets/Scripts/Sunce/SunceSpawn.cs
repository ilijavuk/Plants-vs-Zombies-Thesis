using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunceSpawn : MonoBehaviour
{
    public GameObject prefab;

    // Use this for initialization
    void Start() {
        // Spawn first Sun in 10 seconds, repeat every 10 seconds
        InvokeRepeating("Spawn", 1, 10);
    }
   
    void Spawn() {
		Vector3 pozicijaSpawn = new Vector3(Random.Range(0, 9), Random.Range(6, 6), 0);
        Instantiate(prefab, pozicijaSpawn, Quaternion.identity);
    }
}
