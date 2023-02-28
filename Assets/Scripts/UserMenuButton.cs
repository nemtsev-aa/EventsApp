using System;
using UnityEngine;
using UnityEngine.UI;

public class UserMenuButton : MonoBehaviour
{
    [Tooltip("Cтраница")]
    [SerializeField] public UserPages PageName;

    /// <summary>
    /// Переключение вкладки
    /// </summary>
    public static event Action<UserPages> UserPageSwitching;
    
    public void SetValue(bool value)
    {
        Debug.Log("Нажата кнопка: " + PageName);
        UserPageSwitching?.Invoke(PageName);
    }
}
