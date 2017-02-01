//------------------------------------------------------------------------------
// LoginDomainModel.cs
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

namespace SF.Domain
{
    public class LoginModel
    {
        private int? _expires;

        public string Login { get; set; }

        public string Password { get; set; }

        public int Expires
        {
            get
            {
                if (!_expires.HasValue || _expires.Value < 0)
                {
                    return 60 * 1;
                }

                if (_expires.Value > 60 * 24)
                {
                    return 60 * 3;
                }

                return _expires.Value;
            }
            set { _expires = value; }
        }
    }
}
