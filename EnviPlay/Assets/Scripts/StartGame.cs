using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class CategorySelection : MonoBehaviour
{
    public Toggle transportToggle;
    public Toggle locationToggle;
    public Toggle randomToggle;
    private GameManager gameManager;

    private bool transportSelected;
    private bool locationSelected;
    private bool randomSelected;
    public GameObject prefabTransport;
    public List<CarteData> lTransport;
    public GameObject prefabLieux;
    public List<CarteData> lLieux;
    public GameObject prefabRandom;
    public List<CarteData> lRandom;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
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
        if (transport)
        {
            gameManager.selectedQuestions = lTransport;
            gameManager.prefab = prefabTransport;
        }
        else if(location)
        {
            gameManager.selectedQuestions = lLieux;
            gameManager.prefab = prefabLieux;
        }
        else if(random)
        {
            gameManager.selectedQuestions = lRandom;
            gameManager.prefab = prefabRandom;
        }
        SceneManager.LoadSceneAsync("InGame");
    }

    public void OpenCreditScene()
    {
        SceneManager.LoadSceneAsync("CreditScene");
    }
}
