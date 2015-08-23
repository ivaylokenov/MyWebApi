﻿namespace MyWebApi.Builders.Actions
{
    using System.Web.Http.Results;

    using Contracts;
    using ResponseModels;

    /// <summary>
    /// Class containing methods for testing OkResult.
    /// </summary>
    /// <typeparam name="TActionResult">Result from invoked action in ASP.NET Web API controller.</typeparam>
    public partial class ActionResultTestBuilder<TActionResult>
    {
        /// <summary>
        /// Tests whether action result is plain OkResult.
        /// </summary>
        /// <returns>Response model test builder.</returns>
        public IResponseModelTestBuilder ShouldReturnOk()
        {
            var actionResultAsOkResult = ActionResult as OkResult;
            if (actionResultAsOkResult != null)
            {
                ShouldReturn<OkResult>();
            }
            else
            {
                ValidateActionReturnType(typeof(OkNegotiatedContentResult<>), allowDifferentGenericTypeDefinitions: true);
            }

            return new ResponseModelTestBuilder<TActionResult>(Controller, ActionName, ActionResult);
        }
    }
}