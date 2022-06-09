using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface ILevel
{
    int Level { get; }
    void LevelUp();
}
