using System;
using UnityEngine;
using UnityEngine.UI;

public class AdminMenuButton : MonoBehaviour
{
    [Tooltip("C������� ����")]
    [SerializeField] public AdminPages PageName;
    
    /// <summary>
    /// ������������ �������
    /// </summary>
    public static event Action<AdminPages> AdminPageSwitching;

    public void SetValue()
    {
        Debug.Log("������ ������: " + PageName);
        AdminPageSwitching?.Invoke(PageName);
    }
}
