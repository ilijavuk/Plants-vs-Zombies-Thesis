using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunflowerSpawningSuns : MonoBehaviour
{
	public GameObject Prefab;

	void Spawn(){
        GameObject go = Instantiate(Prefab, new Vector3(transform.position.x + 0.25f, transform.position.y + 0.25f, -1f), Quaternion.identity);
        go.GetComponent<SpriteRenderer>().transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
        go.GetComponent<Speed>().enabled = false;
    }
    void SetStart(bool value)
    {
        InvokeRepeating("Spawn", 4, 10);
        gameObject.GetComponent<Animator>().SetBool("IsSpawned", true);
    }
}
