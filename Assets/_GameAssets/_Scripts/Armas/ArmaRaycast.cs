using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaRaycast : Armas
{



    [SerializeField] float tiempoEntreDisparos = 1;
    [SerializeField] AudioSource audioDisparo;
    float tiempoUltimoDisparo;
    private Camera camara;
    [SerializeField]int daño = 100;
    [SerializeField] float zoomFOV = 15;
    [SerializeField]float incialFOV;
    [SerializeField] Canvas canvasFrancotirador;


   void Awake()
    {
        base.Start();
            
        this.camara = Camera.main;
        incialFOV = camara.fieldOfView;


    }


	private void OnDisable()
	{
        DesactivarZoom();
	}

	private void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            ActivarZoom();
        }
        if (Input.GetMouseButtonUp(1))
        {
            DesactivarZoom();
        }

    }

    void ActivarZoom(){
        camara.fieldOfView = zoomFOV;
        canvasFrancotirador.SetActive(false); 
    }

    void DesactivarZoom(){
        camara.fieldOfView = incialFOV;
    }


    public override void ApretarGatillo()
    {
       
        if (Time.time > tiempoUltimoDisparo + tiempoEntreDisparos){
            if (municionActualCargador > 0 && !estoyRecargando)
            {
                municionActualCargador -= 1;

                tiempoUltimoDisparo = Time.time;
                audioDisparo.Play();
                LanzarRaycast();
            }
            else if (municionActualCargador == 0 && !estoyRecargando) {
                audioRecargaFallida.Play();
            }
        }

       
    }

    void LanzarRaycast()
    {

        Vector3 posicionCamara = camara.transform.position;
        Vector3 fowardCarama = camara.transform.forward;
        Ray rayo = new Ray(posicionCamara, fowardCarama);

        RaycastHit infoImpacto;

        if (Physics.Raycast(rayo, out infoImpacto))
        {


            Collider colliderImpacto = infoImpacto.collider;
            EnemigoTonto enemigo = colliderImpacto.GetComponent<EnemigoTonto>();
            if (enemigo != null)
            {


                enemigo.RecibirDaño(daño);

            }

        }

    }

}

