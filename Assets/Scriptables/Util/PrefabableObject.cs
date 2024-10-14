using UnityEngine;


public class PrefabableObject : BaseObject {
    public GameObject prefab;
    public float prefabAngleOffset;
    public float size;
    public virtual GameObject Instantiate() {
        GameObject instance = Instantiate(this.prefab);
        //instance.AddComponent<ShowForwardVector>();
        return instance;
    }
}
