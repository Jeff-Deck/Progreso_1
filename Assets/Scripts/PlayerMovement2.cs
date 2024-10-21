using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidad de movimiento del objeto
    private Rigidbody2D rb;
    private Vector2 movement;
    private Animator animator; // Referencia al componente Animator

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Obtén el componente Rigidbody2D del objeto
        animator = GetComponent<Animator>(); // Obtén el componente Animator del objeto
    }

    void Update()
    {
        // Obtén la entrada del usuario en los ejes horizontales y verticales
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Actualiza las animaciones según la dirección del movimiento
        UpdateAnimations();
    }

    void FixedUpdate()
    {
        // Mueve el objeto
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    // Método para actualizar las animaciones según la dirección del movimiento
    void UpdateAnimations()
    {
        // Establecer los parámetros de animación
        animator.SetFloat("MoveX", movement.x);
        animator.SetFloat("MoveY", movement.y);
        animator.SetBool("isWalking", movement.x != 0 || movement.y != 0);
    }
}
