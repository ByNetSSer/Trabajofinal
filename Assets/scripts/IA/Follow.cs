using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform player;
    public float speed;
    Enemigo_ scriptenemigo;
    public animacion_E animacionenemigo;
    public float distanciaminima;
    public float countactions;
    public float timmeractions;
    [SerializeField]
    int eleccion;
    int limit = 3;
    // Start is called before the first frame update
    void Awake()
    {
        scriptenemigo = GetComponent<Enemigo_>();
    }

    // Update is called once per frame
    void Update()
    {
        countactions = countactions + Time.deltaTime;
        if(countactions >timmeractions && scriptenemigo.animacion_e.animacion_.GetBool("IsWalking")!=true && scriptenemigo.animacion_e.animacion_.GetBool("Ispunch")!= true&&scriptenemigo.animacion_e.animacion_.GetBool("burla")!= true&&scriptenemigo.animacion_e.animacion_.GetBool("GetDamage")!=true && scriptenemigo.getLifepublic()>0 )
        {
             eleccion= Random.Range(1, limit);
            if (eleccion > 0 && eleccion <= 3)
            {
                scriptenemigo.animacion_e.animacion_.SetBool("burla", true);
            }
            else if (eleccion > 3 && eleccion <= 60)
            {
                scriptenemigo.animacion_e.animacion_.SetBool("IsWalking", true);
            }
            else if (eleccion > 60 && eleccion <= 100)
            {
                scriptenemigo.animacion_e.animacion_.SetBool("Ispunch", true);
                
            }

            eleccion = 0;
            countactions = 0;
        }
        float distance = Mathf.Sqrt(Mathf.Pow(player.position.x - transform.position.x, 2) +Mathf.Pow(player.position.y - transform.position.y, 2));
        if (scriptenemigo.animacion_e.animacion_.GetBool("Death") != true && distance > distanciaminima && animacionenemigo.animacion_.GetBool("IsWalking"))
        {
            /*
            if(player.position.y > transform.position.y)
            {
                transform.position = new Vector2 (transform.position.x,transform.position.y + 0.001f);
            }
            if (player.position.y < transform.position.y)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y - 0.001f);
            }
            */
            // El enemigo no se acerca dentro del cuadrado
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        if (distance < distanciaminima)
        {
            limit = 100;
            scriptenemigo.animacion_e.animacion_.SetBool("IsWalking", false);
        }
        else
        {
            limit = 60;
        }
        
            
    }
}
