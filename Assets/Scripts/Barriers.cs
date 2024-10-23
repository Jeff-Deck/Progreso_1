using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Barriers : MonoBehaviour
{
    public string interactionText; // Texto que aparecerá al interactuar
    private bool isPlayerInRange = false;
    public TextMeshProUGUI uiText; // Referencia al UI Text (TextMeshPro)
    public GameObject dialoguePanel; // Referencia al panel de diálogo (que contiene el texto)

    void Start()
    {
        // Oculta el panel (y el texto dentro de él) al inicio
        dialoguePanel.SetActive(false);
    }

    void Update()
    {
        // Detecta si el jugador presiona la tecla "E" mientras está dentro del área
        if (isPlayerInRange)
        {
            ShowInteractionText(); // Muestra el texto y el panel en la pantalla
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            uiText.text = interactionText; // Cambia el texto de la UI
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            dialoguePanel.SetActive(false); // Oculta el panel y el texto cuando el jugador se aleja
        }
    }

    void ShowInteractionText()
    {
        dialoguePanel.SetActive(true); // Muestra el panel con el texto
        Debug.Log(interactionText); // Opcional: muestra el texto en la consola
    }
}
