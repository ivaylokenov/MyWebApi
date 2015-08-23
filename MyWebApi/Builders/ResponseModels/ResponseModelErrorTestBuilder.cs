﻿namespace MyWebApi.Builders.ResponseModels
{
    using System.Web.Http;
    using System.Web.Http.ModelBinding;

    using Base;
    using Contracts;

    /// <summary>
    /// Used for testing the response model errors.
    /// </summary>
    public class ResponseModelErrorTestBuilder : BaseTestBuilder, IResponseModelErrorTestBuilder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResponseModelErrorTestBuilder" /> class.
        /// </summary>
        /// <param name="controller">Controller on which the action will be tested.</param>
        /// <param name="actionName">Name of the tested action.</param>
        public ResponseModelErrorTestBuilder(ApiController controller, string actionName)
            : base(controller, actionName)
        {
            this.ModelState = controller.ModelState;
        }

        /// <summary>
        /// Gets validated model state of the provided ASP.NET Web API controller instance.
        /// </summary>
        /// <value>Model state dictionary containing all validation errors.</value>
        protected ModelStateDictionary ModelState { get; private set; }

        /// <summary>
        /// Tests whether tested action's model state is valid.
        /// </summary>
        public void ContainingNoModelStateErrors()
        {
            this.CheckValidModelState();
        }
    }
}