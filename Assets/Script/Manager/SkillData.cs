using System;
using System.Collections.Generic;

public enum SelectType
{
    Skill = 1,
    Passive = 2,
    Execute = 3,
}

[Serializable]
public class SkillSelectTable
{
    public SelectType Type;
    public string TargetName;
    public string Name;
    public int Level;
    public int Probability;
}

public class SkillData
{
    static public List<SkillSelectTable> SkillSelectTable = new List<SkillSelectTable>()
    {
        new SkillSelectTable(){ Type = SelectType.Skill, TargetName = "1", Name = "Axeレベルアップ", Level = 0, Probability = 80 },
        new SkillSelectTable(){ Type = SelectType.Passive, TargetName = "1", Name = "速度UP", Level = 0, Probability = 20 },
        new SkillSelectTable(){ Type = SelectType.Passive, TargetName = "1", Name = "攻撃速度UP", Level = 5, Probability = 10 },
        new SkillSelectTable(){ Type = SelectType.Execute, TargetName = "1", Name = "回復", Level = 0, Probability = 90 },
    };
}
