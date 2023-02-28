using System.Collections.Generic;

public enum Gender
{
    All,
    Male,
    Female
}

public class User
{
    /// <summary>
    /// ID пользователя из системы аутентификации
    /// </summary>
    public string UserId;
    /// <summary>
    /// Имя
    /// </summary>
    public string Name;
    /// <summary>
    /// Дата рождения
    /// </summary>
    public string Birthdate;
    /// <summary>
    /// Пол
    /// </summary>
    public Gender Gender;
    /// <summary>
    /// Интересы
    /// </summary>
    public List<string> Interests;
    /// <summary>
    /// Список действий в приложении
    /// </summary>
    public List<UserActions> Actions;
    /// <summary>
    /// Список запланированных мероприятий
    /// </summary>
    public List<EventObj> PlannedEvents;
    /// <summary>
    /// Архив мероприятий
    /// </summary>
    public List<EventObj> ArhiveEvents;

    public User(string userId, string name, string birthdate, Gender gender, List<UserActions> actions, List<EventObj> plannedEvents, List<EventObj> arhiveEvents)
    {
        this.UserId = userId;
        this.Name = name;
        this.Birthdate = birthdate;
        this.Gender = gender;
        this.Actions = actions;
        this.PlannedEvents = plannedEvents;
        this.ArhiveEvents = arhiveEvents;
    }
    public User()
    {

    }
}


