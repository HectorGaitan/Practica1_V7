using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armas : MonoBehaviour {

    #region Propiedades inspector

   

    [SerializeField] protected float tiempoRecarga = 1.5f;

    [SerializeField] protected int municionMaximaInventario = 32;
    [SerializeField] protected int municionActualInventario = 8;
    [SerializeField] protected int municionMaximaCargador = 8;

   
    [SerializeField] protected AudioSource audioRecarga;
    [SerializeField] protected AudioSource audioRecargaFallida;


    [SerializeField] private Sprite iconoArma;

    public Sprite GetIconoArma()
    {
        return iconoArma;
    }



    #endregion

    #region Variables privadas

    protected int municionActualCargador;

    protected bool estoyRecargando = false;
    protected bool gatilloApretado = false;


    #endregion


    #region Getters

    public int GetMunicionActualInventario()
    {
        return municionActualInventario;
    }

    public int GetMunicionActualCargador()
    {
        return municionActualCargador;
    }

    #endregion

    #region Lifecycle methods

    protected virtual void Start()
    {
        municionActualCargador = municionMaximaCargador;
        municionActualInventario = Mathf.Min(municionActualInventario, municionMaximaInventario);
    }

    #endregion

    public virtual void ApretarGatillo(){
        
    }

    public virtual void SoltarGatillo(){
        
    }

    public virtual void Recargar(){

        bool cargadorATope = (municionActualCargador == municionMaximaCargador);
        bool tengoBalas = municionActualInventario > 0;

        if (!estoyRecargando && !cargadorATope && tengoBalas)
        {
            estoyRecargando = true;
            audioRecarga.Play();

            Invoke("FinalizarRecarga", tiempoRecarga);
        }
        else if (!tengoBalas)
        {
            audioRecargaFallida.Play();
        }
    }

    void FinalizarRecarga()
    {
        int municionARecargar = municionMaximaCargador - municionActualCargador;
        municionARecargar = Mathf.Min(municionARecargar, municionActualInventario);

        municionActualInventario -= municionARecargar;
        municionActualCargador += municionARecargar;

        estoyRecargando = false;
    }



}
