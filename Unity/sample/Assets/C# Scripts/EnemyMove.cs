using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    Rigidbody2D rigid;
    public float speed = 5;
    Animator animation;
    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        animation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        animation.SetBool("Walk", true);
        
        transform.Translate(Vector2.left * (Time.deltaTime * speed), Space.Self);


}

    void FixedUpdate()
    {

    }

 //   public double getAngle()
 //   {
 //        double dy = Player.y - transform.position.x.y;
 //       double dx = Player.x - transform.position.x.x;

 //       return Math.atan2(dy, dx) * (180.0 / Math.PI);
 //   }
}
