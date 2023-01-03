using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
public class ResourceMgr : SingLetong<ResourceMgr>
{
    Dictionary<string, dynamic> _resources = new Dictionary<string, dynamic>();
    public Transform m_uiroot;

    public ResourceMgr()
    {
        m_uiroot = GameObject.Find("Canvas").transform;
    }

    static public T LoadResourceByType<T>(string _path) where T : UnityEngine.Object//T:GameObject Path: uibag
    {
        T obj = null;
        //判断库中是否已经加载过
        if (GetInstance()._resources.ContainsKey(_path))
        {
            obj = GetInstance()._resources[_path] as T;
        }
        if (obj == null)
        {
            obj = Resources.Load<T>(_path);
            if (GetInstance()._resources.ContainsKey(_path))
            {
                obj = GetInstance()._resources[_path] as T;
            }
            else
            {
                GetInstance()._resources.Add(_path, obj);
            }
        }
        return obj;
    }

    static public GameObject LoadGoAndIns(string path) //uibag
    {
        GameObject obj = LoadResourceByType<GameObject>(path);//加载
        obj = GameObject.Instantiate(obj);//实例
        obj.transform.SetParent(GetInstance().m_uiroot);//设置父节点
        obj.transform.localPosition = Vector3.zero;//重新设置位置
        return obj;
    }
}
