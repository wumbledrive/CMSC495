public class EquipmentSlots : ItemSlots {
    public Equipment type;

    protected override void OnValidate()
    {
        base.OnValidate();
        gameObject.name = type.ToString() + " Slot";
    }
}
