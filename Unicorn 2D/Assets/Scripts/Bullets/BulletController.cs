using UnityEngine;

public class BulletController : MonoBehaviour
{
    private Rigidbody2D rb;
   
    public Color[] BallColors;
    private int rand;
    Vector3 m_dir;
    public ParticleSystem crashParticle;
    ParticleSystem.MainModule mainModule;
    void Awake()
    {
        mainModule = crashParticle.main;
        rb = GetComponent<Rigidbody2D>();
    }

    void OnEnable()
    {
        rand = Random.Range(0, BallColors.Length);
        gameObject.GetComponent<SpriteRenderer>().color = BallColors[rand];

       // Vector3 mousePosition = Input.mousePosition;

        rb.velocity = transform.right * PlayerPrefs.GetFloat("Velocity");
    }
    void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Asteroid"))
        {
            Vector2 _wallNormal = collision.contacts[0].normal;
            m_dir = Vector2.Reflect(rb.velocity/ PlayerPrefs.GetFloat("Velocity"), _wallNormal);

            rb.velocity = m_dir * PlayerPrefs.GetFloat("Velocity");
            rand = Random.Range(0, BallColors.Length);
            mainModule.startColor = BallColors[rand];
            gameObject.GetComponent<SpriteRenderer>().color = BallColors[rand];
            crashParticle.Play(true);
        }
    
    }
}
