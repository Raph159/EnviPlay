using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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
                description.text = "Dans cette catégorie 'Transport', vous allez comparer différents modes de transport sur la base des émissions de gCO2 par individu en France. Ce calcul tient compte des émissions directes, ainsi que du cycle de vie des véhicules, de leur fabrication à leur démantèlement. Il prend également en compte la production et la distribution de carburant et d'électricité. Cependant, la construction d'infrastructures telles que les routes, les voies ferrées et les aéroports n'est pas incluse dans cette évaluation.";
                break;
            case "location":
                description.text = "Dans cette catégorie 'Lieux', vous allez comparer les émissions de CO2 par habitant dans différents endroits tels que des villes, des pays, etc., pour une année spécifique.";
                break;
            case "random":
                description.text = "Dans cette catégorie 'Alimentation', vous allez comparer des aliments connus comme étant des sources de protéines couramment utilisées. Les chiffres seront en kg de CO2 émis par kg d'aliment produit. Pour les animaux, seule la partie consommée est prise en compte dans le calcul, la carcasse est donc ignorée. Les chiffres sont en équivalent CO2 et prennent en compte toutes les étapes du processus de fabrication et tous les types de gaz à effet de serre.";
                break;
        }
    }
    public void playBtn()
    {
        SceneManager.LoadScene("InGame");
    }
}
