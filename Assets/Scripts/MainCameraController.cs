using UnityEngine;
using System.Collections;

public class MainCameraController : MonoBehaviour {

    public class CameraController : MonoBehaviour
    {
        public float shakeScale = 1.0f; //how far the camera shakes
        public float incrementFactor = 1.0f; //multiplier of shake added by scripts
        public float decrementFactor = 1.0f; //amount of shake decremented per frame
        public float randomIntensity = 10.0f; //how erratic the camera shakes

        private Vector3 originPosition;
        public float shakeLeft = 0.0f;

        void Start()
        {
            originPosition = transform.position;
        }

        void Update()
        {
            if (shakeLeft > 0)
            {
                //Add perlin noise to the current camera position
                float shakeX = (2 * Mathf.PerlinNoise(Time.time * randomIntensity, 0.0f) - 1) * shakeLeft * shakeScale;
                float shakeY = (2 * Mathf.PerlinNoise(0.0f, Time.time * randomIntensity) - 1) * shakeLeft * shakeScale;
                shakeLeft -= decrementFactor;

                transform.position = new Vector3(originPosition.x + shakeX, originPosition.y + shakeY, originPosition.z);

                if (shakeLeft <= 0.0f)
                {
                    shakeLeft = 0.0f;
                }
            }
            else
            {
                transform.position = new Vector3(originPosition.x, originPosition.y, originPosition.z);
            }
        }

        public void addScreenShake(float shakeAmount) //Call this to begin the screen shaking
        {
            shakeLeft += incrementFactor * shakeAmount;
        }
    }
}
