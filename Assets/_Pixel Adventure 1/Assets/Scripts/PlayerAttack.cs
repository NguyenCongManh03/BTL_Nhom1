using Com.LuisPedroFonseca.ProCamera2D.TopDownShooter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Player _player;
    [SerializeField]
    private Transform _pointFire;
    [SerializeField]
    private float _attackSpeed;
    private float _attackTime;
    public int direction;
    // Start is called before the first frame update
    void Start()
    {
        _player = GetComponent<Player>();
        _attackTime = Mathf.Infinity;
        direction = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(_player.isFacingRight) { direction = 1 ; }
        else if(_player.isFacingRight == false) { direction = -1 ; }
        if(_attackTime >= _attackSpeed && Input.GetMouseButtonDown(0)) Attack();
        
        _attackTime += Time.deltaTime;
        
    }
    private void Attack()
    {
        if (_attackTime >= _attackSpeed)
        {
            for (int i = 0; i < PoolManager.Instance._bulletsList.Count; i++)
            {
                if (!PoolManager.Instance._bulletsList[i].activeInHierarchy)
                {
                    PoolManager.Instance._bulletsList[i].transform.position = _pointFire.position;
                    PoolManager.Instance._bulletsList[i].GetComponent<Projectile>().
                         Fire(direction);
                    _attackTime = 0f;
                    break;
                }
            }
        }
    }
}
