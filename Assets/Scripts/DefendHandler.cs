using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DefendHandler : MonoBehaviour
{
    public GameObject soldier;          // Soldier GameObject
    public GameObject damageGreen;      // DamageGreen GameObject
    public float delayBeforeGreen = 1f; // Delay time before activating DamageGreen

    private Animator soldierAnimator;
    private bool isDefending = false;

    void Start()
    {
        // Asignar el Animator y ocultar DamageGreen al inicio
        soldierAnimator = soldier.GetComponent<Animator>();
        damageGreen.SetActive(false);
    }

    public void OnDefendButtonPressed()
    {
        // Prevenir que se vuelva a iniciar si la animación está en curso
        if (!isDefending)
        {
            StartCoroutine(HandleDefendSequence());
        }
    }

    private IEnumerator HandleDefendSequence()
    {
        isDefending = true;

       

        // Esperar una cantidad de tiempo antes de mostrar DamageGreen
        yield return new WaitForSeconds(delayBeforeGreen);

        // Activar DamageGreen y esperar a que termine la animación (ajustable)
        damageGreen.SetActive(true);
        yield return new WaitForSeconds(0.5f); // Cambia 0.5f por la duración real de DamageGreen

        // Ocultar DamageGreen y permitir reiniciar
        damageGreen.SetActive(false);
        isDefending = false;
    }
}
