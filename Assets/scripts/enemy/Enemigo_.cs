using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemigo_ : MonoBehaviour
{
    public animacion_E animacion_e;
    BoxCollider2D boxcolider_;
    public Text prefabTextDamage;
    public Canvas elcanvas;
    public int vida;
    public int DAMAGE;
    class enemigo : Body
    {
        public int Life_ { get { return Life; } set { Life = value; } }
        public int damage_ { get { return damage; } set { damage = value; } }
        public enemigo()
        {
            Life = 100;
            damage_ = 10;
        }
        public void getdamage(int damage)
        {

            Life = Life - damage;
        }
    }
     enemigo enemigobase = new enemigo();
    // Start is called before the first frame update
    void Awake()
    {
        boxcolider_ = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        vida = enemigobase.Life_;
        if(enemigobase.Life_ < 1)
        {
            animacion_e.animacion_.SetBool("Death", true);
            Destroy(this.gameObject, 6);
        }
        if (animacion_e.animacion_.GetBool("GetDamage"))
        {
            boxcolider_.enabled = false;
        }
        else
        {
            boxcolider_.enabled = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Hit")
        {
            animacion_e.animacion_.SetBool("GetDamage", true);
            
            //Text texto = Instantiate(prefabTextDamage, new Vector2(transform.position.x-150.0f, transform.position.y-10.0f), transform.rotation);
            //texto.text = DAMAGE.ToString();
            //texto.transform.SetParent(elcanvas.transform,false);
            
        }
    }
    public void getdamagepublic(int setdamage)
    {
        enemigobase.getdamage(setdamage);
        DAMAGE = setdamage;
    }
    public int getLifepublic()
    {
        return enemigobase.Life_;
    }
    public int setdamage()
    {
        return enemigobase.damage_;
    }

}
