using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PickUp : MonoBehaviour
{
    public string interactionText; // Texto que aparecerá al interactuar
    private bool isPlayerInRange = false;
    public TextMeshProUGUI uiText; // Referencia al UI Text (TextMeshPro)
    public GameObject dialoguePanel; // Referencia al panel de diálogo (que contiene el texto)
    public float destroyDelay = 1f; // Tiempo de espera antes de destruir el objeto después de mostrar el texto

    void Start()
    {
        // Oculta el panel (y el texto dentro de él) al inicio
        dialoguePanel.SetActive(false);
    }

    void Update()
    {
        // Detecta si el jugador presiona la tecla "E" mientras está dentro del área
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
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
        //Debug.Log(dialoguePanel.activeSelf);
        //Debug.Log(interactionText); // Opcional: muestra el texto en la consola
        StartCoroutine(DestroyAfterDelay()); // Inicia la corrutina para destruir el objeto
    }

    IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(destroyDelay); // Espera el tiempo configurado
        dialoguePanel.SetActive(false); // Oculta el panel antes de destruir el objeto
        Destroy(gameObject); // Destruye el objeto
    }
}
