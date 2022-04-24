using System.Collections.Generic;
using UnityEngine;

public class PoolAsteroid : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public int spawnCount;
    [HideInInspector] public List<GameObject> asteroidList;

    public static PoolAsteroid Instance { private set; get;}

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            GameObject asteroid = Instantiate(asteroidPrefab);
            asteroidList.Add(asteroid);
            asteroid.transform.parent = transform;
            asteroid.SetActive(false);
        }
    }
}
