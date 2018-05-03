using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HealthGUI : MonoBehaviour {

    public GameObject player;
    public Text healthText;
    public GameObject obj;
    private int playerAmmo;
    private bool canMelee;

    // Use this for initialization
    IEnumerator Start ()
    {
        // Give time to let the game remove players that aren't there
        yield return new WaitForSeconds(0.1f);

        if (obj.name == "P1_Health")
        {
            if (player != null)
                healthText.text = "Player 1 \r\n" + player.GetComponent<DamageController>().damageTaken + "%";
            else
                Destroy(obj);
        }

        else if (obj.name == "P2_Health")
        {
            if (player != null)
                healthText.text = "Player 2 \r\n" + player.GetComponent<DamageController>().damageTaken + "%";
            else
                Destroy(obj);
        }

        else if (obj.name == "P3_Health")
        {
            if (player != null)
                healthText.text = "Player 3 \r\n" + player.GetComponent<DamageController>().damageTaken + "%";
            else
                Destroy(obj);
        }

        else if (obj.name == "P4_Health")
        {
            if (player != null)
                healthText.text = "Player 4 \r\n" + player.GetComponent<DamageController>().damageTaken + "%";
            else
                Destroy(obj);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (player != null)
        {
            playerAmmo = player.GetComponent<Attack>().ammoCount;
            canMelee = player.GetComponent<Attack>().canMelee;
        }

        if (player != null && obj.name == "P1_Health")
        {
            healthText.text = "Player 1 \r\n" + player.GetComponent<DamageController>().damageTaken + "%";
            ammoGUI();
            meleeGUI();
        }

        if (player != null && obj.name == "P2_Health")
        {
            healthText.text = "Player 2 \r\n" + player.GetComponent<DamageController>().damageTaken + "%";
            ammoGUI();
            meleeGUI();
        }

        if (player != null && obj.name == "P3_Health")
        {
            healthText.text = "Player 3 \r\n" + player.GetComponent<DamageController>().damageTaken + "%";
            ammoGUI();
            meleeGUI();
        }

        if (player != null && obj.name == "P4_Health")
        {
            healthText.text = "Player 4 \r\n" + player.GetComponent<DamageController>().damageTaken + "%";
            ammoGUI();
            meleeGUI();
        }

        if (player == null && obj.name == "P1_Health")
        {
            healthText.text = "Player 1 \r\n" + " DEAD";
        }

        if (player == null && obj.name == "P2_Health")
        {
            healthText.text = "Player 2 \r\n" + " DEAD";
        }

        if (player == null && obj.name == "P3_Health")
        {
            healthText.text = "Player 3 \r\n" + " DEAD";
        }

        if (player == null && obj.name == "P4_Health")
        {
            healthText.text = "Player 4 \r\n" + " DEAD";
        }
    }

    private void meleeGUI()
    {
        if(canMelee)
        {
            obj.transform.Find("Melee").GetComponent<Toggle>().isOn = true;
        }
        else
        {
            obj.transform.Find("Melee").GetComponent<Toggle>().isOn = false;
        }
    }

    private void ammoGUI()
    {
        if(playerAmmo == 5)
        {
            obj.transform.Find("Bullet1").GetComponent<Toggle>().isOn = true;
            obj.transform.Find("Bullet2").GetComponent<Toggle>().isOn = true;
            obj.transform.Find("Bullet3").GetComponent<Toggle>().isOn = true;
            obj.transform.Find("Bullet4").GetComponent<Toggle>().isOn = true;
            obj.transform.Find("Bullet5").GetComponent<Toggle>().isOn = true;
        }

        else if (playerAmmo == 4)
        {
            obj.transform.Find("Bullet1").GetComponent<Toggle>().isOn = true;
            obj.transform.Find("Bullet2").GetComponent<Toggle>().isOn = true;
            obj.transform.Find("Bullet3").GetComponent<Toggle>().isOn = true;
            obj.transform.Find("Bullet4").GetComponent<Toggle>().isOn = true;
            obj.transform.Find("Bullet5").GetComponent<Toggle>().isOn = false;
        }

        else if (playerAmmo == 3)
        {
            obj.transform.Find("Bullet1").GetComponent<Toggle>().isOn = true;
            obj.transform.Find("Bullet2").GetComponent<Toggle>().isOn = true;
            obj.transform.Find("Bullet3").GetComponent<Toggle>().isOn = true;
            obj.transform.Find("Bullet4").GetComponent<Toggle>().isOn = false;
            obj.transform.Find("Bullet5").GetComponent<Toggle>().isOn = false;
        }

        else if (playerAmmo == 2)
        {
            obj.transform.Find("Bullet1").GetComponent<Toggle>().isOn = true;
            obj.transform.Find("Bullet2").GetComponent<Toggle>().isOn = true;
            obj.transform.Find("Bullet3").GetComponent<Toggle>().isOn = false;
            obj.transform.Find("Bullet4").GetComponent<Toggle>().isOn = false;
            obj.transform.Find("Bullet5").GetComponent<Toggle>().isOn = false;
        }

        else if (playerAmmo == 1)
        {
            obj.transform.Find("Bullet1").GetComponent<Toggle>().isOn = true;
            obj.transform.Find("Bullet2").GetComponent<Toggle>().isOn = false;
            obj.transform.Find("Bullet3").GetComponent<Toggle>().isOn = false;
            obj.transform.Find("Bullet4").GetComponent<Toggle>().isOn = false;
            obj.transform.Find("Bullet5").GetComponent<Toggle>().isOn = false;
        }

        else if (playerAmmo == 0)
        {
            obj.transform.Find("Bullet1").GetComponent<Toggle>().isOn = false;
            obj.transform.Find("Bullet2").GetComponent<Toggle>().isOn = false;
            obj.transform.Find("Bullet3").GetComponent<Toggle>().isOn = false;
            obj.transform.Find("Bullet4").GetComponent<Toggle>().isOn = false;
            obj.transform.Find("Bullet5").GetComponent<Toggle>().isOn = false;
        }

        else
        {
            Debug.Log("HOUSTON WE GOT A PROBLEM! - HealthGUI");
        }
    }
}
