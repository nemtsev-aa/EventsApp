using UnityEngine;
using UnityEngine.UI;
using Firebase.Auth;
using Firebase;
using TMPro;

public class ErrorManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _errorText;

    public void UpdateTextError(TextMeshProUGUI errorLabel, string text)
    {
        _errorText = errorLabel;
        _errorText.text += "\n" + text;
        Invoke(nameof(DestroyText), 2f);
    }

    private void DestroyText()
    {
        _errorText.text = "";
    }

    public void WhatErrorOut(FirebaseException firebaseException)
    {
        AuthError errorCode = (AuthError)firebaseException.ErrorCode;
        string message = "Ошибка авторизации!";
        switch (errorCode)
        {
            case AuthError.None: message = "Никто!"; break;
            case AuthError.Unimplemented: message = "Нереализованный!"; break;
            case AuthError.Failure: message = "Отказ! Попробуйте позже!"; break;
            case AuthError.InvalidCustomToken: message = "Недействительный специальный токен!"; break;
            case AuthError.CustomTokenMismatch: message = "Несоответствие пользовательского токена!"; break;
            case AuthError.InvalidCredential: message = "Неверные учетные данные!"; break;
            case AuthError.UserDisabled: message = "Пользователь отключ?н!"; break;
            case AuthError.AccountExistsWithDifferentCredentials: message = "Уч?тная запись существует с другими данными!"; break;
            case AuthError.OperationNotAllowed: message = "Операция не разрешена!"; break;
            case AuthError.EmailAlreadyInUse: message = "Эта почта уже используется!"; break;
            case AuthError.RequiresRecentLogin: message = "Требуется недавний вход!"; break;
            case AuthError.CredentialAlreadyInUse: message = "Учетные данные уже используются!"; break;
            case AuthError.InvalidEmail: message = "Неверный адрес электронной почты!"; break;
            case AuthError.WrongPassword: message = "Неправильный пароль"; break;
            case AuthError.TooManyRequests: message = "Слишком много запросов! Попробуйте позже!"; break;
            case AuthError.UserNotFound: message = "Пользователь не найден"; break;
            case AuthError.ProviderAlreadyLinked: message = "Пользователь уже в игре"; break;
            case AuthError.NoSuchProvider: message = "Нет такого провайдера!"; break;
            case AuthError.InvalidUserToken: message = "Неверный токен пользователя!"; break;
            case AuthError.UserTokenExpired: message = "Срок действия токена пользователя истек!"; break;
            case AuthError.NetworkRequestFailed: message = "Ошибка сетевого запроса!"; break;
            case AuthError.InvalidApiKey: message = "Неверный ключ API!"; break;
            case AuthError.AppNotAuthorized: message = "Приложение не авторизовано!"; break;
            case AuthError.UserMismatch: message = "Несоответствие пользователей!"; break;
            case AuthError.WeakPassword: message = "Слабый пароль!"; break;
            case AuthError.NoSignedInUser: message = "Пользователь не вошел в систему!"; break;
            case AuthError.ApiNotAvailable: message = "Api недоступен!"; break;
            case AuthError.ExpiredActionCode: message = "Код действия с истекшим сроком действия!"; break;
            case AuthError.InvalidActionCode: message = "Неверный код действия!"; break;
            case AuthError.InvalidMessagePayload: message = "Недействительные данные сообщения!"; break;
            case AuthError.InvalidPhoneNumber: message = "Неправильный номер телефона!"; break;
            case AuthError.MissingPhoneNumber: message = "Отсутствует номер телефона!"; break;
            case AuthError.InvalidRecipientEmail: message = "Неверный адрес электронной почты получателя!"; break;
            case AuthError.InvalidSender: message = "Неверный отправитель!"; break;
            case AuthError.InvalidVerificationCode: message = "Неверный проверочный код!"; break;
            case AuthError.InvalidVerificationId: message = "Недействительный идентификатор подтверждения!"; break;
            case AuthError.MissingVerificationCode: message = "Отсутствует код подтверждения!"; break;
            case AuthError.MissingVerificationId: message = "Отсутствует идентификатор подтверждения!"; break;
            case AuthError.MissingEmail: message = "Отсутствует почта!"; break;
            case AuthError.MissingPassword: message = "Отсутствует пароль!"; break;
            case AuthError.QuotaExceeded: message = "Квота превышена!"; break;
            case AuthError.RetryPhoneAuth: message = "Повторите попытку аутентификации телефона!"; break;
            case AuthError.SessionExpired: message = "Сессия истекла!"; break;
            case AuthError.AppNotVerified: message = "Приложение не проверено!"; break;
            case AuthError.AppVerificationFailed: message = "Ошибка проверки приложения!"; break;
            case AuthError.CaptchaCheckFailed: message = "Ошибка проверки Captcha!"; break;
            case AuthError.InvalidAppCredential: message = "Недействительные учетные данные приложения!"; break;
            case AuthError.MissingAppCredential: message = "Отсутствуют учетные данные приложения!"; break;
            case AuthError.InvalidClientId: message = "Неверный идентификатор клиента!"; break;
            case AuthError.InvalidContinueUri: message = "Недействительный код продолжения!"; break;
            case AuthError.MissingContinueUri: message = "Отсутствует URL продолжения!"; break;
            case AuthError.KeychainError: message = "Ошибка связки ключей!"; break;
            case AuthError.MissingAppToken: message = "Отсутствует токен API!"; break;
            case AuthError.MissingIosBundleId: message = "Отсутствует идентификатор пакета !"; break;
            case AuthError.NotificationNotForwarded: message = "Уведомление не отправлено!"; break;
            case AuthError.UnauthorizedDomain: message = "Неавторизованный домен!"; break;
            case AuthError.WebContextAlreadyPresented: message = "Веб-контекст уже представлен!"; break;
            case AuthError.WebContextCancelled: message = "Веб-контекст отменен!"; break;
            case AuthError.DynamicLinkNotActivated: message = "Динамическая ссылка не активирована!"; break;
            case AuthError.Cancelled: message = "Отменено!"; break;
            case AuthError.InvalidProviderId: message = "Недействительный идентификатор поставщика!"; break;
            case AuthError.WebInternalError: message = "Внутренняя веб-ошибка!"; break;
            case AuthError.WebStorateUnsupported: message = "Интернет-магазин не поддерживается!"; break;
            case AuthError.TenantIdMismatch: message = "Несоответствие идентификатора арендатора!"; break;
            case AuthError.UnsupportedTenantOperation: message = "Неподдерживаемая операция арендатора!"; break;
            case AuthError.InvalidLinkDomain: message = "Недействительный домен ссылки!"; break;
            case AuthError.RejectedCredential: message = "Отклоненные учетные данные!"; break;
            case AuthError.PhoneNumberNotFound: message = "Номер телефона не найден!"; break;
            case AuthError.InvalidTenantId: message = "Недействительный идентификатор арендатора!"; break;
            case AuthError.MissingClientIdentifier: message = "Отсутствует идентификатор клиента!"; break;
            case AuthError.MissingMultiFactorSession: message = "Отсутствует многофакторный сеанс!"; break;
            case AuthError.MissingMultiFactorInfo: message = "Отсутствует многофакторная информация!"; break;
            case AuthError.InvalidMultiFactorSession: message = "Недействительный многофакторный сеанс!"; break;
            case AuthError.MultiFactorInfoNotFound: message = "Многофакторная информация не найдена!"; break;
            case AuthError.AdminRestrictedOperation: message = "Операция, ограниченная администратором!"; break;
            case AuthError.UnverifiedEmail: message = "Непроверенный адрес электронной почты!"; break;
            case AuthError.SecondFactorAlreadyEnrolled: message = "Второй фактор уже зарегистрирован!"; break;
            case AuthError.MaximumSecondFactorCountExceeded: message = "Превышено максимальное количество секундных факторов!"; break;
            case AuthError.UnsupportedFirstFactor: message = "Неподдерживаемый первый фактор!"; break;
            case AuthError.EmailChangeNeedsVerification: message = "Изменение адреса электронной почты требует подтверждения!"; break;
            default: break;
        }
        UpdateTextError(_errorText, message);
    }
}
