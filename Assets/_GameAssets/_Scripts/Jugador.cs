using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Jugador : MonoBehaviour {

    [SerializeField] int vidaMaxima = 100;

    int vidaActual;
    bool estoyMuerto;

    Armas[] armas;

    Armas armaEquipada;





    public Armas  GetArmaEquipada()
    {
        return armaEquipada;
    }

    public int GetVidaActual()
    {
        return vidaActual;
    }

    public int GetVidaMaxima()
    {
        return vidaMaxima;
    }

	private void Awake()
	{
        GameManager.jugador = this;

        armas = GetComponentsInChildren<Armas>();
        EquiparArma(0);
	}

	private void Start()
	{
        vidaActual = vidaMaxima;
	}

    private void Update()
    {
        ComprobarInputDisparo();

        ComprobarCambioArma();

    }

    private void ComprobarInputDisparo()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            armaEquipada.ApretarGatillo();
        }
        if (Input.GetButtonUp("Fire1"))
        {
            armaEquipada.SoltarGatillo();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            armaEquipada.Recargar();
        }
    }

    private void ComprobarCambioArma()
    {
        for (int teclaArma = 1; teclaArma <= armas.Length; teclaArma++)
        {

            if (Input.GetKey(teclaArma.ToString()))
            {
                EquiparArma(teclaArma - 1);
            }
        }
    }

    public void RecibirDaño(int dañoAtaque)
    {
        vidaActual = Mathf.Max(0, vidaActual - dañoAtaque);
        if(vidaActual == 0)
        {
            Morir();
        }
    }

    private void Morir()
    {
        if(!estoyMuerto)
        {
            estoyMuerto = true;

            this.enabled = false;
            GetComponent<CharacterController>().enabled = false;
            GetComponent<FirstPersonController>().enabled = false;
            Debug.Log("FIN DE PARTIDA");
        }
    }


    private void EquiparArma(int indiceArma){

        for (int i = 0; i < armas.Length; i++)
        {
            armas[i].gameObject.gameObject.SetActive(false);
        }

        armaEquipada = armas[indiceArma];
        armas[indiceArma].gameObject.SetActive(true);
    }



}



