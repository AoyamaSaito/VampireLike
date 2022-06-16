using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerParam : MonoBehaviour, IPlayerHit
{
    [SerializeField] float _hp = 100;
    [SerializeField] Slider _slider;

    float _currentHp = 0;
    private void Start()
    {
        _currentHp = _hp;
        _slider.value = 1;
        Init();
    }

    private void Init()
    {
        PlayerManager.Instance.SetPlayer(this.gameObject);
    }

    public void Heal()
    {
        _hp = _currentHp;
    }

    public void PlayerHit(float damage)
    {
        if(0 >= _currentHp - damage) return;
        Debug.Log("Damage");
        _currentHp -= damage;
        _slider.value = _currentHp / _hp;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetExp(collision);
    }

    private void GetExp(Collider2D collider)
    {
        collider.GetComponent<IGetExp>()?.HitExp();
    }
}
