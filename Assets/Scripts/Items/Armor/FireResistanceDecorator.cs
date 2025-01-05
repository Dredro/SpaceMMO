
public class FireResistanceDecorator : ArmorDecorator
{
    private readonly int fireResistanceBonus = 10;

    public FireResistanceDecorator(Armor wrappedArmor) : base(wrappedArmor)
    {
        armorData.defenseValue += fireResistanceBonus;
        itemData.name += "+FireResistance";
    }
}