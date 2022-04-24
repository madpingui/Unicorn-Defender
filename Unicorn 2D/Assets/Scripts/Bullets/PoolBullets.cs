using System.Collections.Generic;
using UnityEngine;

public class PoolBullets : MonoBehaviour
{
    public GameObject bulletPrefab;
    public int spawnCount;
    [HideInInspector] public List<GameObject> bulletList;

    public static PoolBullets Instance { private set; get;}

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
            GameObject bullet = Instantiate(bulletPrefab);
            bulletList.Add(bullet);
            bullet.transform.parent = transform;
            bullet.SetActive(false);
        }
    }
}
