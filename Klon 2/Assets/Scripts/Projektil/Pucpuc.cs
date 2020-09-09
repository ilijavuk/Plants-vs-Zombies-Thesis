using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pucpuc : MonoBehaviour
{
    public GameObject Prefab;
    public AudioSource[] AudioSources;
    Animator anim;
    Vector3 pos;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Shoot()
    {
        AudioSources[Random.Range(0, AudioSources.Length)].Play();
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
        BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();
        switch (transform.position.x)
        {
            case -3:
                boxCollider.offset = new Vector2(4f, 0f);
                boxCollider.size = new Vector2(7f, 0.95f); break;
            case -2:
                boxCollider.offset = new Vector2(3.5f, 0f);
                boxCollider.size = new Vector2(6f, 0.95f); break;
            case -1:
                boxCollider.offset = new Vector2(3f, 0f);
                boxCollider.size = new Vector2(5f, 0.95f); break;
            case 0:
                boxCollider.offset = new Vector2(2.5f, 0f);
                boxCollider.size = new Vector2(4f, 0.95f); break;
            case 1:
                boxCollider.offset = new Vector2(2f, 0f);
                boxCollider.size = new Vector2(3f, 0.95f); break;
            case 2:
                boxCollider.offset = new Vector2(1.5f, 0f);
                boxCollider.size = new Vector2(2f, 0.95f); break;
            case 3:
                boxCollider.offset = new Vector2(1f, 0f);
                boxCollider.size = new Vector2(1f, 0.95f); break;
            case 4:
                boxCollider.offset = new Vector2(0f, 0f);
                boxCollider.size = new Vector2(1f, 0.95f); break;
        }
        pos = new Vector3(transform.position.x + 0.367f, transform.position.y + 0.1728f, 0);
        boxCollider.enabled = true;
        gameObject.GetComponent<Animator>().SetBool("IsSpawned", true);
    }
}

