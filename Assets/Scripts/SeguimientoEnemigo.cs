using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class SeguimientoEnemigo : MonoBehaviour
{
    [Header("EnemigoSettings")]
    [SerializeField]
    private int Enemydamage;

    public int maxHealth = 20; 
    public int currentHealth;

    public Transform jugador;
    public float velocidad = 5f;

    public WinCondition winCondition;

    public void Start()
    {
        winCondition = GameObject.FindGameObjectWithTag("WinCondition").GetComponent<WinCondition>();
    }


    public void RecibirDaño(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            winCondition.AddKill();
        }
        else
        {
            //agregar sonido<
        }

    }

    void Update()
    {
        if (jugador == null)
            return;


        // Calcula la dirección hacia el jugador
        Vector3 direccion = (jugador.position - transform.position).normalized;

        // Mueve al enemigo en la dirección del jugador
        transform.Translate(direccion * velocidad * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D Other)
    {
        if (Other.CompareTag("Player"))
        {
            

            JorguitoMovimiento Enemydamage = Other.gameObject.GetComponent<JorguitoMovimiento>();
           
            Other.GetComponent<JorguitoMovimiento>().TakeDamage(5);

        }
        
    }
}