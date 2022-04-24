using UnityEngine;

public class SpawnerAsteroid : MonoBehaviour {

    public int hazardCount;

	void Start ()
    {
        InvokeRepeating("AsteroidRespawn", 1, 1);
    }

    public void AsteroidRespawn()
    {
        for (int i = 0; i < hazardCount; i++)
        {
            int side = Random.Range(1, 5);
            Vector3 randomSpawn = Vector3.zero;
            switch (side)
            {
                case 1:
                    randomSpawn = new Vector3(Random.Range(-3.5f, -5f), Random.Range(-5f, 5f), 0f);
                    break;
                case 2:
                    randomSpawn = new Vector3(Random.Range(-3f, 3f), Random.Range(5.5f, 7f), 0f);
                    break;
                case 3:
                    randomSpawn = new Vector3(Random.Range(3.5f, 5f), Random.Range(-5f, 5f), 0f);
                    break;
                case 4:
                    randomSpawn = new Vector3(Random.Range(-3f, 3f), Random.Range(-5.5f, -7f), 0f);
                    break;
            }

            for (int j = 0; j < PoolAsteroid.Instance.asteroidList.Count; j++)
            {
                if (PoolAsteroid.Instance.asteroidList[j].activeInHierarchy == false)
                {
                    PoolAsteroid.Instance.asteroidList[j].transform.position = randomSpawn;
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
}
