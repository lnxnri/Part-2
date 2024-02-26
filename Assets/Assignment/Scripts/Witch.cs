using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class Witch : MonoBehaviour
{
  
    public float horizontalMovement = 0f;
    private Vector2 movement;
    private Vector2 destination;
    public Animator animator;
    Rigidbody2D rb;
    Animator animators;
    public AnimationCurve movementCurve;
    private float yPosition = -4f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animators = GetComponent<Animator>();
        destination.y = yPosition;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movement = destination - (Vector2)transform.position;
  //  if character is not moving, stand still
        if (movement.magnitude < 0.1)
        {
           movement = Vector2.zero;       
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
   
   
}
