
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    [Header("追蹤範圍"), Range(0, 500)]
    public float rangeTrack = 2;
    [Header("攻擊範圍"), Range(0, 500)]
    public float rangeAttack = 0.5f;
    [Header("移動速度"), Range(0, 50)]
    public float speed = 2;
    
    [Header("攻擊冷卻時間"), Range(0, 10)]
    public float cdAttack = 3;
    [Header("攻擊力"), Range(0, 1000)]
    public float attack = 20;









    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 0, 1, 0.3f);
        Gizmos.DrawSphere(transform.position, rangeTrack);

        Gizmos.color = new Color(1, 0, 0, 0.3f);
        Gizmos.DrawSphere(transform.position, rangeAttack);
    }






}
