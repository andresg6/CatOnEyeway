using UnityEngine;
using System.Collections;

public class FollowGaze : MonoBehaviour {

    public float lerpAmount;

    private GazePointDataComponent gazePointDataComponent;

	void Start () {
        gazePointDataComponent = GetComponent<GazePointDataComponent>();
	}
	
	void Update () {
        EyeXGazePoint lastGazePoint = gazePointDataComponent.LastGazePoint;

        if (lastGazePoint.IsWithinScreenBounds)
        {
            Vector2 screenSpace = lastGazePoint.Screen;

            Vector3 gazeWorldPoint = Camera.main.ScreenToWorldPoint(new Vector3(screenSpace.x, screenSpace.y, Camera.main.nearClipPlane));
            gazeWorldPoint = new Vector3(gazeWorldPoint.x, gazeWorldPoint.y, 0.0f);
            Vector3 lerped = Vector3.Lerp(transform.position, gazeWorldPoint, lerpAmount);
            transform.position = lerped;
        }
	}
}
