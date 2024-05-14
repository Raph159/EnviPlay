using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LimitSceneScript : MonoBehaviour
{
    public TextMeshProUGUI description;
    public TextMeshProUGUI nextBtn;
    private GameManager gameManager;
    public GameObject gameManagerPrefab;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        if (gameManager == null)
        {
            GameObject gameManagerObject = Instantiate(gameManagerPrefab, new Vector3((Screen.width) * (0.5f), Screen.height / 2, 0), Quaternion.identity);
            gameManager = gameManagerObject.GetComponent<GameManager>();
        }
        switch(gameManager.selectionChoice)
        {
            case "transport":
                description.text = "Cette catégorie évalue différents modes de transport en se basant sur l’émission de gCO2 par individu en France. Ce calcul prend en compte les émissions directes, la phase de vie des véhicules (de leur fabrication à leur démantèlement) ainsi que la production et la distribution de carburant et d’électricité. Cependant, la construction des infrastructures telles que les routes, les voies ferrées et les aéroports n’est pas prise en compte.";
                break;
            case "location":
                description.text = "Vous avez choisi la catégorie Lieux, dès lors, vous allez comparer les émissions de CO2 émises par habitant de différents lieux tels que des villes, des pays, ... pour une année précise";
                break;
            case "random":
                description.text = "Random";
                break;
        }
    }
    public void playBtn()
    {
        SceneManager.LoadScene("InGame");
    }
}
