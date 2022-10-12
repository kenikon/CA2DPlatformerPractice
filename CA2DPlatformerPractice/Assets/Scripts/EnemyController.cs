using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] int Health = 100;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EnemyGetDamage(int damage) {
        Health -= damage;
        if (Health <= 0) {
            Destroy(gameObject);
        }
    }
}
