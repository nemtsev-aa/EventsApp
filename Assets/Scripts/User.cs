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
    /// ID ������������ �� ������� ��������������
    /// </summary>
    public string UserId;
    /// <summary>
    /// ���
    /// </summary>
    public string Name;
    /// <summary>
    /// ���� ��������
    /// </summary>
    public string Birthdate;
    /// <summary>
    /// ���
    /// </summary>
    public Gender Gender;
    /// <summary>
    /// ��������
    /// </summary>
    public List<string> Interests;
    /// <summary>
    /// ������ �������� � ����������
    /// </summary>
    public List<UserActions> Actions;
    /// <summary>
    /// ������ ��������������� �����������
    /// </summary>
    public List<EventObj> PlannedEvents;
    /// <summary>
    /// ����� �����������
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


