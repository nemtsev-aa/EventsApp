using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class UserView : MonoBehaviour
{
    [Tooltip("���")]
    [SerializeField] private TMP_InputField _nameField;
    [Tooltip("���� ��������")]
    [SerializeField] private TMP_InputField _birthdateField;
    [Tooltip("���")]
    [SerializeField] private Gender _gender;
    [Tooltip("��������")]
    [SerializeField] private List<Category> _categoryList;

    private string userId;

    
    private void Start()
    {
        userId = ConnectionFirebase.AuthorizationPlayer.CurrentUser.UserId;
    }

    public bool UpdateUserData()
    {
        if (InteractionFirebase.FindUserById(userId) != true)
        {
            /// ������������ �� ������ � ��
            User newUser = new User();
            newUser.UserId = userId;
            newUser.Name = _nameField.text;
            newUser.Birthdate = _birthdateField.text;
            newUser.Gender = Gender.Male;
            newUser.Actions = new List<UserActions>();
            newUser.PlannedEvents = new List<EventObj>();
            newUser.ArhiveEvents = new List<EventObj>();

            InteractionFirebase.WriteUserData(newUser);
        }
        //else
        //{

        //}

        return true;
    }
}
