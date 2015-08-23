﻿namespace MyWebApi.Tests.BuildersTests.ResponseModelsTests
{
    using System.Collections.Generic;
    using System.Linq;
    using Exceptions;
    
    using NUnit.Framework;
    using Setups;
    using Setups.Models;

    [TestFixture]
    public class ResponseModelTestBuilderTests
    {
        [Test]
        public void WithResponseModelShouldNotThrowExceptionWithCorrectResponseModel()
        {
            MyWebApi
                .Controller<WebApiController>()
                .Calling(c => c.OkResultWithResponse())
                .ShouldReturnOk()
                .WithResponseModel<ICollection<ResponseModel>>();
        }

        [Test]
        public void WithResponseModelShouldNotThrowExceptionWithIncorrectInheritedTypeArgument()
        {
            MyWebApi
                .Controller<WebApiController>()
                .Calling(c => c.OkResultWithResponse())
                .ShouldReturnOk()
                .WithResponseModel<IList<ResponseModel>>();
        }

        [Test]
        [ExpectedException(typeof(ResponseModelAssertionException))]
        public void WithResponseModelShouldThrowExceptionWithIncorrectResponseModel()
        {
            MyWebApi
                .Controller<WebApiController>()
                .Calling(c => c.OkResultWithResponse())
                .ShouldReturnOk()
                .WithResponseModel<ResponseModel>();
        }

        [Test]
        [ExpectedException(typeof(ResponseModelAssertionException))]
        public void WithResponseModelShouldThrowExceptionWithIncorrectGenericTypeArgument()
        {
            MyWebApi
                .Controller<WebApiController>()
                .Calling(c => c.OkResultWithResponse())
                .ShouldReturnOk()
                .WithResponseModel<ICollection<int>>();
        }

        [Test]
        public void WithResponseModelShouldNotThrowExceptionWithCorrectPassedExpectedObject()
        {
            var controller = new WebApiController();

            MyWebApi
                .Controller(() => controller)
                .Calling(c => c.OkResultWithResponse())
                .ShouldReturnOk()
                .WithResponseModel(controller.ResponseModel);
        }

        [Test]
        [ExpectedException(typeof(ResponseModelAssertionException))]
        public void WithResponceModelShouldThrowExceptionWithDifferentPassedExpectedObject()
        {
            var controller = new WebApiController();

            MyWebApi
                .Controller<WebApiController>()
                .Calling(c => c.OkResultWithResponse())
                .ShouldReturnOk()
                .WithResponseModel(controller.ResponseModel);
        }

        [Test]
        public void WithResponseModelShouldNotThrowExceptionWithCorrectAssertions()
        {
            MyWebApi
                .Controller<WebApiController>()
                .Calling(c => c.OkResultWithResponse())
                .ShouldReturnOk()
                .WithResponseModel<ICollection<ResponseModel>>(m =>
                {
                    Assert.AreEqual(2, m.Count);
                    Assert.AreEqual(1, m.First().IntegerValue);
                });
        }

        [Test]
        [ExpectedException(typeof(AssertionException))]
        public void WithResponseModelShouldThrowExceptionWithIncorrectAssertions()
        {
            MyWebApi
                .Controller<WebApiController>()
                .Calling(c => c.OkResultWithResponse())
                .ShouldReturnOk()
                .WithResponseModel<ICollection<ResponseModel>>(m =>
                {
                    Assert.AreEqual(1, m.First().IntegerValue);
                    Assert.AreEqual(3, m.Count);
                });
        }

        [Test]
        public void WithResponseModelShouldNotThrowExceptionWithCorrectPredicate()
        {
            MyWebApi
                .Controller<WebApiController>()
                .Calling(c => c.OkResultWithResponse())
                .ShouldReturnOk()
                .WithResponseModel<ICollection<ResponseModel>>(m => m.First().IntegerValue == 1);
        }

        [Test]
        [ExpectedException(typeof(ResponseModelAssertionException))]
        public void WithResponseModelShouldThrowExceptionWithWrongPredicate()
        {
            MyWebApi
                .Controller<WebApiController>()
                .Calling(c => c.OkResultWithResponse())
                .ShouldReturnOk()
                .WithResponseModel<IList<ResponseModel>>(m => m.First().IntegerValue == 2);
        }

        [Test]
        public void WithNoResponseModelShouldNotThrowExceptionWhenNoResponseModel()
        {
            MyWebApi
                .Controller<WebApiController>()
                .Calling(c => c.OkResultAction())
                .ShouldReturnOk()
                .WithNoResponseModel();
        }

        [Test]
        [ExpectedException(typeof(ResponseModelAssertionException))]
        public void WithNoResponseModelShouldThrowExceptionWhenResponseModelExists()
        {
            MyWebApi
                .Controller<WebApiController>()
                .Calling(c => c.OkResultWithResponse())
                .ShouldReturnOk()
                .WithNoResponseModel();
        }
    }
}