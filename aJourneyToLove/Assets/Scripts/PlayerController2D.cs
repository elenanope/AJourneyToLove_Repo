using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController2D : MonoBehaviour
{
    [Header("Movement Parameters")]
    [SerializeField] float speed = 10;
    [Header("Autoreferences")]
    [SerializeField] Rigidbody2D playerRb;
    [SerializeField] Animator playerAnim;
    [SerializeField] PlayerInput playerInput;
    Vector2 moveInput;
    [SerializeField] bool isFacingRight;

    private void Awake()
    {
        //input = GetComponent<PlayerInputHandler>();
        playerAnim = GetComponent<Animator>();
        playerRb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //if(GameManager.Instance.currentGameState!=GameManager.GameState.gameStarted) speed = 0; gameObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        playerRb.velocity = new Vector3(moveInput.x * speed, moveInput.y * speed, 0);
        //hacer mov diagonal
    }
    

    //añadir void Respawn() y que cuando respawnee, depende de donde, reaparezcan los enems
    public void OnMove(InputAction.CallbackContext context)
    {
       if(context.started)
        {
            speed = 8;
            moveInput = context.ReadValue<Vector2>();
            playerAnim.SetBool("Walk", true);
        }
       if(context.canceled)
        {
            speed = 0;
            playerAnim.SetBool("Walk", false);
        }
            
    }
    public void OnAttack(InputAction.CallbackContext context)
    {
       if(context.started)
        {
            playerAnim.SetTrigger("Attack");
        }   
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            playerAnim.SetTrigger("Hit");
            //Respawn();
        }
        if(collision.gameObject.CompareTag("PickUp"))
        {
            GameManager.Instance.memories += 1;
            collision.gameObject.SetActive(false);
        }
    }

}
