using UnityEngine;
using System.Collections;

public class CarDestroyer : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Car"))
        {
            Destroy(other.gameObject);
        }
    }
}
