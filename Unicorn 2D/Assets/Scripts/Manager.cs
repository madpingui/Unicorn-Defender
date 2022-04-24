using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Manager : MonoBehaviour
{

    public float xP, xPNextLevel = 20;
    public float Cadence , Damage , Velocity;
    public int abilityPoints = 0;
    public TextMeshProUGUI levelText,abilityPointsText;
    public GameObject abilityPanel;
    // Start is called before the first frame update

    private void Awake()
    {
  
        if (!PlayerPrefs.HasKey("Cadence"))
        {
            PlayerPrefs.SetFloat("Cadence", 1.2f);
        }
        if (!PlayerPrefs.HasKey("Damage"))
        {
            PlayerPrefs.SetFloat("Damage", 1f);
        }
        if (!PlayerPrefs.HasKey("Velocity"))
        {
            PlayerPrefs.SetFloat("Velocity", 6f);
        }


    }
    void Start()
    {
        
        if (!PlayerPrefs.HasKey("Level"))
            {
             PlayerPrefs.SetInt("Level",1);
            }
        xPNextLevel = Mathf.Pow(2, PlayerPrefs.GetInt("Level")) * 10;
        Cadence = PlayerPrefs.GetFloat("Cadence");
        Damage = PlayerPrefs.GetFloat("Damage");
        Velocity = PlayerPrefs.GetFloat("Velocity");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NextLevel()
    {
        if (abilityPoints == 0 )
        {
            abilityPanel.GetComponent<Animator>().SetTrigger("Show");
        }
     
        PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
        abilityPoints++;
        abilityPointsText.text = abilityPoints.ToString("0");
        xP = 0;
        xPNextLevel = Mathf.Pow(2, PlayerPrefs.GetInt("Level")) * 10;
        levelText.text = PlayerPrefs.GetInt("Level").ToString("0");
    
    }
    public void AddXp(float value)
    {
        xP += value;
        if (xP >= xPNextLevel)
        {
            NextLevel();
        }
    }

    public void DeletePlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
    #region Stats
    public void SumarUpgradeCadence()
    {
        if(abilityPoints > 0)
        {
            abilityPoints--;
            abilityPointsText.text = abilityPoints.ToString("0");
            Cadence -= 0.05f;
            PlayerPrefs.SetFloat("Cadence", Cadence);
        }
        if (abilityPoints <= 0)
        {
            abilityPoints = 0;
            abilityPointsText.text = "";
            abilityPanel.GetComponent<Animator>().SetTrigger("Hide");
        }
    }
    public void SumarUpgradeDamage()
    {
        if (abilityPoints > 0)
        {
            abilityPoints--;
            abilityPointsText.text = abilityPoints.ToString("0");
            Damage += 1f;
            PlayerPrefs.SetFloat("Damage", Damage);
        }
        if (abilityPoints <= 0)
        {
            abilityPoints = 0;
            abilityPointsText.text = "";
            abilityPanel.GetComponent<Animator>().SetTrigger("Hide");
        }
    }
    public void SumarUpgradex2()
    {
        if (abilityPoints > 0)
        {
            abilityPoints--;
            abilityPointsText.text = abilityPoints.ToString("0");
            Velocity += 1f;
            PlayerPrefs.SetFloat("Velocity", Velocity);
        }
        
        if(abilityPoints <= 0)
        {
            abilityPoints = 0;
            abilityPointsText.text = "";
            abilityPanel.GetComponent<Animator>().SetTrigger("Hide");
        }
    }
    #endregion

}

