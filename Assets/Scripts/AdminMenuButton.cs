using System;
using UnityEngine;
using UnityEngine.UI;

public class AdminMenuButton : MonoBehaviour
{
    [Tooltip("Cтраница меню")]
    [SerializeField] public AdminPages PageName;
    
    /// <summary>
    /// Переключение вкладки
    /// </summary>
    public static event Action<AdminPages> AdminPageSwitching;

    public void SetValue()
    {
        Debug.Log("Нажата кнопка: " + PageName);
        AdminPageSwitching?.Invoke(PageName);
    }
}
