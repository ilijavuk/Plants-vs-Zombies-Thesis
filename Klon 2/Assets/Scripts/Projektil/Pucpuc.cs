using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pucpuc : MonoBehaviour
{
    public Animator anim;
    public GameObject prefab;
	static Vector3 poz;
    bool shooting = false;

    public void Pucaj()
    {
        poz = new Vector3(transform.position.x + 0.367f, transform.position.y + 0.1728f, 0);
        Instantiate(prefab, poz, Quaternion.identity);
    }
    void OnTriggerStay2D (Collider2D other){
        if(other.gameObject.tag == "Zombie" && !shooting)
        {
            shooting = true;
            anim.SetBool("shooting", true);
        }
    }
    void OnTriggerExit2D (Collider2D other){
        if (other.gameObject.tag == "Zombie"){
            anim.SetBool("shooting", false);
            shooting = false;
        }
    }
    void SetStart(bool value)
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        gameObject.GetComponent<Animator>().Play("Graso_Idle");
    }
}

