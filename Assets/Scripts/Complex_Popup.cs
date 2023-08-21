using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static Institution;


public class Complex_Popup : MonoBehaviour
{
    public GameObject buttonPrefab;
    public GameManager gameManager;
    

    public List<Institution> orgInstances = new List<Institution>();

    private void Start()
    {
        Institution[] scripts = FindObjectsOfType<Institution>();
        orgInstances.AddRange(scripts);
        GenerateButtons();
    }

    private void GenerateButtons()
    {

        int numberOfButtons = orgInstances.Count;
        Debug.Log("Number of buttons: " + numberOfButtons);

        for (int i = 0; i < numberOfButtons; i++)
        {
            // Instantiate the button prefab and set its parent to this GameObject.
            GameObject button = Instantiate(buttonPrefab, transform);

            // Customize the button's properties here.
            // For example, set the button's text to the index or some meaningful value.
            button.GetComponentInChildren<TextMeshProUGUI>().text = orgInstances[i].name.ToString();

            // Add a click listener to the button
            int buttonIndex = i; // Capture the value of i for the listener
            button.GetComponent<Button>().onClick.AddListener(() => ButtonClicked(buttonIndex));
        }
    }

    // Example click listener function
    private void ButtonClicked(int buttonIndex)
    {
        Debug.Log("Button clicked: " + buttonIndex);
    }
}