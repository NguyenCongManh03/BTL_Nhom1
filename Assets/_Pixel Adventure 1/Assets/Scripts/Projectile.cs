using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Projectile : MonoBehaviour
{
    
    public int _direction;
    private Rigidbody2D _bulletRB;
    public float _bulletSpeed;
    public int _bulletDamage;

    [SerializeField]
    private float _range;
    private Vector2 _position;
    // Start is called before the first frame update
    void Start()
    {
        
        _position = transform.position;
        _bulletRB = GetComponent<Rigidbody2D>();
        _direction = 1;
    }

    // Update is called once per frame
    void Update()
    {
        SetBulletOff();
        _bulletRB.velocity = new Vector2( _direction * _bulletSpeed,_bulletRB.velocity.y);

    }
    private void SetBulletOff()
    {
        if (((Vector2)transform.position - _position).magnitude > _range)
        {
            gameObject.SetActive(false);
        }
    }
    public void Fire(int direction)
    {
        _direction = direction;
        gameObject.SetActive(true);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }
        gameObject.SetActive(false);
    }
}
