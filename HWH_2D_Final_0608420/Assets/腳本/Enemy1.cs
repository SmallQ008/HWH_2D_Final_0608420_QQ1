
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    [Header("追蹤範圍"), Range(0, 500)]
    public float rangeTrack = 2;
    [Header("攻擊範圍"), Range(0, 500)]
    public float rangeAttack = 0.5f;
    [Header("移動速度"), Range(0, 50)]
    public float speed = 2;
    [Header("攻擊特效")]
    public ParticleSystem psAttack;

    [Header("攻擊冷卻時間"), Range(0, 10)]
    public float cdAttack = 3;
    [Header("攻擊力"), Range(0, 1000)]
    public float attack = 50;
  
    private Transform player;
    private player1 _player;
    private float timer;

    [Header("血量")]
    public float hp = 200;
    private float hpMax;
    [Header("血量系統")]
    public HPmanerger1 hpManager;
    [Header("角色是否死亡")]
    private bool isDead = false;

    private float HpMax;

    

    private void Start()
    {
        hpMax = hp;
        player = GameObject.Find("玩家").transform;
        _player = player.GetComponent<player1>();
    }





    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 0, 1, 0.3f);
        Gizmos.DrawSphere(transform.position, rangeTrack);

        Gizmos.color = new Color(1, 0, 0, 0.3f);
        Gizmos.DrawSphere(transform.position, rangeAttack);
    }
    private void Update()
    {
        Track();
    }
    private void Track()
    {
        if (isDead) return;
        float dis = Vector3.Distance(transform.position, player.position);

        //print("距離:" + dis);
        if (dis <= rangeAttack)
        {
            Attack();
        }
        else if (dis <= rangeTrack)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }

    private void Attack()
    {
        timer += Time.deltaTime;

        if (timer >= cdAttack)
        {
            timer = 0;
            psAttack.Play();
            Collider2D hit = Physics2D.OverlapCircle(transform.position, rangeAttack, 1 << 9);
            if (hit && hit.gameObject.tag == "Player") hit.GetComponent<player1>().Hit(attack);

        }


    }
    public void Hit(float damage)
    {
        hp -= damage;
        hpManager.UpdateHpBar(hp, hpMax);
        StartCoroutine(hpManager.ShowDamage(damage));
        if (hp <= 0) Dead();
    }

    private void Dead()
    {
        hp = 0;
        isDead = true;
        Destroy(gameObject, 1.5f);
    }





}
