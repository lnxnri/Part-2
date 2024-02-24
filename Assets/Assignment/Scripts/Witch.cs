using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Witch : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float horizontalMovement = 0f;
    public float inputHorizontal;
    public Vector2 movement;
    private Vector2 destination;
    public Animator animator;
    Rigidbody2D rb;
    Animator animators;
    bool facingRight = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animators = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        inputHorizontal = movement.x;
        movement = destination - (Vector2)transform.position;

        if (movement.magnitude < 0.1 && facingRight)
        {
           movement = Vector2.zero;      
        }
        if (movement.magnitude < 0.1 && !facingRight)
        {
            movement = Vector2.zero;
        }
        if (inputHorizontal > 0 && !facingRight)
        {
            Flip();
        }
        if (inputHorizontal < 0 && facingRight) 
        {
            Flip();
        }

    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            destination.y = transform.position.y;
        }
        animators.SetFloat("Speed", movement.magnitude);
        rb.MovePosition(rb.position + movement.normalized * horizontalMovement * Time.deltaTime);
    }
    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;
    }
}
