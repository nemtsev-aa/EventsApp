using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionFirebase : MonoBehaviour
{
    /// <summary>
    /// Поиск пользователя по ID
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public static bool FindUserById(string userId)
    {

        if(ConnectionFirebase.Reference.Child("Users").Child(userId).GetValueAsync() != null)
        {
            Debug.Log("Пользователь найден!");
            return true;
        }
        else
        {
            Debug.Log("Пользователь не найден!");
            return false;
        }
    }

    public static bool UpdateUserData(User user)
    {

        return true;
    }

    public static bool WriteUserData(User user)
    {
        string json = JsonUtility.ToJson(user);
        ConnectionFirebase.Reference.Child("Users").Child(user.UserId).SetRawJsonValueAsync(json);
        Debug.Log("Данные загружены!");
        return true;
    }
    public void WriteEventData(EventObj user)
    {

    }

    public void ReceivingUserData(User user)
    {

    }

    public void ReceivingEventData(EventObj user)
    {

    }

    
}
