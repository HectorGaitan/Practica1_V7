using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoTonto : MonoBehaviour {

    [Header("Movimiento")]
    [SerializeField] float velocidadMovimiento = 5;
    [SerializeField] float tiempoCambioDireccion = 3;

    [Header("Ataque")]
    [SerializeField] float distanciaAtaque = 5;
    [SerializeField] int dañoAtaque = 10;

    [Header("Particulas")]
    [SerializeField] GameObject prefabParticulasExplosion;
    [SerializeField] GameObject prefabParticulasMuerte;

    CharacterController miCC;

	private void Awake()
	{
        miCC = GetComponent<CharacterController>();
	}
    	
	void Start () {
        InvokeRepeating("CambiarDireccionMovimiento", tiempoCambioDireccion, tiempoCambioDireccion);
	}
		
	void Update () {
        miCC.SimpleMove(transform.forward * velocidadMovimiento);
        IntentarAtacarAlJugador();
	}

    void IntentarAtacarAlJugador()
    {
        Jugador jugador = GameManager.jugador;
        float distancia = Vector3.Distance(this.transform.position, jugador.transform.position);
        if(distancia < distanciaAtaque)
        {
            AtaqueSuicida(jugador);
        }
    }

    private void AtaqueSuicida(Jugador jugador)
    {
        jugador.RecibirDaño(dañoAtaque);

        Instantiate(prefabParticulasExplosion,
                    position: this.transform.position,
                    rotation: Quaternion.identity);

        Destroy(this.gameObject);
    }

    void CambiarDireccionMovimiento()
    {
        float rotacionAleatoria = Random.Range(0, 360);
        Vector3 rotacionAAplicar = new Vector3(0, rotacionAleatoria, 0);
        this.transform.Rotate(rotacionAAplicar);
    }

    public void RecibirDaño(int daño)
    {
        GameObject nuevasParticulasMuerte = Instantiate(prefabParticulasMuerte);
        nuevasParticulasMuerte.transform.position = this.transform.position;

        Destroy(this.gameObject);
    }



}
