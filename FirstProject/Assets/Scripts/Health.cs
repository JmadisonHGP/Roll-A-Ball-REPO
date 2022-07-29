using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Health : MonoBehaviour
{
    #region Variables
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    #endregion
private void Start()
    {
        ChangeHealth(-10);
        Debug.Log(gameObject.name + "max health:" + maxHealth);
        Debug.Log(gameObject.name + "current health:" + currentHealth);
        healthBar.SetMaxHealth(maxHealth);
    }
    public void ChangeHealth(int damage)
    {
        //Health goes up or down
        currentHealth = currentHealth + damage;
        healthBar.SetHealth(currentHealth);
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