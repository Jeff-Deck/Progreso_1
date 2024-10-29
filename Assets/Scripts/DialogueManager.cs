using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText; // Referencia al objeto de texto donde aparecer� el di�logo
    public string[] dialogueLines; // Aqu� almacenaremos las l�neas del di�logo para cada escena
    public GameObject playButton; // Bot�n para avanzar el di�logo
    public string sceneName; 

    private int currentLineIndex = 0; // �ndice de la l�nea actual del di�logo

    void Start()
    {
        // Mostrar la primera l�nea de di�logo al comenzar la escena
        ShowNextDialogue();
    }

    // M�todo para mostrar la siguiente l�nea de di�logo
    public void ShowNextDialogue()
    {
        if (currentLineIndex < dialogueLines.Length)
        {
            dialogueText.text = dialogueLines[currentLineIndex]; // Mostrar la l�nea actual
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
        // Aqu� puedes ocultar el cuadro de di�logo, hacer una transici�n, etc.
         if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName); // Cambia a la escena especificada
        }
    }
}
