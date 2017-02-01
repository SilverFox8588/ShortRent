//------------------------------------------------------------------------------
// HandleErrorAttribute.cs
//
// <copyright from='2017' to='2117' company='SF Technology'> 
// Copyright (c) SF Technology. All Rights Reserved. 
// Information Contained Herein is Proprietary and Confidential. 
// </copyright>
//
// Created: 01/31/2017
// Owner: HongYin Wang
//
//------------------------------------------------------------------------------

using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace SF.ShortRentManage.Filters
{
    public class HandleErrorAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnActionExecuted(actionExecutedContext);

            Exception e = actionExecutedContext.Exception;
            if (e != null)
            {
                actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse(HttpStatusCode.BadRequest);

                string message = e.Message;
                if (e.InnerException != null)
                {
                    message = e.InnerException.Message;
                    if (!message.Contains(e.Message))
                    {
                        message = string.Format("{0} | {1}", e.Message, message);
                    }
                }

                actionExecutedContext.Response.ReasonPhrase = message.Replace(Environment.NewLine, string.Empty);
            }
        }
    }
}