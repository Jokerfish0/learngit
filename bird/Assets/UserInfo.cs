using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInfo
{//创建链表类
    public string UserName;
    public string Password;
    public bool IsMan;
    public UserInfo(string UserName,string Password,bool IsMan)
    {
        this.UserName = UserName;
        this.Password = Password;   
        this.IsMan = IsMan;
    }
}

public class GameManager
{//存储数据方法
    public List<UserInfo>  userInfos = new List<UserInfo>();
    private static GameManager instance;
    public static GameManager Instance {       
        get { 
            if(instance == null)instance = new GameManager();
            return instance;
        }   
    }
    public void SaveUserInfo(UserInfo userInfo)
    {
        userInfos.Add(userInfo);
    }

    public UserInfo GetUserInfo(string name)
    {
        for (int i = 0; i < userInfos.Count; i++)
        {
            if (userInfos[i].UserName == name)
            {
                return userInfos[i];
            }
        }

        return null;
    }

}

