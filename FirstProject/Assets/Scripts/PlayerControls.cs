using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerControls : MonoBehaviour
{

    #region Movement Variables
    public float moveSpeed = 5f;
    private float xInput;
    private float zInput;
    public CharacterController playerController;
    private Vector3 moveDirection;
    public GameObject[] abilities;
    public bool stackAbilities = true;
    #endregion
 
    #region Text Variables
    private int pickUpCount;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        pickUpCount = 0;
        playerController = GetComponent<CharacterController>();
        FindObjectOfType<GameManager>().setCountText(pickUpCount);   
    }

    // Update is called once per frame
    void Update()
    {
        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        moveDirection = new Vector3(xInput, 0, zInput);
        playerController.Move(moveDirection * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other) //A function called whenever the player enters a trigger
    {
        if (other.gameObject.CompareTag("Pickup")) //If the player hits a pickup...
        {
            pickUpCount += 1; //Increment the score
            FindObjectOfType<GameManager>().setCountText(pickUpCount); //Tell the Game Manager to update the score text
            other.gameObject.SetActive(false); //Despawn the pickup game object
        }
    }

}


