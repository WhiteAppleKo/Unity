using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TowerAttack : MonoBehaviour
{
    [SerializeField] private float effectionRadius = 10;
    [HideInInspector] public Transform TowerTransform;
    public LayerMask AttackLayer;
    public List<Collider2D> AttackedObjects = new List<Collider2D>();

    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator animation;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animation = GetComponent<Animator>();
        TowerTransform = GetComponent<Transform>();
    }

    void Update()
    {
        AttackedEnemy();
        AttackEnemy();
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, effectionRadius);
    }

    void AttackedEnemy()
    {
        AttackedObjects = Physics2D.OverlapCircleAll(TowerTransform.position, effectionRadius, AttackLayer).ToList();// can be optimized
    }

    void AttackEnemy()
    {
        if (AttackedObjects.Count >= 1)
            animation.SetBool("Find Enemy", true);
        else
            animation.SetBool("Find Enemy", false);

    }

}