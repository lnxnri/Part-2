using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    public List<Vector2> points;
    public float newPointThreshold = 0.2f;
    Vector2 lastPosition;
    LineRenderer lineRenderer;
    Rigidbody2D rigidbody;
    Vector2 currentPosition;
    public float speed = 1;
    public AnimationCurve landing;
    private float timerValue;
    public Sprite[] sprites = new Sprite[4];
    SpriteRenderer spriteRenderer;
    public float tooClose = 1f;
    public bool onLand = false;
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);

        rigidbody = GetComponent<Rigidbody2D>();

        transform.position = new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), 0);
        transform.Rotate(0, 0, Random.Range(0, 360));
        speed = Random.Range(1, 3);

        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprites[Random.Range(0, 3)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
