using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuncokretSpawnaSunce : MonoBehaviour
{
	private float posX;
	private	float posY;
	public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
		InvokeRepeating("Spawn",7,24);	
    }
	void Spawn(){
		posX = transform.position.x;
		posY = transform.position.y;
		Instantiate(prefab, new Vector3(posX + 0.25f, posY + 0.25f, 0),Quaternion.identity);
	}
}
