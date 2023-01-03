using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIBaseCtrl 
{
    private UIBaseMode m_mode;
    public UIBaseCtrl(UIBaseMode model)
    {
        m_mode = model;
    }

    protected T GetMode<T>() where T:UIBaseMode
    {
        T mode = null;
        if (m_mode != null)
        {
            mode = m_mode as T;
        }
        return mode;
    }
    /// <summary>
    /// 抛出系统事件，用于通知V层刷新界面
    /// </summary>
    /// <param name="msg"></param>
    /// <param name="_data"></param>
    protected void BroadcastSystemMsg(string msg,params decimal[] _data) 
    {
        List<decimal> data = new List<decimal>(_data);
        MsgCenter.BroadcastMsg(EventType.System, msg, data);
    }

    
}
