﻿/**************************************************************************
*                           MIT License
* 
* Copyright (C) 2017 Frederic Chaxel <fchaxel@free.fr>
*
* Permission is hereby granted, free of charge, to any person obtaining
* a copy of this software and associated documentation files (the
* "Software"), to deal in the Software without restriction, including
* without limitation the rights to use, copy, modify, merge, publish,
* distribute, sublicense, and/or sell copies of the Software, and to
* permit persons to whom the Software is furnished to do so, subject to
* the following conditions:
*
* The above copyright notice and this permission notice shall be included
* in all copies or substantial portions of the Software.
*
* THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
* EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
* MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
* IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY
* CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
* TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE
* SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*
*********************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Net.EnIPStack.ObjectsLibrary
{
    public class CIP_Identity_class:CIPObject
    {
        public UInt16? Revision { get; set; }
        public UInt16? Max_Instance { get; set; }
        public byte[] Remain_Undecoded_Bytes { get; set; }

        public override string ToString()
        {
            return "Identity class";
        }
        public override bool SetRawBytes(byte[] b)
        {
            int Idx = 0;

            Revision = GetUInt16(ref Idx, b);
            Max_Instance = GetUInt16(ref Idx, b);

            if (Idx < b.Length)
            {
                Remain_Undecoded_Bytes = new byte[b.Length - Idx];
                Array.Copy(b, Idx, Remain_Undecoded_Bytes, 0, Remain_Undecoded_Bytes.Length);
            }

            return true;   
        }
        // maybe
        public override byte[] GetRawBytes()
        {
            return null;
        }
    }
    public class CIP_Identity_instance : CIPObject
    {
        public UInt16? Vendor_ID { get; set; }
        public UInt16? Device_Type { get; set; }
        public UInt16? Product_Code { get; set; }
        public Byte? Major_Revision { get; set; }
        public Byte? Minor_Revision { get; set; }
        public UInt16? Status { get; set; } // WORD ?
        public UInt32? Serial_Number { get; set; }
        public String Product_Name { get; set; }
        public byte[] Remain_Undecoded_Bytes { get; set; }

        public override string ToString()
        {
            return "Identity instance";
        }

        public override bool SetRawBytes(byte[] b)
        {
            int Idx = 0;

            Vendor_ID = GetUInt16(ref Idx, b);
            Device_Type = GetUInt16(ref Idx, b);
            Product_Code = GetUInt16(ref Idx, b);
            Major_Revision = GetByte(ref Idx, b);
            Minor_Revision = GetByte(ref Idx, b);
            Status = GetUInt16(ref Idx, b);
            Serial_Number = GetUInt32(ref Idx, b);
            Product_Name = GetShortString(ref Idx, b);

            if (Idx < b.Length)
            {
                Remain_Undecoded_Bytes = new byte[b.Length - Idx];
                Array.Copy(b, Idx, Remain_Undecoded_Bytes, 0, Remain_Undecoded_Bytes.Length);
            }
            return true;
        }
        // maybe
        public override byte[] GetRawBytes()
        {

            return null;
        }
    }
}
