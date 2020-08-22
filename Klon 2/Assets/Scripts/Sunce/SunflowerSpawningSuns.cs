using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunflowerSpawningSuns : MonoBehaviour
{
	private float posX;
	private	float posY;
	public GameObject prefab;

	void Spawn(){
		posX = transform.position.x;
		posY = transform.position.y;
        GameObject go = Instantiate(prefab, new Vector3(posX + 0.25f, posY + 0.25f, 0), Quaternion.identity);
        go.GetComponent<SpriteRenderer>().transform.localScale = new Vector2(0.75f, 0.75f);
        go.GetComponent<Speed>().enabled = false;
    }
    void SetStart(bool value)
    {
        InvokeRepeating("Spawn", 7, 24);
        gameObject.GetComponent<Animator>().Play("Sunflower_Idle");
    }
}
