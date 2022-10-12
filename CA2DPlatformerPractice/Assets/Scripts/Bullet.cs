using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] int BulletDamage = 50;
    Rigidbody2D rb;
    [SerializeField] float BulletForce = 5f;
    PlayerController PlayerScript;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        PlayerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        if (PlayerScript.FireDirection == true) {
            rb.AddForce(Vector2.right * BulletForce, ForceMode2D.Impulse);
        }else {
            rb.AddForce(Vector2.left * BulletForce, ForceMode2D.Impulse);
        }
        Destroy(gameObject, 3);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.transform.CompareTag("Enemy")) {
            other.transform.GetComponent<EnemyController>().EnemyGetDamage(BulletDamage);
            Destroy(gameObject);
        }
    }
}
