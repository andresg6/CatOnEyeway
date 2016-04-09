using UnityEngine;
using System.Collections;

public class BurgerCar : MonoBehaviour {
    public Vector2 direction; //should be normalized
    public float speed;

    void FixedUpdate()
    {
        transform.Translate(direction.normalized * speed * Time.deltaTime);
    }


    void OnCollisionStay2D(Collision2D other)
    {
        Debug.Log("Durger hit something, panic panic!");
        if(other.gameObject.tag == "Wall") //Reflect direction along the wall
        {
            Debug.Log("Burger hit a wall, call the ambulance");
            direction = Vector2.Reflect(direction, new Vector2(0, 1)); //Assuming walls always collide from top or bottom
        }
    }
}
