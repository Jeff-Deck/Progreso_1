using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHandler : MonoBehaviour
{
    public GameObject soldier;          // Soldier GameObject
    public GameObject damageRed;        // DamageRed GameObject
    public GameObject damageBlue;       // DamageBlue GameObject
    public float delayBeforeBlue = 1f;  // Delay time before activating DamageBlue

    private Animator soldierAnimator;
    private bool isAnimating = false;

    void Start()
    {
        // Asignar el Animator y ocultar DamageRed y DamageBlue al inicio
        soldierAnimator = soldier.GetComponent<Animator>();
        damageRed.SetActive(false);
        damageBlue.SetActive(false);
    }

    public void OnAttackButtonPressed()
    {
        // Prevenir que se vuelva a iniciar si la animación está en curso
        if (!isAnimating)
        {
            StartCoroutine(HandleAttackSequence());
        }
    }

    private IEnumerator HandleAttackSequence()
    {
        isAnimating = true;

        // Cambiar estado de Soldier a Dead_Damage usando el trigger
        soldierAnimator.SetTrigger("Dead_Damage");
        damageRed.SetActive(true);

        // Esperar a que termine la animación Dead_Damage
        yield return new WaitForSeconds(soldierAnimator.GetCurrentAnimatorStateInfo(0).length);

        // Desactivar DamageRed y esperar el tiempo configurado antes de DamageBlue
        damageRed.SetActive(false);
        yield return new WaitForSeconds(delayBeforeBlue);

        // Activar DamageBlue y esperar a que termine la animación
        damageBlue.SetActive(true);
        yield return new WaitForSeconds(0.5f);  // Ajusta según la duración de la animación DamageBlue

        // Ocultar DamageBlue y permitir reiniciar
        damageBlue.SetActive(false);
        isAnimating = false;
    }
}
