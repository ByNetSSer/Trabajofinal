using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animacion : MonoBehaviour
{
    public Animator animacion_;
    public SpriteRenderer renderer_;
    public GameObject Damage;
    public Player player;
    float horizontal;
    float vertical;
    // Start is called before the first frame update
    void Awake()
    {
        animacion_ = GetComponent<Animator>();
        renderer_ = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        animacion_.SetInteger("ismovingx", (int)vertical);
        animacion_.SetInteger("ismovingy", (int)horizontal);

        if (horizontal< 0 )
        {
            renderer_.flipX = true;
        }
        else if (horizontal > 0)
        {
            renderer_.flipX = false;
        }
        
        if (Input.GetKeyDown("k") && animacion_.GetBool("ispunch")!= true && !animacion_.GetBool("Dead")&& !animacion_.GetBool("in damage"))
        {
            animacion_.SetBool("ispunch", true);
            animacion_.SetInteger("rndpunch", 1);
        }
        else if (Input.GetKeyDown("l") && animacion_.GetBool("ispunch") != true&&!animacion_.GetBool("Dead")&&!animacion_.GetBool("in damage"))
        {
            animacion_.SetBool("ispunch", true);
            animacion_.SetInteger("rndpunch", 2);
        }
        
        
    }
    
    void notpunch()
    {
        animacion_.SetInteger("rndpunch", 0);
        animacion_.SetBool("ispunch", false);
        
    }
    void notstun()
    {
        animacion_.SetBool("in damage", false);
    }
    void CreateDamage()
    {
        if (renderer_.flipX)
        {
            GameObject hit=Instantiate(Damage, new Vector2(transform.position.x - 0.4f, transform.position.y - 0.35f), transform.rotation);
            hit.GetComponent<GetDamageToobjet>().getdamage(player.setdamage());
        }
        else
        {
            GameObject Hit=Instantiate(Damage, new Vector2(transform.position.x + 0.4f, transform.position.y - 0.35f), transform.rotation);
            Hit.GetComponent<GetDamageToobjet>().getdamage(player.setdamage());
        }

    }
    private void FixedUpdate()
    {
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Damage") {
            animacion_.SetBool("in damage", true);
        }
    }
}
