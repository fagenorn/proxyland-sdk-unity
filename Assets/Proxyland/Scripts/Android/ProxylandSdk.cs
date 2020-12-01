using UnityEngine;

public class Proxyland
{
#if UNITY_ANDROID && !UNITY_EDITOR
    private static readonly AndroidJavaClass _proxylandClass = new AndroidJavaClass("com.betroix.proxyland.ProxylandSdk");

    private static readonly AndroidJavaClass _unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");

    private static readonly AndroidJavaObject _activity = _unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

    private static readonly AndroidJavaObject _context = _activity.Call<AndroidJavaObject>("getApplicationContext");
#endif

    public static void Init(string parnterId, string apiKey)
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        var companion = _proxylandClass.GetStatic<AndroidJavaObject>("Companion");
        companion.Call("initializeAsync", _context, parnterId, apiKey, null, null);
#endif
    }
}