using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    #region Variables
    public int maxHealth;
    public int currentHealth;
    #endregion

    private void Start()
    {
        ChangeHealth(-10);
        Debug.Log(gameObject.name + "max health:" + maxHealth);
        Debug.Log(gameObject.name + "current health:" + currentHealth);
    }

    public void ChangeHealth(int damage)
    {
        //Health goes up or down
        currentHealth = currentHealth + damage;

        if (currentHealth <= 0)
        {
            if(CompareTag("Player"))
            {
                gameObject.SetActive(false); //Despawn the player
                FindObjectOfType<GameManager>().EndGame(); //Tell the Game Manager to reset the level
            }

            else
            {
                Destroy(gameObject);
            }

        }
    }
}