# Tips

## Use a base class

```csharp
    public abstract class BaseWindow : EditorWindow
    {
    }

    public class NodeWindow : BaseWindow
    {
    }
```

## Use what you know

```csharp
class MyWindow : EditorWindow
{
    static void Init()
    {
        var w = GetWindow();//sometimes...
        w.Show();
        //just use this for clarity
        var w = ScriptableObject.CreateInstance();
        w.Show();
    }
}
```

## Write C# code

When programming with a ```MonoBehaviour``` a common paradigm is to declare public fields for debugging purposes. When programming for the Editor use ```private``` when a field should not be accessed and ```public``` when someone does need access. It is also distracting when a non supported serialized type is assumed to show up in the inspector and I spend 30 minutes trying to make it show up.

## Making buttons

### GUI.Button

|Button |  Use? | Useful? |
|------------ | ------------- | ------------ |
|```GUI.Button```| not lazy|keeping track of rect for controlid|
|```GUILayout.Button```| lazy|auto layout                                               |
|```EditorGUI.Button```| not lazy|editable fields, keeping track of rect for control id |
|```EditorGUILayout.Button```| lazy| editable fields, autolayout                        |

if you have the rect then you can ensure the correct unique id for the control

```csharp
GUIUtility.GetRect
```

### Drawing things manually

```csharp
Handles.Draw
```

### SerializedObject and SerializedProperty

Allows the user to assign an Object reference to a field.

```csharp
UnityEngine.Object obj;
EditorGUILayout.ObjectField(obj);
```

### How to display useful information about obj

1. Convert object to SerializedObject

    ```csharp
    var so = new SerializedObject(obj)
    ```

2. Get the property you want to show from the created SerializedObject

    ```csharp
    var sp = so.FindProperty("fieldname")
    ```
