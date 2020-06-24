using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class zombie : MonoBehaviour
{
    public Vector2 varijabla;
	public int HP;
    public float speed;
    public static progressBar skripta;
    private void Start()
    {
        varijabla.x = -1/speed;
        varijabla.y = 0;
    }
    void Update()
	{
		this.gameObject.GetComponent<Rigidbody2D>().velocity = varijabla;
	}
	void OnTriggerEnter2D (Collider2D other){
		if(other.gameObject.tag == "Projectile"){
			Destroy(other.gameObject);
            HP -= 20;

			// Destroy if died
			if (HP <= 0){
				StartCoroutine(unisti());
			}	
		}
	}
	IEnumerator unisti()
	{
		transform.position = new Vector3(11,0,0);
		yield return 0; // skippaj jedan frame
		Destroy(gameObject);
        Counter.value++;
	}
}
