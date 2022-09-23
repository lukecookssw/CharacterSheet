namespace CharacterSheet.Application.Common.Calculators;

public static class AttributeModifierCalculator
{
    public static int CalculateModifier(int attributeValue)
    {
        return (int)Math.Floor(((decimal)attributeValue - 10) / 2);
    }
}
