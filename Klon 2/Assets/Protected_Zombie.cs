using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Protected_Zombie : MonoBehaviour
{
    public Sprite DamagedOnce;
    public Sprite DamagedTwice;
    public int ProtectedHP;
    public int ZombieHP;
    private int HP;
    private SpriteRenderer Renderer;

    private void Start()
    {
        Renderer = transform.GetChild(1).GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        HP = gameObject.GetComponent<zombie>().HP - ZombieHP;


        if (HP < ProtectedHP * 2 / 3)
        {
            Renderer.sprite = DamagedOnce;
        }
        if (HP < ProtectedHP / 3)
        {
            Renderer.sprite = DamagedTwice;
        }
        if (HP < 0)
        {
            Renderer.enabled = false;
        }

    }
}
