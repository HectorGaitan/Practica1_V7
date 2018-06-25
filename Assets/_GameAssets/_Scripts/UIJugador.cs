using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIJugador : MonoBehaviour {

    [SerializeField] Image barraVida;
    [SerializeField] Text textoMunicion;
    [SerializeField] Image imagenArma;

	// Use this for initialization
	void Start () {
		
	}
		
	void Update ()
    {
        Jugador jugador = GameManager.jugador;
        ActualizarBarraVida(jugador);
        ActualizarTextoMunicion(jugador);
    }

    private void ActualizarBarraVida(Jugador jugador)
    {
        float vidaActual = jugador.GetVidaActual();
        float vidaMaxima = jugador.GetVidaMaxima();
        float porcentaje = vidaActual / vidaMaxima;

        barraVida.fillAmount = porcentaje;
	}

    private void ActualizarTextoMunicion(Jugador jugador)
    {
        Armas armaEquipada = jugador.GetArmaEquipada();

        int municionCargador = armaEquipada.GetMunicionActualCargador();
        int municionInventario = armaEquipada.GetMunicionActualInventario();

        textoMunicion.text = municionCargador + " / " + municionInventario;

        imagenArma.sprite = armaEquipada.GetIconoArma();



    }
}
