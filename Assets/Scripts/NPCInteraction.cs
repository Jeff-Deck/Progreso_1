using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    public GameObject mc; // Referencia al personaje principal
    public GameObject npcGeisha; // Referencia al NPC
    public float interactionDistance = 2f; // Distancia mínima para activar la interacción
    public float retreatDistance = 3f; // Distancia a la que se alejará MC después de la interacción

    private bool hasInteractedInitially = false; // Bandera para la interacción inicial
    private bool isInteracting = false; // Bandera para verificar si MC está en una interacción

    private void Update()
    {
        // Verificar la distancia entre MC y el NPC
        float distance = Vector3.Distance(mc.transform.position, npcGeisha.transform.position);

        // Iniciar la interacción si MC está dentro del rango de interacción y no está interactuando
        if (distance <= interactionDistance && !isInteracting)
        {
            if (!hasInteractedInitially)
            {
                StartInitialInteraction();
                hasInteractedInitially = true;
            }
            else
            {
                StartSubsequentInteraction();
            }
        }
    }

    private void StartInitialInteraction()
    {
        isInteracting = true;
        Debug.Log("Interacción inicial con NPC_Geisha.");

        // Aquí puedes agregar la lógica específica para la interacción inicial (diálogos, animaciones, etc.)

        // Después de la interacción, alejar a MC
        RetreatAfterInteraction();
    }

    private void StartSubsequentInteraction()
    {
        isInteracting = true;
        Debug.Log("Interacción subsecuente con NPC_Geisha.");

        // Aquí puedes agregar la lógica para interacciones subsecuentes (diálogos, animaciones, etc.)

        // Después de la interacción, alejar a MC
        RetreatAfterInteraction();
    }

    private void RetreatAfterInteraction()
    {
        // Calcular la dirección de alejamiento
        Vector3 retreatDirection = (mc.transform.position - npcGeisha.transform.position).normalized;
        Vector3 retreatPosition = mc.transform.position + retreatDirection * retreatDistance;

        // Mover a MC a la posición de alejamiento
        mc.transform.position = retreatPosition;

        // Reiniciar la bandera de interacción
        isInteracting = false;
    }
}
