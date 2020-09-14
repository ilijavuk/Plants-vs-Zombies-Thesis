using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantsHP : MonoBehaviour
{
    public int HP;

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

    public void WhenMouseEnter()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, .5f);
    }
    public void WhenMouseExit()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
    }

    public void WhenMouseDown()
    {
        Destroy(gameObject);
    }

}
