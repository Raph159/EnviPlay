using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    // Références aux textes et à l'image de mon UI de carte
    public Text nameText;
    public Text impactC02;
    public Image image;

    // ScriptableObject avec les informations de la carte
    public CarteData carteData; 

    void Start()
    {
        // Envoi des données du ScriptableObject aux éléments de UI
        nameText.text = carteData.nom;
        image.sprite = carteData.visuel;
        impactC02.text = carteData.impactCO2.ToString() + " gCO2";
    }
    public float GetImpactC02()
    {
        return carteData.impactCO2;
    }
}