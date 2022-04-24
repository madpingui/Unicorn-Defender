using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Transform[] prefabsAsteroids;

    public float timeSpawn;
    private int zone;

    void Update()
    {
        if(Time.timeSinceLevelLoad > timeSpawn)
        {
            timeSpawn += 5;

            if (zone >= prefabsAsteroids.Length)
                zone = 0;

            for (int i = 0; i < prefabsAsteroids[zone].childCount; i++)
                AsteroidRespawn(prefabsAsteroids[zone].GetChild(i).transform.position);

            zone++;
        }
    }

    public void AsteroidRespawn(Vector3 spawnPos)
    {
        for (int j = 0; j < PoolAsteroid.Instance.asteroidList.Count; j++)
        {
            if (PoolAsteroid.Instance.asteroidList[j].activeInHierarchy == false)
            {
                PoolAsteroid.Instance.asteroidList[j].transform.position = spawnPos;
                PoolAsteroid.Instance.asteroidList[j].SetActive(true);
                break;
            }
            else
            {
                if (j == PoolAsteroid.Instance.asteroidList.Count - 1)
                {
                    GameObject newAsteroid = Instantiate(PoolAsteroid.Instance.asteroidPrefab) as GameObject;
                    newAsteroid.transform.parent = PoolAsteroid.Instance.transform;
                    newAsteroid.SetActive(false);
                    PoolAsteroid.Instance.asteroidList.Add(newAsteroid);
                }
            }
        }
    }
}
