﻿using System;
using System.Text;
using Newtonsoft.Json;
using System.IO;
using System.Xml;

namespace ACH_Decomp
{
    class Conversion
    {
        public string filepath { get; set; }
        public int g { get; set; }
        public int PECount { get; set; }
        public int ADCount { get; set; }
        public string SEC { get; set; }
        public string FType { get; set; }
        
        //TODO: XML file is adding the header each time it's appended, that needs to stop!
        //maybe add a method that passes the xw parameter, but wouldn't that result in the same issue?
        //********** ACH CONVERSION START *********//
        public void FHRConv(string p)
        {
            FHR f = new FHR();
            f.RecordTypeCode = p.Substring(0, 1);
            f.PriorityCode = p.Substring(1, 2);
            f.ImmediateDestination = p.Substring(3, 10);
            f.ImmediateOrigin = p.Substring(13, 10);
            f.FileCreationDate = p.Substring(23, 6);
            f.FileCreationTime = p.Substring(29, 4);
            f.FileIDModifier = p.Substring(33, 1);
            f.RecordSize = p.Substring(34, 3);
            f.BlockingFactor = p.Substring(37, 2);
            f.FormatCode = p.Substring(39, 1);
            f.ImmediateDestinationName = p.Substring(40, 23);
            f.ImmediateOriginName = p.Substring(63, 23);
            f.ReferenceCode = p.Substring(86, 8);
            if (g == 1) //JSON
            {
                using (StreamWriter sw = new StreamWriter(filepath))
                {
                    StringBuilder sb = new StringBuilder();
                    StringWriter ssw = new StringWriter(sb);
                    JsonWriter w = new JsonTextWriter(sw);
                    w.Formatting = Newtonsoft.Json.Formatting.Indented;
                    w.WriteStartObject();
                    w.WritePropertyName("FileHeaderRecord");
                    w.WriteStartObject();
                    w.WritePropertyName("RecordTypeCode");
                    w.WriteValue(f.RecordTypeCode);
                    w.WritePropertyName("PriorityCode");
                    w.WriteValue(f.PriorityCode);
                    w.WritePropertyName("ImmediateDestination");
                    w.WriteValue(f.ImmediateDestination);
                    w.WritePropertyName("ImmediateOrigin");
                    w.WriteValue(f.ImmediateOrigin);
                    w.WritePropertyName("FileCreationDate");
                    w.WriteValue(f.FileCreationDate);
                    w.WritePropertyName("FileCreationTime");
                    w.WriteValue(f.FileCreationTime);
                    w.WritePropertyName("FileIDModifier");
                    w.WriteValue(f.FileIDModifier);
                    w.WritePropertyName("RecordSize");
                    w.WriteValue(f.RecordSize);
                    w.WritePropertyName("BlockingFactor");
                    w.WriteValue(f.BlockingFactor);
                    w.WritePropertyName("FormatCode");
                    w.WriteValue(f.FormatCode);
                    w.WritePropertyName("ImmediateDestinationName");
                    w.WriteValue(f.ImmediateDestinationName);
                    w.WritePropertyName("ImmediateOriginName");
                    w.WriteValue(f.ImmediateOriginName);
                    w.WritePropertyName("ReferenceCode");
                    w.WriteValue(f.ReferenceCode);
                    w.WriteEndObject();
                    sw.WriteLine(",");
                }
            } else if (g == 2)
            {
                //XML write
                using (StreamWriter sw = new StreamWriter(filepath))
                {
                    StringBuilder sb = new StringBuilder();
                    StringWriter ssw = new StringWriter(sb);
                    XmlWriterSettings xws = new XmlWriterSettings();
                    xws.Indent = true;
                    XmlWriter xw = XmlWriter.Create(sw, xws);
                    xw.WriteStartElement("FileHeaderRecord");        
                    xw.WriteStartElement("RecordTypeCode", f.RecordTypeCode);
                    xw.WriteEndElement();
                    xw.WriteStartElement("PriorityCode", f.PriorityCode);
                    xw.WriteEndElement();
                    xw.WriteStartElement("ImmediateDestination", f.ImmediateDestination);
                    xw.WriteEndElement();
                    xw.WriteStartElement("ImmediateOrigin", f.ImmediateOrigin);
                    xw.WriteEndElement();
                    xw.WriteStartElement("FileCreationDate", f.FileCreationDate);
                    xw.WriteEndElement();
                    xw.WriteStartElement("FileCreationTime", f.FileCreationTime);
                    xw.WriteEndElement();
                    xw.WriteStartElement("FileIDModifier", f.FileIDModifier);
                    xw.WriteEndElement();
                    xw.WriteStartElement("RecordSize", f.RecordSize);
                    xw.WriteEndElement();
                    xw.WriteStartElement("BlockingFactor", f.BlockingFactor);
                    xw.WriteEndElement();
                    xw.WriteStartElement("FormatCode", f.FormatCode);
                    xw.WriteEndElement();
                    xw.WriteStartElement("ImmediateDestinationName", f.ImmediateDestinationName);
                    xw.WriteEndElement();
                    xw.WriteStartElement("ImmediateOriginName", f.ImmediateOriginName);
                    xw.WriteEndElement();
                    xw.WriteStartElement("ReferenceCode", f.ReferenceCode);
                    xw.WriteEndElement();
                    xw.WriteEndElement();
                    xw.Flush();
                    xw.Close();
                }

            }
        } //xml and json done
        public void BHRConv(string p)
        {
            BHR b = new BHR();
            SEC = p.Substring(50, 3);
            if (SEC == "IAT")
            {
                Console.WriteLine("IAT BHR!!");
                b.RecordTypeCode = p.Substring(0, 1);
                b.ServiceClassCode = p.Substring(1, 3);
                b.IATIndicator = p.Substring(4, 16);
                b.ForeignExchangeIndicator = p.Substring(20, 2);
                b.ForeignExchangeReferenceIndicator = p.Substring(22, 1);
                b.ForeignExchangeReference = p.Substring(23, 15);
                b.ISODestinationCode = p.Substring(38, 2);
                b.OriginiatorIdentification = p.Substring(40, 10);
                b.StandardEntryClassCode = p.Substring(50, 3);
                b.CompanyEntryDescription = p.Substring(53, 10);
                b.ISOOriginatingCurrencyCode = p.Substring(63, 3);
                b.ISODestinationCurrencyCode = p.Substring(66, 3);
                b.EffectiveEntryDate = p.Substring(69, 6);
                b.SettlementDate = p.Substring(75, 3);
                b.OriginatorStatusCode = p.Substring(78, 1);
                b.OriginatingDFIIdentification = p.Substring(79, 8);
                b.BatchNumber = p.Substring(87, 7);
                if(g == 1)
                {
                    using (StreamWriter sw = File.AppendText(filepath))
                    {
                        StringBuilder sb = new StringBuilder();
                        StringWriter ssw = new StringWriter(sb);
                        JsonWriter w = new JsonTextWriter(sw);
                        w.Formatting = Newtonsoft.Json.Formatting.Indented;
                        w.WritePropertyName("BatchHeaderRecord");
                        w.WriteStartObject();
                        w.WritePropertyName("RecordTypeCode");
                        w.WriteValue(b.RecordTypeCode);
                        w.WritePropertyName("ServiceClassCode");
                        w.WriteValue(b.ServiceClassCode);
                        w.WritePropertyName("IATIndicator");
                        w.WriteValue(b.IATIndicator);
                        w.WritePropertyName("ForeignExchangeIndicator");
                        w.WriteValue(b.ForeignExchangeIndicator);
                        w.WritePropertyName("ForeignExchangeReferenceIndicator");
                        w.WriteValue(b.ForeignExchangeReferenceIndicator);
                        w.WritePropertyName("ForeignExchangeReference");
                        w.WriteValue(b.ForeignExchangeReference);
                        w.WritePropertyName("ISODestinationCode");
                        w.WriteValue(b.ISODestinationCode);
                        w.WritePropertyName("OriginatorIdentification");
                        w.WriteValue(b.OriginiatorIdentification);
                        w.WritePropertyName("StandardEntryClassCode");
                        w.WriteValue(b.StandardEntryClassCode);
                        w.WritePropertyName("CompanyEntryDescription");
                        w.WriteValue(b.CompanyEntryDescription);
                        w.WritePropertyName("ISOOriginatingCurrencyCode");
                        w.WriteValue(b.ISOOriginatingCurrencyCode);
                        w.WritePropertyName("ISODestinationCurrencyCode");
                        w.WriteValue(b.ISODestinationCurrencyCode);
                        w.WritePropertyName("EffectiveEntryDate");
                        w.WriteValue(b.EffectiveEntryDate);
                        w.WritePropertyName("SettlementDate");
                        w.WriteValue(b.SettlementDate);
                        w.WritePropertyName("OriginatorStatusCode");
                        w.WriteValue(b.OriginatorStatusCode);
                        w.WritePropertyName("OriginatingDFIIdentification");
                        w.WriteValue(b.OriginatingDFIIdentification);
                        w.WritePropertyName("BatchNumber");
                        w.WriteValue(b.BatchNumber);
                        w.WriteEndObject();
                        sw.WriteLine(",");
                        sw.WriteLine(sb.ToString());
                        sw.Close();
                    }
                } else if(g == 2)
                {
                    using (StreamWriter sw = File.AppendText(filepath))
                    {
                        StringBuilder sb = new StringBuilder();
                        StringWriter ssw = new StringWriter(sb);
                        XmlWriterSettings xws = new XmlWriterSettings();
                        xws.Indent = true;
                        XmlWriter xw = XmlWriter.Create(sw, xws);
                        xw.WriteStartElement("BatchHeaderRecord");
                        xw.WriteStartElement("RecordTypeCode", b.RecordTypeCode);
                        xw.WriteEndElement();
                        xw.WriteStartElement("ServiceClassCode", b.ServiceClassCode);
                        xw.WriteEndElement();
                        xw.WriteStartElement("IATIndicator", b.IATIndicator);
                        xw.WriteEndElement();
                        xw.WriteStartElement("ForeignExchangeIndicator", b.ForeignExchangeIndicator);
                        xw.WriteEndElement();
                        xw.WriteStartElement("ForeignExchangeReferenceIndicator", b.ForeignExchangeReferenceIndicator);
                        xw.WriteEndElement();
                        xw.WriteStartElement("ForeignExchangeReference", b.ForeignExchangeReference);
                        xw.WriteEndElement();
                        xw.WriteStartElement("ISODestinationCode", b.ISODestinationCode);
                        xw.WriteEndElement();
                        xw.WriteStartElement("OriginatorIdentification", b.OriginiatorIdentification);
                        xw.WriteEndElement();
                        xw.WriteStartElement("StandardEntryClassCode", b.StandardEntryClassCode);
                        xw.WriteEndElement();
                        xw.WriteStartElement("CompanyEntryDescription", b.CompanyEntryDescription);
                        xw.WriteEndElement();
                        xw.WriteStartElement("ISOOriginatingCurrencyCode", b.ISOOriginatingCurrencyCode);
                        xw.WriteEndElement();
                        xw.WriteStartElement("ISODestinationCurrencyCode", b.ISODestinationCurrencyCode);
                        xw.WriteEndElement();
                        xw.WriteStartElement("EffectiveEntryDate", b.EffectiveEntryDate);
                        xw.WriteEndElement();
                        xw.WriteStartElement("SettlementDate", b.SettlementDate);
                        xw.WriteEndElement();
                        xw.WriteStartElement("OriginatorStatusCode", b.OriginatorStatusCode);
                        xw.WriteEndElement();
                        xw.WriteStartElement("OriginatingDFIIdentification", b.OriginatingDFIIdentification);
                        xw.WriteEndElement();
                        xw.WriteStartElement("BatchNumber", b.BatchNumber);
                        xw.WriteEndElement();
                        xw.WriteEndElement();
                        xw.Close();
                    }
                }
            }
            else
            {
                Console.WriteLine("Normal BHR!!");
                Console.WriteLine(g);
                b.RecordTypeCode = p.Substring(0, 1);
                b.ServiceClassCode = p.Substring(1, 3);
                b.CompanyName = p.Substring(4, 16);
                b.CompanyDiscretionaryData = p.Substring(20, 20);
                b.CompanyIdentification = p.Substring(40, 10);
                b.StandardEntryClassCode = p.Substring(50, 3);
                b.CompanyEntryDescription = p.Substring(53, 10);
                b.CompanyDescriptiveDate = p.Substring(63, 6);
                b.EffectiveEntryDate = p.Substring(69, 6);
                b.SettlementDate = p.Substring(75, 3);
                b.OriginatorStatusCode = p.Substring(78, 1);
                b.OriginatingDFIIdentification = p.Substring(79, 8);
                b.BatchNumber = p.Substring(87, 7);
                if (g == 1)
                {
                    using (StreamWriter sw = File.AppendText(filepath))
                    {
                        StringBuilder sb = new StringBuilder();
                        StringWriter ssw = new StringWriter(sb);
                        JsonWriter w = new JsonTextWriter(sw);
                        w.Formatting = Newtonsoft.Json.Formatting.Indented;
                        w.WritePropertyName("BatchHeaderRecord");
                        w.WriteStartObject();
                        w.WritePropertyName("RecordTypeCode");
                        w.WriteValue(b.RecordTypeCode);
                        w.WritePropertyName("ServiceClassCode");
                        w.WriteValue(b.ServiceClassCode);
                        w.WritePropertyName("CompanyName");
                        w.WriteValue(b.CompanyName);
                        w.WritePropertyName("CompanyDiscretionaryData");
                        w.WriteValue(b.CompanyDiscretionaryData);
                        w.WritePropertyName("CompanyIdentification");
                        w.WriteValue(b.CompanyIdentification);
                        w.WritePropertyName("StandardEntryClassCode");
                        w.WriteValue(b.StandardEntryClassCode);
                        w.WritePropertyName("CompanyEntryDescription");
                        w.WriteValue(b.CompanyEntryDescription);
                        w.WritePropertyName("CompanyDescriptiveDate");
                        w.WriteValue(b.CompanyDescriptiveDate);
                        w.WritePropertyName("EffectiveEntryDate");
                        w.WriteValue(b.EffectiveEntryDate);
                        w.WritePropertyName("SettlementDate");
                        w.WriteValue(b.SettlementDate);
                        w.WritePropertyName("OriginatorStatusCode");
                        w.WriteValue(b.OriginatorStatusCode);
                        w.WritePropertyName("OriginatingDFIIdentification");
                        w.WriteValue(b.OriginatingDFIIdentification);
                        w.WritePropertyName("BatchNumber");
                        w.WriteValue(b.BatchNumber);
                        w.WriteEndObject();
                        sw.WriteLine(",");
                        sw.WriteLine(sb.ToString());
                        sw.Close();
                    }
                } else if(g == 2)
                {
                    using (StreamWriter sw = File.AppendText(filepath))
                    {
                        StringBuilder sb = new StringBuilder();
                        StringWriter ssw = new StringWriter(sb);
                        XmlWriterSettings xws = new XmlWriterSettings();
                        xws.Indent = true;
                        XmlWriter xw = XmlWriter.Create(sw, xws);
                        xw.WriteStartElement("BatchHeaderRecord");
                        xw.WriteStartElement("RecordTypeCode", b.RecordTypeCode);
                        xw.WriteEndElement();
                        xw.WriteStartElement("ServiceClassCode", b.ServiceClassCode);
                        xw.WriteEndElement();
                        xw.WriteStartElement("CompanyName", b.CompanyName);
                        xw.WriteEndElement();
                        xw.WriteStartElement("CompanyDiscretionaryData", b.CompanyDiscretionaryData);
                        xw.WriteEndElement();
                        xw.WriteStartElement("CompanyIdentification", b.CompanyIdentification);
                        xw.WriteEndElement();
                        xw.WriteStartElement("StandardEntryClassCode", b.StandardEntryClassCode);
                        xw.WriteEndElement();
                        xw.WriteStartElement("CompanyEntryDescription", b.CompanyEntryDescription);
                        xw.WriteEndElement();
                        xw.WriteStartElement("CompanyDescriptiveDate", b.CompanyDescriptiveDate);
                        xw.WriteEndElement();
                        xw.WriteStartElement("EffectiveEntryDate", b.EffectiveEntryDate);
                        xw.WriteEndElement();
                        xw.WriteStartElement("SettlementDate", b.SettlementDate);
                        xw.WriteEndElement();
                        xw.WriteStartElement("OriginatorStatusCode", b.OriginatorStatusCode);
                        xw.WriteEndElement();
                        xw.WriteStartElement("OriginatingDFIIdentification", b.OriginatingDFIIdentification);
                        xw.WriteEndElement();
                        xw.WriteStartElement("BatchNumber", b.BatchNumber);
                        xw.WriteEndElement();
                        xw.WriteEndElement();
                        xw.Close();
                    }
                }
            }
            
        } //xml and json done
        public void SECCheck(string p)
        {
            switch (SEC)
            {
                case "CTX":
                    CTXConv(p);
                    break;
                case "CCD":
                    CCDConv(p);
                    break;
                case "PPD":
                    PPDConv(p);
                    break;
                case "TEL":
                    TELConv(p);
                    break;
                case "WEB":
                    WEBConv(p);
                    break;
                case "IAT":
                    IATConv(p); //handle the addenda differently too...
                    break;
                default:
                    Console.WriteLine("unknown sec");
                    break;
            }
        } //done
        public void PPDConv(string p)
        {
            PPD d = new PPD();
            d.RecordTypeCode = p.Substring(0, 1);
            d.TransactionCode = p.Substring(1, 2);
            d.ReceivingDFIIdentification = p.Substring(3, 8);
            d.CheckDigit = p.Substring(11, 1);
            d.DFIAccountNumber = p.Substring(12, 17);
            d.Amount = p.Substring(29, 10);
            d.IndividualIdentificationNumber = p.Substring(39, 15);
            d.IndividualName = p.Substring(54, 22);
            d.DiscretionaryData = p.Substring(76, 2);
            d.AddendaRecordIndicator = p.Substring(78, 1);
            d.TraceNumber = p.Substring(79, 15);
            if (g == 1)
            {
                using (StreamWriter sw = File.AppendText(filepath))
                {
                    StringBuilder sb = new StringBuilder();
                    StringWriter ssw = new StringWriter(sb);
                    JsonWriter w = new JsonTextWriter(sw);
                    w.Formatting = Newtonsoft.Json.Formatting.Indented;
                    w.WritePropertyName("PPD_" + PECount);
                    w.WriteStartObject();
                    w.WritePropertyName("RecordTypeCode");
                    w.WriteValue(d.RecordTypeCode);
                    w.WritePropertyName("TransactionCode");
                    w.WriteValue(d.TransactionCode);
                    w.WritePropertyName("ReceivingDFIIdentification");
                    w.WriteValue(d.ReceivingDFIIdentification);
                    w.WritePropertyName("CheckDigit");
                    w.WriteValue(d.CheckDigit);
                    w.WritePropertyName("DFIAccountNumber");
                    w.WriteValue(d.DFIAccountNumber);
                    w.WritePropertyName("Amount");
                    w.WriteValue(d.Amount);
                    w.WritePropertyName("IndividualIdentificationNumber");
                    w.WriteValue(d.IndividualIdentificationNumber);
                    w.WritePropertyName("IndividualName");
                    w.WriteValue(d.IndividualName);
                    w.WritePropertyName("DiscretionaryData");
                    w.WriteValue(d.DiscretionaryData);
                    w.WritePropertyName("AddendaRecordIndicator");
                    w.WriteValue(d.AddendaRecordIndicator);
                    w.WritePropertyName("TraceNumber");
                    w.WriteValue(d.TraceNumber);
                    w.WriteEndObject();
                    sw.WriteLine(",");
                    sw.WriteLine(sb.ToString());
                    sw.Close();
                }
            } else if(g == 2)
            {
                using (StreamWriter sw = File.AppendText(filepath))
                {
                    StringBuilder sb = new StringBuilder();
                    StringWriter ssw = new StringWriter(sb);
                    XmlWriterSettings xws = new XmlWriterSettings();
                    xws.Indent = true;
                    XmlWriter xw = XmlWriter.Create(sw, xws);
                    xw.WriteStartElement("PPD_" + PECount);
                    xw.WriteStartElement("RecordTypeCode", d.RecordTypeCode);
                    xw.WriteEndElement();
                    xw.WriteStartElement("TransactionCode", d.TransactionCode);
                    xw.WriteEndElement();
                    xw.WriteStartElement("ReceivingDFIIdentification", d.ReceivingDFIIdentification);
                    xw.WriteEndElement();
                    xw.WriteStartElement("CheckDigit", d.CheckDigit);
                    xw.WriteEndElement();
                    xw.WriteStartElement("DFIAccountNumber", d.DFIAccountNumber);
                    xw.WriteEndElement();
                    xw.WriteStartElement("Amount", d.Amount);
                    xw.WriteEndElement();
                    xw.WriteStartElement("IndividualIdentificationNumber", d.IndividualIdentificationNumber);
                    xw.WriteEndElement();
                    xw.WriteStartElement("IndividualName", d.IndividualName);
                    xw.WriteEndElement();
                    xw.WriteStartElement("DiscretionaryData", d.DiscretionaryData);
                    xw.WriteEndElement();
                    xw.WriteStartElement("AddendaRecordIndicator", d.AddendaRecordIndicator);
                    xw.WriteEndElement();
                    xw.WriteStartElement("TraceNumber", d.TraceNumber);
                    xw.WriteEndElement();
                    xw.WriteEndElement();
                    xw.Close();
                }

            }
        } //xml and json done
        public void CTXConv(string p)
        {
            CTX c = new CTX();
            c.RecordTypeCode = p.Substring(0, 1);
            c.TransactionCode = p.Substring(1, 2);
            c.ReceivingDFIIdentification = p.Substring(3, 8);
            c.CheckDigit = p.Substring(11, 1);
            c.DFIAccountNumber = p.Substring(12, 17);
            c.TotalAmount = p.Substring(29, 10);
            c.IdentificationNumber = p.Substring(39, 15);
            c.NumberOfAddendaRecords = p.Substring(54, 4);
            c.ReceivingCompanyName = p.Substring(58, 16);
            c.Reserved = p.Substring(74, 2);
            c.DiscretionaryData = p.Substring(76, 2);
            c.AddendaRecordIndicator = p.Substring(78, 1);
            c.TraceNumber = p.Substring(79, 15);
            if (g == 1)
            {
                using (StreamWriter sw = File.AppendText(filepath))
                {
                    StringBuilder sb = new StringBuilder();
                    StringWriter ssw = new StringWriter(sb);
                    JsonWriter w = new JsonTextWriter(sw);
                    w.Formatting = Newtonsoft.Json.Formatting.Indented;
                    w.WritePropertyName("CTX_" + PECount);
                    w.WriteStartObject();
                    w.WritePropertyName("RecordTypeCode");
                    w.WriteValue(c.RecordTypeCode);
                    w.WritePropertyName("TransactionCode");
                    w.WriteValue(c.TransactionCode);
                    w.WritePropertyName("ReceivingDFIIdentification");
                    w.WriteValue(c.ReceivingDFIIdentification);
                    w.WritePropertyName("CheckDigit");
                    w.WriteValue(c.CheckDigit);
                    w.WritePropertyName("DFIAccountNumber");
                    w.WriteValue(c.DFIAccountNumber);
                    w.WritePropertyName("TotalAmount");
                    w.WriteValue(c.TotalAmount);
                    w.WritePropertyName("IdentificationNumber");
                    w.WriteValue(c.IdentificationNumber);
                    w.WritePropertyName("NumberOfAddendaRecords");
                    w.WriteValue(c.NumberOfAddendaRecords);
                    w.WritePropertyName("ReceivingCompanyName");
                    w.WriteValue(c.ReceivingCompanyName);
                    w.WritePropertyName("Reserved");
                    w.WriteValue(c.Reserved);
                    w.WritePropertyName("DiscretionaryData");
                    w.WriteValue(c.DiscretionaryData);
                    w.WritePropertyName("AddendaRecordIndicator");
                    w.WriteValue(c.AddendaRecordIndicator);
                    w.WritePropertyName("TraceNumber");
                    w.WriteValue(c.TraceNumber);
                    w.WriteEndObject();
                    sw.WriteLine(sb.ToString());
                    sw.Close();
                }
            }
        } //json done
        public void CCDConv(string p)
        {
            CCD c = new CCD();
            c.RecordTypeCode = p.Substring(0, 1);
            c.TransactionCode = p.Substring(1, 2);
            c.ReceivingDFIIdentification = p.Substring(3, 8);
            c.CheckDigit = p.Substring(11, 1);
            c.DFIAccountNumber = p.Substring(12, 17);
            c.Amount = p.Substring(29, 10);
            c.IdentificationNumber = p.Substring(39, 15);
            c.ReceivingCompanyName = p.Substring(54, 22);
            c.DiscretionaryData = p.Substring(76, 2);
            c.AddendaRecordIndicator = p.Substring(78, 1);
            c.TraceNumber = p.Substring(79, 15);
            if (g == 1)
            {
                using (StreamWriter sw = File.AppendText(filepath))
                {
                    StringBuilder sb = new StringBuilder();
                    StringWriter ssw = new StringWriter(sb);
                    JsonWriter w = new JsonTextWriter(sw);
                    w.Formatting = Newtonsoft.Json.Formatting.Indented;
                    w.WritePropertyName("CCD_" + PECount);
                    w.WriteStartObject();
                    w.WritePropertyName("RecordTypeCode");
                    w.WriteValue(c.RecordTypeCode);
                    w.WritePropertyName("TransactionCode");
                    w.WriteValue(c.TransactionCode);
                    w.WritePropertyName("ReceivingDFIIdentification");
                    w.WriteValue(c.ReceivingDFIIdentification);
                    w.WritePropertyName("CheckDigit");
                    w.WriteValue(c.CheckDigit);
                    w.WritePropertyName("DFIAccountNumber");
                    w.WriteValue(c.DFIAccountNumber);
                    w.WritePropertyName("Amount");
                    w.WriteValue(c.Amount);
                    w.WritePropertyName("IdentificationNumber");
                    w.WriteValue(c.IdentificationNumber);
                    w.WritePropertyName("ReceivingCompanyName");
                    w.WriteValue(c.ReceivingCompanyName);
                    w.WritePropertyName("DiscretionaryData");
                    w.WriteValue(c.DiscretionaryData);
                    w.WritePropertyName("AddendaRecordIndicator");
                    w.WriteValue(c.AddendaRecordIndicator);
                    w.WritePropertyName("TraceNumber");
                    w.WriteValue(c.TraceNumber);
                    w.WriteEndObject();
                    sw.WriteLine(sb.ToString());
                    sw.Close();
                }
            }
        } //json done
        public void TELConv(string p)
        {
            TEL t = new TEL();
            t.RecordTypeCode = p.Substring(0, 1);
            t.TransactionCode = p.Substring(1, 2);
            t.ReceivingDFIIdentification = p.Substring(3, 8);
            t.CheckDigit = p.Substring(11, 1);
            t.DFIAccountNumber = p.Substring(12, 17);
            t.Amount = p.Substring(29, 10);
            t.IndividualIdentificationNumber = p.Substring(39, 15);
            t.IndividualName = p.Substring(54, 22);
            t.DiscretionaryData = p.Substring(76, 2);
            t.AddendaRecordIndicator = p.Substring(78, 1);
            t.TraceNumber = p.Substring(79, 15);
            if (g == 1)
            {
                using (StreamWriter sw = File.AppendText(filepath))
                {
                    StringBuilder sb = new StringBuilder();
                    StringWriter ssw = new StringWriter(sb);
                    JsonWriter w = new JsonTextWriter(sw);
                    w.Formatting = Newtonsoft.Json.Formatting.Indented;
                    w.WritePropertyName("TEL_" + PECount);
                    w.WriteStartObject();
                    w.WritePropertyName("RecordTypeCode");
                    w.WriteValue(t.RecordTypeCode);
                    w.WritePropertyName("TransactionCode");
                    w.WriteValue(t.TransactionCode);
                    w.WritePropertyName("ReceivingDFIIdentification");
                    w.WriteValue(t.ReceivingDFIIdentification);
                    w.WritePropertyName("CheckDigit");
                    w.WriteValue(t.CheckDigit);
                    w.WritePropertyName("DFIAccountNumber");
                    w.WriteValue(t.DFIAccountNumber);
                    w.WritePropertyName("Amount");
                    w.WriteValue(t.Amount);
                    w.WritePropertyName("IndividualIdentificationNumber");
                    w.WriteValue(t.IndividualIdentificationNumber);
                    w.WritePropertyName("IndividualName");
                    w.WriteValue(t.IndividualName);
                    w.WritePropertyName("DiscretionaryData");
                    w.WriteValue(t.DiscretionaryData);
                    w.WritePropertyName("AddendaRecordIndicator");
                    w.WriteValue(t.AddendaRecordIndicator);
                    w.WritePropertyName("TraceNumber");
                    w.WriteValue(t.TraceNumber);
                    w.WriteEndObject();
                    sw.WriteLine(sb.ToString());
                    sw.Close();
                }
            }
        } //json done
        public void WEBConv(string p)
        {
            WEB e = new WEB();
            e.RecordTypeCode = p.Substring(0, 1);
            e.TransactionCode = p.Substring(1, 2);
            e.ReceivingDFIIdentification = p.Substring(3, 8);
            e.CheckDigit = p.Substring(11, 1);
            e.DFIAccountNumber = p.Substring(12, 17);
            e.Amount = p.Substring(29, 10);
            e.IndividualIdentificationNumber = p.Substring(39, 15);
            e.IndividualName = p.Substring(54, 22);
            e.PaymentTypeCode = p.Substring(76, 2);
            e.AddendaRecordIndicator = p.Substring(78, 1);
            e.TraceNumber = p.Substring(79, 15);
            if (g == 1)
            {
                using (StreamWriter sw = File.AppendText(filepath))
                {
                    StringBuilder sb = new StringBuilder();
                    StringWriter ssw = new StringWriter(sb);
                    JsonWriter w = new JsonTextWriter(sw);
                    w.Formatting = Newtonsoft.Json.Formatting.Indented;
                    w.WritePropertyName("WEB_" + PECount);
                    w.WriteStartObject();
                    w.WritePropertyName("RecordTypeCode");
                    w.WriteValue(e.RecordTypeCode);
                    w.WritePropertyName("TransactionCode");
                    w.WriteValue(e.TransactionCode);
                    w.WritePropertyName("ReceivingDFIIdentification");
                    w.WriteValue(e.ReceivingDFIIdentification);
                    w.WritePropertyName("CheckDigit");
                    w.WriteValue(e.CheckDigit);
                    w.WritePropertyName("DFIAccountNumber");
                    w.WriteValue(e.DFIAccountNumber);
                    w.WritePropertyName("Amount");
                    w.WriteValue(e.Amount);
                    w.WritePropertyName("IndividualIdentificationNumber");
                    w.WriteValue(e.IndividualIdentificationNumber);
                    w.WritePropertyName("IndividualName");
                    w.WriteValue(e.IndividualName);
                    w.WritePropertyName("PaymentTypeCode");
                    w.WriteValue(e.PaymentTypeCode);
                    w.WritePropertyName("AddendaRecordIndicator");
                    w.WriteValue(e.AddendaRecordIndicator);
                    w.WritePropertyName("TraceNumber");
                    w.WriteValue(e.TraceNumber);
                    w.WriteEndObject();
                    sw.WriteLine(sb.ToString());
                    sw.Close();
                }
            }
        } //json done
        public void IATConv(string p)
        {
            IAT i = new IAT();
            i.RecordTypeCode = p.Substring(0, 1);
            i.TransactionCode = p.Substring(1, 2);
            i.ReceivingDFIIdentification = p.Substring(3, 8);
            i.CheckDigit = p.Substring(11, 1);
            i.NumberOfAddendaRecords = p.Substring(12, 4);
            i.Reserved = p.Substring(16, 13);
            i.Amount = p.Substring(29, 10);
            i.ForeignReceiverAcct = p.Substring(39, 35);
            i.Reserved2 = p.Substring(74, 2);
            i.GatewayOperator = p.Substring(76, 1);
            i.SecondaryOFAC = p.Substring(77, 1);
            i.AddendaRecordIndicator = p.Substring(78, 1);
            i.TraceNumber = p.Substring(79, 15);
            if(g == 1)
            {
                using (StreamWriter sw = File.AppendText(filepath))
                {
                    StringBuilder sb = new StringBuilder();
                    StringWriter ssw = new StringWriter(sb);
                    JsonWriter w = new JsonTextWriter(sw);
                    w.Formatting = Newtonsoft.Json.Formatting.Indented;
                    w.WritePropertyName("IAT_" + PECount);
                    w.WriteStartObject();
                    w.WritePropertyName("RecordTypeCode");
                    w.WriteValue(i.RecordTypeCode);
                    w.WritePropertyName("TransactionCode");
                    w.WriteValue(i.TransactionCode);
                    w.WritePropertyName("ReceivingDFIIdentification");
                    w.WriteValue(i.ReceivingDFIIdentification);
                    w.WritePropertyName("CheckDigit");
                    w.WriteValue(i.CheckDigit);
                    w.WritePropertyName("NumberOfAddendaRecords");
                    w.WriteValue(i.NumberOfAddendaRecords);
                    w.WritePropertyName("Reserved");
                    w.WriteValue(i.Reserved);
                    w.WritePropertyName("Amount");
                    w.WriteValue(i.Amount);
                    w.WritePropertyName("ForeignReceiverAccount");
                    w.WriteValue(i.ForeignReceiverAcct);
                    w.WritePropertyName("Reserved_2");
                    w.WriteValue(i.Reserved2);
                    w.WritePropertyName("GatewayOperator");
                    w.WriteValue(i.GatewayOperator);
                    w.WritePropertyName("SecondaryOFAC");
                    w.WriteValue(i.SecondaryOFAC);
                    w.WritePropertyName("AddendaRecordIndicator");
                    w.WriteValue(i.AddendaRecordIndicator);
                    w.WritePropertyName("TraceNumber");
                    w.WriteValue(i.TraceNumber);
                    w.WriteEndObject();
                    sw.WriteLine(sb.ToString());
                    sw.Close();
                }
            } else if(g == 2)
            {
                using (StreamWriter sw = File.AppendText(filepath))
                {
                    StringBuilder sb = new StringBuilder();
                    StringWriter ssw = new StringWriter(sb);
                    XmlWriterSettings xws = new XmlWriterSettings();
                    xws.Indent = true;
                    XmlWriter xw = XmlWriter.Create(sw, xws);
                    xw.WriteStartElement("IAT_" + PECount);
                    xw.WriteStartElement("RecordTypeCode", i.RecordTypeCode);
                    xw.WriteEndElement();
                    xw.WriteStartElement("TransactionCode", i.TransactionCode);
                    xw.WriteEndElement();
                    xw.WriteStartElement("ReceivingDFIIdentification", i.ReceivingDFIIdentification);
                    xw.WriteEndElement();
                    xw.WriteStartElement("CheckDigit", i.CheckDigit);
                    xw.WriteEndElement();
                    xw.WriteStartElement("NumberOfAddendaRecords", i.NumberOfAddendaRecords);
                    xw.WriteEndElement();
                    xw.WriteStartElement("Reserved", i.Reserved);
                    xw.WriteEndElement();
                    xw.WriteStartElement("Amount", i.Amount);
                    xw.WriteEndElement();
                    xw.WriteStartElement("ForeignReceiverAccount", i.ForeignReceiverAcct);
                    xw.WriteEndElement();
                    xw.WriteStartElement("Reserved_2", i.Reserved2);
                    xw.WriteEndElement();
                    xw.WriteStartElement("GatewayOperator", i.GatewayOperator);
                    xw.WriteEndElement();
                    xw.WriteStartElement("SecondaryOFAC", i.SecondaryOFAC);
                    xw.WriteEndElement();
                    xw.WriteStartElement("AddendaRecordIndicator", i.AddendaRecordIndicator);
                    xw.WriteEndElement();
                    xw.WriteStartElement("TraceNumber", i.TraceNumber);
                    xw.WriteEndElement();
                    xw.WriteEndElement();
                    xw.Close();
                }
            }
        } //xml and json done
        public void ARConv(string p)
        {
            Addenda a = new Addenda();
            string ATC = p.Substring(1, 2);
            if (SEC == "IAT")
            {
                switch (ATC)
                {
                    case "10":
                        a.RecordTypeCode = p.Substring(0, 1);
                        a.AddendaTypeCode = p.Substring(1, 2);
                        a.TransactionTypeCode = p.Substring(3, 3);
                        a.ForeignPaymentAmount = p.Substring(6, 18);
                        a.ForeignTraceNumber = p.Substring(24, 22);
                        a.ReceivingCompanyName = p.Substring(46, 35);
                        a.Reserved = p.Substring(81, 6);
                        a.EntryDetailSequenceNumber = p.Substring(87, 7);
                        if (g == 1)
                        {
                            using (StreamWriter sw = File.AppendText(filepath))
                            {
                                StringBuilder sb = new StringBuilder();
                                StringWriter ssw = new StringWriter(sb);
                                JsonWriter w = new JsonTextWriter(sw);
                                w.Formatting = Newtonsoft.Json.Formatting.Indented;
                                w.WritePropertyName("Addenda_" + ADCount);
                                w.WriteStartObject();
                                w.WritePropertyName("RecordTypeCode");
                                w.WriteValue(a.RecordTypeCode);
                                w.WritePropertyName("AddendaTypeCode");
                                w.WriteValue(a.AddendaTypeCode);
                                w.WritePropertyName("TransactionTypeCode");
                                w.WriteValue(a.TransactionTypeCode);
                                w.WritePropertyName("ForeignPaymentAmount");
                                w.WriteValue(a.ForeignPaymentAmount);
                                w.WritePropertyName("ForeignTraceNumber");
                                w.WriteValue(a.ForeignTraceNumber);
                                w.WritePropertyName("ReceivingCompanyName");
                                w.WriteValue(a.ReceivingCompanyName);
                                w.WritePropertyName("Reserved");
                                w.WriteValue(a.Reserved);
                                w.WritePropertyName("EntryDetailSequenceNumber");
                                w.WriteValue(a.EntryDetailSequenceNumber);
                                w.WriteEndObject();
                                sw.WriteLine(",");
                                sw.WriteLine(sb.ToString());
                                sw.Close();
                            }
                        } else if(g == 2)
                        {
                            using (StreamWriter sw = File.AppendText(filepath))
                            {
                                StringBuilder sb = new StringBuilder();
                                StringWriter ssw = new StringWriter(sb);
                                XmlWriterSettings xws = new XmlWriterSettings();
                                xws.Indent = true;
                                XmlWriter xw = XmlWriter.Create(sw, xws);
                                xw.WriteStartElement("Addenda_" + ADCount);
                                xw.WriteStartElement("RecordTypeCode", a.RecordTypeCode);
                                xw.WriteEndElement();
                                xw.WriteStartElement("TransactionTypeCode", a.TransactionTypeCode);
                                xw.WriteEndElement();
                                xw.WriteStartElement("ForeignPaymentAmount", a.ForeignPaymentAmount);
                                xw.WriteEndElement();
                                xw.WriteStartElement("ForeignTraceNumber", a.ForeignTraceNumber);
                                xw.WriteEndElement();
                                xw.WriteStartElement("ReceivingCompanyName", a.ReceivingCompanyName);
                                xw.WriteEndElement();
                                xw.WriteStartElement("Reserved", a.Reserved);
                                xw.WriteEndElement();
                                xw.WriteStartElement("EntryDetailSequenceNumber", a.EntryDetailSequenceNumber);
                                xw.WriteEndElement();
                                xw.WriteEndElement();
                                xw.Close();
                            }
                        }
                        break;
                    case "11":
                        a.RecordTypeCode = p.Substring(0, 1);
                        a.AddendaTypeCode = p.Substring(1, 2);
                        a.OriginatorName = p.Substring(3, 35);
                        a.OriginatorStreetAddress = p.Substring(38, 35);
                        a.Reserved = p.Substring(73, 14);
                        a.EntryDetailSequenceNumber = p.Substring(87, 7);
                        if (g == 1)
                        {
                            using (StreamWriter sw = File.AppendText(filepath))
                            {
                                StringBuilder sb = new StringBuilder();
                                StringWriter ssw = new StringWriter(sb);
                                JsonWriter w = new JsonTextWriter(sw);
                                w.Formatting = Newtonsoft.Json.Formatting.Indented;
                                w.WritePropertyName("Addenda_" + ADCount);
                                w.WriteStartObject();
                                w.WritePropertyName("RecordTypeCode");
                                w.WriteValue(a.RecordTypeCode);
                                w.WritePropertyName("AddendaTypeCode");
                                w.WriteValue(a.AddendaTypeCode);
                                w.WritePropertyName("OriginatorName");
                                w.WriteValue(a.OriginatorName);
                                w.WritePropertyName("OriginatorStreetAddress");
                                w.WriteValue(a.OriginatorStreetAddress);
                                w.WritePropertyName("Reserved");
                                w.WriteValue(a.Reserved);
                                w.WritePropertyName("EntryDetailSequenceNumber");
                                w.WriteValue(a.EntryDetailSequenceNumber);
                                w.WriteEndObject();
                                sw.WriteLine(",");
                                sw.WriteLine(sb.ToString());
                                sw.Close();
                            }

                        } else if(g == 2)
                        {
                            using (StreamWriter sw = File.AppendText(filepath))
                            {
                                StringBuilder sb = new StringBuilder();
                                StringWriter ssw = new StringWriter(sb);
                                XmlWriterSettings xws = new XmlWriterSettings();
                                xws.Indent = true;
                                XmlWriter xw = XmlWriter.Create(sw, xws);
                                xw.WriteStartElement("Addenda_" + ADCount);
                                xw.WriteStartElement("RecordTypeCode", a.RecordTypeCode);
                                xw.WriteEndElement();
                                xw.WriteStartElement("AddendaTypeCode", a.AddendaTypeCode);
                                xw.WriteEndElement();
                                xw.WriteStartElement("OriginatorName", a.OriginatorName);
                                xw.WriteEndElement();
                                xw.WriteStartElement("OriginatorStreetAddress", a.OriginatorStreetAddress);
                                xw.WriteEndElement();
                                xw.WriteStartElement("Reserved", a.Reserved);
                                xw.WriteEndElement();
                                xw.WriteStartElement("EntryDetailSequenceNumber", a.EntryDetailSequenceNumber);
                                xw.WriteEndElement();
                                xw.WriteEndElement();
                                xw.Close();
                            }

                        }
                        break;
                    case "12":
                        a.RecordTypeCode = p.Substring(0, 1);
                        a.AddendaTypeCode = p.Substring(1, 2);
                        a.OriginatorCityStateProvince = p.Substring(3, 35);
                        a.OriginatorCountryPostalCode = p.Substring(38, 35);
                        a.Reserved = p.Substring(73, 14);
                        a.EntryDetailSequenceNumber = p.Substring(87, 7);
                        if (g == 1)
                        {
                            using (StreamWriter sw = File.AppendText(filepath))
                            {
                                StringBuilder sb = new StringBuilder();
                                StringWriter ssw = new StringWriter(sb);
                                JsonWriter w = new JsonTextWriter(sw);
                                w.Formatting = Newtonsoft.Json.Formatting.Indented;
                                w.WritePropertyName("Addenda_" + ADCount);
                                w.WriteStartObject();
                                w.WritePropertyName("RecordTypeCode");
                                w.WriteValue(a.RecordTypeCode);
                                w.WritePropertyName("AddendaTypeCode");
                                w.WriteValue(a.AddendaTypeCode);
                                w.WritePropertyName("OriginatorCityStateProvince");
                                w.WriteValue(a.OriginatorCityStateProvince);
                                w.WritePropertyName("OriginatorCountryPostalCode");
                                w.WriteValue(a.OriginatorCountryPostalCode);
                                w.WritePropertyName("Reserved");
                                w.WriteValue(a.Reserved);
                                w.WritePropertyName("EntryDetailSequenceNumber");
                                w.WriteValue(a.EntryDetailSequenceNumber);
                                w.WriteEndObject();
                                sw.WriteLine(",");
                                sw.WriteLine(sb.ToString());
                                sw.Close();
                            }

                        } else if(g == 2)
                        {
                            using (StreamWriter sw = File.AppendText(filepath))
                            {
                                StringBuilder sb = new StringBuilder();
                                StringWriter ssw = new StringWriter(sb);
                                XmlWriterSettings xws = new XmlWriterSettings();
                                xws.Indent = true;
                                XmlWriter xw = XmlWriter.Create(sw, xws);
                                xw.WriteStartElement("Addenda_" + ADCount);
                                xw.WriteStartElement("RecordTypeCode", a.RecordTypeCode);
                                xw.WriteEndElement();
                                xw.WriteStartElement("AddendaTypeCode", a.AddendaTypeCode);
                                xw.WriteEndElement();
                                xw.WriteStartElement("OriginatorCityStateProvince", a.OriginatorCityStateProvince);
                                xw.WriteEndElement();
                                xw.WriteStartElement("OriginatorCountryPostalCode", a.OriginatorCountryPostalCode);
                                xw.WriteEndElement();
                                xw.WriteStartElement("Reserved", a.Reserved);
                                xw.WriteEndElement();
                                xw.WriteStartElement("EntryDetailSequenceNumber", a.EntryDetailSequenceNumber);
                                xw.WriteEndElement();
                                xw.WriteEndElement();
                                xw.Close();
                            }

                        }
                        break;
                    case "13":
                        a.RecordTypeCode = p.Substring(0, 1);
                        a.AddendaTypeCode = p.Substring(1, 2);
                        a.OriginatingDFIName = p.Substring(3, 35);
                        a.OriginatingDFIIDNumber = p.Substring(38, 2);
                        a.OriginatingDFIIdentification = p.Substring(40, 34);
                        a.OriginatingDFIBranch = p.Substring(74, 3);
                        a.Reserved = p.Substring(77, 10);
                        a.EntryDetailSequenceNumber = p.Substring(87, 7);
                        if(g == 1)
                        {
                            using (StreamWriter sw = File.AppendText(filepath))
                            {
                                StringBuilder sb = new StringBuilder();
                                StringWriter ssw = new StringWriter(sb);
                                JsonWriter w = new JsonTextWriter(sw);
                                w.Formatting = Newtonsoft.Json.Formatting.Indented;
                                w.WritePropertyName("Addenda_" + ADCount);
                                w.WriteStartObject();
                                w.WritePropertyName("RecordTypeCode");
                                w.WriteValue(a.RecordTypeCode);
                                w.WritePropertyName("AddendaTypeCode");
                                w.WriteValue(a.AddendaTypeCode);
                                w.WritePropertyName("OriginatingDFIName");
                                w.WriteValue(a.OriginatingDFIName);
                                w.WritePropertyName("OriginatingDFIIdentification");
                                w.WriteValue(a.OriginatingDFIIdentification);
                                w.WritePropertyName("OriginatingDFIBranch");
                                w.WriteValue(a.OriginatingDFIBranch);
                                w.WritePropertyName("Reserved");
                                w.WriteValue(a.Reserved);
                                w.WritePropertyName("EntryDetailSequenceNumber");
                                w.WriteValue(a.EntryDetailSequenceNumber);
                                w.WriteEndObject();
                                sw.WriteLine(",");
                                sw.WriteLine(sb.ToString());
                                sw.Close();
                            }

                        } else if(g == 2)
                        {
                            using (StreamWriter sw = File.AppendText(filepath))
                            {
                                StringBuilder sb = new StringBuilder();
                                StringWriter ssw = new StringWriter(sb);
                                XmlWriterSettings xws = new XmlWriterSettings();
                                xws.Indent = true;
                                XmlWriter xw = XmlWriter.Create(sw, xws);
                                xw.WriteStartElement("Addenda_" + ADCount);
                                xw.WriteStartElement("RecordTypeCode", a.RecordTypeCode);
                                xw.WriteEndElement();
                                xw.WriteStartElement("AddendaTypeCode", a.AddendaTypeCode);
                                xw.WriteEndElement();
                                xw.WriteStartElement("OriginatingDFIName", a.OriginatingDFIName);
                                xw.WriteEndElement();
                                xw.WriteStartElement("OriginatingDFIIdentification", a.OriginatingDFIIdentification);
                                xw.WriteEndElement();
                                xw.WriteStartElement("Reserved", a.Reserved);
                                xw.WriteEndElement();
                                xw.WriteStartElement("EntryDetailSequenceNumber", a.EntryDetailSequenceNumber);
                                xw.WriteEndElement();
                                xw.WriteEndElement();
                                xw.Close();
                            }

                        }
                        break;
                    case "14":
                        a.RecordTypeCode = p.Substring(0, 1);
                        a.AddendaTypeCode = p.Substring(1, 2);
                        a.ReceivingDFIName = p.Substring(3, 35);
                        a.ReceivingDFIIDNumber = p.Substring(38, 2);
                        a.ReceivingDFIIdentification = p.Substring(40, 34);
                        a.ReceivingDFIBranch = p.Substring(74, 3);
                        a.Reserved = p.Substring(77, 10);
                        a.EntryDetailSequenceNumber = p.Substring(87, 7);
                        if(g == 1)
                        {
                            using (StreamWriter sw = File.AppendText(filepath))
                            {
                                StringBuilder sb = new StringBuilder();
                                StringWriter ssw = new StringWriter(sb);
                                JsonWriter w = new JsonTextWriter(sw);
                                w.Formatting = Newtonsoft.Json.Formatting.Indented;
                                w.WritePropertyName("Addenda_" + ADCount);
                                w.WriteStartObject();
                                w.WritePropertyName("RecordTypeCode");
                                w.WriteValue(a.RecordTypeCode);
                                w.WritePropertyName("AddendaTypeCode");
                                w.WriteValue(a.AddendaTypeCode);
                                w.WritePropertyName("ReceivingDFIName");
                                w.WriteValue(a.ReceivingDFIName);
                                w.WritePropertyName("ReceivingDFIIdentificationNumber");
                                w.WriteValue(a.ReceivingDFIIDNumber);
                                w.WritePropertyName("ReceivingDFIBranch");
                                w.WriteValue(a.ReceivingDFIBranch);
                                w.WritePropertyName("Reserved");
                                w.WriteValue(a.Reserved);
                                w.WritePropertyName("EntryDetailSequenceNumber");
                                w.WriteValue(a.EntryDetailSequenceNumber);
                                w.WriteEndObject();
                                sw.WriteLine(",");
                                sw.WriteLine(sb.ToString());
                                sw.Close();
                            }
                        } else if(g == 2)
                        {
                            using (StreamWriter sw = File.AppendText(filepath))
                            {
                                StringBuilder sb = new StringBuilder();
                                StringWriter ssw = new StringWriter(sb);
                                XmlWriterSettings xws = new XmlWriterSettings();
                                xws.Indent = true;
                                XmlWriter xw = XmlWriter.Create(sw, xws);
                                xw.WriteStartElement("Addenda_" + ADCount);
                                xw.WriteStartElement("RecordTypeCode", a.RecordTypeCode);
                                xw.WriteEndElement();
                                xw.WriteStartElement("AddendaTypeCode", a.AddendaTypeCode);
                                xw.WriteEndElement();
                                xw.WriteStartElement("ReceivingDFIName", a.ReceivingDFIName);
                                xw.WriteEndElement();
                                xw.WriteStartElement("ReceivingDFIIdentificationNumber", a.ReceivingDFIIDNumber);
                                xw.WriteEndElement();
                                xw.WriteStartElement("ReceivingDFIBranch", a.ReceivingDFIBranch);
                                xw.WriteEndElement();
                                xw.WriteStartElement("Reserved", a.Reserved);
                                xw.WriteEndElement();
                                xw.WriteStartElement("EntryDetailSequenceNumber", a.EntryDetailSequenceNumber);
                                xw.WriteEndElement();
                                xw.WriteEndElement();
                                xw.Close();
                            }

                        }
                        break;
                    case "15":
                        a.RecordTypeCode = p.Substring(0, 1);
                        a.AddendaTypeCode = p.Substring(1, 2);
                        a.ReceiverIDNumber = p.Substring(3, 15);
                        a.ReceiverStreetAddress = p.Substring(18, 35);
                        a.Reserved = p.Substring(53, 34);
                        a.EntryDetailSequenceNumber = p.Substring(87, 7);
                        if(g == 1)
                        {
                            using (StreamWriter sw = File.AppendText(filepath))
                            {
                                StringBuilder sb = new StringBuilder();
                                StringWriter ssw = new StringWriter(sb);
                                JsonWriter w = new JsonTextWriter(sw);
                                w.Formatting = Newtonsoft.Json.Formatting.Indented;
                                w.WritePropertyName("Addenda_" + ADCount);
                                w.WriteStartObject();
                                w.WritePropertyName("RecordTypeCode");
                                w.WriteValue(a.RecordTypeCode);
                                w.WritePropertyName("AddendaTypeCode");
                                w.WriteValue(a.AddendaTypeCode);
                                w.WritePropertyName("ReceiverIDNumber");
                                w.WriteValue(a.ReceiverIDNumber);
                                w.WritePropertyName("ReceiverStreetAddress");
                                w.WriteValue(a.ReceiverStreetAddress);
                                w.WritePropertyName("Reserved");
                                w.WriteValue(a.Reserved);
                                w.WritePropertyName("EntryDetailSequenceNumber");
                                w.WriteValue(a.EntryDetailSequenceNumber);
                                w.WriteEndObject();
                                sw.WriteLine(",");
                                sw.WriteLine(sb.ToString());
                                sw.Close();
                            }
                        } else if(g == 2)
                        {
                            using (StreamWriter sw = File.AppendText(filepath))
                            {
                                StringBuilder sb = new StringBuilder();
                                StringWriter ssw = new StringWriter(sb);
                                XmlWriterSettings xws = new XmlWriterSettings();
                                xws.Indent = true;
                                XmlWriter xw = XmlWriter.Create(sw, xws);
                                xw.WriteStartElement("Addenda_" + ADCount);
                                xw.WriteStartElement("RecordTypeCode", a.RecordTypeCode);
                                xw.WriteEndElement();
                                xw.WriteStartElement("AddendaTypeCode", a.AddendaTypeCode);
                                xw.WriteEndElement();
                                xw.WriteStartElement("ReceiverIDNumber", a.ReceiverIDNumber);
                                xw.WriteEndElement();
                                xw.WriteStartElement("ReceiverStreetAddress", a.ReceiverStreetAddress);
                                xw.WriteEndElement();
                                xw.WriteStartElement("Reserved", a.Reserved);
                                xw.WriteEndElement();
                                xw.WriteStartElement("EntryDetailSequenceNumber", a.EntryDetailSequenceNumber);
                                xw.WriteEndElement();
                                xw.WriteEndElement();
                                xw.Close();
                            }

                        }
                        break;
                    case "16":
                        a.RecordTypeCode = p.Substring(0, 1);
                        a.AddendaTypeCode = p.Substring(1, 2);
                        a.ReceiverCityStateProvince = p.Substring(3, 35);
                        a.ReceiverCountryPostalCode = p.Substring(38, 35);
                        a.Reserved = p.Substring(73, 14);
                        a.EntryDetailSequenceNumber = p.Substring(87, 7);
                        if(g == 1)
                        {
                            using (StreamWriter sw = File.AppendText(filepath))
                            {
                                StringBuilder sb = new StringBuilder();
                                StringWriter ssw = new StringWriter(sb);
                                JsonWriter w = new JsonTextWriter(sw);
                                w.Formatting = Newtonsoft.Json.Formatting.Indented;
                                w.WritePropertyName("Addenda_" + ADCount);
                                w.WriteStartObject();
                                w.WritePropertyName("RecordTypeCode");
                                w.WriteValue(a.RecordTypeCode);
                                w.WritePropertyName("AddendaTypeCode");
                                w.WriteValue(a.AddendaTypeCode);
                                w.WritePropertyName("ReceiverCityStateProvince");
                                w.WriteValue(a.ReceiverCityStateProvince);
                                w.WritePropertyName("ReceiverCountryPostalCode");
                                w.WriteValue(a.ReceiverCountryPostalCode);
                                w.WritePropertyName("Reserved");
                                w.WriteValue(a.Reserved);
                                w.WritePropertyName("EntryDetailSequenceNumber");
                                w.WriteValue(a.EntryDetailSequenceNumber);
                                w.WriteEndObject();
                                sw.WriteLine(",");
                                sw.WriteLine(sb.ToString());
                                sw.Close();
                            }
                        } else if(g == 2)
                        {
                            using (StreamWriter sw = File.AppendText(filepath))
                            {
                                StringBuilder sb = new StringBuilder();
                                StringWriter ssw = new StringWriter(sb);
                                XmlWriterSettings xws = new XmlWriterSettings();
                                xws.Indent = true;
                                XmlWriter xw = XmlWriter.Create(sw, xws);
                                xw.WriteStartElement("Addenda_" + ADCount);
                                xw.WriteStartElement("RecordTypeCode", a.RecordTypeCode);
                                xw.WriteEndElement();
                                xw.WriteStartElement("AddendaTypeCode", a.AddendaTypeCode);
                                xw.WriteEndElement();
                                xw.WriteStartElement("ReceiverCityStateProvince", a.ReceiverCityStateProvince);
                                xw.WriteEndElement();
                                xw.WriteStartElement("ReceiverCountryPostalCode", a.ReceiverCountryPostalCode);
                                xw.WriteEndElement();
                                xw.WriteStartElement("Reserved", a.Reserved);
                                xw.WriteEndElement();
                                xw.WriteStartElement("EntryDetailSequenceNumber", a.EntryDetailSequenceNumber);
                                xw.WriteEndElement();
                                xw.WriteEndElement();
                                xw.Close();
                            }

                        }
                        break;
                    case "17":
                        a.RecordTypeCode = p.Substring(0, 1);
                        a.AddendaTypeCode = p.Substring(1, 2);
                        a.PaymentRelatedInformation = p.Substring(3, 80);
                        a.AddendaSequenceNumber = p.Substring(83, 4);
                        a.EntryDetailSequenceNumber = p.Substring(87, 7);
                        if(g == 1)
                        {
                            using (StreamWriter sw = File.AppendText(filepath))
                            {
                                StringBuilder sb = new StringBuilder();
                                StringWriter ssw = new StringWriter(sb);
                                JsonWriter w = new JsonTextWriter(sw);
                                w.Formatting = Newtonsoft.Json.Formatting.Indented;
                                w.WritePropertyName("Addenda_" + ADCount);
                                w.WriteStartObject();
                                w.WritePropertyName("RecordTypeCode");
                                w.WriteValue(a.RecordTypeCode);
                                w.WritePropertyName("AddendaTypeCode");
                                w.WriteValue(a.AddendaTypeCode);
                                w.WritePropertyName("PaymentRelatedInformation");
                                w.WriteValue(a.PaymentRelatedInformation);
                                w.WritePropertyName("AddendaSequenceNumber");
                                w.WriteValue(a.AddendaSequenceNumber);
                                w.WritePropertyName("EntryDetailSequenceNumber");
                                w.WriteValue(a.EntryDetailSequenceNumber);
                                w.WriteEndObject();
                                sw.WriteLine(",");
                                sw.WriteLine(sb.ToString());
                                sw.Close();
                            }
                        } else if(g == 2)
                        {
                            using (StreamWriter sw = File.AppendText(filepath))
                            {
                                StringBuilder sb = new StringBuilder();
                                StringWriter ssw = new StringWriter(sb);
                                XmlWriterSettings xws = new XmlWriterSettings();
                                xws.Indent = true;
                                XmlWriter xw = XmlWriter.Create(sw, xws);
                                xw.WriteStartElement("Addenda_" + ADCount);
                                xw.WriteStartElement("RecordTypeCode", a.RecordTypeCode);
                                xw.WriteEndElement();
                                xw.WriteStartElement("AddendaTypeCode", a.AddendaTypeCode);
                                xw.WriteEndElement();
                                xw.WriteStartElement("PaymentRelatedInformation", a.PaymentRelatedInformation);
                                xw.WriteEndElement();
                                xw.WriteStartElement("AddendaSequenceNumber", a.AddendaSequenceNumber);
                                xw.WriteEndElement();
                                xw.WriteStartElement("EntryDetailSequenceNumber", a.EntryDetailSequenceNumber);
                                xw.WriteEndElement();
                                xw.WriteEndElement();
                                xw.Close();
                            }

                        }
                        break;
                }
            }
            else
            {
                a.RecordTypeCode = p.Substring(0, 1);
                a.AddendaTypeCode = p.Substring(1, 2);
                a.PaymentRelatedInformation = p.Substring(3, 80);
                a.AddendaSequenceNumber = p.Substring(83, 4);
                a.EntryDetailSequenceNumber = p.Substring(87, 7);
                if(g == 1)
                {
                    using (StreamWriter sw = File.AppendText(filepath))
                    {
                        StringBuilder sb = new StringBuilder();
                        StringWriter ssw = new StringWriter(sb);
                        JsonWriter w = new JsonTextWriter(sw);
                        w.Formatting = Newtonsoft.Json.Formatting.Indented;
                        w.WritePropertyName("Addenda_" + ADCount);
                        w.WriteStartObject();
                        w.WritePropertyName("RecordTypeCode");
                        w.WriteValue(a.RecordTypeCode);
                        w.WritePropertyName("AddendaTypeCode");
                        w.WriteValue(a.AddendaTypeCode);
                        w.WritePropertyName("PaymentRelatedInformation");
                        w.WriteValue(a.PaymentRelatedInformation);
                        w.WritePropertyName("AddendaSequenceNumber");
                        w.WriteValue(a.AddendaSequenceNumber);
                        w.WritePropertyName("EntryDetailSequenceNumber");
                        w.WriteValue(a.EntryDetailSequenceNumber);
                        w.WriteEndObject();
                        sw.WriteLine(",");
                        sw.WriteLine(sb.ToString());
                        sw.Close();
                    }
                } else if(g == 2)
                {
                    using (StreamWriter sw = File.AppendText(filepath))
                    {
                        StringBuilder sb = new StringBuilder();
                        StringWriter ssw = new StringWriter(sb);
                        XmlWriterSettings xws = new XmlWriterSettings();
                        xws.Indent = true;
                        XmlWriter xw = XmlWriter.Create(sw, xws);
                        xw.WriteStartElement("Addenda_" + ADCount);
                        xw.WriteStartElement("RecordTypeCode", a.RecordTypeCode);
                        xw.WriteEndElement();
                        xw.WriteStartElement("AddendaTypeCode", a.AddendaTypeCode);
                        xw.WriteEndElement();
                        xw.WriteStartElement("PaymentRelatedInformation", a.PaymentRelatedInformation);
                        xw.WriteEndElement();
                        xw.WriteStartElement("AddendaSequenceNumber", a.AddendaSequenceNumber);
                        xw.WriteEndElement();
                        xw.WriteStartElement("EntryDetailSequenceNumber", a.EntryDetailSequenceNumber);
                        xw.WriteEndElement();
                        xw.WriteEndElement();
                        xw.Close();
                    }

                }
            }
        } //xml and json done
        public void BCRConv(string p)
        {
            BCR b = new BCR();
            b.RecordTypeCode = p.Substring(0, 1);
            b.ServiceClassCode = p.Substring(1, 3);
            b.EntryAddendaCount = p.Substring(4, 6);
            b.EntryHash = p.Substring(10, 10);
            b.TotalDebitEntryAmount = p.Substring(20, 12);
            b.TotalCreditEntryAmount = p.Substring(32, 12);
            b.CompanyIdentification = p.Substring(44, 10);
            b.MessageAuthenticationCode = p.Substring(54, 19);
            b.Reserved = p.Substring(73, 6);
            b.OriginatingDFIIdentification = p.Substring(79, 8);
            b.BatchNumber = p.Substring(87, 7);
            if (g == 1)
            {
                using (StreamWriter sw = File.AppendText(filepath))
                {
                    StringBuilder sb = new StringBuilder();
                    StringWriter ssw = new StringWriter(sb);
                    JsonWriter w = new JsonTextWriter(sw);
                    w.Formatting = Newtonsoft.Json.Formatting.Indented;
                    w.WritePropertyName("BatchControlRecord");
                    w.WriteStartObject();
                    w.WritePropertyName("RecordTypeCode");
                    w.WriteValue(b.RecordTypeCode);
                    w.WritePropertyName("ServiceClassCode");
                    w.WriteValue(b.ServiceClassCode);
                    w.WritePropertyName("EntryAddendaCount");
                    w.WriteValue(b.EntryAddendaCount);
                    w.WritePropertyName("EntryHash");
                    w.WriteValue(b.EntryHash);
                    w.WritePropertyName("TotalDebitEntryAmount");
                    w.WriteValue(b.TotalDebitEntryAmount);
                    w.WritePropertyName("TotalCreditEntryAmount");
                    w.WriteValue(b.TotalCreditEntryAmount);
                    w.WritePropertyName("CompanyIdentification");
                    w.WriteValue(b.CompanyIdentification);
                    w.WritePropertyName("MessageAuthenticationCode");
                    w.WriteValue(b.MessageAuthenticationCode);
                    w.WritePropertyName("Reserved");
                    w.WriteValue(b.Reserved);
                    w.WritePropertyName("OriginatingDFIIdentification");
                    w.WriteValue(b.OriginatingDFIIdentification);
                    w.WritePropertyName("BatchNumber");
                    w.WriteValue(b.BatchNumber);
                    w.WriteEndObject();
                    sw.WriteLine(",");
                    sw.WriteLine(sb.ToString());
                    sw.Close();
                }
            }
        } //json done
        public void FCRConv(string p)
        {
            FCR f = new FCR();
            f.RecordTypeCode = p.Substring(0, 1);
            f.BatchCount = p.Substring(1, 6);
            f.BlockCount = p.Substring(7, 6);
            f.EntryAddendaCount = p.Substring(13, 8);
            f.EntryHash = p.Substring(21, 10);
            f.TotalDebitEntryAmount = p.Substring(31, 12);
            f.TotalCreditEntryAmount = p.Substring(43, 12);
            f.Reserved = p.Substring(55, 39);
            if(g == 1)
            {
                using (StreamWriter sw = File.AppendText(filepath))
                {
                    StringBuilder sb = new StringBuilder();
                    StringWriter ssw = new StringWriter(sb);
                    JsonWriter w = new JsonTextWriter(sw);
                    w.Formatting = Newtonsoft.Json.Formatting.Indented;
                    w.WritePropertyName("FileControlRecord");
                    w.WriteStartObject();
                    w.WritePropertyName("RecordTypeCode");
                    w.WriteValue(f.RecordTypeCode);
                    w.WritePropertyName("BatchCount");
                    w.WriteValue(f.BatchCount);
                    w.WritePropertyName("BlockCount");
                    w.WriteValue(f.BlockCount);
                    w.WritePropertyName("EntryAddendaCount");
                    w.WriteValue(f.EntryAddendaCount);
                    w.WritePropertyName("EntryHash");
                    w.WriteValue(f.EntryHash);
                    w.WritePropertyName("TotalDebitEntryAmount");
                    w.WriteValue(f.TotalDebitEntryAmount);
                    w.WritePropertyName("TotalCreditEntryAmount");
                    w.WriteValue(f.TotalCreditEntryAmount);
                    w.WritePropertyName("Reserved");
                    w.WriteValue(f.Reserved);
                    w.WriteEndObject();
                    sw.WriteLine("}"); //temp
                    sw.WriteLine(sb.ToString());
                    sw.Close();
                }
            }
        } //json done
        //********** ACH CONVERSION END **********//

        //********** WIRE CONVERSION START **********//
        public void WIRE_FileHeader(string p)
        {
            FileHeader FH = new FileHeader();
            FH.RecordCode = p.Substring(0, 2);
            FH.ABAFRB = p.Substring(3, 9);
            FH.ReceiverIdentification = p.Substring(13, 9);
            FH.FileCreationDate = p.Substring(23, 6);
            FH.FileCreationTime = p.Substring(30, 4);
            FH.FileIDNumber = p.Substring(35, 3);
            FH.PhysicalRecordLength = p.Substring(39, 2);
            FH.BlockSize = p.Substring(42, 1);
            FH.VersionNumber = p.Substring(44, 1);
            if (g == 3)
            {
                {
                    using (StreamWriter sw = new StreamWriter(filepath))
                    {
                        StringBuilder sb = new StringBuilder();
                        StringWriter ssw = new StringWriter(sb);
                        JsonWriter w = new JsonTextWriter(sw);
                        w.Formatting = Newtonsoft.Json.Formatting.Indented;
                        w.WriteStartObject();
                        w.WritePropertyName("FileHeader");
                        w.WriteStartObject();
                        w.WritePropertyName("RecordCode");
                        w.WriteValue(FH.RecordCode);
                        w.WritePropertyName("ABA/FRB");
                        w.WriteValue(FH.ABAFRB);
                        w.WritePropertyName("ReceiverIdentification");
                        w.WriteValue(FH.ReceiverIdentification);
                        w.WritePropertyName("FileCreationDate");
                        w.WriteValue(FH.FileCreationDate);
                        w.WritePropertyName("FileCreationTime");
                        w.WriteValue(FH.FileCreationTime);
                        w.WritePropertyName("FileIdentificationNumber");
                        w.WriteValue(FH.FileIDNumber);
                        w.WritePropertyName("PhysicalRecordLength");
                        w.WriteValue(FH.PhysicalRecordLength);
                        w.WritePropertyName("BlockSize");
                        w.WriteValue(FH.BlockSize);
                        w.WritePropertyName("VersionNumber");
                        w.WriteValue(FH.VersionNumber);
                        w.WriteEndObject();
                        sw.WriteLine(",");
                    }
                }
            }
        }
        public void WIRE_GroupHeader(string p)
        {
            GroupHeader GH = new GroupHeader();
            GH.RecordCode = p.Substring(0, 2);
            GH.ReceiverIdentification = p.Substring(3, 9);
            GH.ABAFRB = p.Substring(11, 9);
            GH.GroupStatus = p.Substring(21, 1);
            GH.AsOfDate = p.Substring(23, 6);
            GH.AsOfTime = p.Substring(30, 4);
            GH.CurrencyCode = p.Substring(35, 3);
            GH.AsOfDateModififer = p.Substring(39, 1);
            if (g == 3)
            {
                using (StreamWriter sw = File.AppendText(filepath))
                {
                    StringBuilder sb = new StringBuilder();
                    StringWriter ssw = new StringWriter(sb);
                    JsonWriter w = new JsonTextWriter(sw);
                    w.Formatting = Newtonsoft.Json.Formatting.Indented;
                    w.WriteStartObject();
                    w.WritePropertyName("GroupHeader");
                    w.WriteStartObject();
                    w.WritePropertyName("RecordCode");
                    w.WriteValue(GH.RecordCode);
                    w.WritePropertyName("ABA/FRB");
                    w.WriteValue(GH.ABAFRB);
                    w.WritePropertyName("GroupStatus");
                    w.WriteValue(GH.GroupStatus);
                    w.WritePropertyName("AsOfDate");
                    w.WriteValue(GH.AsOfDate);
                    w.WritePropertyName("AsOfTime");
                    w.WriteValue(GH.AsOfTime);
                    w.WritePropertyName("CurrencyCode");
                    w.WriteValue(GH.CurrencyCode);
                    w.WritePropertyName("AsOfDateModifier");
                    w.WriteValue(GH.AsOfDateModififer);
                    w.WriteEndObject();
                    sw.WriteLine(",");
                }

            }
        }
        public void WIRE_AcctID(string p)
        {
            AccountIdentifier AI = new AccountIdentifier();
            AI.RecordCode = p.Substring(0, 2);
            AI.CustomerAccountNumber = p.Substring(3, 12);
            AI.CurrencyCode = p.Substring(16, 3);
            try
            {
                AI.TypeCode = p.Substring(20, 3);
                AI.TypeCode = AI.TypeCode.TrimEnd(',');
            } catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e);
            } finally
            {
                Console.WriteLine("what a great finally statement");
            }
            try
            {
                AI.Amount = p.Substring(24); //14 byte max but can be less.
                AI.Amount = AI.Amount.TrimEnd(',', '/');
            } catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e);
            } finally
            {
                Console.WriteLine("this is my finally statement");
            }
            if (g == 3)
            {
                using (StreamWriter sw = File.AppendText(filepath))
                {
                    StringBuilder sb = new StringBuilder();
                    StringWriter ssw = new StringWriter(sb);
                    JsonWriter w = new JsonTextWriter(sw);
                    w.Formatting = Newtonsoft.Json.Formatting.Indented;
                    w.WriteStartObject();
                    w.WritePropertyName("AccountIdentifier");
                    w.WriteStartObject();
                    w.WritePropertyName("RecordCode");
                    w.WriteValue(AI.RecordCode);
                    w.WritePropertyName("CustomerAccountNumber");
                    w.WriteValue(AI.CustomerAccountNumber);
                    w.WritePropertyName("TypeCode"); //check if null
                    w.WriteValue(AI.TypeCode);
                    w.WritePropertyName("Amount"); //check if null
                    w.WriteValue(AI.Amount);
                    w.WriteEndObject();
                    sw.WriteLine(",");
                }

            }
            //AI.ItemCount = p.Substring(38, 1);
            //AI.FundsType = p.Substring(39, 1);
        }
        private int nextint { get; set; }
        public void WIRE_TransDetail(string p) //TODO parse them via comma, substringing doesn't seem to work well!
        {
            TransactionDetail TD = new TransactionDetail();
            TD.RecordCode = p.Substring(0, 2);
            TD.TypeCode = p.Substring(3, 3);
            try
            {
                TD.Amount = p.Substring(7);
                int ind = TD.Amount.IndexOf(',');
                TD.Amount = TD.Amount.Substring(0, ind);
                nextint = (TD.RecordCode.Length + TD.TypeCode.Length + TD.Amount.Length + 3); //3 commas
            } catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e);
            } finally
            {
                Console.WriteLine("welcome to my finally statement!");
            }
            TD.FundsType = p.Substring(nextint, 1);
            Console.WriteLine(TD.FundsType);
            
            FType = TD.FundsType;
            switch (TD.FundsType)
            {
                case "0": //immediate delivery
                    Console.WriteLine("FundsType: " + TD.FundsType);
                    nextint = (TD.RecordCode.Length + TD.TypeCode.Length + TD.Amount.Length + TD.FundsType.Length + 4);
                    Console.WriteLine(nextint);
                    break;
                case "1": //1 day availability
                    Console.WriteLine("FundsType: " + TD.FundsType);
                    break;
                case "2": //two or more day availability
                    Console.WriteLine("FundsType: " + TD.FundsType);
                    break;
                case "S": //distributed availability
                    try
                    {
                        Console.WriteLine("FundsType: " + TD.FundsType);
                        nextint = (TD.RecordCode.Length + TD.TypeCode.Length + TD.Amount.Length + TD.FundsType.Length + 4);
                        TD.SField1 = p.Substring(nextint);
                        int ind = TD.SField1.IndexOf(',');
                        TD.SField1 = TD.SField1.Substring(0, ind);
                        nextint = (TD.RecordCode.Length + TD.TypeCode.Length + TD.Amount.Length + TD.FundsType.Length + TD.SField1.Length + 5);
                        TD.SField2 = p.Substring(nextint);
                        ind = TD.SField2.IndexOf(',');
                        TD.SField2 = TD.SField2.Substring(0, ind);
                        nextint = (TD.RecordCode.Length + TD.TypeCode.Length + TD.Amount.Length + TD.FundsType.Length + TD.SField1.Length + TD.SField2.Length + 6);
                        TD.SField3 = p.Substring(nextint);
                        ind = TD.SField3.IndexOf(',');
                        TD.SField3 = TD.SField3.Substring(0, ind);
                        Console.WriteLine(TD.SField1);
                        Console.WriteLine(TD.SField2);
                        Console.WriteLine(TD.SField3);
                    } catch (ArgumentOutOfRangeException e)
                    {
                        Console.WriteLine(e);
                    } finally
                    {
                        Console.WriteLine("GO GO GO");
                    }
                    break;
                case "V": //value dated
                    Console.WriteLine("FundsType: " + TD.FundsType);
                    break;
                case "D": //distributed availability
                    Console.WriteLine("FundsType: " + TD.FundsType);
                    break;
                case "Z": //unknown / default
                    Console.WriteLine("FundsType: " + TD.FundsType);
                    break;
            }
            
            
        }





        //********** WIRE CONVERSION END **********//
    }
}
