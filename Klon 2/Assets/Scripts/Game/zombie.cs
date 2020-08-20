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

    public void TakeDamage (int damage)
    {
        HP -= damage;

        // Destroy if died
        if (HP <= 0)
        {
            StartCoroutine(destroy());
        }

    }
	IEnumerator destroy()
	{
		transform.position = new Vector3(11,0,0);
		yield return 0; // skippaj jedan frame
		Destroy(gameObject);
	}

    private void OnDestroy()
    {
        Counter.value++;
    }
}
