
public class StatModifiers{

    public readonly float Value;
    public readonly object Source;

    public StatModifiers(float value, object source)
    {
        Value = value;
        Source = source;
    }

    public StatModifiers(float value) : this(value, null) { }

}
