//------------------------------------------------------------------------------
// BasicAuthorizeAttribute.cs
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
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using SF.Common;
using SF.Domain;
using SF.ILogic;

namespace SF.ShortRentManage.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class BasicAuthorizeAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            AuthenticationHeaderValue authHeader = actionContext.Request.Headers.Authorization;
            if (authHeader != null)
            {
                if (authHeader.Scheme.Equals("basic", StringComparison.OrdinalIgnoreCase) &&
                    !string.IsNullOrWhiteSpace(authHeader.Parameter))
                {
                    int currentUserId = Utils.RetrieveUserId(authHeader.Parameter);
                    if (IsUserEnabled(actionContext, currentUserId))
                    {
                        string sessionKey = Utils.VerifySessionKey(authHeader.Parameter);
                        try
                        {
                            GenericPrincipal currentPrincipal = new GenericPrincipal(new GenericIdentity(sessionKey), null);
                            Thread.CurrentPrincipal = currentPrincipal;

                            return;
                        }
                        catch (Exception ex)
                        {
                            HandleUnauthorizedRequest(actionContext, ex);
                        }
                    }
                }
                return;
            }
            HandleUnauthorizedRequest(actionContext);
        }

        private bool IsUserEnabled(HttpActionContext actionContext, int userId)
        {
            AccountDomainModel user = AccountLogic.GetAccountById(userId);

            if (user == null || !user.IsEnabled)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.NotAcceptable);
                actionContext.Response.ReasonPhrase = "Your account has been disabled.";
                return false;
            }
            return true;
        }

        /// <summary>
        /// Handles the unauthorized request.
        /// </summary>
        /// <param name="actionContext">The action context.</param>
        /// <param name="ex">Exception.</param>
        private void HandleUnauthorizedRequest(HttpActionContext actionContext, Exception ex = null)
        {
            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            actionContext.Response.ReasonPhrase = ex == null ? "Session token cannot be found." :
                string.Format("Invalid session token: {0}",
                    ex.ToString().Replace('\n', ' ').Replace('\r', ' '));
        }

        public IAccountLogic AccountLogic => (IAccountLogic)GlobalConfiguration.Configuration
            .DependencyResolver.GetService(typeof(IAccountLogic));
    }
}