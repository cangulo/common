﻿using AutoFixture;
using AutoFixture.AutoNSubstitute;
using AutoFixture.Xunit2;
using Xunit;
using Xunit.Sdk;

namespace cangulo.common.testing.dataatributes
{
    /// <summary>
    /// Thanks to
    /// https://stackoverflow.com/questions/38088639/use-autodata-and-memberdata-attributes-in-xunit-test
    /// https://blog.nikosbaxevanis.com/2012/07/27/composite-xunit-net-data-attributes/
    /// https://blog.nikosbaxevanis.com/2012/07/31/autofixture-xunit-net-and-auto-mocking/
    /// </summary>
    public class AutoNSubstituteDataAttribute : AutoDataAttribute
    {
        public AutoNSubstituteDataAttribute()
            : base(() => new Fixture().Customize(new AutoNSubstituteCustomization()))
        {
        }
    }

    public class InlineAutoNSubstituteDataAttribute : CompositeDataAttribute
    {
        public InlineAutoNSubstituteDataAttribute(params object[] values)
            : base(new DataAttribute[] {
            new InlineDataAttribute(values), new AutoNSubstituteDataAttribute() })
        {
        }
    }
}
