using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour {

    public float damageMultiplier;

    public float meleeLifeRate = 2f;
    private float check = 0.0f;

    void Start()
    {
        check = Time.time + meleeLifeRate;
    }

    void Update()
    {
        if(Time.time > check)
        {
            check = Time.time + meleeLifeRate;
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        // If the melee collides with a floor then destroy the melee
        if (col.gameObject.layer == 8)
        {
            Destroy(this.gameObject);
        }

        // If the melee collides with a player knock them back then destroy the melee
        if (col.gameObject.tag == "Player")
        {
            Vector2 x = new Vector2(0, 0);

            if (this.gameObject.GetComponent<Transform>().rotation.z == 0)
            {
                x = Vector2.right * 3.0f;
            }

            if (this.gameObject.GetComponent<Transform>().rotation.z == 180)
            {
                x = Vector2.left * 3.0f;
            }

            col.gameObject.GetComponent<DamageController>().applyDamage(damageMultiplier, x);
            Destroy(this.gameObject);
        }
    }
}
