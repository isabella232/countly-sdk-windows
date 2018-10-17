﻿using CountlySDK;
using CountlySDK.CountlyCommon.Entities;
using CountlySDK.Entities;
using CountlySDK.Entities.EntityBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject_common
{
    internal class TestHelper
    {
        //list of generic string values
        public static String[] v = new string[] { "123", "234", "345", "a", "b", "c", "d", "e", "f", "t", "u", "p", "s", "g", "1t", "1u", "1p", "12s", "12g", "12t", "1u2", "12p", "122", "12g" };
        public static int[] iv = new int[] { 12, 23, 34, 45, 56, 67, 52, 23, 76, 975, 3345 };
        public static bool[] bv = new bool[] { true, false };
        public static long[] lv = new long[] { 23, 345, 543, 76, 87, 3245, 3543, 9780, 43534, 123, 5634 };
        public static double[] dv = new double[] {123.43, 456.43, 678.543, 456.23, 765.34 };

        public static BeginSession CreateBeginSession(int indexData, int indexMetrics)
        {
            Metrics m = new Metrics(v[indexMetrics + 4], v[indexMetrics + 5], v[indexMetrics + 6], v[indexMetrics + 7], v[indexMetrics + 8], v[indexMetrics + 9]);
            BeginSession bs = new BeginSession(v[indexData + 0], v[indexData + 1], v[indexData + 2], m);
            return bs;
        }

        public static EndSession CreateEndSession(int index)
        {
            EndSession es = new EndSession(v[index + 0], v[index + 1]);
            return es;
        }

        public static UpdateSession CreateUpdateSession(int indexData, int indexDuration)
        {
            UpdateSession us = new UpdateSession(v[indexData + 0], v[indexData + 1], iv[indexDuration]);
            return us;
        }

        public static CustomInfoItem CreateCustomInfoItem(int index)
        {
            CustomInfoItem cii = new CustomInfoItem(v[index], v[index + 1]);
            return cii;
        }

        public static CustomInfo CreateCustomInfo(int index)
        {
            CustomInfo ci = new CustomInfo();
            ci.Add(v[index + 0], v[index + 1]);
            ci.Add(v[index + 2], v[index + 3]);
            return ci;
        }

        public static CountlyUserDetails CreateCountlyUserDetails(int indexData, int indexCustomInfo)
        {
            CountlyUserDetails cud = new CountlyUserDetails();
            PopulateCountlyUserDetails(cud, indexData, indexCustomInfo);            

            return cud;
        }

        public static void PopulateCountlyUserDetails(CountlyUserDetails cud, int indexData, int indexCustomInfo)
        {
            cud.BirthYear = iv[indexData];
            cud.Custom.Add(v[indexData + 0], v[indexData + 1]);
            cud.Custom.Add(v[indexData + 2], v[indexData + 3]);
            cud.Email = v[indexData + 4];
            cud.Gender = v[indexData + 5];
            cud.Username = v[indexData + 6];
            cud.Phone = v[indexData + 7];
            cud.Organization = v[indexData + 8];
            cud.Name = v[indexData + 9];
            cud.Picture = v[indexData + 10];

            CustomInfo cui = CreateCustomInfo(indexCustomInfo);
            cud.Custom = cui;
        }

            public static DeviceId CreateDeviceId(int index, int indexIdMethod)
        {
            DeviceBase.DeviceIdMethodInternal method;
            indexIdMethod = indexIdMethod % 6;
            switch (indexIdMethod)
            {
                case 0:
                    method = DeviceBase.DeviceIdMethodInternal.none;
                    break;
                case 1:
                    method = DeviceBase.DeviceIdMethodInternal.cpuId;
                    break;
                case 2:
                    method = DeviceBase.DeviceIdMethodInternal.windowsGUID;
                    break;
                case 3:
                    method = DeviceBase.DeviceIdMethodInternal.winHardwareToken;
                    break;
                case 4:
                    method = DeviceBase.DeviceIdMethodInternal.multipleWindowsFields;
                    break;
                case 5:
                    method = DeviceBase.DeviceIdMethodInternal.developerSupplied;
                    break;
                default:
                    method = DeviceBase.DeviceIdMethodInternal.none;
                    break;
            }

            DeviceId did = new DeviceId(v[index], method);
            return did;
        }

        public static ExceptionEvent CreateExceptionEvent(int index)
        {
            TimeSpan ts = new TimeSpan(iv[index], iv[index + 1], iv[index + 2], iv[index + 3]);
            ExceptionEvent ee = new ExceptionEvent();
            ee.AppVersion = v[index];

            Dictionary<String, String> cust = new Dictionary<string, string>();
            cust.Add(v[index + 1], v[index + 2]);
            cust.Add(v[index + 3], v[index + 4]);

            ee.Custom = cust;
            ee.Device = v[index + 5];
            ee.Error = v[index + 6];
            ee.Logs = v[index + 7];
            ee.Manufacture = v[index + 8];
            ee.Name = v[index + 9];
            ee.NonFatal = bv[index % 2];
            ee.Online = bv[(index + 1) % 2];
            ee.Orientation = v[index + 10];
            ee.OS = v[index + 11];
            ee.OSVersion = v[index + 12];
            ee.RamCurrent = lv[index];
            ee.RamTotal = lv[index + 1];
            ee.Resolution = v[index + 13];
            ee.Run = lv[index + 2];

            return ee;
        }

        public static Metrics CreateMetrics(int index)
        {
            Metrics m = new Metrics(v[index], v[index + 1], v[index + 2], v[index + 3], v[index + 4], v[index + 5]);

            return m;
        }

        public static SegmentationItem CreateSegmentationItem(int index)
        {
            SegmentationItem si = new SegmentationItem(v[index], v[index + 1]);
            return si;
        }

        public static Segmentation CreateSegmentation(int index)
        {
            Segmentation se = new Segmentation();
            se.Add(v[index], v[index + 1]);
            se.Add(v[index + 2], v[index + 3]);
            return se;
        }

        public static CountlyEvent CreateCountlyEvent(int index)
        {
            Segmentation se = CreateSegmentation(index);
            CountlyEvent ce = new CountlyEvent(v[index], iv[index], dv[index], se);

            Dictionary<String, String> cust = new Dictionary<string, string>();
            cust.Add(v[index + 1], v[index + 2]);
            cust.Add(v[index + 3], v[index + 4]);
            
            return ce;
        }
    }
}
