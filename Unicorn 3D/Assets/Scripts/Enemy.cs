using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    private float health;
    public float expOnDeath;
    private Player player;
    private GameObject wayPoint;
    private Vector3 wayPointPos;
    private float speed = 0.5f;
    private Text healthUI;

    private float speedRot;

    private void Start()
    {
        transform.eulerAngles = Vector3.zero;
        speedRot = Random.Range(-1f, 1f);

        health = Random.Range ((int)Time.time / 8, (int)Time.time / 2);
        if(health < 1)
        {
            health = 1;
        }
        healthUI = GetComponentInChildren<Text>();
        healthUI.text = health.ToString("");
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            wayPoint = GameObject.FindGameObjectWithTag("Player");
        }
    }

    public void Die()
    {
        player.AddExperience(expOnDeath);
        GameManager.Instance.AddScore();
        Destroy(gameObject);
    }

    public void Update()
    {
        if(player != null)
        {
            wayPointPos = new Vector3(wayPoint.transform.position.x, transform.position.y, wayPoint.transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, wayPointPos, speed * Time.deltaTime);
            transform.Rotate(0, speedRot, 0,Space.Self);
        }
    }

    public void healthLeft()
    {
        health--;
        healthUI.text = health.ToString("");
        if(health <= 0)
        {
            Die();
        }
    }
}
