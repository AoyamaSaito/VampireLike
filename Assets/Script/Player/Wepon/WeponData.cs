using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeponData
{
    int power;
    float interval;
    int quantity;

    public WeponData(string[] _dataList)
    {
        power = int.Parse(_dataList[0]);
        interval = float.Parse(_dataList[1]);
        quantity = int.Parse(_dataList[2]);
    }
    
}

//using system;
//using system.collections;
//using system.collections.generic;
//using unityengine;

//public class characterdata
//{
//    int id;
//    string name;
//    int hp;
//    int at;

//    public characterdata(string[] _datalist)
//    {
//        id = int.parse(_datalist[0]);
//        name = _datalist[1];
//        hp = int.parse(_datalist[2]);
//        at = int.parse(_datalist[3]);
//    }
//    public void debugparametaview()
//    {
//        debug.log(string.format("{0} id:{1} hp:{2} at:{3}", name, id, hp, at));
//    }
//}

