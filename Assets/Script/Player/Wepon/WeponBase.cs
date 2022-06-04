using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeponBase : MonoBehaviour
{
    [SerializeField] string _sheetId = "";

    protected int power;
    protected float interval;
    protected int quantity;
}
