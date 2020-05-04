using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using System;
[RequireComponent(typeof(CharacterController))]
//[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : Character
{
    
    public CharacterController controller;
    //public Rigidbody _rb;
    public float _moveHorizontal;
    public float _moveForward;
    public float Health = 100;
    public float MaxHealth = 100;
    public Vector3 moveDirection;
    

    public void TakeDamage(float damage)
    {
        Health -= damage;
    }
    
    void Start()
    {
        controller = this.gameObject.GetComponent<CharacterController>();
        if (KeyBindManager.keys.Count < 1)
        {
            //KeyBindManager.keys.Add(baseSetup[i].keyName, (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString(baseSetup[i].keyName, baseSetup[i].defaultKey)));
            KeyBindManager.keys.Add("Forward", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Forward", "W")));
            KeyBindManager.keys.Add("Backward", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Backward", "S")));
            KeyBindManager.keys.Add("Left", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Left", "A")));
            KeyBindManager.keys.Add("Right", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Right", "D")));
        }


    }
    void Update()
    {
        //_moveHorizontal = Input.GetAxis("Horizontal");

        //_moveForward = Input.GetAxis("Vertical");
        float horizontal = 0;
        float vertical = 0;
        if (Input.GetKey(KeyBindManager.keys["Forward"]))
        {
            vertical++;
        }

        if (Input.GetKey(KeyBindManager.keys["Backward"]))
        {
            vertical--;
        }

        if (Input.GetKey(KeyBindManager.keys["Left"]))
        {
            horizontal--;
        }

        if (Input.GetKey(KeyBindManager.keys["Right"]))
        {
            horizontal++;
        }



        moveDirection = transform.TransformDirection(new Vector3(horizontal, 0, vertical));
        moveDirection *= speed;


        controller.Move(moveDirection * Time.deltaTime);

        if (Health <= 0)
        {
            Destroy(gameObject, 5f);
        }
       
    }
    private void FixedUpdate()
    {

        //Vector3 movement = new Vector3(_moveHorizontal, 0, _moveForward);
        //_rb.AddForce(movement * speed);
        

    }
    




}
