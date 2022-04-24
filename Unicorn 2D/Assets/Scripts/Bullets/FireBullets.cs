using UnityEngine;

public class FireBullets : MonoBehaviour
{
    public Transform bulletSpawner;
    private float nextFire;
    public Animator anim;
    public ParticleSystem shootParticle;

    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time > nextFire)
        {
            nextFire = Time.time + PlayerPrefs.GetFloat("Cadence");
            anim.SetBool("Firing", true);
            shootParticle.Play(true);
            for (int i = 0; i < PoolBullets.Instance.bulletList.Count; i++)
            {
                if (PoolBullets.Instance.bulletList[i].activeInHierarchy == false)
                {
                    PoolBullets.Instance.bulletList[i].transform.position = bulletSpawner.position;
                    PoolBullets.Instance.bulletList[i].transform.rotation = transform.rotation;
                    PoolBullets.Instance.bulletList[i].SetActive(true);
                    break;
                }
                else
                {
                    if(i == PoolBullets.Instance.bulletList.Count-1)
                    {
                        GameObject newBullet = Instantiate(PoolBullets.Instance.bulletPrefab) as GameObject;
                        newBullet.transform.parent = PoolBullets.Instance.transform;
                        newBullet.SetActive(false);
                        PoolBullets.Instance.bulletList.Add(newBullet);
                    }
                }
            }
        }
        else 
        {
            anim.SetBool("Firing", false);
        }
    }

}
