using UnityEngine;
using UnityEditor;

//CreateAssetMenu makes something createable in the Unity Asset Menu (Like creating a folder)
[CreateAssetMenu(menuName = "Items/Item")]
public class Item : ScriptableObject
{
    [SerializeField] string id;
    public string ID { get { return id; } }
    public string ItemName;
    public Sprite Icon;
    [Range(1, 25)]
    public int MaximumStack = 1;
    private void OnValidate()
    {
        //   string path = AssetDatabase.GetAssetPath(this);
        //  id = AssetDatabase.AssetPathToGUID(path);
        Debug.Log("item bug commented out here");
    }

    public virtual Item GetCopy()
    {
        return this;
    }

    public virtual void Destroy()
    {

    }
}
