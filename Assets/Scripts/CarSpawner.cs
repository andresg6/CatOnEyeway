using UnityEngine;
using System.Collections;

public class CarSpawner : MonoBehaviour {
    public GameObject[] carsToSpawn;

    public float spawnDelay;

	// Use this for initialization
	void Start () {
        StartCoroutine("SpawnCar");
	}
	
	// Update is called once per frame
	void Update () {

	}

    IEnumerator SpawnCar()
    {
        while (true)
        {
            Debug.Log("SpawnCar");
            GameObject newCar = (GameObject)Instantiate(getRandomCar(), transform.position, transform.rotation);
            CarMovement carMove = newCar.GetComponent<CarMovement>();
            carMove.speed = -10.0f;
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    GameObject getRandomCar()
    {
        int index = Random.Range(0, carsToSpawn.Length);
        return carsToSpawn[index];
    }
}
