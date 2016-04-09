using UnityEngine;
using System.Collections;

public class FollowMouse : MonoBehaviour {

    public float lerpAmount;

    void Start()
    {
    }

    void Update()
    {
        Vector3 mousePos = Input.mousePosition;

        Vector3 gazeWorldPoint = Camera.main.ScreenToWorldPoint(mousePos);
        gazeWorldPoint = new Vector3(gazeWorldPoint.x, gazeWorldPoint.y, 0.0f);
        Vector3 lerped = Vector3.Lerp(transform.position, gazeWorldPoint, lerpAmount);
        transform.position = lerped;
    }
}
