namespace BusinessLayer;

public static class Mapping
{
    public static T Map<T>(this object source)
        => (T)Convert.ChangeType(source, typeof(T));
    
}