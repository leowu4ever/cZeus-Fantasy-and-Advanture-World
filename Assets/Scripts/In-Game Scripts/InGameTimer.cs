using UnityEngine;
using System.Collections;
using System.Timers;

public class InGameTimer : MonoBehaviour {

    public static int countTime;
    public static bool isTimerFinish = false;
    private static Timer timer;

    // Use this for initialization
     public static void initTimer (int initTimerValue) {
        countTime = initTimerValue;
        ClearTimer();
        isTimerFinish = false;
        timer = new Timer(1000);
        timer.Elapsed += new ElapsedEventHandler(TimerTick);
        
    }
    public static void StartTimer()
    {
        timer.Start();
    }
    public static void StopTimer()
    {
        timer.Stop();
    }
    public static void ExtendTimer(int value)
    {
        countTime = countTime + value;
    }
    public static void ClearTimer()
    {
        if(timer!=null)
            timer.Close();
        isTimerFinish = false;
    }

    public static void TimerTick(object o, System.EventArgs e)
    {
        countTime--;
        if (countTime < 1)
        {
            isTimerFinish = true;
            timer.Stop();
            timer.Close();
        }
    }
}
