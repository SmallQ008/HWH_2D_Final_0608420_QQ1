
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


    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.2f);
        Gizmos.DrawSphere(transform.position, rangeAttack);
    }



    private void Move()
    {
        print("移動");
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
       RaycastHit2D hit = Physics2D.CircleCast(transform.position, rangeAttack, -transform.up,0 , 1 << 8);
        print("碰到的物件:" + hit.collider.name);
    }

    private void Hit()
    {

    }

    private void Dead()
    {

    }
    private void Start()
    {
        Move();
    }
    private void Update()
    {
        Move();
    }


}
