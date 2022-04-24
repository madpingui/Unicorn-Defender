using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class TiendaManager : MonoBehaviour
{
    public static TiendaManager Instance { set; get; }

    private int valorUpgradeCad = 100;
    private int valorUpgradeDmg = 100;
    private int valorUpgradeVel = 100;

    private int frameCad = 0;
    private int frameDmg = 0;
    private int frameVel = 0;

    public Image upgCadence;
    public Image upgDamage;
    public Image upgVelocity;

    public Sprite[] arrayCad;
    public Sprite[] arrayDmg;
    public Sprite[] arrayVel;

    private int Cadence = 10;
    private int Damage = 10;
    private int Velocity = 10;

    public TextMeshProUGUI coinTextTienda, valueCadText, valueDmgText, valueVelText;
    private float coinScore;

    private void Awake()
    {
        Instance = this;


        valorUpgradeCad = PlayerPrefs.GetInt("UpgradeCad");
        valorUpgradeDmg = PlayerPrefs.GetInt("UpgradeDmg");
        valorUpgradeVel = PlayerPrefs.GetInt("UpgradeVel");

       
        Cadence = PlayerPrefs.GetInt("Cadence");
        Damage = PlayerPrefs.GetInt("Damage");
        Velocity = PlayerPrefs.GetInt("Velocity");

        coinScore = PlayerPrefs.GetInt("Score");

        coinTextTienda.text = coinScore.ToString("0");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            coinScore += 1000;
            coinTextTienda.text = coinScore.ToString("0");
        }
    }

    private void Start()
    {
        frameCad = PlayerPrefs.GetInt("frameCad");
        frameDmg = PlayerPrefs.GetInt("frameDmg");
        frameVel = PlayerPrefs.GetInt("frameVel");

        upgCadence.sprite = arrayCad[frameCad];
        upgDamage.sprite = arrayDmg[frameDmg];
        upgVelocity.sprite = arrayVel[frameVel];

        coinTextTienda.text = coinScore.ToString("0");

        if (Cadence < 16)
        {
            valueCadText.text = valorUpgradeCad.ToString("0");
        }
        else
        {
            valueCadText.text = ("Mejorado!");
        }

        if (Damage < 16)
        {
            valueDmgText.text = valorUpgradeDmg.ToString("0");
        }
        else
        {
            valueDmgText.text = ("Mejorado!");
        }

        if (Velocity < 16)
        {
            valueVelText.text = valorUpgradeVel.ToString("0");
        }
        else
        {
            valueVelText.text = ("Mejorado!");
        }

        coinTextTienda.text = coinScore.ToString("0");
    }

    public void SumarUpgradeCadence()
    {
        if (coinScore >= valorUpgradeCad)
        {
            if(Cadence < 16)
            {
                frameCad++;
                PlayerPrefs.SetInt("frameCad", frameCad);
                upgCadence.sprite = arrayCad[frameCad];

                Cadence += 1;
                coinScore -= valorUpgradeCad;
                PlayerPrefs.SetInt("Cadence", Cadence);
                valorUpgradeCad *= 2;
                PlayerPrefs.SetInt("Score", (int)coinScore);
                coinTextTienda.text = coinScore.ToString("0");
                PlayerPrefs.SetInt("UpgradeCad", valorUpgradeCad);
                if(Cadence < 16)
                {
                    valueCadText.text = valorUpgradeCad.ToString("0");
                }
                else
                {
                    valueCadText.text = ("Mejorado!");
                }
            }
        }      
    }
    public void SumarUpgradeDamage()
    {
        if (coinScore >= valorUpgradeDmg)
        {
            if (Damage < 16)
            {
				
                frameDmg++;
                PlayerPrefs.SetInt("frameMag", frameDmg);
                upgDamage.sprite = arrayDmg[frameDmg];

                Damage += 1;
                coinScore -= valorUpgradeDmg;
                PlayerPrefs.SetInt("Damage", Damage);
                valorUpgradeDmg *= 2;
                PlayerPrefs.SetInt("Score", (int)coinScore);
                coinTextTienda.text = coinScore.ToString("0");

                PlayerPrefs.SetInt("UpgradeDmg", valorUpgradeDmg);
                if (Damage < 16)
                {
                    valueDmgText.text = valorUpgradeDmg.ToString("0");
                }
                else
                {
                    valueDmgText.text = ("Mejorado!");
                }
            }
        }
    }
    public void SumarUpgradex2()
    {
        if (coinScore >= valorUpgradeVel)
        {
            if (Velocity < 16)
            {

                frameVel++;
                PlayerPrefs.SetInt("frameX2", frameVel);
                upgVelocity.sprite = arrayVel[frameVel];

                Velocity += 1;
                coinScore -= valorUpgradeVel;
                PlayerPrefs.SetInt("Velocity", Velocity);
                valorUpgradeVel *= 2;
                PlayerPrefs.SetInt("Score", (int)coinScore);
                coinTextTienda.text = coinScore.ToString("0");

                PlayerPrefs.SetInt("Upgradex2", valorUpgradeVel);
                
                if (Velocity < 16)
                {
                    valueVelText.text = valorUpgradeVel.ToString("0");
                }
                else
                {
                    valueVelText.text = ("Mejorado!");
                }
            }
        }
    }

    public void VolverLobby()
    {
        SceneManager.LoadScene("GameScene");
    }
}
