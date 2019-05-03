﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace ServiceLayer.Services
{
    // This class provides a set of signing methods that conform to LTI spec
    public class SignatureService
    {
        public bool IsValidClientRequest(string userId, string email, string timestamp, string signature)
        {
            // Dictionary represents the signed body of the request to the destination server
            // Props can be added to this, and they will be added to signature
            var payload = PreparePayload(userId, email, timestamp);
            var generatedSignature = Sign(payload);
            return generatedSignature == signature;
        }

        public Dictionary<string, string> PreparePayload(string userId, string email, string timestamp)
        {
            var preparedPayload = new Dictionary<string, string>
            {
                { "ssoUserId", userId },
                { "email", email },
                { "timestamp", timestamp.ToString() }
            };
            return preparedPayload;
        }

        // Signs a dictionary with the provided key by constructing a key/value string
        public string Sign(Dictionary<string, string> payload)
        {
            // Order the provided dictionary by key
            // This is necessary so that the recipient of the payload will be able to generate the
            // correct hash even if the order changes
            var orderedPayload = from payloadItem in payload
                                 orderby payloadItem.Value descending
                                 select payloadItem;

            var payloadString = "";
            // Build a payload string with the format:
            // key =value;key2=value2;
            // SECURITY: This must be passed in this format so that the resulting hash is the same
            foreach (var pair in orderedPayload)
            {
                payloadString = payloadString + pair.Key + "=" + pair.Value + ";";
            }

            var signature = Sign(payloadString);
            return signature;
        }

        // Signs a string with the provided key
        public string Sign(string payloadString)
        {
            // Instantiate a new hashing algorithm with the provided key
            HMACSHA256 hashingAlg = new HMACSHA256(Encoding.ASCII.GetBytes("5E5DDBD9B984E4C95BBFF621DF91ABC9A5318DAEC0A3B231B4C1BC8FE0851610"));

            //Environment.GetEnvironmentVariable("AppLaunchSecretKey", EnvironmentVariableTarget.Machine)

            // Get the raw bytes from our payload string
            byte[] payloadBuffer = Encoding.ASCII.GetBytes(payloadString);

            // Calculate our hash from the byte array
            byte[] signatureBytes = hashingAlg.ComputeHash(payloadBuffer);

            var signature = Convert.ToBase64String(signatureBytes);
            return signature;
        }
    }
}