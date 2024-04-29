using UnityEngine;
using UnityEngine.UI;

public class LocationCard : MonoBehaviour
{
    public Text impactC02;

    void Start()
    {
        impactC02.text += " T de CO2 / habitants";
    }

}