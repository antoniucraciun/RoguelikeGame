using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "SkillData", menuName = "Skills", order = 1)]
[System.Serializable]
public class SkillData : ScriptableObject
{
    public Sprite icon;

    public string skillName;
    [TextArea]
    public string skillDescription;

    public float cooldown;
    public float currentCooldown;

    public bool isPassive;

    public UnityEvent onCast = new UnityEvent();
}
