using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaTrigger : Armas
{

    [SerializeField] ParticleSystem particulasLlamarada;
    [SerializeField] Collider triggerLlamadara;



    public override void ApretarGatillo()
    {
       

            particulasLlamarada.Play();
            triggerLlamadara.gameObject.SetActive(true);

    }
    public override void SoltarGatillo()
    {

            particulasLlamarada.Stop();
            triggerLlamadara.gameObject.SetActive(false);

    }


    private void OnTriggerStay(Collider objetivo)

    {
        if (objetivo.tag == "Enemigo")
        {
            objetivo.GetComponent<EnemigoTonto>().RecibirDaño(+5);

        }

    }

}




// LanzaLLamas rigibody kinematico al propio lanza llamas ,triger y particulas