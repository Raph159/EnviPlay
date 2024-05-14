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
                description.text = "Dans cette cat�gorie 'Transport', vous allez comparer diff�rents modes de transport sur la base des �missions de gCO2 par individu en France. Ce calcul tient compte des �missions directes, ainsi que du cycle de vie des v�hicules, de leur fabrication � leur d�mant�lement. Il prend �galement en compte la production et la distribution de carburant et d��lectricit�. Cependant, la construction d�infrastructures telles que les routes, les voies ferr�es et les a�roports n�est pas incluse dans cette �valuation.";
                break;
            case "location":
                description.text = "Dans cette cat�gorie �Lieux�, vous allez comparer les �missions de CO2 par habitant dans diff�rents endroits tels que des villes, des pays, etc., pour une ann�e sp�cifique.";
                break;
            case "random":
                description.text = "Dans cette cat�gorie �Alimentation�, vous allez comparer des aliments connus comme �tant des sources de prot�ines couramment utilis�es. Les chiffres seront en kg de CO2 �mis par kg d�aliment produit. Pour les animaux, seule la partie consomm�e est prise en compte dans le calcul, la carcasse est donc ignor�e. Les chiffres sont en �quivalent CO2 et prennent en compte toutes les �tapes du processus de fabrication et tous les types de gaz � effet de serre.";
                break;
        }
    }
    public void playBtn()
    {
        SceneManager.LoadScene("InGame");
    }
}
