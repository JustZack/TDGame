using UnityEngine;
using System.Reflection;

public abstract class BaseObject : ScriptableObject {
    public T Copy<T>() where T : BaseObject, new() {
        // Create a new instance of the derived class
        T copy = CreateInstance<T>();

        // Get all fields of the current instance
        FieldInfo[] fields = this.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance);

        // Copy each field value
        foreach (FieldInfo field in fields)
        {
            field.SetValue(copy, field.GetValue(this));
        }
        return copy;
    }

    public abstract GameObject Instantiate();
}

    


       