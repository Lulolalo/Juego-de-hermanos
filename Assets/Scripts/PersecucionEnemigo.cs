using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersecucionEnemigo : MonoBehaviour
{
    
    public Transform jugador;
    public float velocidad = 5f;


    void Update()
    {
        if (jugador == null)
            return;

       
        // Calcula la dirección hacia el jugador
        Vector3 direccion = (jugador.position - transform.position).normalized;

        // Mueve al enemigo en la dirección del jugador
        transform.Translate(direccion * velocidad * Time.deltaTime);
    }
}

