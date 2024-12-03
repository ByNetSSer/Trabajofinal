using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public animacion animatorplayer;
    public int vida;
    class Jugador : Body
    {
        int Hearts;
        int Stamina;
        public int Hearts_ { get { return Hearts; }set { Hearts = value; } }
        public int Life_ { get { return Life; } set { Life = value; } }
        public int Stamina_ { get { return Stamina; } set { Stamina = value; } }
        public int damage_ { get { return damage; } set { damage = value; } }
        public Jugador()
        {
            Hearts = 3;
            Life = 100;
            Stamina = 100;
            damage = 7;
        }
        public void Getdamage(int damage) {
            Life = Life - damage;
        }
    }
    Jugador player = new Jugador();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        vida = player.Life_;
        if (player.Life_ <1)
        {
            animatorplayer.animacion_.SetBool("Dead", true);
        }
    }
    public int setdamage()
    {
        return player.damage_;  

    }
    public void GetDamage(int damage)
    {
        player.Getdamage(damage);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Hit_e")
        {
            animatorplayer.animacion_.SetBool("in damage", true);

            //Text texto = Instantiate(prefabTextDamage, new Vector2(transform.position.x-150.0f, transform.position.y-10.0f), transform.rotation);
            //texto.text = DAMAGE.ToString();
            //texto.transform.SetParent(elcanvas.transform,false);

        }
    }
}
