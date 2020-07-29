using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiSpawn : MonoBehaviour
{
    public GameObject prefab;
    public int pocetak;
    public int kraj;
    public float delay;
    void Start() {
        StartCoroutine(spawn());
    }

    IEnumerator spawn()
    {
        Vector3 pozicijaSpawn = new Vector3(8, Random.Range(pocetak, kraj), 0);
        yield return new WaitForSeconds(delay);
        for (int i = 0; i < 3; i++)
        {
            
            Instantiate(prefab, pozicijaSpawn, Quaternion.identity);
            yield return new WaitForSeconds(15);
        }

        Instantiate(prefab, pozicijaSpawn, Quaternion.identity);
        Instantiate(prefab, pozicijaSpawn, Quaternion.identity);
    }
}
