using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class LinternaBateriaController : MonoBehaviour
{
    public GameObject linterna;
    public float duracionBateria = 100f;
    public float consumoBateriaPorSegundo = 1f;
    public float cargaBateria = 50f;  // Nueva variable para la carga de la batería
    

    private Light2D luzLinterna;
    private bool linternaEncendida = true;

    void Start()
    {
        luzLinterna = linterna.GetComponent<Light2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            linternaEncendida = !linternaEncendida;
            luzLinterna.enabled = linternaEncendida;
        }

        if (linternaEncendida)
        {
            ConsumirBateria();
        }

        // Recargar batería con la tecla "R"
        if (Input.GetKeyDown(KeyCode.R))
        {
            RecargarBateria();
        }

        
    }

    void ConsumirBateria()
    {
        duracionBateria -= consumoBateriaPorSegundo * Time.deltaTime;

        if (duracionBateria <= 0)
        {
            duracionBateria = 0;
            linternaEncendida = false;
            luzLinterna.enabled = false;
        }
    }

    void RecargarBateria()
    {
        duracionBateria += cargaBateria;

        if (duracionBateria > 100f)
        {
            duracionBateria = 100f;
        }
    }
}