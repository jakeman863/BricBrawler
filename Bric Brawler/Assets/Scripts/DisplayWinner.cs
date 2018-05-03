using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DisplayWinner : MonoBehaviour {

    public Text winner;
    private string playerNumber;

	// Use this for initialization
	void Start ()
    {
        checkWinner();

        winner.text = playerNumber + " WINS!";
    }

    private void checkWinner()
    {
        if(GameObject.Find("P1"))
        {
            playerNumber = "Player 1";
        }

        else if (GameObject.Find("P2"))
        {
            playerNumber = "Player 2";
        }

        else if (GameObject.Find("P3"))
        {
            playerNumber = "Player 2";
        }

        else if (GameObject.Find("P4"))
        {
            playerNumber = "Player 2";
        }

        else
        {
            playerNumber = "Nobody";
        }
    }
}
