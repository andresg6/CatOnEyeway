using UnityEngine;
using System.Collections;

public class FollowGaze : MonoBehaviour {

    private GazePointDataComponent gazePointDataComponent;

	void Start () {
        gazePointDataComponent = GetComponent<GazePointDataComponent>();
	}
	
	void Update () {
        EyeXGazePoint lastGazePoint = gazePointDataComponent.LastGazePoint;

        if (lastGazePoint.IsWithinScreenBounds)
        {
            Vector2 screenSpace = lastGazePoint.Screen;
            transform.position = Camera.main.ScreenToWorldPoint(new Vector3(screenSpace.x, screenSpace.y, Camera.main.nearClipPlane));
        }
	}
}
