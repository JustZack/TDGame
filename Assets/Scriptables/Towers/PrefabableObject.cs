using UnityEngine;


public class PrefabableObject : ScriptableObject {
    public GameObject prefab;
    public float size;
    public virtual GameObject Instantiate() {
        GameObject instance = Instantiate(this.prefab);
        instance.AddComponent<ShowForwardVector>();
        return instance;
    }
}
