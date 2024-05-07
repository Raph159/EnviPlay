using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonPress : MonoBehaviour
{
    public List<CarteData> cartes; //Liste des cartes
    private GameManager gameManager; //Object contenant les cartes de la bonne catégorie
    private GameObject carte1; // Carte 1 active dans le jeu
    private GameObject carte2; // Carte 2 active dans le jeu
    private GameObject carte3; // Carte 3 active dans le jeu
    private GameObject cartePrefab; // Prefab pour instancier les cartes
    public GameObject parentObject; // Game Object parent pour définir le placement des cartes
    public Button boutonPlus; // Bouton plus
    public Button boutonMoins; // Bouton moins 
    public TextMeshProUGUI scoreText;
    public GameObject endgame;
    public GameObject boutonRetry;
    public GameObject boutonBackMenu;
    //Mouvement
    private float vitesseDeplacement; // Vitesse de déplacement des cartes
    private float distanceDeplacement; // Distance de déplacement égale à la largeur d'une carte
    //Position
    private float positionInitialeX = (Screen.width)*(0.25f); //Position x carte 1
    private Vector3 positionInit3 = new ((Screen.width)*(1.25f),Screen.height/2,0); //Posiition initiale carte 3
    //Bool
    private bool plus = false; // Savoir si le bouton plus est activé
    private bool moins = false; // Savoir si le bouton moins est activé
    private bool carte33Cree = false; // Savoir si la carte3 a été crée
    private bool derniereCarte = false; // Savoir si on est à la dernière carte du jeu
    public int score = 0;


    void Start()
    {
        //Etat de la partie
        distanceDeplacement = (Screen.width)/2;
        vitesseDeplacement = distanceDeplacement/2;

        gameManager = FindObjectOfType<GameManager>();
        if (gameManager != null)
        {
            cartes = new List<CarteData>(gameManager.selectedQuestions);
            cartePrefab = gameManager.prefab;
        }

        //Création carte 1
        int index = Random.Range(0,cartes.Count-1);
        carte1 = Instantiate(cartePrefab, new Vector3((Screen.width)*(0.25f),Screen.height/2,0), Quaternion.identity,parentObject.transform);
        carte1.GetComponent<Card>().carteData = cartes[index];

        carte1.transform.GetChild(2).gameObject.SetActive(true); // Afficher l'impact CO2
        carte1.transform.SetSiblingIndex(0);
        cartes.RemoveAt(index);

        //Création carte 2
        index = Random.Range(0,cartes.Count-1);
        carte2 = Instantiate(cartePrefab, new Vector3((Screen.width)*(0.75f),Screen.height/2,0), Quaternion.identity,parentObject.transform);
        carte2.GetComponent<Card>().carteData = cartes[index];
        carte2.transform.SetSiblingIndex(1);

        cartes.RemoveAt(index);

        //Set score à 0
        scoreText.text = "Score: " + score.ToString();
    }

    void Update()
    {
        if (plus)
        {
            if (carte2.GetComponent<Card>().GetImpactC02() >= carte1.GetComponent<Card>().GetImpactC02())
            {
                if (cartes.Count == 0 && derniereCarte)
                {
                    actuScore();
                    Debug.Log("You win the game");
                    EndGame(true);
                    plus = false;
                }
                else
                {
                    DeplacerCartes(ref plus);
                }
            }
            else
            {
                Debug.Log("You Lose");
                EndGame(false);
                plus = false;
            }
        }
        else if(moins)
        {
            if (carte2.GetComponent<Card>().GetImpactC02() <= carte1.GetComponent<Card>().GetImpactC02())
            {
                if (cartes.Count == 0 && derniereCarte)
                {
                    actuScore();
                    Debug.Log("You win the game");
                    EndGame(true);
                    moins = false;
                }
                else
                {
                    DeplacerCartes(ref moins);
                }
            }
            else
            {
                Debug.Log("You Lose");
                EndGame(false);
                moins = false;
            }
        }
    }
    public void DeplacerCartes(ref bool button)
    {
        float deplacement = vitesseDeplacement * Time.deltaTime;
        if(carte33Cree == false)
        {
            carte2.transform.GetChild(2).gameObject.SetActive(true);
            DesacButton();
            Debug.Log("Bien vu");
            CreationCarte3();
            carte33Cree = true;
        }
        // Déplacer les cartes vers la gauche
        carte1.transform.Translate(Vector3.left * deplacement);
        carte2.transform.Translate(Vector3.left * deplacement);
        carte3.transform.Translate(Vector3.left * deplacement);

        // Vérifier si la distance de déplacement a été atteinte
        if (positionInitialeX - carte1.transform.position.x >= distanceDeplacement)
        {
            FinDeplacement();
            button = false;
            if (cartes.Count == 0)
            {
                derniereCarte = true;
            }
        }
    }
    public void FinDeplacement()
    {
        actuScore();
        GameObject temp = carte1;
        carte1 = carte2;
        carte2 = carte3;
        Destroy(temp);
        ActiButton();
        carte33Cree = false;
    }
    private void CreationCarte3()
    {
        int index = Random.Range(0,cartes.Count);

        carte3 = Instantiate(cartePrefab, positionInit3, Quaternion.identity,parentObject.transform);
        carte3.GetComponent<Card>().carteData = cartes[index];
        carte3.transform.SetSiblingIndex(2);

        cartes.RemoveAt(index);
    }
    private void DesacButton()
    {
        boutonPlus.GetComponent<Image>().enabled = false;
        boutonPlus.enabled = false;
        boutonMoins.GetComponent<Image>().enabled = false;
        boutonMoins.enabled = false;
    }
    private void ActiButton()
    {
        boutonPlus.GetComponent<Image>().enabled = true;
        boutonPlus.enabled = true;
        boutonMoins.GetComponent<Image>().enabled = true;
        boutonMoins.enabled = true;
    }
    private void actuScore()
    {
        score +=1;
        scoreText.text = "Score: " + score.ToString();
    }
    private void EndGame(bool win)
    {
        DesacButton();
        carte2.transform.GetChild(2).gameObject.SetActive(true);
        gameManager.setBestScore(score);
        boutonBackMenu.SetActive(true);
        boutonRetry.SetActive(true);
        TextMeshProUGUI textEndgame = endgame.GetComponent<TextMeshProUGUI>();
        if (win)
        {
            textEndgame.text = "You win";
            endgame.SetActive(true);
        }
        else
        {
            textEndgame.text = "Lose";
            endgame.SetActive(true);
        }
    }
    public void Replay()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        cartes = gameManager.selectedQuestions;
        SceneManager.LoadScene(currentSceneName);
    }
    public void BackMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void ButtonPlus()
    {
        plus = true;
        boutonPlus.enabled = false;
        boutonPlus.enabled = true;
    }
    public void ButtonMoins()
    {
        moins = true;
        boutonMoins.enabled = false;
        boutonMoins.enabled = true;
    }
}