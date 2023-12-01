using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class WinCondition : MonoBehaviour
{
    
    public TextMeshProUGUI killText;

    int kill = 0;

    private void Start()
    {
        killText.text = kill.ToString() + "KILLS";
    }









    //public static WinCondition instance;

    //public int enemigosEliminados = 0;
    //public int objetivoEnemigos = 5;

    //public Text textoGanador;

    //void Awake()
    //{
    //    if (instance == null)
    //    {
    //        instance = this;
    //    }
    //    else
    //    {
    //        Destroy(gameObject);
    //    }
    //}

    //void Start()
    //{
    //    ActualizarTexto();
    //}

    //public void EnemigoEliminado()
    //{
    //    enemigosEliminados++;

    //    ActualizarTexto();

    //    if (enemigosEliminados >= objetivoEnemigos)
    //    {
    //        GanarJuego();
    //    }
    //}

    //void ActualizarTexto()
    //{
    //    textoGanador.text = "Enemigos Eliminados: " + enemigosEliminados + " / " + objetivoEnemigos;
    //}

    //void GanarJuego()
    //{
    //    Debug.Log("¡Has ganado el juego!");
    //    // Puedes agregar aquí cualquier acción que desees cuando el jugador gane el juego.
    //}
}
