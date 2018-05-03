using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour {

    public float damageTaken;
    private Rigidbody2D rb2d;

    public float knockbackRate = 2f;
    private float nextKnockback = 0.0f;

    public int hitCheck;

    // Use this for initialization
    void Start ()
    {
        hitCheck = 0;
        rb2d = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(Input.GetKeyUp("x"))
        {
            Debug.Log(hitCheck);
        }
	}

    public void applyDamage(float value, Vector2 x)
    {
        rb2d.GetComponentInParent<PlayerController>().soundSource.clip = rb2d.GetComponentInParent<PlayerController>().hitSound;
        rb2d.GetComponentInParent<PlayerController>().soundSource.Play();

        damageTaken += value;
        rb2d.AddForce(x * damageTaken);

        hitCheck = 1;
        StartCoroutine(resetHitCheck());
    }

    IEnumerator resetHitCheck()
    {
        yield return new WaitForSeconds(.5f);
        hitCheck = 0;
    }
}
