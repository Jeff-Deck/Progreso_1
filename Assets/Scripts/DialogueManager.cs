using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText; // Referencia al objeto de texto donde aparecerá el diálogo
    public GameObject playButton; // Referencia al botón de avanzar el diálogo (por si necesitas ocultarlo)

    private int currentLineIndex = 0; // Índice de la línea actual del diálogo
    private string[] dialogueLines; // Array que contendrá las líneas del diálogo

    void Start()
    {
        // Inicializar el diálogo
        dialogueLines = new string[]
        {
            "Geisha: ¡Hola, me alegra verte!",
            "MC: ¡También me alegra verte, Geisha!",
            "Geisha: Tenemos mucho de qué hablar.",
            "MC: Estoy listo para lo que venga.",
        };

        // Mostrar la primera línea de diálogo
        ShowNextDialogue();
    }

    // Método para avanzar al siguiente diálogo
    public void ShowNextDialogue()
    {
        Debug.Log("Botón Play presionado");

        // Verificar si hemos llegado al final del diálogo
        if (currentLineIndex < dialogueLines.Length)
        {
            // Mostrar la línea actual
            dialogueText.text = dialogueLines[currentLineIndex];
            currentLineIndex++; // Avanzar al siguiente diálogo
        }
        else
        {
            EndDialogue(); // Si no hay más líneas, terminar el diálogo
        }
    }

    // Método para finalizar el diálogo
    private void EndDialogue()
    {
        Debug.Log("Diálogo terminado.");
        // Opcional: ocultar el cuadro de diálogo, el botón o hacer una transición
        // dialogueText.gameObject.SetActive(false); 
        // playButton.SetActive(false);
    }
}
