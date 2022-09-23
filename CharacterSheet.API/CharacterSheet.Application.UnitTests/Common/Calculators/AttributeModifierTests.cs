using CharacterSheet.Application.Common.Calculators;
using FluentAssertions;
using NUnit.Framework;

namespace CharacterSheet.Application.UnitTests.Common.Calculators;

public class AttributeModifierTests
{
    [Test]
    public void AttributeOf_8_ShouldHaveModifier_Minus1()
    {
        var result = AttributeModifierCalculator.CalculateModifier(8);
        result.Should().Be(-1);
    }
    [Test]
    public void AttributeOf_9_ShouldHaveModifier_Minus1()
    {
        var result = AttributeModifierCalculator.CalculateModifier(9);
        result.Should().Be(-1);
    }
    [Test]
    public void AttributeOf_10_ShouldHaveModifier_0()
    {
        var result = AttributeModifierCalculator.CalculateModifier(10);
        result.Should().Be(0);
    }
    [Test]
    public void AttributeOf_11_ShouldHaveModifier_0()
    {
        var result = AttributeModifierCalculator.CalculateModifier(11);
        result.Should().Be(0);
    }
    [Test]
    public void AttributeOf_12_ShouldHaveModifier_1()
    {
        var result = AttributeModifierCalculator.CalculateModifier(12);
        result.Should().Be(1);
    }
}
