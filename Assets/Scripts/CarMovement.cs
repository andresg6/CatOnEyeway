using UnityEngine;
using System.Collections;

public class CarMovement : MonoBehaviour {

    public float speed;

    private Rigidbody2D rigid;

	// Use this for initialization
	void Start () {
        rigid = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
    }

    void FixedUpdate()
    {
        rigid.velocity = new Vector2(speed, rigid.velocity.y);
    }
}
