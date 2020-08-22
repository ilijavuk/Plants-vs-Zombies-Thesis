using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pucpuc : MonoBehaviour
{
    public Animator animacija;
    public GameObject prefab;
	static Vector3 poz;
    bool pucam = false;

    public void Pucaj()
    {
        poz = new Vector3(transform.position.x + 0.367f, transform.position.y + 0.1728f, 0);
        Instantiate(prefab, poz, Quaternion.identity);
    }
    void OnTriggerStay2D (Collider2D other){
        if(other.gameObject.tag == "Zombie" && !pucam){
            pucam = true;
            animacija.SetBool("puca", true);
        }
    }
    void OnTriggerExit2D (Collider2D other){
        if (other.gameObject.tag == "Zombie"){
            animacija.SetBool("puca", false);
            pucam = false;
        }
    }
    void SetStart(bool value)
    {
        gameObject.GetComponent<Animator>().Play("Graso_Idle");
    }
}

