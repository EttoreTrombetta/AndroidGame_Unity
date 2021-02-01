using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public string enemyName;
    public int hp = 100;
    public int damage = 5;
    public float attackRange;
    public float triggerDistance;
    public float speed;
    public float attackRate;
    public float reactionTime;
    public Transform firingPoint;
    public Transform sprite;
    public Transform player;
    public NavMeshAgent agent;
    public Animator anim;
    public ParticleSystem hitFeedback;
    //public AudioSource attackNoise;

    private bool walk = false;
    private float cooldown;

    private void Start()
    {
        agent.speed = speed;
        cooldown = reactionTime;
    }

    private void Update()
    {
        firingPoint.LookAt(player);
        sprite.LookAt(player);

        walk = Vector3.Distance(transform.position, player.position) <= triggerDistance && Vector3.Distance(transform.position, player.position) >= attackRange;

        if(walk)
        {
            agent.destination = player.position;
            agent.speed = speed;
            cooldown = reactionTime;
        }
        else if(!walk)
        {
            Attack();
            agent.speed = 0;
        }

        if(hp <= 0)
        {
            Death();
        }

        if (cooldown > 0f)
        {
            cooldown -= Time.deltaTime;
            //Debug.Log(cooldown);
        }

        anim.SetBool("isWalking", agent.speed > 0f);
        anim.SetBool("isAttacking", cooldown <= 0f);
    }

    private void Attack()
    {
        //attackNoise.Play();
        RaycastHit hit;
        if (Physics.Raycast(firingPoint.transform.position, firingPoint.transform.forward, out hit, attackRange) && hit.collider.tag == "Player" && cooldown <= 0f)
        {
            player.GetComponent<Player>().hp -= damage;
            //Debug.Log(player.GetComponent<Player>().hp);
            cooldown = attackRate;
        }
    }

    private void Death()
    {
        Destroy(this.gameObject);
    }
}
