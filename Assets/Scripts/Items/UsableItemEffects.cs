using UnityEngine;

public abstract class UsableItemEffects : ScriptableObject {

    public abstract void ExecuteEffect(UsableItem parent, Player player);

}
