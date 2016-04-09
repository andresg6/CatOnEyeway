using UnityEngine;
using System.Collections;

public class FollowObject : MonoBehaviour {

    public GameObject objectToFollow;
    public float speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, objectToFollow.transform.position, step);
        GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
    }
}
