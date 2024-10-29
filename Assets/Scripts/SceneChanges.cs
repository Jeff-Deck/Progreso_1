using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneChanges : MonoBehaviour
{
    public string interactionText; // Texto que se mostrará al interactuar
    public string sceneName; // Nombre de la escena a la que se cambiará
    private bool isPlayerInRange = false;
    public TextMeshProUGUI uiText; // Referencia al UI Text (TextMeshPro)
    public GameObject dialoguePanel; // Referencia al panel de diálogo (que contiene el texto)
    private bool isTextDisplayed = false; // Control para verificar si el texto ya fue mostrado

    void Start()
    {
        // Oculta el panel al inicio
        dialoguePanel.SetActive(false);
    }

    void Update()
    {
        // Detecta si el jugador presiona la tecla "E" mientras está dentro del área
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            ShowInteractionText(); // Muestra el texto y el panel en la pantalla
        }

        // Cambia de escena cuando el texto ha sido mostrado completamente
        if (isTextDisplayed)
        {
            ChangeScene(); // Cambia a la escena especificada
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
            dialoguePanel.SetActive(false); // Oculta el panel cuando el jugador se aleja
            isTextDisplayed = false; // Resetea el estado de visualización del texto
        }
    }

    void ShowInteractionText()
    {
        dialoguePanel.SetActive(true); // Muestra el panel con el texto
        StartCoroutine(DisplayTextAndChangeScene());
    }

    IEnumerator DisplayTextAndChangeScene()
    {
        // Muestra el texto y espera un momento antes de marcar el texto como mostrado
        yield return new WaitForSeconds(3f); // Ajusta el tiempo según la duración del texto
        isTextDisplayed = true; // Marca que el texto fue mostrado
    }

    void ChangeScene()
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName); // Cambia a la escena especificada
        }
    }
}
