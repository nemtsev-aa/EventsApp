using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


public class UI_Manager : MonoBehaviour
{
    [Tooltip("C������� �����������")]
    [SerializeField] private GameObject _loginPage;

    [Tooltip("������ �������������� ��� ����������� ������� ����������")]
    [SerializeField] private GameObject _adminButtonsWrapper;
    private List<AdminMenuButton> _adminMenuButtons = new List<AdminMenuButton>();
    [Tooltip("��������� ������� ��������������")]
    [SerializeField] private GameObject _adminPagesObj;
    [Tooltip("������ ������� ��������������")]
    [SerializeField] private List<GameObject> _adminPages;

    [Tooltip("������ ������������ ��� ����������� ������� ����������")]
    [SerializeField] private GameObject _userButtonsWrapper;
    private List<UserMenuButton> _userMenuButtons = new List<UserMenuButton>();
    [Tooltip("��������� ������� ������������")]
    [SerializeField] private GameObject _userPagesObj;
    [Tooltip ("������ ������� ������������")]
    [SerializeField] private List<GameObject> _userPages;
    
    /// <summary>
    ///  ������ �������� �������
    /// </summary>
    private int _activePageName;
    
    #region Action
    /// <summary>
    /// ������������ �������
    /// </summary>
    public static event Action<int> TabsSwitching;
    #endregion

    void Start()
    {
        SwitchLoginPage(true);
    }

    private void SwitchLoginPage(bool status)
    {
        if (status)
        {
            //���������� ������� "����"
            _loginPage.SetActive(true);

            _adminButtonsWrapper.SetActive(false);
            _adminPagesObj.SetActive(false);

            _userButtonsWrapper.SetActive(false);
            _userPagesObj.SetActive(false);
        }
        else
        {
            //������������ ������� "����"
            _loginPage.SetActive(false);
        }
        
    }

    private void OnEnable()
    {
        RegistrationFirebase.SignOutMake += LoginMenuView;
        RegistrationFirebase.UserAuthorization += ActivateMenuButtons;
        RegistrationFirebase.AdminAuthorization += ActivateMenuButtons;

        AdminMenuButton.AdminPageSwitching += SwitchAdminPage;
        UserMenuButton.UserPageSwitching += SwitchUserPage;
    }

    private void OnDisable()
    {
        RegistrationFirebase.SignOutMake -= LoginMenuView;
        RegistrationFirebase.UserAuthorization -= ActivateMenuButtons;
        RegistrationFirebase.AdminAuthorization -= ActivateMenuButtons;

        AdminMenuButton.AdminPageSwitching -= SwitchAdminPage;
        UserMenuButton.UserPageSwitching -= SwitchUserPage;
    }
    private void LoginMenuView()
    {
        _userButtonsWrapper.SetActive(false);

        throw new NotImplementedException();
    }
    private void ActivateMenuButtons()
    {
        SwitchLoginPage(false);

        if (RegistrationFirebase.AdminStatus == true)
        {
            _adminButtonsWrapper.SetActive(true);
            _adminPagesObj.SetActive(true);

            SwitchAdminPage(AdminPages.Statistic);
            Debug.Log("����� �����");
        }
        else
        {
            _userButtonsWrapper.SetActive(true);
            _userPagesObj.SetActive(true);
            SwitchUserPage(UserPages.Account);
            Debug.Log("����� ������������");
        }
    }

    //private void SetStatusMenuButtons(bool status)
    //{
    //    if (status)
    //    {
    //        // �������� ������
    //        _menuButtonsWrapper.SetActive(true);

    //        // ��������� ������ 
    //        menuButtons.AddRange(gameObject.GetComponentsInChildren<MenuButton>());

    //        // ���������� ������
    //        foreach (var iMenuButton in menuButtons)
    //        {
    //            iMenuButton.SetStatus(true);
    //        }
    //    }
    //    else
    //    {
    //        // ��������� ������
    //        _menuButtonsWrapper.SetActive(false);
    //    } 
    //}

    //private void SetValueMenuButton(bool value, int index)
    //{
    //    // ��������� ������
    //    foreach (var iMenuButton in menuButtons)
    //    {
    //        if (iMenuButton.Index == index)
    //        {
    //            iMenuButton.SetValue(value);
    //        }  
    //    }
    //}

    /// <summary>
    /// ������������ ������� ����
    /// </summary>
    /// <param name="pageIndex"></param>
    public void SwitchAdminPage(AdminPages viewPage)
    {
        foreach (var iPage in _adminPages)
        {
            if (iPage.GetComponent<AdminPage>().PageName == viewPage)
            {
                iPage.SetActive(true);
            }
            else
            {
                iPage.SetActive(false);
            }
        }


    }

    /// <summary>
    /// ������������ ������� ����
    /// </summary>
    /// <param name="pageIndex"></param>
    public void SwitchUserPage(UserPages viewPage)
    {
        foreach (var iPage in _userPages)
        {
            if (iPage.GetComponent<UserPage>().PageName == viewPage)
            {
                iPage.SetActive(true);
            }
            else
            {
                iPage.SetActive(false);
            } 
        }
    }
}
