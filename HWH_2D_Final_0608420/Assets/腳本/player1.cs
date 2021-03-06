
using UnityEngine;

public class player1 : MonoBehaviour
{
    [Header("等級")]
    [Tooltip("這是角色的等級")]
    public int lv = 1;
    [Header("移動速度"),Range(0,300)]
    public float speed = 10.5f;
    public bool isDead = false;
    [Tooltip("這是角色的名稱")]
    public string cName = "貓咪";
    [Header("虛擬搖桿")]
    public FixedJoystick joystick;
    [Header("變形元件")]
    public Transform tra;
    [Header("動畫元件")]
    public Animator ani;
    [Header("偵測範圍")]
    public float rangeAttack = 2.5f;
    [Header("音效來源")]
    public AudioSource aud;
    [Header("攻擊音效")]
    public AudioClip soundAttack;
    [Header("血量")]
    public float hp = 200;
    private float hpMax;
    [Header("血量系統")]
    public HPmanerger1 hpManager;
    [Header("攻擊力"), Range(0, 1000)]
    public float attack = 50;



    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.2f);
        Gizmos.DrawSphere(transform.position, rangeAttack);
    }



    private void Move()
    {
       // print("移動");
        float h = joystick.Horizontal;
        float v = joystick.Vertical;

        tra.Translate(h*speed*Time.deltaTime,v*speed*Time.deltaTime, 0);
        ani.SetFloat("水平", h);
        ani.SetFloat("垂直", v);
        

    }

    public void Attack()
    {
        aud.PlayOneShot(soundAttack, 0.5f);
        print("攻擊");
        Collider2D hit = Physics2D.OverlapCircle(transform.position, rangeAttack, 1 << 8);

        aud.PlayOneShot(soundAttack, 0.5f);
        if (hit && hit.gameObject.tag == "Enemy") hit.gameObject.GetComponent<Enemy1>().Hit(attack);
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

    }
    private void Start()
    {
        hpMax = hp;
        
    }
    private void Update()
    {
        Move();
    }


}
