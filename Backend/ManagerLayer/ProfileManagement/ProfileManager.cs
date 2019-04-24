﻿using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Gucci.DataAccessLayer.Tables;
using Newtonsoft.Json;
using Gucci.ServiceLayer.Interface;
using Gucci.ServiceLayer.Model;
using Gucci.ServiceLayer.Requests;
using Gucci.ServiceLayer.Services;

namespace Gucci.ManagerLayer.ProfileManagement
{

    public class ProfileManager
    {
        private ICryptoService _cryptoService;
        private IUserService _userService;
        private IJWTService _jwtServce;
        private RatingService _ratingService;

        public ProfileManager()
        {
            _userService = new UserService();
            _cryptoService = new CryptoService();
            _jwtServce = new JWTService();
            _ratingService = new RatingService();
        }

        public bool CheckUserExists(int userID)
        {
            return _userService.IsUsernameFoundById(userID);
        }

        public string GetUserRating(int userID)
        {
            return _ratingService.GetRating(userID).ToString();
        }

        public HttpResponseMessage GetUser(string userID)
        {
            try
            {
                int userIDConverted = Convert.ToInt32(userID);
                if (!CheckUserExists(userIDConverted))
                {
                    var httpResponseFail = new HttpResponseMessage(HttpStatusCode.NotFound)
                    {
                        Content = new StringContent("User does not exist")
                    };
                    return httpResponseFail;
                }

                User retrievedUser = _userService.GetUserById(userIDConverted);
                if (retrievedUser == null)
                {
                    var httpResponseFail = new HttpResponseMessage(HttpStatusCode.NotFound)
                    {
                        Content = new StringContent("User does not exist")
                    };
                    return httpResponseFail;
                }
                UserProfile up = new UserProfile();
                up.FirstName = retrievedUser.FirstName;
                up.LastName = retrievedUser.LastName;
                up.UserName = retrievedUser.UserName;
                up.DoB = retrievedUser.DoB;
                up.City = retrievedUser.City;
                up.State = retrievedUser.State;
                up.Country = retrievedUser.Country;
                up.EventCreationCount = retrievedUser.EventCreationCount;
                up.Rating = GetUserRating(userIDConverted);
                var httpResponse = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(up))
                };
                return httpResponse;
            }
            catch
            {
                //log
                var httpResponse = new HttpResponseMessage(HttpStatusCode.ServiceUnavailable)
                {
                    Content = new StringContent("Unable to get user")
                };
                return httpResponse;
            }
        }

        public HttpResponseMessage GetUserToUpdate(string jwtToken)
        {
            if (_jwtServce.IsJWTSignatureTampered(jwtToken))
            {
                var httpResponseFail = new HttpResponseMessage(HttpStatusCode.Unauthorized)
                {
                    Content = new StringContent("Session is invalid")
                };
                return httpResponseFail;
            }

            if (_userService.GetUserById(_jwtServce.GetUserIDFromToken(jwtToken)) == null)
            {
                var httpResponseFail = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent("Unable to get user from token")
                };
                return httpResponseFail;
            }

            int userID = _jwtServce.GetUserIDFromToken(jwtToken);
            if (userID == -1)
            {
                var httpResponseFail = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent("Unable to retrieve user data, user not found")
                };
                return httpResponseFail;
            }

            User retrievedUser = _userService.GetUserById(userID);
            UpdateProfileRequest request = new UpdateProfileRequest();
            request.FirstName = retrievedUser.FirstName;
            request.LastName = retrievedUser.LastName;
            request.DoB = retrievedUser.DoB;
            request.City = retrievedUser.City;
            request.State = retrievedUser.State;
            request.Country = retrievedUser.Country;

            var httpResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JsonConvert.SerializeObject(request))
            };
            return httpResponse;
        }

        public HttpResponseMessage UpdateUserProfile(UpdateProfileRequest request)
        {
            if (_jwtServce.IsJWTSignatureTampered(request.JwtToken)){
                var httpResponseFail = new HttpResponseMessage(HttpStatusCode.Unauthorized)
                {
                    Content = new StringContent("Session is invalid")
                };
                return httpResponseFail;
            }

            int userID = _jwtServce.GetUserIDFromToken(request.JwtToken);
            User retrievedUser = _userService.GetUserById(userID);
            retrievedUser.FirstName = request.FirstName;
            retrievedUser.LastName = request.LastName;
            retrievedUser.DoB = request.DoB;
            retrievedUser.City = request.City;
            retrievedUser.State = request.State;
            retrievedUser.Country = request.Country;
            if (!_userService.UpdateUser(retrievedUser))
            {
                var httpResponseFail = new HttpResponseMessage(HttpStatusCode.ServiceUnavailable)
                {
                    Content = new StringContent("Unable to update user")
                };
                return httpResponseFail;
            }

            var httpResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("Profile has been updated")
            };
            return httpResponse;
        }

        public HttpResponseMessage GetEmail(string jwtToken)
        {
            if (_jwtServce.IsJWTSignatureTampered(jwtToken))
            {
                var httpResponseFail = new HttpResponseMessage(HttpStatusCode.Unauthorized)
                {
                    Content = new StringContent("Session is invalid")
                };
                return httpResponseFail;
            }
            var retrievedEmail = _jwtServce.GetUsernameFromToken(jwtToken);

            var httpResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(retrievedEmail)
            };
            return httpResponse;
        }

        public bool CheckProfileActivated(string jwtToken)
        {
            int userID = _jwtServce.GetUserIDFromToken(jwtToken);
            if (_userService.IsUsernameFoundById(userID))
            {
                User retrievedUser = _userService.GetUserById(userID);
                return retrievedUser.IsActivated;
            }
            return false;
        }



        /*
        public int RateUser(RateRequest request, string rateeID)
        {
            try
            {
                int raterID = _jwtServce.GetUserIDFromToken(request.jwtToken);
                UserRating ur = new UserRating();
                ur.RatedId1 = Convert.ToInt32(rateeID);
                ur.RaterId1 = Convert.ToInt32(raterID);
                ur.Rating = Convert.ToInt32(request.rating);
                _ratingService.CreateRating(ur);
                return 1;
            }
            catch (FormatException)
            {
                //log
                return -1;
            }
        }
        */
    }
}
