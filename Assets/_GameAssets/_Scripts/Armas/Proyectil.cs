using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour {

    [SerializeField] float tiempoVida = 3;
    [SerializeField] int daño = 1;

    [SerializeField] GameObject prefabParticulasImpacto;

	private void Start()
	{
        Destroy(this.gameObject, tiempoVida);
	}

	private void OnTriggerEnter(Collider other)
	{
        HacerDañoAEnemigo(other);
        GenerarParticulasImpacto();
        Destroy(this.gameObject);
	}

    private void GenerarParticulasImpacto()
    {
        GameObject nuevasParticulasImpacto = Instantiate(prefabParticulasImpacto);
        nuevasParticulasImpacto.transform.position = this.transform.position;
    }

    private void HacerDañoAEnemigo(Collider other)
    {
        if (other.CompareTag("Enemigo"))
        {
            EnemigoTonto enemigo = other.GetComponent<EnemigoTonto>();
            enemigo.RecibirDaño(daño);
        }
    }
}
