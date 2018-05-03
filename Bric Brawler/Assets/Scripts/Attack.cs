using UnityEngine;

public class Attack : MonoBehaviour {

    public Transform player;
    public int ammoCount = 5;
    public Rigidbody2D bullet;
    public GameObject melee;
    public float speed = 3.0f;
    private string playerNum;

    public float fireRate = 0.5f;
    private float nextFire = 0.0f;

    public float meleeRate = 6.0f;
    private float nextMelee = 0.0f;
    public bool canMelee;

    public float reloadRate = 4.0f;
    private float nextReload = 0.0f;

    private int shootDirection;

    public AudioClip shotSound;

	// Use this for initialization
	void Start ()
    {
        playerNum = this.name;
        shootDirection = 1;
        canMelee = true;
    }
	
    void FixedUpdate()
    {
        playerDirection();
    }

	// Update is called once per frame
	void Update ()
    {
        if (Input.GetAxis(playerNum + "_Shoot") > 0 && ammoCount > 0 && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            newFire();
        }

        if (Input.GetAxis(playerNum + "_Melee") > 0 && canMelee)
        {
            nextMelee = Time.time + meleeRate;
            Melee();
        }

        if (Time.time > nextMelee)
        {
            canMelee = true;
        }
        else
        {
            canMelee = false;
        }

        if (ammoCount < 5 && Time.time > nextReload)
        {
            nextReload = Time.time + reloadRate;
            ammoCount++;
        }
    }

    private void Melee()
    {
        float x = 0, y = 0;

        Vector2 meleePosition = getMeleePosition(ref x,ref y);
        Quaternion meleeAngle = getMeleeAngle(x,y);

        GameObject meleeCopy = Instantiate(melee, meleePosition, transform.rotation * meleeAngle) as GameObject;
        Physics2D.IgnoreCollision(meleeCopy.GetComponent<Collider2D>(), player.GetComponent<Collider2D>());
        meleeCopy.tag = playerNum;
        meleeCopy.transform.parent = player.transform;
    }

    private Quaternion getMeleeAngle(float x, float y)
    {
        float z = 0;

        // Case of no direction given
        if (Input.GetAxis(playerNum + "_Aim_X") == 0 && Input.GetAxis(playerNum + "_Aim_Y") == 0)
        {
            if(shootDirection == 1)
            {
                z = 0f;
            }
            else if(shootDirection == -1)
            {
                z = 180f;
            }
            else
            {
                Debug.Log("Houston we got a problem!");
            }
        }

        else if (x == 0.1f && y == 0.0f)
        {
            z = 0f;
        }

        else if (x == 0.1f && y == 0.1f)
        {
            z = 45f;
        }

        else if (x == 0.0f && y == 0.1f)
        {
            z = 90f;
        }

        else if (x == -0.1f && y == 0.1f)
        {
            z = 135f;
        }

        else if (x == -0.1f && y == 0.0f)
        {
            z = 180f;
        }

        else if (x == -0.1f && y == -0.1f)
        {
            z = 225f;
        }

        else if (x == 0.0f && y == -0.1f)
        {
            z = 270f;
        }

        else if (x == 0.1f && y == -0.1f)
        {
            z = 315f;
        }

        return Quaternion.Euler(0.0f, 0.0f, z);
    }

    private Vector2 getMeleePosition(ref float x, ref float y)
    {

        if (Input.GetAxis(playerNum + "_Aim_X") > 0)
        {
            x = 0.1f;
        }
            
        else if (Input.GetAxis(playerNum + "_Aim_X") < 0)
        {
            x = -0.1f;
        }
            
        if (Input.GetAxis(playerNum + "_Aim_Y") > 0)
        {
            y = 0.1f;
        }
           
        else if (Input.GetAxis(playerNum + "_Aim_Y") < 0)
        {
            y = -0.1f;
        }

        if (Input.GetAxis(playerNum + "_Aim_X") == 0 && (Input.GetAxis(playerNum + "_Aim_Y") == 0))
        {
            if(shootDirection  == 1)
            {
                x = 0.1f;
                y = 0.0f;
            }

            else if(shootDirection == -1)
            {
                x = -0.1f;
                y = 0.0f;
            }

            else
            {
                Debug.Log("Problem in melee attack position");
            }
        }

        Vector2 meleePosition = new Vector2((transform.position.x + x), (transform.position.y + y));

        return meleePosition;
    }

    private void newFire()
    {
        float x = 0.0f, y = 0.0f;
        float posX = 0.0f, posY = 0.0f;

        Vector2 shotPosition = getMeleePosition(ref posX, ref posY);

        Rigidbody2D bulletCopy = Instantiate(bullet, shotPosition, transform.rotation) as Rigidbody2D;
        //Physics2D.IgnoreCollision(bulletCopy.GetComponent<Collider2D>(), player.GetComponent<Collider2D>());
        bulletCopy.tag = playerNum;
        setConstantVelocity(ref x,ref y);
        bulletCopy.velocity = new Vector2(x, y) * speed;
        shootDirectionFix(bulletCopy);
        ammoCount -= 1;
    }

    private void setConstantVelocity(ref float x, ref float y)
    {
        if (Input.GetAxis(playerNum + "_Aim_X") > 0)
            if (Input.GetAxis(playerNum + "_Aim_X") > Input.GetAxis(playerNum + "_Aim_Y"))
            {
                x = 1.0f;
                y = Input.GetAxis(playerNum + "_Aim_Y");
            }
            else
            {
                y = 1.0f;
                x = Input.GetAxis(playerNum + "_Aim_X");
            }
        else if (Input.GetAxis(playerNum + "_Aim_X") < 0)
            if (Input.GetAxis(playerNum + "_Aim_X") > Input.GetAxis(playerNum + "_Aim_Y"))
            {
                y = -1.0f;
                x = Input.GetAxis(playerNum + "_Aim_X");
            }
            else
            {
                x = -1.0f;
                y = Input.GetAxis(playerNum + "_Aim_Y");
            }

        if (Input.GetAxis(playerNum + "_Aim_Y") > 0)
            if (Input.GetAxis(playerNum + "_Aim_X") > Input.GetAxis(playerNum + "_Aim_Y"))
            {
                x = 1.0f;
                y = Input.GetAxis(playerNum + "_Aim_Y");
            }
            else
            {
                y = 1.0f;
                x = Input.GetAxis(playerNum + "_Aim_X");
            }
        else if (Input.GetAxis(playerNum + "_Aim_Y") < 0)
            if (Input.GetAxis(playerNum + "_Aim_X") > Input.GetAxis(playerNum + "_Aim_Y"))
            {
                y = -1.0f;
                x = Input.GetAxis(playerNum + "_Aim_X");
            }
            else
            {
                x = -1.0f;
                y = Input.GetAxis(playerNum + "_Aim_Y");
            }
    }

    private void shootDirectionFix(Rigidbody2D bulletCopy)
    {
        if (bulletCopy.GetComponent<Rigidbody2D>().velocity.x == 0 && bulletCopy.GetComponent<Rigidbody2D>().velocity.y == 0)
        {
            bulletCopy.GetComponent<Rigidbody2D>().velocity = new Vector2(shootDirection * speed, bulletCopy.GetComponent<Rigidbody2D>().velocity.y);
        }
    }

    private void playerDirection()
    {
        if (player.GetComponent<Rigidbody2D>().velocity.x < 0)
        {
            shootDirection = -1;
        }

        else if (player.GetComponent<Rigidbody2D>().velocity.x > 0)
        {
            shootDirection = 1;
        }
        /* To set a shot with no angle to the look direction of the player!
         * 
        */
    }
}