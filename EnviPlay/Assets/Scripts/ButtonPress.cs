using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPress : MonoBehaviour
{
    public GameObject carte1;
    private Card instanceCarte1;
    public GameObject carte2;
    private Card instanceCarte2;
    public GameObject carte3;
    public GameObject cartePrefab;
    public GameObject parentObject;
    public GameObject boutonPlus;
    public GameObject boutonMoins;
    public float vitesseDeplacement = 500f; // Vitesse de déplacement des cartes
    public float distanceDeplacement = 0f; // Distance de déplacement égale à la largeur d'une carte

    private bool plus = false;

    private bool moins = false;

    private float positionInitialeX;
    private Vector3 positionInit3;


    void Start()
    {
        //Etat de la partie
        positionInitialeX = carte1.transform.position.x;
        positionInit3 = carte3.transform.position;
        distanceDeplacement = (Screen.width)/2;
        vitesseDeplacement = distanceDeplacement/2;

        //Valeur pour la comparaison
        instanceCarte1 = carte1.GetComponent<Card>();
        instanceCarte2 = carte2.GetComponent<Card>();
    }

    void Update()
    {
        if (plus)
        {
            if (instanceCarte2.GetImpactC02() >= instanceCarte1.GetImpactC02())
            {
                Debug.Log("Bien vu");
                
                boutonPlus.GetComponent<Image>().enabled = false;
                boutonPlus.SetActive(false);
                boutonMoins.GetComponent<Image>().enabled = false;
                boutonMoins.SetActive(false);

                DeplacerCartes(ref plus);
            
                
            }
            else
            {
                Debug.Log("You Lose");
                plus = false;
            }
        }
        else if(moins)
        {
            if (instanceCarte2.GetImpactC02() <= instanceCarte1.GetImpactC02())
            {
                Debug.Log("Bien vu");
                
                boutonPlus.GetComponent<Image>().enabled = false;
                boutonPlus.SetActive(false);
                boutonMoins.GetComponent<Image>().enabled = false;
                boutonMoins.SetActive(false);

                DeplacerCartes(ref moins);
            
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

        // Déplacer les cartes vers la gauche
        carte1.transform.Translate(Vector3.left * deplacement);
        carte2.transform.Translate(Vector3.left * deplacement);
        carte3.transform.Translate(Vector3.left * deplacement);

        // Vérifier si la distance de déplacement a été atteinte
        if (positionInitialeX - carte1.transform.position.x >= distanceDeplacement)
        {
            FinDeplacement();
            button = false;
        }
    }
    public void FinDeplacement()
    {
        //deplacementEnCours = false;
        positionInitialeX = carte1.transform.position.x;

        Transform parentTransform = parentObject.transform;

        int insertionIndex = parentTransform.childCount - 1; // l'index de l'avant-dernier enfant
        insertionIndex = Mathf.Clamp(insertionIndex, 0, parentTransform.childCount); // assurez-vous que l'index est valide
        insertionIndex = Mathf.Max(0, insertionIndex); // assurez-vous que l'index est positif
        insertionIndex -= 1; // déplacez-vous à l'avant-dernière place

        GameObject test = Instantiate(cartePrefab, positionInit3, Quaternion.identity,parentObject.transform);

        test.transform.SetSiblingIndex(insertionIndex);

        GameObject temp = carte1;

        carte1 = carte2;

        positionInitialeX = carte1.transform.position.x;

        carte2 = carte3;
            
        carte3 = test;

        Destroy(temp);

        instanceCarte1 = carte1.GetComponent<Card>();
        instanceCarte2 = carte2.GetComponent<Card>();

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
