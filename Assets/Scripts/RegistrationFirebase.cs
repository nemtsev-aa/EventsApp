using Firebase.Auth;
using Firebase;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Threading.Tasks;
using System;

public class RegistrationFirebase : MonoBehaviour
{
    // Если true, то после регистрации пользователю не надобудет потом заново входить.
    [Tooltip("Запомнить пользователя")]
    [SerializeField] private bool _allowLoginIfHasUser = false;
    [SerializeField] private TMP_InputField _inputFieldEmail;
    [SerializeField] private TMP_InputField _inputFieldPassword;
    [Tooltip("Флажёк - Запомнить пользователя")]
    [SerializeField] private Toggle _allowLoginToggle;
    [SerializeField] private TextMeshProUGUI _errorText;

    [SerializeField] private ErrorManager _errorManager;
    [SerializeField] private UI_Manager _uiManager;

    [Tooltip("Текстовое поле - ID пользователя")]
    public static string UserId = "";

    public static bool AdminStatus;
    /// <summary>
    /// Успешная авторизация пользователя
    /// </summary>
    public static event Action UserAuthorization;
    /// <summary>
    /// Успешная авторизация администратора
    /// </summary>
    public static event Action AdminAuthorization;
    /// <summary>
    /// Выход из системы
    /// </summary>
    public static event Action SignOutMake;

    private void Start()
    {
        _allowLoginToggle.onValueChanged.AddListener(delegate
        {
            SetToggleValue(_allowLoginToggle.isOn);
        });
    }
    // Инициализация системы аутентификации
    private void InitializeFirebase()
    {
        // Если в систем присутствует пользователь
        if (ConnectionFirebase.AuthorizationPlayer.CurrentUser != null)
        {
            // Если флаг "Запомнить пароль" не установлен
            if (_allowLoginIfHasUser == false)
            {
                // Осуществляем выход из системы
                ConnectionFirebase.AuthorizationPlayer.SignOut();
            }
            else
            {
                // Переходим в приложение по сохранёным данным пользователя
                if (PlayerPrefs.GetString("email") != null)
                {
                    _inputFieldEmail.text = PlayerPrefs.GetString("email");
                }
                if (PlayerPrefs.GetString("password") != null)
                {
                    _inputFieldPassword.text = PlayerPrefs.GetString("password");
                }

                if (_inputFieldEmail.text == "admin@mail.ru")
                {
                    AdminStatus = true;
                }

                // Переходим в личный кабинет 
                Invoke(nameof(GoToApp), 2f);
            }
        }
    }

    public void RegisterButton()
    {
        StartCoroutine(RegisterPlayer(_inputFieldEmail.text, _inputFieldPassword.text));
    }

    public void LoginButton()
    {
        StartCoroutine(SignIn(_inputFieldEmail.text, _inputFieldPassword.text));
    }
    private IEnumerator SignIn(string email, string password)
    {
        var loginTask = ConnectionFirebase.AuthorizationPlayer.SignInWithEmailAndPasswordAsync(email, password);
        yield return new WaitUntil(predicate: () => loginTask.IsCompleted);

        if (loginTask.Exception != null)
        {
            _errorManager.WhatErrorOut(loginTask.Exception.GetBaseException() as FirebaseException);
        }
        else
        {
            if (email == "admin@mail.ru")
            {
                AdminStatus = true;
            }
            _errorManager.UpdateTextError(_errorText, $"Удачный вход пользователя {email}");
            GoToApp();
        }
    }

    //public void LoginButton()
    //{
    //    LoginPlayer(_inputFieldEmail.text, _inputFieldPassword.text);
    //}

    //private void LoginPlayer(string email, string password)
    //{
    //    var loginTask = ConnectionFirebase.AuthorizationPlayer.SignInWithEmailAndPasswordAsync(email, password);
    //    yield return new WaitUntil(predicate: () => loginTask.IsCompleted);




    //    //var taskScheduler = TaskScheduler.FromCurrentSynchronizationContext();
    //    //ConnectionFirebase.AuthorizationPlayer.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(taskScheduler =>
    //    //{
    //    //    if (taskScheduler.IsFaulted)
    //    //    {
    //    //        _errorManager.UpdateTextError(taskScheduler.Exception.GetBaseException().ToString().Remove(0, 28));
    //    //        return;
    //    //    }

    //    //    if (taskScheduler.IsCompleted)
    //    //    {
    //    //        if (email == "admin@mail.ru")
    //    //        {
    //    //            AdminStatus = true;
    //    //        }
    //    //        _errorManager.UpdateTextError($"Удачный вход пользователя {email}");
    //    //        GoToApp();
    //    //        return;
    //    //    }
    //    //}, taskScheduler);

    //    //if (ConnectionFirebase.AuthorizationPlayer.CurrentUser != null)
    //    //{
    //    //    ConnectionFirebase.AuthorizationPlayer.SignOut();
    //    //}
    //}

    private void GoToApp()
    {
        UserId = ConnectionFirebase.AuthorizationPlayer.CurrentUser.UserId;
        if (AdminStatus == false)
        {
            UserAuthorization?.Invoke();
        }
        else
        {
            AdminAuthorization?.Invoke();
        }
    }

    /// <summary>
    /// Регистрация пользователя
    /// </summary>
    /// <param name="name"></param>
    /// <param name="email"></param>
    /// <param name="password"></param>
    /// <param name="url"></param>
    /// <returns></returns>
    private IEnumerator RegisterPlayer(string email, string password)
    {
        // Регистрируем пользователя в приложении через систему аутентификации
        var registerTask = ConnectionFirebase.AuthorizationPlayer.CreateUserWithEmailAndPasswordAsync(email, password);
        yield return new WaitUntil(predicate: () => registerTask.IsCompleted);
        // Если в процессе создания возникли ошибки - выводим сообщение
        if (registerTask.Exception != null)
        {
            _errorManager.WhatErrorOut(registerTask.Exception.GetBaseException() as FirebaseException);
        }
        else
        {
            ConnectionFirebase.User = registerTask.Result;

            if (ConnectionFirebase.User != null)
            {
                UserProfile profile = new UserProfile { DisplayName = email };
                var profileTask = ConnectionFirebase.User.UpdateUserProfileAsync(profile);
                yield return new WaitUntil(predicate: () => profileTask.IsCompleted);

                if (profileTask.Exception != null)
                {
                    _errorManager.UpdateTextError(_errorText, "Ошибка создания профиля!");
                }
                else
                {
                    SaveUsersData();
                }

                // Переходим в личный кабинет 
                Invoke(nameof(GoToApp), 2f);
            }
        }
    }
    /// <summary>
    /// Сохранение данных пользователя
    /// </summary>
    private void SaveUsersData()
    {
        if (_allowLoginIfHasUser)
        {
            PlayerPrefs.SetString("email", _inputFieldEmail.text);
            PlayerPrefs.SetString("password", _inputFieldPassword.text);
        }
        else
        {
            PlayerPrefs.SetString("email", null);
            PlayerPrefs.SetString("password", null);
        } 
    }
    /// <summary>
    /// Переключение автосохранения логина и пароля
    /// </summary>
    /// <param name="value"></param>
    private void SetToggleValue(bool value)
    {
        _allowLoginToggle.isOn = value;
        _allowLoginIfHasUser = value;
    }

    public void SignOut()
    {
        // Осуществляем выход из системы
        ConnectionFirebase.AuthorizationPlayer.SignOut();

        SignOutMake?.Invoke();
    }
}
