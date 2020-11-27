# Getting Started

Unity SDK for [proxyland.io](https://proxyland.io/)

# Usage

## Unity

1. Import **ProxylandSdk-\*.unitypackage**
2. Resolve dependencies: **Assets > External Dependency Manager > Android Resolver > Resolve**
3. Initialize SDK

```c#
public class InitScript : MonoBehaviour
{
    void Start()
    {
        Proxyland.Init("PARTNER_ID", "API_KEY");
    }
}
```
