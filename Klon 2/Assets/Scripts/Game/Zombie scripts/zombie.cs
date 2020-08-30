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
    private SpriteRenderer Renderer;
    private void Start()
    {
        varijabla.x = -1/speed;
        varijabla.y = 0;
        Renderer = gameObject.GetComponent<SpriteRenderer>();
        GetComponent<Animator>().GetCurrentAnimatorClipInfo().
        //GetComponent<Animator>().Play();
    }
    void Update()
	{
		this.gameObject.GetComponent<Rigidbody2D>().velocity = varijabla;
	}

    void Flicker()
    {
        Renderer.color = new Color(1f, 1f, 1f, 1f);
        // Destroy if died
        if (HP <= 0)
        {
            StartCoroutine(destroy());
        }
    }

    public void TakeDamage (int damage)
    {
        Renderer.color = new Color(1f, 1f, 1f, .7f);
        HP -= damage;
        Invoke("Flicker", 0.1f);
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
