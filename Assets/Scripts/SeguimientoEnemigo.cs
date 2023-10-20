using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguimientoEnemigo : MonoBehaviour
{
    [SerializeField]
    private int Enemydamage;

    public int maxHealth = 20; 
    public int currentHealth;

    public Transform jugador;
    public float velocidad = 5f;


    public void recibirdano(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }

    }

    void Update()
    {
        if (jugador == null)
            return;


        // Calcula la direcci�n hacia el jugador
        Vector3 direccion = (jugador.position - transform.position).normalized;

        // Mueve al enemigo en la direcci�n del jugador
        transform.Translate(direccion * velocidad * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D Other)
    {
        if (Other.CompareTag("Player"))
        {
            // Detectamos una colisi�n con el jugador
            // Aseg�rate de configurar el tag "Player" en el objeto del jugador.

            JorguitoMovimiento Enemydamage = Other.gameObject.GetComponent<JorguitoMovimiento>();
           
            Other.GetComponent<JorguitoMovimiento>().TakeDamage(5);
        }
        
    }
}