using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorEnemigos : MonoBehaviour {

    [SerializeField] GameObject prefabEnemigo;
    [SerializeField] int numeroEnemigosAGenerar = 10;
    [SerializeField] float tiempoEntreEnemigos = 4;
    [SerializeField] float radioZonaGeneracion = 10;
    [SerializeField] float alturaInvocacion = 1;

    int numeroEnemigosGenerados = 0;

	void Start () 
    {
        InvokeRepeating("GenerarEnemigo", 0, tiempoEntreEnemigos);	
	}

    void GenerarEnemigo() 
    {
        if (numeroEnemigosGenerados < numeroEnemigosAGenerar)
        {
            numeroEnemigosGenerados += 1;

            Vector3 desplazamientoAleatorio = Random.insideUnitSphere * radioZonaGeneracion;
            desplazamientoAleatorio.y = 0;

            GameObject nuevoEnemigo = Instantiate(prefabEnemigo);
            nuevoEnemigo.transform.position = this.transform.position + desplazamientoAleatorio;
            nuevoEnemigo.transform.position += Vector3.up * alturaInvocacion;

            nuevoEnemigo.transform.rotation = this.transform.rotation;
        }
        else 
        {
            CancelInvoke();
        }
    }


	
}
