using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granda : MonoBehaviour
{

    public enum TipoDetonacion
    {
        PorTiempo, PorColision
    }


    [SerializeField] float radioExplosion;
    [SerializeField] int daño;
    [SerializeField] TipoDetonacion detonacion;
    [SerializeField] float retardoExplosion;
    [SerializeField] GameObject prefabExplosion;
    float intanteExplosion;

    // Use this for initialization
    void Start()
    {
        intanteExplosion = Time.time + retardoExplosion;
        this.transform.forward = Random.insideUnitSphere;
    }

        // Update is called once per frame
        void Update()
        {
            if (detonacion == TipoDetonacion.PorTiempo && Time.time > intanteExplosion)
            {
                Explotar();
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (detonacion == TipoDetonacion.PorColision)
            {
                Explotar();
            }
        }



        void Explotar()
        {
            DañarEnemigos();

            Instantiate(prefabExplosion, position: this.transform.position, rotation: Quaternion.identity);
            Destroy(this.gameObject);

        }

        void DañarEnemigos()
        {

            Collider[] collidersAfectados = Physics.OverlapSphere(this.transform.position, radioExplosion);
            for (int i = 0; i < collidersAfectados.Length; i++)
            {
                EnemigoTonto posibleEnemigo = collidersAfectados[i].GetComponent<EnemigoTonto>();
                if (posibleEnemigo != null)
                {

                    posibleEnemigo.RecibirDaño(daño);
                }
            }
        }





}