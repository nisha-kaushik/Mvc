﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Xunit;

namespace Microsoft.AspNetCore.Mvc.ModelBinding.Binders
{
    public class FormCollectionModelBinderProviderTest
    {
        [Theory]
        [InlineData(typeof(FormCollection))]
        [InlineData(typeof(TestClass))]
        [InlineData(typeof(IList<int>))]
        [InlineData(typeof(int[]))]
        public void Create_ForNonFormCollectionTypes_ReturnsNull(Type modelType)
        {
            // Arrange
            var provider = new FormCollectionModelBinderProvider();
            var context = new TestModelBinderProviderContext(modelType);

            // Act
            var result = provider.GetBinder(context);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void Create_ForFormCollectionToken_ReturnsBinder()
        {
            // Arrange
            var provider = new FormCollectionModelBinderProvider();
            var context = new TestModelBinderProviderContext(typeof(IFormCollection));

            // Act
            var result = provider.GetBinder(context);

            // Assert
            Assert.IsType<FormCollectionModelBinder>(result);
        }

        private class TestClass
        {
        }
    }
}