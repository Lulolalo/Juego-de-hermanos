using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoDivide : MonoBehaviour
{
    public Transform jugador;
    public float velocidad = 5f;
    public GameObject enemigoPrefab;  // Prefab del enemigo a generar al morir
    

    public int maxHealth = 20;
    public int currentHealth;

    void Update()
    {
        if (jugador == null)
            return;


        // Calcula la dirección hacia el jugador
        Vector3 direccion = (jugador.position - transform.position).normalized;

        // Mueve al enemigo en la dirección del jugador
        transform.Translate(direccion * velocidad * Time.deltaTime);

    }
    public void recibirdamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            Dividir();
        }

    }

    public void Dividir()
    {
        Instantiate(Enemigo, posicionSpawn, Quaternion.identity);
    }
}
