using UnityEngine;

public static class Proxyland
{
#if UNITY_ANDROID && !UNITY_EDITOR
    private static AndroidJavaObject _proxylandStatic = null;
    private static AndroidJavaObject _currentActivity = null;
#endif

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Init()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        if ( Application.platform == RuntimePlatform.Android )
        {
            using (var unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
            using (var proxylandClass = new AndroidJavaClass("com.betroix.proxyland.ProxylandSdk"))
            {
                _currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
                _proxylandStatic = proxylandClass.GetStatic<AndroidJavaObject>("Companion");
            }
        }
#endif
    }

    public static void Init(string parnterId, string apiKey)
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        _proxylandStatic.Call("initializeAsync", _currentActivity, parnterId, apiKey, null, null);
#endif
    }
}