using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D Player;
    float MovementX;
    [Range(0, 20)]
    [SerializeField] float MoveSpeed;
    [SerializeField] Transform FirePoint;
    [SerializeField] GameObject Bullet;

    float NextAttackTime;
    [SerializeField] float AttackRate;
    [SerializeField] float Second;
    public bool FireDirection = true;
    // Start is called before the first frame update
    void Start()
    {
        Player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboard();
        PlayerFire();

    }

    void PlayerFire() {
        if (Input.GetMouseButton(0)) {
            if (Time.time >= NextAttackTime) {
                Instantiate(Bullet, FirePoint.position, Quaternion.Euler(0, 0, 0));
                NextAttackTime = Time.time + Second / AttackRate;
            }
        }
    }

    void PlayerMoveKeyboard() {
        MovementX = Input.GetAxis("Horizontal");
        if (MovementX > 0f) {
            Player.velocity = new Vector2(MovementX * MoveSpeed, Player.velocity.y);
            transform.localScale = new Vector2(1, 1);
            FireDirection = true;
        }
        else if (MovementX < 0f) {
            Player.velocity = new Vector2(MovementX * MoveSpeed, Player.velocity.y);
            transform.localScale = new Vector2(-1, 1);
            FireDirection = false;
        }
        else {
            Player.velocity = new Vector2(0, Player.velocity.y);
        }
    }
}
