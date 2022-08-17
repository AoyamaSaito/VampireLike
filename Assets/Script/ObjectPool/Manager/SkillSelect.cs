using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SkillSelect : SingletonMonoBehaviour<SkillSelect>
{
    [SerializeField] CanvasGroup _canvas;
    [SerializeField] List<GameObject> _selectList;

    List<SkillSelectTable> _selectTable = new List<SkillSelectTable>();
    List<UnityEngine.UI.Text> _selectText = new List<UnityEngine.UI.Text>();

    bool _startEvent = false;

    void Start()
    {
        for (int i = 0; i < _selectList.Count; ++i)
        {
            _selectTable.Add(null);
            _selectText.Add(_selectList[i].GetComponentInChildren<UnityEngine.UI.Text>());
            {
                var index = i;
                var btn = _selectList[i].GetComponentInChildren<UnityEngine.UI.Button>();
                btn.onClick.AddListener(() =>
                {
                    if (_canvas.alpha == 0) return;
                    OnClick(index);
                });
            }
        }
    }

    private void Update()
    {
        if (_startEvent)
        {
            SelectStart();
            _startEvent = false;
        }
    }

    public void SelectStartDelay()
    {
        _startEvent = true;
    }

    public void SelectStart()
    {
        _canvas.alpha = 1;

        List<SkillSelectTable> table = new List<SkillSelectTable>();
        var list = SkillData.SkillSelectTable.Where(s => GameManager.Level >= s.Level);

        int totalProb = list.Sum(s => s.Probability);
        int rand = Random.Range(0, totalProb);

        for (int i = 0; i < _selectList.Count; ++i)
        {
            _selectTable[i] = null;
            _selectText[i].text = "";
        }

        for (int i = 0; i < _selectList.Count; ++i)
        {
            foreach (var s in list)
            {
                //if (rand < s.Probability)
                //{
                //    Debug.Log(s.Name);
                //    _selectTable[i] = s;
                //    _selectText[i].text = s.Name;
                //    list = list.Where(ls => !(ls.Type == s.Type && ls.TargetName == s.TargetName));
                //    break;
                //}
                Debug.Log(s.Name);
                _selectTable[i] = s;
                _selectText[i].text = s.Name;
                list = list.Where(ls => !(ls.Type == s.Type && ls.TargetName == s.TargetName));
                rand -= s.Probability;
                break;
            }
        }
    }

    public void OnClick(int index)
    {
        GameManager.Instance.LevelUpSelect(_selectTable[index]);

        _canvas.alpha = 0;
    }
}
