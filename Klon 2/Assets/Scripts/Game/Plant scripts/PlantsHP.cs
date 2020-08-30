﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantsHP : MonoBehaviour
{
    public int HP;
    private Shovel shovel;

    private void Start()
    {
        GameObject shovelButton = GameObject.Find("Button Shovel");
        if (shovelButton)
        {
            shovel = shovelButton.GetComponent<Shovel>();
        }
        
    }

    public void SmanjiHP(int dmg)
    {
        HP -= dmg;
        if (HP <= 0)
        {
            StartCoroutine(unisti());
        }
    }

    IEnumerator unisti()
    {
        transform.position = new Vector3(11, transform.position.y, 0);
        yield return 0; // skippaj jedan frame
        Destroy(gameObject);
    }

    private void OnMouseEnter()
    {
        if(shovel && shovel.toggledOn)
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, .5f);
    }
    private void OnMouseExit()
    {
        if (shovel && shovel.toggledOn)
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
    }

    private void OnMouseDown()
    {
        if (shovel && shovel.toggledOn)
            Destroy(gameObject);

    }
}
