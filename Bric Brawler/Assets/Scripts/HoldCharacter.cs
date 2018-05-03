using UnityEngine;
using System.Collections;


public class HoldCharacter : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            col.transform.parent = gameObject.transform;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            col.transform.parent = null;
        }
    }

}
