using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Stats : MonoBehaviour
{
    public EntityStats playerStats;

    public float health;
    public float totalHealth;
    public float percentageTotalHealth;
    public float healthBeforeDamage;
    public UnityEvent onHealthChanged = new UnityEvent();
    public UnityEvent onEntityDead = new UnityEvent();

    public float mana;
    public float totalMana;
    public float percentageTotalMana;
    public float manaBeforeUse;
    public UnityEvent onManaChanged = new UnityEvent(); 

    public float armor;
    public float totalArmor;
    public float damageResistancePercent;
    public UnityEvent onArmorChanged = new UnityEvent();

    public float magicResistance;
    public float totalMagicResistance;
    public float magicResistancePercent;
    public UnityEvent onMagicResistChange = new UnityEvent();

    public int level;
    public float experience;
    public float expToNextLevel;
    public float percentageExperience;
    public UnityEvent onExperienceChanged = new UnityEvent();
    public UnityEvent onLevelUp = new UnityEvent();

    void Awake()
    {
        //load stats
        health = playerStats.health;
        mana = playerStats.mana;
        armor = playerStats.armor;
        magicResistance = playerStats.magicResist;
        experience = playerStats.experience;
        level = playerStats.level;

        UpdateTotalHealth();
        UpdateTotalMana();
        UpdateTotalArmor();
        UpdateTotalMagicResist();
        UpdateExperience();
    }

    float timer = 2f;
    private void Update()
    {
        //timer -= Time.deltaTime;
        //if (timer < 0)
        //{
        //    TestTakeDamage();
        //    TestUseMana();
        //    TestExperience();
        //    timer = 2f;
        //}
        
    }

    void TestTakeDamage()
    {
        TakeDamage(StatType.Physic, 20);
    }

    void TestUseMana()
    {
        UseMana(20f);
    }

    void TestExperience()
    {
        ChangeExperience(1f);
    }

    public void TakeDamage(StatType type, float amount)
    {
        switch (type)
        {
            case StatType.Physic:
                totalHealth -= (amount - amount * damageResistancePercent);
                break;
            case StatType.Magic:
                totalHealth -= (amount - amount * magicResistancePercent);
                break;
            case StatType.True:
                totalHealth -= amount;
                break;
            default:
                break;
        }
        percentageTotalHealth = totalHealth / healthBeforeDamage;
        CheckIfEntityDead();
        onHealthChanged.Invoke();
    }

    public void UseMana(float amount)
    {
        totalMana -= amount;
        percentageTotalMana = totalMana / manaBeforeUse;
        onManaChanged.Invoke();
    }

    public void ChangeExperience(float amount)
    {
        float totalExp = experience + amount;
        if (totalExp > expToNextLevel)
        {
            experience = totalExp - expToNextLevel;
            level++;
            expToNextLevel = 5 + level * 5;
            percentageExperience = experience / expToNextLevel;
            onExperienceChanged.Invoke();
            onLevelUp.Invoke();
        }
        else
        {
            experience += amount;
            percentageExperience = experience / expToNextLevel;
            onExperienceChanged.Invoke();
        }

    }

    void UpdateTotalHealth()
    {
        totalHealth = health;
        healthBeforeDamage = totalHealth;
        percentageTotalHealth = totalHealth / healthBeforeDamage;
    }

    void UpdateTotalMana()
    {
        totalMana = mana;
        manaBeforeUse = totalMana;
        percentageTotalMana = totalMana / manaBeforeUse;
    }

    void UpdateTotalArmor()
    {
        totalArmor = armor;
        damageResistancePercent = totalArmor / (totalArmor + 100);
    }

    void UpdateTotalMagicResist()
    {
        totalMagicResistance = magicResistance;
        magicResistancePercent = totalMagicResistance / (totalMagicResistance + 100);
    }

    void UpdateExperience()
    {
        expToNextLevel = 5 + level * 5;
    }

    void CheckIfEntityDead()
    {
        if (totalHealth <= 0)
            onEntityDead.Invoke();
    }

    public void UpdateAllStats()
    {
        onHealthChanged.Invoke();
        onManaChanged.Invoke();
        onArmorChanged.Invoke();
        onMagicResistChange.Invoke();
        onExperienceChanged.Invoke();
        onLevelUp.Invoke();
    }
}