using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CarteData", menuName = "My Game/Carte Data")]
public class CarteData : ScriptableObject
{
    public string nom;
    public Sprite visuel;
    public float impactCO2;
}