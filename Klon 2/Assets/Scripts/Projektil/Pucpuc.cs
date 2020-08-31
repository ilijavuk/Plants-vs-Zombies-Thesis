using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pucpuc : MonoBehaviour
{
    public GameObject Prefab;
    Animator anim;
    Vector3 pos;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Shoot()
    {
        Instantiate(Prefab, pos, Quaternion.identity);
    }

    void OnTriggerStay2D (Collider2D other){
        if(other.gameObject.tag == "Zombie" )
        {
            anim.SetBool("shooting", true);
        }
    }

    void OnTriggerExit2D (Collider2D other){
        if (other.gameObject.tag == "Zombie"){
            anim.SetBool("shooting", false);
        }
    }

    void SetStart(bool value)
    {
        pos = new Vector3(transform.position.x + 0.367f, transform.position.y + 0.1728f, 0);
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        gameObject.GetComponent<Animator>().SetBool("IsSpawned", true);
    }
}

