﻿using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Middleware
{
    public class ExceptionMiddleware
    {
        private RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                await HandleExceptionAsync(context, e);
                throw;
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception e)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            string message = "Internal Server Error";
            IEnumerable<ValidationFailure> validationFailures;
            if(e.GetType() == typeof(ValidationFailure))
            {
                message = e.Message;
                validationFailures = ((ValidationException)e).Errors;
                return context.Response.WriteAsync(new ValidationErrorDetails
                {
                    Message = message,
                    Errors = validationFailures,
                    StatusCode = 400
                }.ToString());
            }
            return context.Response.WriteAsync(new ErrorDetails
            {
                Message = message,
                StatusCode = context.Response.StatusCode
            }.ToString());
        }
    }
}