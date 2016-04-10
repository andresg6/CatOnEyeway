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
            GameObject newCar = (GameObject)Instantiate(getRandomCar(), transform.position, transform.rotation);
        }
    }

    GameObject getTotallyRandomCar()
    {
        int index = Random.Range(0, carsToSpawn.Length);
        return carsToSpawn[index];
    }

    GameObject getRandomCar()
    {
        //dumb hack for burger car spawn
        if (carsToSpawn.Length == 1)
        {
            return carsToSpawn[0];
        }

        float rand = Random.value;
        Debug.Log(rand);
        if (rand >= 0.97f)
        {
            return carsToSpawn[1]; //old man
        }
        else if (rand >= 0.90f)
        {
            return carsToSpawn[0]; //cop car 
        }
        else if (rand >= 0.50f)
        {
            return carsToSpawn[2]; //purple car
        }
        else
        {
            return carsToSpawn[3]; //red car
        }
    }

    float getRandomSpawnDelay()
    {
        return Random.Range(spawnDelayMin, spawnDelayMax);
    }
}
