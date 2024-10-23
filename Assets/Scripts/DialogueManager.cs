using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText; // Referencia al objeto de texto donde aparecer� el di�logo
    public GameObject playButton; // Referencia al bot�n de avanzar el di�logo (por si necesitas ocultarlo)

    private int currentLineIndex = 0; // �ndice de la l�nea actual del di�logo
    private string[] dialogueLines; // Array que contendr� las l�neas del di�logo

    void Start()
    {
        // Inicializar el di�logo
        dialogueLines = new string[]
        {
            "Geisha: �Hola, me alegra verte!",
            "MC: �Tambi�n me alegra verte, Geisha!",
            "Geisha: Tenemos mucho de qu� hablar.",
            "MC: Estoy listo para lo que venga.",
        };

        // Mostrar la primera l�nea de di�logo
        ShowNextDialogue();
    }

    // M�todo para avanzar al siguiente di�logo
    public void ShowNextDialogue()
    {
        Debug.Log("Bot�n Play presionado");

        // Verificar si hemos llegado al final del di�logo
        if (currentLineIndex < dialogueLines.Length)
        {
            // Mostrar la l�nea actual
            dialogueText.text = dialogueLines[currentLineIndex];
            currentLineIndex++; // Avanzar al siguiente di�logo
        }
        else
        {
            EndDialogue(); // Si no hay m�s l�neas, terminar el di�logo
        }
    }

    // M�todo para finalizar el di�logo
    private void EndDialogue()
    {
        Debug.Log("Di�logo terminado.");
        // Opcional: ocultar el cuadro de di�logo, el bot�n o hacer una transici�n
        // dialogueText.gameObject.SetActive(false); 
        // playButton.SetActive(false);
    }
}
