using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LimitSceneScript : MonoBehaviour
{
    public Text description;
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
                description.text = "transport";
                break;
            case "location":
                description.text = "Vous avez choisi la cat�gorie Lieux, d�s lors, vous allez comparer les �missions de CO2 �mises par habitant de diff�rents lieux tels que des villes, des pays, ...";
                break;
            case "random":
                description.text = "random";
                break;
        }
    }
    public void playBtn()
    {
        SceneManager.LoadScene("InGame");
    }
}
