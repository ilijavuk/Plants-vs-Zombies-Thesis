using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunSpawn : MonoBehaviour
{
    public GameObject Prefab;

    void Start() {
        InvokeRepeating("Spawn", 1, 10);
    }
   
    void Spawn() {
		Vector3 pozicijaSpawn = new Vector3(Random.Range(-4, 5), 5, -1);
        Instantiate(Prefab, pozicijaSpawn, Quaternion.identity);
    }
}
