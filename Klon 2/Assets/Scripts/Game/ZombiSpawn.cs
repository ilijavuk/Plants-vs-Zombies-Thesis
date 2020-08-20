using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZombiSpawn : MonoBehaviour
{
    public GameObject[] prefab;
    public int start;
    public int end;
    public float delay;
    private int numberOfSpawns;
    private int typeOfSpawns;
    void Start() {
        StartCoroutine(spawn());
        numberOfSpawns = Levels.spawns[Counter.currentLevel - 1, 0];
        typeOfSpawns = Levels.spawns[Counter.currentLevel - 1, 1];
    }

    IEnumerator spawn()
    {
        Vector3 pozicijaSpawn = new Vector3(8, Random.Range(start, end), 0);
        yield return new WaitForSeconds(delay);
        for (int i = 0; i < numberOfSpawns; i++)
        {
            Instantiate(prefab[Random.Range(0, typeOfSpawns)], pozicijaSpawn, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(0.0f, 10.0f));
        }
    }
}
