//------------------------------------------------------------------------------
// AuthorizationController.cs
//
// <copyright from='2017' to='2117' company='SF Technology'> 
// Copyright (c) SF Technology. All Rights Reserved. 
// Information Contained Herein is Proprietary and Confidential. 
// </copyright>
//
// Created: 02/01/2017
// Owner: HongYin Wang
//
//------------------------------------------------------------------------------

using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web.Http;
using SF.Domain;
using SF.ILogic;
using SF.Common;

namespace SF.ShortRentManage.Controllers
{
    public class AuthorizationController : ApiController
    {
        private readonly IAccountLogic _accountLogic;

        public AuthorizationController(IAccountLogic accountLogic)
        {
            _accountLogic = accountLogic;
        }

        [HttpPost]
        [Route("api/Login")]
        public HttpResponseMessage Login(LoginModel model)
        {
            //if (!_commonBusiness.IsSystemEnabled())
            //{
            //    throw new HttpResponseException(new HttpResponseMessage
            //    {
            //        StatusCode = HttpStatusCode.Unauthorized,
            //        ReasonPhrase = Resources.Message.Error_SystemDisabled
            //    });
            //}

            if (model == null)
            {
                throw new HttpResponseException(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.Unauthorized,
                    ReasonPhrase = "Login cannot be empty."
                });
            }

            if (string.IsNullOrWhiteSpace(model.Login) || string.IsNullOrWhiteSpace(model.Password))
            {
                throw new HttpResponseException(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.Unauthorized,
                    ReasonPhrase = "Login name or password cannot be empty."
                });
            }

            AccountDomainModel user = _accountLogic.GetAccountByLogin(model.Login);
            if (user == null)
            {
                throw new HttpResponseException(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.Unauthorized,
                    ReasonPhrase = "The login cannot be found."
                });
            }

            if (!user.IsEnabled)
            {
                throw new HttpResponseException(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.Unauthorized,
                    ReasonPhrase = "Your account has been disabled."
                });
            }

            string encryptPassword = GetMd5HashStr(model.Password);
            if (!encryptPassword.Equals(user.Password))
            {
                throw new HttpResponseException(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.Unauthorized,
                    ReasonPhrase = "Incorrect password."

                });
            }

            return new HttpResponseMessage
            {
                Content = new StringContent(Utils.NewSessionKey(user.AccountId, model.Expires)),
                StatusCode = HttpStatusCode.OK
            };
        }

        [HttpGet]
        [Route("api/Logout")]
        public HttpResponseMessage Logout()
        {
            return new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK
            };
        }

        private string GetMd5HashStr(string str)
        {
            MD5 md5 = MD5.Create();
            byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(str));

            string pwd = string.Empty;
            for (int i = 0; i < s.Length; i++)
            {
                pwd = pwd + s[i].ToString("X");
            }

            return pwd;
        }
    }
}