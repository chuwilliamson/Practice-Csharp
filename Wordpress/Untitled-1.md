# Expression bodies allow you to make auto properties and also set them on the same line

By creating an expression body you provide a very readable way to view members.
An expression-bodied method consists of a single expression that returns a value whose type matches the method's return type.
Ever since I started using Expression Bodies I can't stop. So I hope by showing you ways you can use it you will join me in using them as well.

## Examples

---

### The below code returns the string “Donray Williams” when you access the property “New Name”

```csharp
public string NewName => "Donray Williams"; // New Way

public string OldName // Old Way
{
    get
    {
        return "Donray Williams";
    }
}
```

### Expressions for methods/functions which returns value to the caller

### For example, the below code will return sub of the parameters when you call the “NewSum” method

```csharp
public int NewSum(int a, int b) => a + b; // New Way

public int OldSum(int a, int b) // Old Way
{
    return a + b;
}
```

## Implementations I have used

---

```csharp
using Contexts;
using Data;

namespace States.Concrete
{
    public class FindLeafState : State
    {
        protected AntData Data => UnityEngine.Resources.Load<AntData>("AntData");

        public override void Update(IContext context)
        {
            Data.Velocity = (Data.LeafPosition - Data.AntPosition).normalized; 

            if (Data.LeafDistance <= 1)
                context.ChangeState(new GoHomeState { Context = context });
        }
    }
}
```

```csharp

using UnityEngine;

namespace Data
{
    [CreateAssetMenu(menuName = "Data/AntData")]
    public class AntData : ScriptableObject
    {
        public float CursorDistance => Vector3.Distance(a: CursorPosition, b: AntPosition);
        public float HomeDistance => Vector3.Distance(a: HomePosition, b: AntPosition);
        public float LeafDistance => Vector3.Distance(a: LeafPosition, b: AntPosition);
    }
}
```

```csharp
public class Player : MonoBehaviour {}

[CreateAssetMenu]
public class FloatValue : ScriptableObject
{
    public float Value;
}

public class Follow : MonoBehaviour
{
    public FloatValue StoppingDistace => UnityEngine.Resources.Load<FloatValue>("StoppingDistance");
    private Transform _target => FindObjectOfType<Player>().GetComponent<Transform>();
    public FloatValue Speed => UnityEngine.Resources.Load<FloatValue>("Speed");

    void Update ()
    {
        if (Vector2.Distance(transform.position, _target.position) > StoppingDistace)
        {
            transform.position = Vector2.MoveTowards(transform.position, _target.position, Speed.Value * Time.deltaTime);
        }
    }
}
```