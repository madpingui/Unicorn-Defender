using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedSpawn : MonoBehaviour {

    [SerializeField]
    private GameObject spawnee;

    private int contador;

    private bool stopSpawning = false;

    [SerializeField]
    private float spawnTime;
    [SerializeField]
    private float spawnDelay;

    public float r = 5f;

    // Use this for initialization
    void Start ()
    {
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
	}

    public void SpawnObject()
    {
        int spawnedObjs = 0;

        while(spawnedObjs < 3)
        {
            float angle = Random.Range(0, Mathf.PI * 2);
            Vector3 pos3d = new Vector3(Mathf.Sin(angle) * r, 0, Mathf.Cos(angle) * r);

            GameObject enemmigo = Instantiate(spawnee, pos3d, transform.rotation);
            enemmigo.transform.parent = transform.parent;
            spawnedObjs++;
        }

        contador++;
        if (stopSpawning)
        {
            CancelInvoke("SpawnObject");
        }

        if(contador >= 5)
        {
            spawnDelay -= 0.2f;
            if(spawnDelay < 0.5f)
            {
                spawnDelay = 0.5f;
            }
        }
    }
}
