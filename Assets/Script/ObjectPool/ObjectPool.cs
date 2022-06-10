using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Unity��́A����̌^�̃I�u�W�F�N�g�v�[��
/// </summary>
/// <typeparam name="T"></typeparam>
public class ObjectPool<T> where T : UnityEngine.Object, IObjectPool
{
    T BaseObj;
    Transform Parent;
    List<T> Pool = new ();
    int Index = 0;

    public void SetBaseObj(T obj, Transform parent)
    {
        BaseObj = obj;
        Parent = parent;
    }

    public void Pooling(T obj)
    {
        obj.DisactiveForInstantiate();
        Pool.Add(obj);
    }

    public void SetCapacity(int size)
    {
        //���ɃI�u�W�F�N�g�T�C�Y���傫���Ƃ��͍X�V���Ȃ�
        if (size < Pool.Count) return;

        for (int i = Pool.Count - 1; i < size; ++i)
        {
            T Obj = default(T);
            if (Parent)
            {
                Obj = GameObject.Instantiate(BaseObj, Parent);
            }
            else
            {
                Obj = GameObject.Instantiate(BaseObj);
            }
            Pooling(Obj);
        }
    }

    public T Instantiate()
    {
        T ret = null;
        for (int i = 0; i < Pool.Count; ++i)
        {
            int index = (Index + i) % Pool.Count;
            if (Pool[index].IsActive) continue;

            Pool[index].Create();
            ret = Pool[index];
            break;
        }

        if(ret == null)
        {
            SetCapacity(Pool.Count + Pool.Count/2);
            return Instantiate();
        }

        return ret;
    }
}