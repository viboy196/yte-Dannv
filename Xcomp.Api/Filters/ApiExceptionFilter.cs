﻿using Xcomp.Api.Common.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace Xcomp.Api.Filters
{
    public class ApiExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is ValidationException)
            {
                var ex = context.Exception as ValidationException;
                context.Exception = null;

                context.Result = new JsonResult(ex.Message);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            else if (context.Exception is NotFoundException)
            {
                // handle explicit 'known' API errors
                var ex = context.Exception as NotFoundException;
                context.Exception = null;

                context.Result = new JsonResult(ex.Message);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
            }
            else if (context.Exception is BadRequestException)
            {
                // handle explicit 'known' API errors
                var ex = context.Exception as BadRequestException;
                context.Exception = null;

                context.Result = new JsonResult(ex.Message);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            else if (context.Exception is UnauthorizedAccessException)
            {
                context.Result = new JsonResult(context.Exception.Message);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            }
            else if (context.Exception is ForbiddenException)
            {
                context.Result = new JsonResult(context.Exception.Message);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
            }


            base.OnException(context);
        }
    }
}
