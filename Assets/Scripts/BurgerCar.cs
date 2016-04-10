using UnityEngine;
using System.Collections;

public class BurgerCar : MonoBehaviour {
    public Vector2 direction; //should be normalized
    public float speed;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        
        transform.Translate(direction.normalized * speed * Time.deltaTime);
        rb.velocity = new Vector2(0,0);
    }


    void OnCollisionStay2D(Collision2D other)
    {
        if(other.gameObject.tag == "Wall") //Reflect direction along the wall
        {
            direction = Vector2.Reflect(direction, new Vector2(0, 1)); //Assuming walls always collide from top or bottom
        }
    }
}
