using UnityEngine;
using UnityEngine.UI;

public class CategorySelection : MonoBehaviour
{
    public Toggle transportToggle;
    public Toggle locationToggle;
    public Toggle randomToggle;

    private bool transportSelected;
    private bool locationSelected;
    private bool randomSelected;

    // Fonction appelée lorsque le bouton Play est cliqué
    public void OnPlayButtonClicked()
    {
        // Vérifier quelles catégories ont été sélectionnées
        transportSelected = transportToggle.isOn;
        locationSelected = locationToggle.isOn;
        randomSelected = randomToggle.isOn;

        // Lancer la partie avec les catégories sélectionnées
        StartGame(transportSelected, locationSelected, randomSelected);
    }

    // Fonction pour démarrer la partie avec les catégories sélectionnées
    private void StartGame(bool transport, bool location, bool random)
    {
        // Faire quelque chose avec les catégories sélectionnées, comme charger les questions correspondantes
        Debug.Log("Démarre la partie avec les catégories sélectionnées : Transport = " + transport + ", Lieux = " + location + ", Aléatoire = " + random);
    }
}
