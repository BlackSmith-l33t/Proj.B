using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PotionData.asset", menuName = "Potion/PotionData"]
public class PotionData : ScriptableObject
{
    new public string name;
    public string Description;

    public int resilience; // Hp 회복력
    public Sprite icon;
    public Potion prefab;
}
