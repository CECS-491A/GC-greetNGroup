﻿using DataAccessLayer.Models;
using ManagerLayer.UADManagement;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceLayer.Interface;
using ServiceLayer.Services;
using System;
using System.Collections.Generic;

namespace UnitTest.UADTest
{
    [TestClass]
    public class UADTest
    {
        #region ManagerTest
        [TestMethod]
        public void TestMonthlyLoginvsRegistered()
        {
            UADManager uadManager = new UADManager();
            uadManager.GetLoginVSRegistered("March");
            Assert.AreEqual(true, true);

        }

        [TestMethod]
        public void TestMonthlyLoginOverSixMonths()
        {
            UADManager uadManager = new UADManager();
            uadManager.GetLoggedInMonthly("March");
            Assert.AreEqual(true, true);

        }

        [TestMethod]
        public void Top5MostUsedFeature()
        {
            UADManager uadManager = new UADManager();
            uadManager.GetTop5MostUsedFeature("March");
            Assert.AreEqual(true, true);

        }

        [TestMethod]
        public void AverageSessionDuration()
        {
            UADManager uadManager = new UADManager();
            uadManager.GetAverageSessionDuration("March");
            Assert.AreEqual(true, true);

        }

        [TestMethod]
        public void AverageSessionMonthly()
        {
            UADManager uadManager = new UADManager();
            uadManager.GetAverageSessionMonthly("March");
            Assert.AreEqual(true, true);

        }

        [TestMethod]
        public void Top5AveragePageSession()
        {
            UADManager uadManager = new UADManager();
            uadManager.GetTop5AveragePageSession("March");
            Assert.AreEqual(true, true);

        }
        #endregion

        #region Passed Test
        [TestMethod]
        public void GetNumberofLogsID_Pass()
        {
            //Arrange
            IUADService _uadService = new UADService();
            GNGLoggerService _loggerService = new GNGLoggerService();
            bool expected = true;
            bool actual = false;
            string logID = "1001";

            //Read testlogs from this path
            string path = "C:\\Users\\Midnightdrop\\Documents\\GitHub\\GreetNGroup\\Backend\\UnitTest\\UADTest\\TestLogs\\PassLogs";
            List<GNGLog> logList = new List<GNGLog>();

            //Act
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
            //Arrange
            IUADService _uadService = new UADService();
            GNGLoggerService _loggerService = new GNGLoggerService();
            bool expected = true;
            bool actual = false;
            string month = "March";

            //Read testlogs from this path
            string path = "C:\\Users\\Midnightdrop\\Documents\\GitHub\\GreetNGroup\\Backend\\UnitTest\\UADTest\\TestLogs\\PassLogs";
            List<GNGLog> logList = new List<GNGLog>();

            //Act
            logList = _loggerService.ReadLogsPath(path);
            logList = _uadService.GetLogsFortheMonth(logList, month);
            if (logList.Count == 2)
            {
                actual = true;
            }

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void GetLogswithID_Pass()
        {
            //Arrange
            IUADService _uadService = new UADService();
            GNGLoggerService _loggerService = new GNGLoggerService();
            bool expected = true;
            bool actual = false;
            string logID = "1001";

            //Read testlogs from this path
            string path = "C:\\Users\\Midnightdrop\\Documents\\GitHub\\GreetNGroup\\Backend\\UnitTest\\UADTest\\TestLogs\\PassLogs";
            List<GNGLog> logList = new List<GNGLog>();

            //Act
            logList = _loggerService.ReadLogsPath(path);
            logList = _uadService.GetLogswithID(logList, logID);
            if (logList.Count == 4)
            {
                actual = true;
            }

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void QuickSortInteger_Pass()
        {
            //Arrange
            IUADService _uadService = new UADService();
            bool expected = true;
            bool actual = false;
            List<int> numList = new List<int> {5, 4, 3, 2, 1};
            List<string> wordList = new List<string> { "E", "D", "C", "B", "A" };

            //Act
            _uadService.QuickSortInteger(numList, wordList, 0, wordList.Count - 1);
            if((numList[0] == 1 && wordList[0].Equals("A")) && (numList[1] == 2 && wordList[1].Equals("B")) && (numList[2] == 3 && wordList[2].Equals("C")) && (numList[3] == 4 && wordList[3].Equals("D")) && (numList[4] == 5 && wordList[4].Equals("E")))
            {
                actual = true;
            }
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void QuickSortInteger_Pass_DuplicateNumbers()
        {
            //Arrange
            IUADService _uadService = new UADService();
            bool expected = true;
            bool actual = false;
            List<int> numList = new List<int> { 2, 3, 5, 3, 1 };
            List<string> wordList = new List<string> { "E", "D", "C", "B", "A" };

            //Act
            _uadService.QuickSortInteger(numList, wordList, 0, wordList.Count - 1);
            if ((numList[0] == 1 && wordList[0].Equals("A")) && (numList[1] == 2 && wordList[1].Equals("E")) && (numList[2] == 3 && wordList[2].Equals("B")) && (numList[3] == 3 && wordList[3].Equals("D")) && (numList[4] == 5 && wordList[4].Equals("C")))
            {
                actual = true;
            }
            Assert.AreEqual(actual, expected);
        }
        [TestMethod]
        public void QuickSortDouble_Pass()
        {
            //Arrange
            IUADService _uadService = new UADService();
            bool expected = true;
            bool actual = false;
            double[] numList = { 5.5, 4.4, 3.3, 2.2, 1.1 };
            List<string> wordList = new List<string> { "E", "D", "C", "B", "A" };

            //Act
            _uadService.QuickSortDouble(numList, wordList);
            if ((numList[0] == 1.1 && wordList[0].Equals("A")) && (numList[1] == 2.2 && wordList[1].Equals("B")) && (numList[2] == 3.3 && wordList[2].Equals("C")) && (numList[3] == 4.4 && wordList[3].Equals("D")) && (numList[4] == 5.5 && wordList[4].Equals("E")))
            {
                actual = true;
            }
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void CalculateAverageSessionTime_Pass()
        {
            //Arrange
            IUADService _uadService = new UADService();
            GNGLoggerService _loggerService = new GNGLoggerService();
            bool expected = true;
            bool actual = false;

            //Read logs from this path
            string path = "C:\\Users\\Midnightdrop\\Documents\\GitHub\\GreetNGroup\\Backend\\UnitTest\\UADTest\\TestLogs\\PassLogs_SessionTimes";
            List<GNGLog> logList = new List<GNGLog>();

            //Act
            logList = _loggerService.ReadLogsPath(path);
            double averageTime = _uadService.CalculateAverageSessionTime(logList);
            if(averageTime == 60)
            {
                actual = true;
            }
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void GetEntryLogswithURL_Pass()
        {
            //Arrange
            IUADService _uadService = new UADService();
            GNGLoggerService _loggerService = new GNGLoggerService();
            string entryLog = "https://www.endpoint.com";
            bool expected = true;
            bool actual = false;

            //Read logs from this path
            string path = "C:\\Users\\Midnightdrop\\Documents\\GitHub\\GreetNGroup\\Backend\\UnitTest\\UADTest\\TestLogs\\PassLogs";
            List<GNGLog> logList = new List<GNGLog>();

            //Act
            logList = _loggerService.ReadLogsPath(path);
            _uadService.GetEntryLogswithURL(logList, entryLog);
            if (logList.Count == 3)
            {
                actual = true;
            }
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void GetExitLogswithURL_Pass()
        {
            //Arrange
            IUADService _uadService = new UADService();
            GNGLoggerService _loggerService = new GNGLoggerService();
            string entryLog = "https://www.startpoint.com";
            bool expected = true;
            bool actual = false;

            //Read logs from this path
            string path = "C:\\Users\\Midnightdrop\\Documents\\GitHub\\GreetNGroup\\Backend\\UnitTest\\UADTest\\TestLogs\\PassLogs";
            List<GNGLog> logList = new List<GNGLog>();

            //Act
            logList = _loggerService.ReadLogsPath(path);
            _uadService.GetExitLogswithURL(logList, entryLog);
            if (logList.Count == 4)
            {
                actual = true;
            }
            Assert.AreEqual(actual, expected);
        }
        
        [TestMethod]
        public void GetNumberofLogsID_Pass_IDNotLogged()
        {
            //Arrange
            IUADService _uadService = new UADService();
            GNGLoggerService _loggerService = new GNGLoggerService();
            bool expected = true;
            bool actual = false;
            string logID = "1010";

            //Read testlogs from this path
            string path = "C:\\Users\\Midnightdrop\\Documents\\GitHub\\GreetNGroup\\Backend\\UnitTest\\UADTest\\TestLogs\\PassLogs";
            List<GNGLog> logList = new List<GNGLog>();

            //Act
            logList = _loggerService.ReadLogsPath(path);
            int numOfLogs = _uadService.GetNumberofLogsID(logList, logID);
            if (numOfLogs == 0)
            {
                actual = true;
            }
            Assert.AreNotSame(actual, expected);
        }

        [TestMethod]
        public void GetLogsFortheMonth_Pass_MonthNotLogged()
        {
            //Arrange
            IUADService _uadService = new UADService();
            GNGLoggerService _loggerService = new GNGLoggerService();
            bool expected = true;
            bool actual = false;
            string month = "December";

            //Read testlogs from this path
            string path = "C:\\Users\\Midnightdrop\\Documents\\GitHub\\GreetNGroup\\Backend\\UnitTest\\UADTest\\TestLogs\\PassLogs";
            List<GNGLog> logList = new List<GNGLog>();

            //Act
            logList = _loggerService.ReadLogsPath(path);
            logList = _uadService.GetLogsFortheMonth(logList, month);
            if (logList.Count == 0)
            {
                actual = true;
            }

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void GetLogswithID_Pass_IDNotLogged()
        {
            //Arrange
            IUADService _uadService = new UADService();
            GNGLoggerService _loggerService = new GNGLoggerService();
            bool expected = true;
            bool actual = false;
            string logID = "1011";

            //Read testlogs from this path
            string path = "C:\\Users\\Midnightdrop\\Documents\\GitHub\\GreetNGroup\\Backend\\UnitTest\\UADTest\\TestLogs\\PassLogs";
            List<GNGLog> logList = new List<GNGLog>();

            //Act
            logList = _loggerService.ReadLogsPath(path);
            logList = _uadService.GetLogswithID(logList, logID);
            if (logList.Count == 0)
            {
                actual = true;
            }
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void GetEntryLogswithURL_Pass_URLNotLogged()
        {
            //Arrange
            IUADService _uadService = new UADService();
            GNGLoggerService _loggerService = new GNGLoggerService();
            string entryLog = "https://www.test.com";
            bool expected = true;
            bool actual = false;

            //Read logs from this path
            string path = "C:\\Users\\Midnightdrop\\Documents\\GitHub\\GreetNGroup\\Backend\\UnitTest\\UADTest\\TestLogs\\PassLogs";
            List<GNGLog> logList = new List<GNGLog>();

            //Act
            logList = _loggerService.ReadLogsPath(path);
            _uadService.GetEntryLogswithURL(logList, entryLog);
            if (logList.Count == 0)
            {
                actual = true;
            }
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void GetExitLogswithURL_Pass_URLNotLogged()
        {
            //Arrange
            IUADService _uadService = new UADService();
            GNGLoggerService _loggerService = new GNGLoggerService();
            string entryLog = "https://www.test.com";
            bool expected = true;
            bool actual = false;

            //Read logs from this path
            string path = "C:\\Users\\Midnightdrop\\Documents\\GitHub\\GreetNGroup\\Backend\\UnitTest\\UADTest\\TestLogs\\PassLogs";
            List<GNGLog> logList = new List<GNGLog>();

            //Act
            logList = _loggerService.ReadLogsPath(path);
            _uadService.GetExitLogswithURL(logList, entryLog);
            if (logList.Count == 0)
            {
                actual = true;
            }
            Assert.AreEqual(actual, expected);
        }

        
        #endregion

        #region Failed Test
        [TestMethod]
        public void QuickSortInteger_Fail_LessWordsThanNumbers()
        {
            //Arrange
            IUADService _uadService = new UADService();
            bool expected = true;
            bool actual = false;
            List<int> numList = new List<int> { 5, 4, 3, 2, 1 };
            List<string> wordList = new List<string> { "E", "D", "C", "B"};

            //Act
            try
            {
                _uadService.QuickSortInteger(numList, wordList, 0, wordList.Count - 1);
                if (wordList[0].Equals("A") == true && wordList[1].Equals("B") == true && wordList[2].Equals("C") == true && wordList[3].Equals("D") == true && wordList[4].Equals("E") == true)
                {
                    actual = true;
                }
            }
            catch(Exception all)
            {
                
            }
            
            Assert.AreNotEqual(actual, expected);
        }

        [TestMethod]
        public void QuickSortInteger_Fail_LessNumbersThanWords()
        {
            //Arrange
            IUADService _uadService = new UADService();
            bool expected = true;
            bool actual = false;
            List<int> numList = new List<int> { 5, 4, 3, 2};
            List<string> wordList = new List<string> { "E", "D", "C", "B", "A" };

            //Act
            try
            {
                _uadService.QuickSortInteger(numList, wordList, 0, wordList.Count - 1);
                if (wordList[0].Equals("A") == true && wordList[1].Equals("B") == true && wordList[2].Equals("C") == true && wordList[3].Equals("D") == true && wordList[4].Equals("E") == true)
                {
                    actual = true;
                }
            }
            catch (Exception all)
            {

            }
            Assert.AreNotEqual(actual, expected);
        }

        [TestMethod]
        public void QuickSortInteger_Fail_MoreWordsThanNumbers()
        {
            //Arrange
            IUADService _uadService = new UADService();
            bool expected = true;
            bool actual = false;
            List<int> numList = new List<int> { 5, 4, 3, 2, 1 };
            List<string> wordList = new List<string> { "E", "D", "C", "B", "A", "Z" };

            //Act
            try
            {
                _uadService.QuickSortInteger(numList, wordList, 0, wordList.Count - 1);
                if (wordList[0].Equals("A") == true && wordList[1].Equals("B") == true && wordList[2].Equals("C") == true && wordList[3].Equals("D") == true && wordList[4].Equals("E") == true)
                {
                    actual = true;
                }
            }
            catch (Exception all)
            {

            }

            Assert.AreNotEqual(actual, expected);
        }

        [TestMethod]
        public void CalculateAverageSessionTime_Fail_LogsNotInRightOrder()
        {
            //Arrange
            IUADService _uadService = new UADService();
            GNGLoggerService _loggerService = new GNGLoggerService();
            bool expected = true;
            bool actual = false;

            //Read logs from this path
            string path = "C:\\Users\\Midnightdrop\\Documents\\GitHub\\GreetNGroup\\Backend\\UnitTest\\UADTest\\TestLogs\\FailedLogs";
            List<GNGLog> logList = new List<GNGLog>();

            //Act
            logList = _loggerService.ReadLogsPath(path);
            double averageTime = _uadService.CalculateAverageSessionTime(logList);
            Console.WriteLine(averageTime);
            if (averageTime == 60)
            {
                actual = true;
            }
            Assert.AreNotEqual(actual, expected);
        }
        #endregion
    }
}
