using Gucci.DataAccessLayer.Models;
using Gucci.ManagerLayer.UADManagement;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Gucci.ServiceLayer.Interface;
using Gucci.ServiceLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTest.UADTest
{
    [TestClass]
    public class UADTest
    {
        private UADManager uadManager = new UADManager();
        private UADService _uadService = new UADService();
        private LoggerService _loggerService = new LoggerService();
        #region ManagerTest
        [TestMethod]
        public void GetLoginComparedToRegistered_Pass()
        {
            // Arrange
            bool expected = true;
            bool actual = false;
            var expectedAverageLogins = "1.5";
            var expectedRegistered = "14";
            // Act
            var test = uadManager.GetLoginComparedToRegistered("April", 1);
            if(test[0].Value.CompareTo(expectedAverageLogins) == 0 && test[3].Value.CompareTo(expectedRegistered) == 0)
            {
                actual = true;
            }
            for(int i = 0; i < test.Count; i++)
            {
                Console.WriteLine(test[i].InfoType + ' ' + test[i].Value);
            }
            // Assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void GetMonthlyLoginOverSixMonths_Pass()
        {
            // Arrange
            bool expected = true;
            bool actual = false;
            var expectedLogins = new List<string> { "0", "0", "3", "2", "1", "0" };
            var expectedMonths = new List<string> { "June", "May", "April", "March", "February", "January" };
            var actualLogin = new List<string>();
            var actualMonths = new List<string>();

            // Act
            var test = uadManager.GetLoggedInMonthly("June", 1);
            for (int i = 0; i < test.Count; i++)
            {
                Console.WriteLine(test[i].InfoType + ' ' + test[i].Value);
                actualLogin.Add(test[i].Value);
                actualMonths.Add(test[i].InfoType);
            }
            if(expectedLogins.SequenceEqual(actualLogin) && expectedMonths.SequenceEqual(actualMonths))
            {
                actual = true;
            }
            // Assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void GetTop5MostUsedFeature_Pass()
        {
            // Arrange
            bool expected = true;
            bool actual = false;
            var expectedFeatures = new List<string> {"SearchAction", "EventCreated", "EventJoined", "UserRatings" ,"FindEventForMe"};
            var expectedCount = new List<string> {"11", "3",  "1", "0", "0" };
            var actualFeatures = new List<string>();
            var actualCount = new List<string>();
            // Act
            var test = uadManager.GetTop5MostUsedFeature("April", 1);
            for (int i = 0; i < test.Count; i++)
            {
                Console.WriteLine(test[i].InfoType + ' ' + test[i].Value);
                actualFeatures.Add(test[i].InfoType);
                actualCount.Add(test[i].Value);
            }
            if (expectedFeatures.SequenceEqual(actualFeatures) && expectedCount.SequenceEqual(actualCount))
            {
                actual = true;
            }
            // Assert
            Assert.AreEqual(actual, expected);

        }

        [TestMethod]
        public void GetAverageSessionDuration_Pass()
        {
            // Arrange
            bool expected = true;
            bool actual = false;
            var expectedAverageSession = "417.67";
            var expectedMinSession = "53";
            var expectedMaxSession = "840";

            // Act
            var test = uadManager.GetAverageSessionDuration("April", 1);
            if(expectedAverageSession == test[0].Value && expectedMinSession == test[1].Value && expectedMaxSession == test[2].Value)
            {
                actual = true;
            }
            for (int i = 0; i < test.Count; i++)
            {
                Console.WriteLine(test[i].InfoType + ' ' + test[i].Value);
            }
            // Assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void GetAverageSessionMonthly_Pass()
        {
            // Assign
            bool expected = true;
            bool actual = false;
            var expectedDuration = new List<string> { "0", "0", "417.67", "956.5", "533", "0" };
            var expectedMonths = new List<string> { "June", "May", "April", "March", "February", "January" };
            var actualDuration = new List<string>();
            var actualMonths = new List<string>();

            // Act
            var test = uadManager.GetAverageSessionMonthly("June", 1);
            for (int i = 0; i < test.Count; i++)
            {
                Console.WriteLine(test[i].InfoType + ' ' + test[i].Value);
                actualMonths.Add(test[i].InfoType);
                actualDuration.Add(test[i].Value);
            }
            if (expectedDuration.SequenceEqual(actualDuration) && expectedMonths.SequenceEqual(actualMonths))
            {
                actual = true;
            }
            // Assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void GetTop5AveragePageSession_Pass()
        {
            // Assign
            bool expected = true;
            bool actual = false;
            var expectedUrls = new List<string> { "https://www.greetngroup.com/search", "https://www.greetngroup.com/createevent", "https://www.greetngroup.com", "https://www.greetngroup.com/faq", "https://www.greetngroup.com/help" };
            var expectedDuration = new List<string> { "547", "62", "0", "0", "0" };
            var actualUrls = new List<string>();
            var actualDuration = new List<string>();

            // Act
            var test = uadManager.GetTop5AveragePageSession("April", 1);
            for (int i = 0; i < test.Count; i++)
            {
                Console.WriteLine(test[i].InfoType + ' ' + test[i].Value);
                actualUrls.Add(test[i].InfoType);
                actualDuration.Add(test[i].Value);
            }
            if (expectedDuration.SequenceEqual(actualDuration) && expectedUrls.SequenceEqual(actualUrls))
            {
                actual = true;
            }
            // Assert
            Assert.AreEqual(actual, expected);
        }
        #endregion

        #region Passed Test
        [TestMethod]
        public void GetNumberofLogsID_Pass()
        {
            // Arrange
            bool expected = true;
            bool actual = false;
            string logID = "ClickEvent";
            string path = "C:\\Users\\Midnightdrop\\Documents\\GitHub\\GreetNGroup\\Backend\\UnitTest\\UADTest\\TestLogs\\ServiceLogs\\PassLogs";
            List<GNGLog> logList = new List<GNGLog>();

            // Act
            logList = _loggerService.ReadLogsPath(path);
            int numOfLogs = _uadService.GetNumberofLogsID(logList, logID);
            if(numOfLogs == 4)
            {
                actual = true;
            }
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void GetLogsFortheMonth_Pass()
        {
            // Arrange
            bool expected = true;
            bool actual = false;
            string month = "March";
            string path = "C:\\Users\\Midnightdrop\\Documents\\GitHub\\GreetNGroup\\Backend\\UnitTest\\UADTest\\TestLogs\\ServiceLogs\\PassLogs";
            List<GNGLog> logList = new List<GNGLog>();

            // Act
            logList = _loggerService.ReadLogsPath(path);
            logList = _uadService.GetLogsFortheMonth(logList, month);
            if (logList.Count == 3)
            {
                actual = true;
            }
            // Assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void GetLogswithID_Pass()
        {
            // Arrange
            IUADService _uadService = new UADService();
            LoggerService _loggerService = new LoggerService();
            bool expected = true;
            bool actual = false;
            string logID = "ClickEvent";

            // Read testlogs from this path
            string path = "C:\\Users\\Midnightdrop\\Documents\\GitHub\\GreetNGroup\\Backend\\UnitTest\\UADTest\\TestLogs\\ServiceLogs\\PassLogs";
            List<GNGLog> logList = new List<GNGLog>();

            // Act
            logList = _loggerService.ReadLogsPath(path);
            logList = _uadService.GetLogswithID(logList, logID);
            if (logList.Count == 4)
            {
                actual = true;
            }

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void CalculateAverageSessionTime_Pass()
        {
            // Arrange
            IUADService _uadService = new UADService();
            LoggerService _loggerService = new LoggerService();
            bool expected = true;
            bool actual = false;

            // Read logs from this path
            string path = "C:\\Users\\Midnightdrop\\Documents\\GitHub\\GreetNGroup\\Backend\\UnitTest\\UADTest\\TestLogs\\ServiceLogs\\PassLogs_SessionTimes";
            List<GNGLog> logList = new List<GNGLog>();

            // Act
            logList = _loggerService.ReadLogsPath(path);
            var averageTime = _uadService.CalculateAverageSessionInformation(logList);
            if(averageTime[0].CompareTo("60") == 0)
            {
                actual = true;
            }
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void GetEntryLogswithURL_Pass()
        {
            // Arrange
            string entryLog = "https://www.endpoint.com";
            bool expected = true;
            bool actual = false;
            string path = "C:\\Users\\Midnightdrop\\Documents\\GitHub\\GreetNGroup\\Backend\\UnitTest\\UADTest\\TestLogs\\ServiceLogs\\PassLogs";
            List<GNGLog> logList = new List<GNGLog>();

            // Act
            logList = _loggerService.ReadLogsPath(path);
            _uadService.GetEntryLogswithURL(logList, entryLog);
            if (logList.Count == 3)
            {
                actual = true;
            }
            // Assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void GetExitLogswithURL_Pass()
        {
            // Arrange
            string entryLog = "https://www.startpoint.com";
            bool expected = true;
            bool actual = false;
            string path = "C:\\Users\\Midnightdrop\\Documents\\GitHub\\GreetNGroup\\Backend\\UnitTest\\UADTest\\TestLogs\\ServiceLogs\\PassLogs";
            List<GNGLog> logList = new List<GNGLog>();

            // Act
            logList = _loggerService.ReadLogsPath(path);
            _uadService.GetExitLogswithURL(logList, entryLog);
            if (logList.Count == 4)
            {
                actual = true;
            }
            // Assert
            Assert.AreEqual(actual, expected);
        }
        
        [TestMethod]
        public void GetNumberofLogsID_Pass_IDNotLogged()
        {
            // Arrange
            bool expected = true;
            bool actual = false;
            string logID = "EventCreated";
            string path = "C:\\Users\\Midnightdrop\\Documents\\GitHub\\GreetNGroup\\Backend\\UnitTest\\UADTest\\TestLogs\\ServiceLogs\\PassLogs";
            List<GNGLog> logList = new List<GNGLog>();

            // Act
            logList = _loggerService.ReadLogsPath(path);
            int numOfLogs = _uadService.GetNumberofLogsID(logList, logID);
            if (numOfLogs == 0)
            {
                actual = true;
            }
            // Assert
            Assert.AreNotSame(actual, expected);
        }

        [TestMethod]
        public void GetLogsFortheMonth_Pass_MonthNotLogged()
        {
            // Arrange
            bool expected = true;
            bool actual = false;
            string month = "December";
            string path = "C:\\Users\\Midnightdrop\\Documents\\GitHub\\GreetNGroup\\Backend\\UnitTest\\UADTest\\TestLogs\\ServiceLogs\\PassLogs";
            List<GNGLog> logList = new List<GNGLog>();

            // Act
            logList = _loggerService.ReadLogsPath(path);
            logList = _uadService.GetLogsFortheMonth(logList, month);
            if (logList.Count == 0)
            {
                actual = true;
            }
            // Assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void GetLogswithID_Pass_IDNotLogged()
        {
            //Arrange
            bool expected = true;
            bool actual = false;
            string logID = "EventDeleted";
            string path = "C:\\Users\\Midnightdrop\\Documents\\GitHub\\GreetNGroup\\Backend\\UnitTest\\UADTest\\TestLogs\\ServiceLogs\\PassLogs";
            List<GNGLog> logList = new List<GNGLog>();

            //Act
            logList = _loggerService.ReadLogsPath(path);
            logList = _uadService.GetLogswithID(logList, logID);
            if (logList.Count == 0)
            {
                actual = true;
            }
            // Assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void GetEntryLogswithURL_Pass_URLNotLogged()
        {
            //Arrange
            IUADService _uadService = new UADService();
            LoggerService _loggerService = new LoggerService();
            string entryLog = "https://www.test.com";
            bool expected = true;
            bool actual = false;
            string path = "C:\\Users\\Midnightdrop\\Documents\\GitHub\\GreetNGroup\\Backend\\UnitTest\\UADTest\\TestLogs\\ServiceLogs\\PassLogs";
            List<GNGLog> logList = new List<GNGLog>();

            //Act
            logList = _loggerService.ReadLogsPath(path);
            _uadService.GetEntryLogswithURL(logList, entryLog);
            if (logList.Count == 0)
            {
                actual = true;
            }
            // Assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void GetExitLogswithURL_Pass_URLNotLogged()
        {
            //Arrange
            string entryLog = "https://www.test.com";
            bool expected = true;
            bool actual = false;

            //Read logs from this path
            string path = "C:\\Users\\Midnightdrop\\Documents\\GitHub\\GreetNGroup\\Backend\\UnitTest\\UADTest\\TestLogs\\ServiceLogs\\PassLogs";
            List<GNGLog> logList = new List<GNGLog>();

            //Act
            logList = _loggerService.ReadLogsPath(path);
            _uadService.GetExitLogswithURL(logList, entryLog);
            if (logList.Count == 0)
            {
                actual = true;
            }

            // Assert
            Assert.AreEqual(actual, expected);
        }

        
        #endregion

        #region Failed Test
        [TestMethod]
        public void CalculateAverageSessionTime_Fail_LogsNotInRightOrder()
        {
            //Arrange
            bool expected = true;
            bool actual = false;
            string path = "C:\\Users\\Midnightdrop\\Documents\\GitHub\\GreetNGroup\\Backend\\UnitTest\\UADTest\\TestLogs\\ServiceLogs\\FailedLogs";
            List<GNGLog> logList = new List<GNGLog>();

            //Act
            logList = _loggerService.ReadLogsPath(path);
            var averageTime = _uadService.CalculateAverageSessionInformation(logList);
            Console.WriteLine(averageTime);
            if(averageTime[0].CompareTo("60") == 0)
            {
                actual = true;
            }
            // Assert
            Assert.AreNotEqual(actual, expected);
        }
        #endregion
    }
}
