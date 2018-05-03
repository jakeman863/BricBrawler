using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    private int controllerCount;
    private bool gameOver;
    private int playersAlive;
    public GameObject gameOverScreen;
    public GameObject gameOverController;
    public GameObject pauseScreen;
    public GameObject pauseController; 

    public GameObject P1, P2, P3, P4;

	// Use this for initialization
	void Start ()
    {
        Time.timeScale = 1;
        gameOver = false;

        getControllers();
        activatePlayers();
	}
	
	// Update is called once per frame
	void Update ()
    {
        checkPlayersAlive();
        gameOverCheck();

		if(gameOver)
        {
            Time.timeScale = 0;
            gameOverScreen.SetActive(true);
        }

        if(Input.GetButtonUp("Pause") && !gameOver)
        {
            if(Time.timeScale == 1)
            {
                gameOverController.SetActive(false);
                pauseController.SetActive(true);
                Time.timeScale = 0;
                pauseScreen.SetActive(true);
            }

            else
            {
                gameOverController.SetActive(true);
                Time.timeScale = 1;
                pauseScreen.SetActive(false);
                pauseController.SetActive(false);
            }
        }
	}

    // Gets the number of connected controllers and sets it to controllerCount
    private void getControllers()
    {
        string[] controllers = Input.GetJoystickNames();
        for (int i = 0; i < controllers.Length; i++)
        {
            if (controllers[i].Length > 0)
            {
                controllerCount += 1;
            }
        }
    }

    // Activates the players according to controllerCount
    private void activatePlayers()
    {
        if (controllerCount == 0)
        {
            Destroy(P1);
            Destroy(P2);
            Destroy(P3);
            Destroy(P4);
        }
        else if (controllerCount == 1)
        {
            Destroy(P2);
            Destroy(P3);
            Destroy(P4);
        }

        else if (controllerCount == 2)
        {
            Destroy(P3);
            Destroy(P4);
        }

        else if (controllerCount == 3)
        {
            Destroy(P4);
        }
    }

    // Checks if players are still alive, if only one left then set gameOver to true
    private void checkPlayersAlive()
    {
        playersAlive = 0;

        if(P1)
        {
            playersAlive += 1;
        }

        if (P2)
        {
            playersAlive += 1;
        }

        if (P3)
        {
            playersAlive += 1;
        }

        if (P4)
        {
            playersAlive += 1;
        }
    }

    private void gameOverCheck()
    {
        if(playersAlive == 1)
        {
            gameOver = true;
        }
    }

}
