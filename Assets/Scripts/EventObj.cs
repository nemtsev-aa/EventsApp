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
    /// Название
    /// </summary>
    public string Name;
    /// <summary>
    /// Описание
    /// </summary>
    public string IconURL;
    /// <summary>
    /// Описание
    /// </summary>
    public string Description;
    /// <summary>
    /// Категория
    /// </summary>
    public Category Category;
    /// <summary>
    /// Дата проведения
    /// </summary>
    public string Date;
    /// <summary>
    /// Время проведения
    /// </summary>
    public string Time;
    /// <summary>
    /// Возраст участников
    /// </summary>
    public string AgeRange;
    /// <summary>
    /// Список участников
    /// </summary>
    public List<User> Participants;
    /// <summary>
    /// Статус
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
