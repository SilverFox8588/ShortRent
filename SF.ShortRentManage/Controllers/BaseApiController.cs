//------------------------------------------------------------------------------
// BaseApiController.cs
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
using System.Threading;
using System.Web.Http;
using SF.Domain;
using SF.ILogic;
using SF.Common;
using SF.ShortRentManage.Filters;

namespace SF.ShortRentManage.Controllers
{
    //[BasicAuthorize]
    [HandleError]
    public class BaseApiController : ApiController
    {
        private readonly IAccountLogic _accountLogic;

        public BaseApiController(IAccountLogic accountLogic)
        {
            _accountLogic = accountLogic;
        }

        protected AccountDomainModel CurrentUser
        {
            get
            {
                if (!Thread.CurrentPrincipal.Identity.IsAuthenticated)
                {
                    return null;
                }

                string[] fields = Thread.CurrentPrincipal.Identity.Name.Split(Utils.FieldDelimiter);
                if (fields.Length < 3)
                {
                    throw new HttpResponseException(new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.Unauthorized,
                        ReasonPhrase = "Invalid request fields."
                    });
                }

                int userId = int.Parse(fields[0]);

                AccountDomainModel user = _accountLogic.GetAccountById(userId);
                if (user == null)
                {
                    throw new HttpResponseException(new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.Unauthorized,
                        ReasonPhrase = "Invalid user."
                    });
                }

                return user;
            }
        }

        protected HttpResponseException CreateHttpResponseException(HttpStatusCode statusCode, string reasonPhrase)
        {
            return new HttpResponseException(new HttpResponseMessage
            {
                StatusCode = statusCode,
                ReasonPhrase = reasonPhrase.Replace(Environment.NewLine, string.Empty)
            });
        }
    }
}