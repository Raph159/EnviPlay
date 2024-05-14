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
                description.text = "Cette cat�gorie �value diff�rents modes de transport en se basant sur l��mission de gCO2 par individu en France. Ce calcul prend en compte les �missions directes, la phase de vie des v�hicules (de leur fabrication � leur d�mant�lement) ainsi que la production et la distribution de carburant et d��lectricit�. Cependant, la construction des infrastructures telles que les routes, les voies ferr�es et les a�roports n�est pas prise en compte.";
                break;
            case "location":
                description.text = "Vous avez choisi la cat�gorie Lieux, d�s lors, vous allez comparer les �missions de CO2 �mises par habitant de diff�rents lieux tels que des villes, des pays, ... pour une ann�e pr�cise";
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
