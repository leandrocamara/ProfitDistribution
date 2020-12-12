using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ProfitDistribution.API.ViewModels;
using ProfitDistribution.Application.Abstraction.Common.Interfaces;

namespace ProfitDistribution.API.Filters
{
    public class CommonResponseFilter : ActionFilterAttribute
    {
        private readonly IWebHostEnvironment _env;
        private readonly ILogger<CommonResponseFilter> _logger;
        private const string ErroResultMessager = "An unexpected error has occurred. Try again later. {0}";

        public CommonResponseFilter(IWebHostEnvironment env, ILogger<CommonResponseFilter> logger)
        {
            _env = env;
            _logger = logger;
        }

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            object result = null;
            var resultType = context?.Result?.GetType();
            var valuePropertyInfo = resultType?.GetProperty("Value", BindingFlags.Public | BindingFlags.Instance);

            if (resultType != null && valuePropertyInfo != null)
                result = valuePropertyInfo.GetValue(context.Result);

            IResponse response;
            if (result is IResponse || context.Result is IResponse)
            {
                response = result as IResponse ?? context.Result as IResponse;
                if (response != null && response.Success)
                {
                    ParseSuccessCommonResponseViewModel(context, response);
                }
                else
                {
                    ParseExceptionCommonResponseViewModel(context, response);
                }
            }

            base.OnResultExecuting(context);
        }

        private void ParseExceptionCommonResponseViewModel(ResultExecutingContext context, IResponse response)
        {
            context.Result = new BadRequestObjectResult(new ValidationResult(response.Exception.Message,
                new[] {response.Exception.GetType().Name}));

            _logger.LogError(response.Exception, response.Exception.Message);

            if (_env.IsDevelopment()) return;

            var erroResultMessager = string.Format(ErroResultMessager, context.HttpContext.TraceIdentifier);
            context.Result = new ObjectResult(new CommonResponseViewModel(false, erroResultMessager))
            {
                StatusCode = StatusCodes.Status500InternalServerError,
            };
        }

        private void ParseSuccessCommonResponseViewModel(ResultExecutingContext context, IResponse response)
        {
            var responseGenericPropertyInfo = response?.GetType()
                .GetProperty(nameof(CommonResponseViewModel<int>.Data), BindingFlags.Public | BindingFlags.Instance);
            if (responseGenericPropertyInfo != null)
            {
                var responseGenericData = responseGenericPropertyInfo.GetValue(response);
                var responseGenericDataType = responseGenericData?.GetType();
                var typeMapDestination = GetTypeToMapResult(context);

                var responseGenericConstructorInfo = typeof(CommonResponseViewModel<>)
                    .MakeGenericType((typeMapDestination ?? responseGenericDataType)!)?.GetConstructor(new[]
                        {typeof(bool), typeMapDestination ?? responseGenericDataType, typeof(string)});

                context.Result = new OkObjectResult(responseGenericConstructorInfo?
                    .Invoke(new[] {true, responseGenericData, null}));
            }
            else
            {
                context.Result = new OkObjectResult(new CommonResponseViewModel(true));
            }
        }

        private Type GetTypeToMapResult(ResultExecutingContext context)
        {
            var reflectedActionDescriptor = context?.ActionDescriptor as ControllerActionDescriptor;
            Type typeToMapResult = null;

            if (reflectedActionDescriptor != null)
            {
                typeToMapResult = reflectedActionDescriptor.MethodInfo
                    .GetCustomAttributes(typeof(ProducesResponseTypeAttribute), false)
                    .OfType<ProducesResponseTypeAttribute>()
                    .Where(w => w.StatusCode == StatusCodes.Status200OK)
                    .Select(s => s.Type.GenericTypeArguments.FirstOrDefault())
                    .FirstOrDefault();
            }

            return typeToMapResult;
        }
    }
}