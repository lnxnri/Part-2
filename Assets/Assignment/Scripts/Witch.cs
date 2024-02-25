using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Witch : MonoBehaviour
{
  
    public float horizontalMovement = 0f;
    public float inputHorizontal;
    public Vector2 movement;
    private Vector2 destination;
    public Animator animator;
    Rigidbody2D rb;
    Animator animators;
    bool facingRight = true;
    public AnimationCurve movementCurve;

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
    //if character is not moving, stand still
        if (movement.magnitude < 0.1 && facingRight)
        {
           movement = Vector2.zero;      
        }
        if (movement.magnitude < 0.1 && !facingRight)
        {
            movement = Vector2.zero;
        }
        //if character is moving right or left, flip to according direction
        if (inputHorizontal > 0 && !facingRight)
        {
            Flip();
        }
        if (inputHorizontal < 0 && facingRight) 
        {
            Flip();
        }
        float curveValue = movementCurve.Evaluate(Time.time); // Evaluate the curve at the current time
        movement *= curveValue;

    }
    private void Update()
    {
        //move character with left click
        if (Input.GetMouseButtonDown(0))
        {
            destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            destination.y = transform.position.y;
        }
        //attack with right click
        if (Input.GetMouseButtonDown(1))
        {
            animators.SetTrigger("attack");
        }
        animators.SetFloat("Speed", movement.magnitude);
        rb.MovePosition(rb.position + movement.normalized * horizontalMovement * Time.deltaTime);
    }
   
    //function to check which way character is facing
    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;
    }
}
