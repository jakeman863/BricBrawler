using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float damageMultiplier;

    void Start()
    {
        
    }

    void Update()
    {
        checkOutOfBounds();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.name == "Melee(Clone)")
        {
            if (col.gameObject.tag != this.gameObject.tag)
            {
                this.gameObject.GetComponent<Rigidbody2D>().velocity *= -1;
            }
        }

    }

    void OnCollisionEnter2D (Collision2D col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            Destroy(this.gameObject);
        }

        // If the bullet collides with a floor then destroy the bullet
        if (col.gameObject.name == "Floor")
        {
            Destroy(this.gameObject);
        }

        // If the bullet collides with a player knock them back then destroy the bullet
        if (col.gameObject.tag == "Player")
        {
            Vector2 x = new Vector2(0,0);

            if (this.gameObject.GetComponent<Rigidbody2D>().velocity.x > 0)
            {
                x = Vector2.right * 3.0f;
            }

            if(this.gameObject.GetComponent<Rigidbody2D>().velocity.x < 0)
            {
                x = Vector2.left * 3.0f;
            }

            col.gameObject.GetComponent<DamageController>().applyDamage(damageMultiplier, x);
            Destroy(this.gameObject);
        }
    }

    // Checks if the bullet is out of bounds or if it's not moving
    private void checkOutOfBounds()
    {
        if (this.gameObject.GetComponent<Transform>().position.x >= 3 || this.gameObject.GetComponent<Transform>().position.x <= -3 || this.gameObject.GetComponent<Transform>().position.y <= -2 || this.gameObject.GetComponent<Transform>().position.y >= 2)
        {
            Destroy(this.gameObject);
        }

        if (this.gameObject.GetComponent<Rigidbody2D>().velocity.x == 0 && this.gameObject.GetComponent<Rigidbody2D>().velocity.y == 0)
        {
            Destroy(this.gameObject);
        }
    }
}
