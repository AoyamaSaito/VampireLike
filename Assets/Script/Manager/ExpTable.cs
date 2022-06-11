using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpTable
{
    static private ExpTable _instance = new ExpTable();
    static public ExpTable Instance => _instance;
    private ExpTable() { }

    private int[] _levelTable = new int[] { 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21,
        22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41,
        42, 43, 45, 46, 47, 48, 49, 50};
    public int[] LevelTable => _levelTable;
}
