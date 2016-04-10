using UnityEngine;
using System.Collections;

public class CarSpawner : MonoBehaviour {
    public GameObject[] carsToSpawn;

    public float spawnDelayMin;
    public float spawnDelayMax;

	void Start () {
        StartCoroutine("SpawnCar");
	}
	
	void Update () {

	}

    IEnumerator SpawnCar()
    {
        while (true)
        {
            yield return new WaitForSeconds(getRandomSpawnDelay());
            Debug.Log("SpawnCar");
            GameObject newCar = (GameObject)Instantiate(getRandomCar(), transform.position, transform.rotation);
            CarMovement carMove = newCar.GetComponent<CarMovement>();
            carMove.speed = -10.0f;
        }
    }

    GameObject getRandomCar()
    {
        int index = Random.Range(0, carsToSpawn.Length);
        return carsToSpawn[index];
    }

    float getRandomSpawnDelay()
    {
        return Random.Range(spawnDelayMin, spawnDelayMax);
    }
}
