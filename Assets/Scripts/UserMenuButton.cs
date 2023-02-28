using System;
using UnityEngine;
using UnityEngine.UI;

public class UserMenuButton : MonoBehaviour
{
    [Tooltip("C�������")]
    [SerializeField] public UserPages PageName;

    /// <summary>
    /// ������������ �������
    /// </summary>
    public static event Action<UserPages> UserPageSwitching;
    
    public void SetValue(bool value)
    {
        Debug.Log("������ ������: " + PageName);
        UserPageSwitching?.Invoke(PageName);
    }
}
