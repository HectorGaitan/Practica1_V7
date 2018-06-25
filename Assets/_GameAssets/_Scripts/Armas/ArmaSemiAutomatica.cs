using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaSemiAutomatica : ArmaProyectiles
{









    #region Other methods

    public override void ApretarGatillo()
    {
        float tiempoActual = Time.time;
        float tiempoDesdeUltimoDisparo = tiempoActual - tiempoUltimoDisparo;

        bool puedoDisparar =
            tiempoDesdeUltimoDisparo > tiempoEntreDisparos ;
        
        if(puedoDisparar){
            DispararArma();

        }




    }

 


    #endregion

}
