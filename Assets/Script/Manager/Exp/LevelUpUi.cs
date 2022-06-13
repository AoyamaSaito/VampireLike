using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpUi : MonoBehaviour
{
    string _text = "";
    ILevel _level = null;

    private LevelUpUi( string text, ILevel level)
    {
        _text = text;
        _level = level;
    }
}
