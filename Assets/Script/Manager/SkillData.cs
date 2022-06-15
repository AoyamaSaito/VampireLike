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
        new SkillSelectTable(){ Type = SelectType.Skill, TargetName = "1", Name = "�������e", Level = 0, Probability = 80 },
        new SkillSelectTable(){ Type = SelectType.Skill, TargetName = "1", Name = "�ߋ����͈�", Level = 0, Probability = 80 },
        new SkillSelectTable(){ Type = SelectType.Passive, TargetName = "1", Name = "�U��UP", Level = 0, Probability = 40 },
        new SkillSelectTable(){ Type = SelectType.Passive, TargetName = "1", Name = "���xUP", Level = 0, Probability = 20 },
        new SkillSelectTable(){ Type = SelectType.Passive, TargetName = "1", Name = "�U�����xUP", Level = 5, Probability = 10 },
        new SkillSelectTable(){ Type = SelectType.Execute, TargetName = "1", Name = "��", Level = 0, Probability = 90 },
        new SkillSelectTable(){ Type = SelectType.Execute, TargetName = "1", Name = "�S�[���h", Level = 0, Probability = 40 }
    };
}
