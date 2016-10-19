using UnityEngine;
using System.Collections;

public static class Log {

    static string LogURL = "http://wunderlich-paul.de/wizard/Log.php";

    public static void LogEntry(string action, int id)
    {
        //Start Coroutine
        WWWForm form = new WWWForm();
        form.AddField("useridPost", id);
        form.AddField("actionPost", action);
        WWW www = new WWW(LogURL, form);
        Debug.Log("Logged: " + action);
    }
}
