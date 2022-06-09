using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour, IObjectPool
{
    [SerializeField] 
    float _movePower = 30f;
    [SerializeField] 
    Rigidbody2D _rb;
    [SerializeField] 
    SpriteRenderer _image;
    [SerializeField] 
    WeponData _weponData;

    private int _power = 0;
    private float _interval = 0;
    private int _quantity = 0;
    private Wepon _wepon;

    bool _isActrive = false;
    public bool IsActive => _isActrive;
    public void DisactiveForInstantiate()
    {
        _image.enabled = false;
        _rb.simulated = false;
    }
    public void Create()
    {
        _image.enabled = true;
        _rb.simulated = true;

        transform.position = PlayerManager.Instance.Player.transform.position;

        _wepon = _weponData.Wepon;
        _power = _wepon.Power;
        _interval = _wepon.Interval;
        _quantity = _wepon.Quantity;

        Vector3 dir = new Vector3(Random.Range(0.5f, -0.5f), Random.Range(0.5f, -0.5f), 0).normalized;
        _rb.AddForce(dir * _movePower, ForceMode2D.Impulse);
    }

    public void Destroy()
    {
        _image.enabled = false;
        _rb.simulated = false;
    }

    private void OnTriggerEnter2D(Collider2D collision, EnemyParam param = null)
    {
        if (collision.gameObject.TryGetComponent<EnemyParam>(out param))
        {
            param.Damage(_power);
        }
    }
}
