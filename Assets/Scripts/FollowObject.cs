using UnityEngine;
using System.Collections;

public class FollowObject : MonoBehaviour {

    public GameObject objectToFollow;
    public float speed;

	bool facingRight = true;	// y rotation 0 = facingRight, 180 = facing left

	
	// Update is called once per frame
	void Update () {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, objectToFollow.transform.position, step);

		if (facingRight && objectToFollow.transform.position.x < transform.position.x) {
			RotateObject ();
		} else if (!facingRight && objectToFollow.transform.position.x > transform.position.x) {
			RotateObject();
		}

        GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
    }


	void RotateObject() {
		if (transform.rotation.y == 180) {
			transform.Rotate (0, 0, 0);
		} else {
			transform.Rotate (0, 180, 0);
		}
		facingRight = !facingRight;
	}
}
