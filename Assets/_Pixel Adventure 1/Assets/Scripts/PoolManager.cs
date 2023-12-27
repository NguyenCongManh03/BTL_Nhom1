using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    private static PoolManager _instance;
    public static PoolManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject("PoolManager");
                go.AddComponent<PoolManager>();
            }
            return _instance;
        }
    }
    [Header("Bullet")]
    [SerializeField]
    private int _numberOfBullet;
    public GameObject _bulletPerfab;
    [SerializeField]
    public List<GameObject> _bulletsList = new List<GameObject>();
    [SerializeField]
    private GameObject _bulletContainer;
    private void Awake()
    {
        _instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < _numberOfBullet; i++)
        {
            GameObject bullet =
                Instantiate(_bulletPerfab, Vector2.zero, Quaternion.identity) as GameObject;
            bullet.transform.parent = _bulletContainer.transform;
            bullet.SetActive(false);
            _bulletsList.Add(bullet);
        }
    }

    
}
