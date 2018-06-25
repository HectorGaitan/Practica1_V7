using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaProyectiles : Armas {



    [SerializeField] protected Rigidbody prefabProyectil;
    [SerializeField] protected Transform puntoDisparo;

    [SerializeField] protected float fuerzaDisparo = 50;
    [SerializeField] protected float tiempoEntreDisparos = 1;
    [SerializeField] protected AudioSource audioDisparo;
    protected float tiempoUltimoDisparo;





    protected void DispararArma()
    {


        if (municionActualCargador > 0 && !estoyRecargando)
        {
            LanzarProyectil();
        }
        else if (municionActualCargador == 0 && !estoyRecargando)
        {
            // TODO: Cambiar por sonido distinto
            audioRecargaFallida.Play();
        }
    }


    protected void LanzarProyectil()
    {
        tiempoUltimoDisparo = Time.time;

        audioDisparo.PlayOneShot(audioDisparo.clip);

        municionActualCargador -= 1;

        Rigidbody nuevoProyectil = Instantiate(prefabProyectil);
        nuevoProyectil.transform.position = puntoDisparo.position;
        nuevoProyectil.transform.rotation = puntoDisparo.rotation;
        nuevoProyectil.AddForce(puntoDisparo.transform.forward * fuerzaDisparo, ForceMode.Impulse);
    }




}
