using UnityEngine;
using System.Collections;

public class FollowGaze : MonoBehaviour {

    public float lerpAmount;

    private EyeXHost eyeXHost;
    private GazePointDataComponent gazePointDataComponent;

	void Start () {
        eyeXHost = EyeXHost.GetInstance();
        gazePointDataComponent = GetComponent<GazePointDataComponent>();
	}
	
	void Update () {
        EyeXDeviceStatus eyeTrackerDeviceStatus = eyeXHost.EyeTrackingDeviceStatus;

        if (!Input.GetKey(KeyCode.Space))
        {
            if (eyeTrackerDeviceStatus == EyeXDeviceStatus.Tracking)
            {
                FollowGazePoint();
            }
            else
            {
                FollowMouse();
            }
        }
	}

    void FollowGazePoint()
    {
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

    void FollowMouse()
    {
        Vector3 mousePos = Input.mousePosition;

        Vector3 gazeWorldPoint = Camera.main.ScreenToWorldPoint(mousePos);
        gazeWorldPoint = new Vector3(gazeWorldPoint.x, gazeWorldPoint.y, 0.0f);
        Vector3 lerped = Vector3.Lerp(transform.position, gazeWorldPoint, lerpAmount);
        transform.position = lerped;
    }
}
