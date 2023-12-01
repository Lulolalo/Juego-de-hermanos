using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinCondition : MonoBehaviour
{ 

    public static WinCondition instance;

    public int enemigosEliminados = 0;
    public int objetivoEnemigos = 50;

    public Text textoGanador;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        ActualizarTexto();
    }

    public void EnemigoEliminado()
    {
        enemigosEliminados++;

        ActualizarTexto();

        if (enemigosEliminados >= objetivoEnemigos)
        {
            GanarJuego();
        }
    }

    void ActualizarTexto()
    {
        textoGanador.text = "Enemigos Eliminados: " + enemigosEliminados + " / " + objetivoEnemigos;
    }

    void GanarJuego()
    {
        Debug.Log("�Has ganado el juego!");
        // Puedes agregar aqu� cualquier acci�n que desees cuando el jugador gane el juego.
    }
}