using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPress : MonoBehaviour
{
    private List<CarteData> cartes; //Liste des cartes
    private GameManager gameManager; //Object contenant les cartes de la bonne catégorie
    private GameObject carte1; // Carte 1 active dans le jeu
    private GameObject carte2; // Carte 2 active dans le jeu
    private GameObject carte3; // Carte 3 active dans le jeu
    private GameObject cartePrefab; // Prefab pour instancier les cartes
    public GameObject parentObject; // Game Object parent pour définir le placement des cartes
    public GameObject boutonPlus; // Bouton plus
    public GameObject boutonMoins; // Bouton moins
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

    void Start()
    {
        //Etat de la partie
        distanceDeplacement = (Screen.width)/2;
        vitesseDeplacement = distanceDeplacement/2;

        gameManager = FindObjectOfType<GameManager>();
        if (gameManager != null)
        {
            cartes = gameManager.selectedQuestions;
            cartePrefab = gameManager.prefab;
        }

        //Création carte 1
        int index = Random.Range(0,cartes.Count-1);
        carte1 = Instantiate(cartePrefab, new Vector3((Screen.width)*(0.25f),Screen.height/2,0), Quaternion.identity,parentObject.transform);
        carte1.GetComponent<Card>().carteData = cartes[index];
        carte1.transform.SetSiblingIndex(0);
        cartes.RemoveAt(index);

        //Création carte 2
        index = Random.Range(0,cartes.Count-1);
        carte2 = Instantiate(cartePrefab, new Vector3((Screen.width)*(0.75f),Screen.height/2,0), Quaternion.identity,parentObject.transform);
        carte2.GetComponent<Card>().carteData = cartes[index];
        carte2.transform.SetSiblingIndex(1);
        cartes.RemoveAt(index);
    }

    void Update()
    {
        if (plus)
        {
            if (carte2.GetComponent<Card>().GetImpactC02() >= carte1.GetComponent<Card>().GetImpactC02())
            {
                if (cartes.Count == 0 && derniereCarte)
                {
                    Debug.Log("You win the game");
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
                plus = false;
            }
        }
        else if(moins)
        {
            if (carte2.GetComponent<Card>().GetImpactC02() <= carte1.GetComponent<Card>().GetImpactC02())
            {
                if (cartes.Count == 0 && derniereCarte)
                {
                    Debug.Log("You win the game");
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
                moins = false;
            }
        }
    }
    public void DeplacerCartes(ref bool button)
    {
        float deplacement = vitesseDeplacement * Time.deltaTime;
        if(carte33Cree == false)
        {
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

        GameObject temp = carte1;
        carte1 = carte2;
        carte2 = carte3;
        Destroy(temp);
        ActiButton();
        carte33Cree = false;
    }
    private void CreationCarte3()
    {
        Transform parentTransform = parentObject.transform;
        int insertionIndex = parentTransform.childCount - 1; // l'index de l'avant-dernier enfant
        insertionIndex = Mathf.Clamp(insertionIndex, 0, parentTransform.childCount); // assurez-vous que l'index est valide
        insertionIndex = Mathf.Max(0, insertionIndex); // assurez-vous que l'index est positif
        //insertionIndex -= 0; // déplacez-vous à l'avant-dernière place

        int index = Random.Range(0,cartes.Count);

        carte3 = Instantiate(cartePrefab, positionInit3, Quaternion.identity,parentObject.transform);
        carte3.GetComponent<Card>().carteData = cartes[index];
        carte3.transform.SetSiblingIndex(insertionIndex);

        cartes.RemoveAt(index);
    }
    private void DesacButton()
    {
        boutonPlus.GetComponent<Image>().enabled = false;
        boutonPlus.SetActive(false);
        boutonMoins.GetComponent<Image>().enabled = false;
        boutonMoins.SetActive(false);
    }
    private void ActiButton()
    {
        boutonPlus.GetComponent<Image>().enabled = true;
        boutonPlus.SetActive(true);
        boutonMoins.GetComponent<Image>().enabled = true;
        boutonMoins.SetActive(true);
    }
    public void ButtonPlus()
    {
        plus = true;
    }
    public void ButtonMoins()
    {
        moins = true;
    }
}