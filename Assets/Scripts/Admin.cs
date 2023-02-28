using System.Collections.Generic;
using UnityEngine;

public class Admin : MonoBehaviour
{
    /// <summary>
    /// E-mail
    /// </summary>
    public string Email;
    /// <summary>
    /// Пароль
    /// </summary>
    public string Password;
    /// <summary>
    /// Список действий в приложении
    /// </summary>
    public List<AdminAction> Actions;
}
