﻿namespace Kendo.Mvc.UI.Fluent.Tests
{
    using Kendo.Mvc.Infrastructure;
    using Moq;
    using Xunit;

    public class PivotConfiguratorBuilderTests
    {
        private readonly PivotConfigurator pivotConfigurator;
        private readonly PivotConfiguratorBuilder builder;

        public PivotConfiguratorBuilderTests()
        {
            pivotConfigurator = new PivotConfigurator(TestHelper.CreateViewContext(), 
                new Mock<IJavaScriptInitializer>().Object, 
                new Mock<IUrlGenerator>().Object);
            builder = new PivotConfiguratorBuilder(pivotConfigurator);
        }

        [Fact]
        public void Filterable_sets_the_corresponding_property()
        {
            builder.Filterable(true);
            Assert.True(pivotConfigurator.Filterable);
        }

        [Fact]
        public void Messages_sets_the_corresponding_property()
        {
            string value = "custom message";
            builder.Messages(m => m.ColumnsLabel(value));

            pivotConfigurator.Messages.ColumnsLabel.Equals(value);
        }

        [Fact]
        public void Messages_FieldMenu_sets_the_corresponding_property()
        {
            string value = "custom message";
            builder.Messages(m => m.FieldMenu(fm => fm.Info(value)));

            pivotConfigurator.Messages.FieldMenu.Info.Equals(value);
        }
    }
}
