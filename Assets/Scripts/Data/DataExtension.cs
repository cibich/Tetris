using System;
using UnityEngine;

public class DataExtension
{
    public static string FormatTime(float time)
    {
        int hours = Mathf.FloorToInt(time / 3600f);
        int minutes = Mathf.FloorToInt((time % 3600f) / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);

        TimeSpan timeSpan = new TimeSpan(hours, minutes, seconds);
        return timeSpan.ToString(@"hh\:mm\:ss");
    }

    public static string FormatDate(ulong date)
    {
        ulong timestampSeconds = date;
        DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(timestampSeconds);
        return dateTime.Date.ToShortDateString();
    }
}
