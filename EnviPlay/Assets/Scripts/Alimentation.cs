using UnityEngine;
using UnityEngine.UI;

public class AlimentationCard : MonoBehaviour
{
    public Text impactC02;

    void Start()
    {
        impactC02.text += " kgCO2 / kg";
    }
}