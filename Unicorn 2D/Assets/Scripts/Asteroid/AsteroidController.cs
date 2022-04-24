using UnityEngine;
using TMPro;

public class AsteroidController : MonoBehaviour
{
    private float health, initialHealth;
    public TextMeshProUGUI healthText;
    public Gradient lifeColor;
    private float speedRot;
    private Transform target;
    public float moveSpeed, actualSpeed;
    
    public SpriteRenderer asteroidSprite;
    public float maxLife;
    public ParticleSystem destroyParticle;
    public Manager manager;


    private void Start()
    {
        gameObject.transform.GetChild(0).GetComponent<Animator>().speed = Random.Range(-1.1f, 1.1f);
    }
    private void OnEnable()
    {
       
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>();
        health = Mathf.FloorToInt(Random.Range(1 + Time.timeSinceLevelLoad / 5, 3 + Time.timeSinceLevelLoad / 5));
        healthText.text = health.ToString("0");
        target = FindObjectOfType<UnicornMovement>().transform;
        initialHealth = health;
        actualSpeed = moveSpeed * (1.7f - manager.Cadence) / manager.Cadence;


    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, actualSpeed/3000);
        asteroidSprite.color = lifeColor.Evaluate(maxLife / health);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            health -= PlayerPrefs.GetFloat("Damage");
            
            if(health <= 0)
            {
                ParticleSystem particleDestroy = Instantiate(destroyParticle, transform.position, transform.rotation);

                manager.AddXp(initialHealth);
                gameObject.SetActive(false);
            }
            healthText.text = health.ToString("0");
        }
    }
}
