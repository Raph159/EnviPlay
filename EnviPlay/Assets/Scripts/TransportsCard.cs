using UnityEngine;
using UnityEngine.UI;

public class TransportsCard : MonoBehaviour
{
    public Text impactC02;

    void Start()
    {
        impactC02.text += " gCO2 / km et passager";
    }
}