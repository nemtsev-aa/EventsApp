using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum EventStatus
{
    Active,
    Archive
}

public enum Category
{
    All,
    PaintingAndGraphics,
    Ecology,
    Vocals,
    IT,
    TheatricalArt,
    AppliedCreativity,
    SportsGames,
    Researches
}

public class EventObj
{
    /// <summary>
    /// ��������
    /// </summary>
    public string Name;
    /// <summary>
    /// ��������
    /// </summary>
    public string IconURL;
    /// <summary>
    /// ��������
    /// </summary>
    public string Description;
    /// <summary>
    /// ���������
    /// </summary>
    public Category Category;
    /// <summary>
    /// ���� ����������
    /// </summary>
    public string Date;
    /// <summary>
    /// ����� ����������
    /// </summary>
    public string Time;
    /// <summary>
    /// ������� ����������
    /// </summary>
    public string AgeRange;
    /// <summary>
    /// ������ ����������
    /// </summary>
    public List<User> Participants;
    /// <summary>
    /// ������
    /// </summary>
    public EventStatus Status;

    public EventObj(string name, string iconURL, Category category, string description, string date, string time, string ageRange, List<User> participants, EventStatus status)
    {
        this.Name = name;
        this.IconURL = iconURL;
        this.Category = category;
        this.Description = description;
        this.Date = date;
        this.Time = time;
        this.AgeRange = ageRange;
        this.Participants = participants;
        this.Status = status;
    }
}
