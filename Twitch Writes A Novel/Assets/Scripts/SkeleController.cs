using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkeleController : MonoBehaviour {
    public Animator animator;
    Text damageText;
    Transform textSpawn;
    public bool team = false;
    public int redorBlue;
    

    public float health = 100f;
    public float damage = 10f;
    public float speed = 10f;
    float attackDelay;

    bool Attacking = false;
	// Use this for initialization
	void Start () {

        Destroy(gameObject, 15f);
        damage = Random.Range(10f, 15f);

    }

    // Update is called once per frame
    void Update () {


        if(health <= 0)
        {
            Destroy(gameObject);
        }

        if (Attacking)
        {
            animator.SetBool("Attacking", true);

            attackDelay = attackDelay + Time.deltaTime;
        
            if(attackDelay > 1f)
            {
                attackDelay = 0f;
                LoseHP();
            }
        }
        else
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed * redorBlue);
            animator.SetBool("Attacking", false);

        }






    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(redorBlue > 0)
        {
            if(collision.tag == "BlueTeam")
            {
                Debug.Log("Attacking");
                Attacking = true;
            }
        }else if(redorBlue < 0)
        {
            if(collision.tag == "RedTeam")
            {
                Debug.Log("Attacking");
                Attacking = true;
            }
        }
        
        

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Stopped Attacking");

        Attacking = false;

    }

    void LoseHP()
    {
        health = health - damage;
        Debug.Log("Attacked");
    }

    void updateText()
    {
        damageText.text = health.ToString();
    }

}
