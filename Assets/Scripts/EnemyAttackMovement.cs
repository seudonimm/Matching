using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackMovement : MonoBehaviour
{
    Transform _transform;

    [SerializeField] float moveSpeed;
    [SerializeField] Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        _transform = transform;

        if (_transform.position.y == 7)
        {
            direction = Vector2.down;
        }
        if (_transform.position.x == 7)
        {
            direction = Vector2.left;
        }
        if (_transform.position.y == -7)
        {
            direction = Vector2.up;
        }
        if (_transform.position.x == -7)
        {
            direction = Vector2.right;
        }

    }

    // Update is called once per frame
    void Update()
    {
        _transform.Translate(direction * moveSpeed * Time.deltaTime);

        if (direction == Vector2.down && _transform.position.y < 0)
        {
            Destroy(gameObject);
        }
        if (direction == Vector2.up && _transform.position.y > 0)
        {
            Destroy(gameObject);
        }
        if (direction == Vector2.left && _transform.position.x < 0)
        {
            Destroy(gameObject);
        }
        if (direction == Vector2.right && _transform.position.x > 0)
        {
            Destroy(gameObject);
        }
    }
}
