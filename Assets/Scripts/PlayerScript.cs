using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{

    private Rigidbody2D rb;
    private CircleCollider2D coll;
    
    

    [SerializeField] private Vector2 MoveForce = new Vector2(100,0);
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        coll = this.gameObject.GetComponent<CircleCollider2D>();
        radius = coll.radius;
        
    }

    public LayerMask groundLayer;

    private void Update()
    {   
        RaycastHit2D hit;
        hit = Physics2D.Raycast(transform.position, new Vector2(0f, -1f), 0.7f, groundLayer);
        Debug.DrawRay(transform.position, new Vector2(0f, -1f), Color.red);

        if (!canJump && hit)
        {
            canJump = true;
        }
        if (!hit) 
            canJump = false;

        
    }

    void FixedUpdate()
    {
        Move(movementVector.x);
    }


    private float radius;
    private int MoveDirection;

    private void Move(float direction)
    {
        rb.AddForceAtPosition(MoveForce * direction, new Vector2(transform.position.x , transform.position.y + radius));
    }


    private Vector2 movementVector;

    void OnMove(InputValue input)
    {
        Debug.Log("MOVE");
        movementVector = input.Get<Vector2>();
    }


    [SerializeField] float JumpForce = 100f;
    public bool canJump = true;

    void OnJump(InputValue input)
    {
        if (canJump && rb.linearVelocityX * movementVector.x >= 0)
        {
            rb.AddForce(new Vector2(JumpForce * 0.85f * movementVector.x, JumpForce * 0.5f), ForceMode2D.Impulse);
            canJump = false;
        }
    }
    


}
