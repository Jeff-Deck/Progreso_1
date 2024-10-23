using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText; // Referencia al objeto de texto donde aparecerá el diálogo
    public string[] dialogueLines; // Aquí almacenaremos las líneas del diálogo para cada escena
    public GameObject playButton; // Botón para avanzar el diálogo

    private int currentLineIndex = 0; // Índice de la línea actual del diálogo

    void Start()
    {
        // Mostrar la primera línea de diálogo al comenzar la escena
        ShowNextDialogue();
    }

    // Método para mostrar la siguiente línea de diálogo
    public void ShowNextDialogue()
    {
        if (currentLineIndex < dialogueLines.Length)
        {
            dialogueText.text = dialogueLines[currentLineIndex]; // Mostrar la línea actual
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
        // Aquí puedes ocultar el cuadro de diálogo, hacer una transición, etc.
    }
}
