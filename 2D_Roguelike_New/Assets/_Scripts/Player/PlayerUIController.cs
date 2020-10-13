using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.Events;

public class PlayerUIController : MonoBehaviour
{
    public TMP_Text armorText;
    public TMP_Text magicResistText;

    public Image healthBar;
    public Image manaBar;
    public Image experienceBar;

    public Stats stats;
    public TMP_Text statsCheck;

    void Start()
    {
        healthBar = GameObject.FindGameObjectWithTag("Health").GetComponent<Image>();
        manaBar = GameObject.FindGameObjectWithTag("Mana").GetComponent<Image>();
        armorText = GameObject.FindGameObjectWithTag("Armor").GetComponent<TMP_Text>();
        magicResistText = GameObject.FindGameObjectWithTag("MagicResist").GetComponent<TMP_Text>();
        experienceBar = GameObject.FindGameObjectWithTag("Experience").GetComponent<Image>();
        //healthBar = GameObject.Find("HealthBar").GetComponent<Image>();
        //manaBar = GameObject.Find("ManaBar").GetComponent<Image>();
        //armorText = GameObject.Find("ArmorText").GetComponent<TMP_Text>();
        //magicResistText = GameObject.Find("MagicResistText").GetComponent<TMP_Text>();
        //experienceBar = GameObject.Find("ExperienceBar").GetComponent<Image>();
        stats = GetComponent<Stats>();
        stats.onHealthChanged.AddListener(UpdateHealth);
        stats.onManaChanged.AddListener(UpdateMana);
        stats.onArmorChanged.AddListener(UpdateArmor);
        stats.onMagicResistChange.AddListener(UpdateMagicResist);
        stats.onExperienceChanged.AddListener(UpdateExperience);
        stats.onEntityDead.AddListener(OnPlayerDeath);
        stats.UpdateAllStats();
    }

    public void OnPlayerDeath()
    {
        Debug.Log("Player Dead");
    }

    public void UpdateHealth()
    {
        healthBar.fillAmount = stats.percentageTotalHealth;
    }

    public void UpdateMana()
    {
        manaBar.fillAmount = stats.percentageTotalMana;
    }

    public void UpdateArmor()
    {
        armorText.text = Mathf.FloorToInt(stats.totalArmor).ToString();
    }

    public void UpdateMagicResist()
    {
        magicResistText.text = Mathf.FloorToInt(stats.totalMagicResistance).ToString();
    }

    public void UpdateExperience()
    {
        experienceBar.fillAmount = stats.percentageExperience;
    }
}
